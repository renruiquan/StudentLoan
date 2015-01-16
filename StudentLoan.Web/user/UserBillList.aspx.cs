using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Model;
using StudentLoan.BLL;
using StudentLoan.Common;

namespace StudentLoan.Web.user
{
    public partial class UserBillList : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式

                string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                Control objControl = Master.FindControl(id);

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion

                string action = this.Request<string>("action");

                //用户还款
                if (action == "repayment")
                {
                    int loanId = this.Request<int>("loanid", 0);
                    int currentAmortization = this.Request<int>("current", 0);

                    //检查用户余额并还款

                    UsersEntityEx userModel = base.GetUserModel();
                    UserRepaymentEntityEx userRepaymentModel = new UserRepaymentBLL().GetModel(loanId, currentAmortization);

                    if (userModel == null)
                    {
                        this.artDialog("提示", "登录超时，请重新登录后再试", "login.aspx");
                        return;
                    }
                    else
                    {
                        //从数据库中读取用户余额信息，防止提示用户重复充值
                        userModel = new UsersBLL().GetModel(userModel.UserId);

                        bool result = false;

                        result = this.Repayment(userModel, userRepaymentModel);


                        this.artDialog("提示", string.Format("还款{0}", result == true ? "成功" : "失败"), "UserBillList.aspx");

                    }
                }

                this.BindData();
            }
        }

        private void BindData()
        {
            UsersEntityEx userModel = base.GetUserModel();

            if (userModel == null)
            {
                this.artDialog("提示", "登录超时，请重新登录", "login.aspx");
                return;
            }

            string strWhere = string.Format(" a.UserId={0} and T.RepaymentTime <=getdate()", userModel.UserId);


            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserRepaymentEntityEx> sourceList = new UserRepaymentBLL().GetListByPage(strWhere, "", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserRepaymentBLL().GetRecordCount(strWhere);


            this.objRepeater1.DataSource = sourceList;
            this.objRepeater1.DataBind();
        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }
        private bool Repayment(UsersEntityEx userModel, UserRepaymentEntityEx userRepaymentModel)
        {
            if (userModel.Amount < (userRepaymentModel.Interest + userRepaymentModel.RepaymentMoney))
            {
                this.artDialog("提示", string.Format("对不起，你的账户余额不足，无法完成还款，当前账号的余额为{0}，还需充值{1}元", userModel.Amount.ToString("C"), Convert.ToDecimal((userRepaymentModel.Interest + userRepaymentModel.RepaymentMoney) - userModel.Amount).ToString("C")), "Charge.aspx");
                return false;
            }
            else
            {
                //获取借款订单
                UserLoanEntityEx userLoanModel = new UserLoanBLL().GetModel(userRepaymentModel.LoanId);

                //逾期天数
                int overdueDay = 0;

                DateTime currentDateTime = DateTime.Now.ToString("yyyy-MM-dd").Convert<DateTime>();
                DateTime repaymentDateTime = userRepaymentModel.RepaymentTime.ToString("yyyy-MM-dd").Convert<DateTime>();

                TimeSpan ts = currentDateTime - repaymentDateTime;

                if (ts.Days > 5)
                {
                    overdueDay = ts.Days;
                    userRepaymentModel.BreakContract = (0.005 * overdueDay * Convert.ToDouble(userLoanModel.LoanMoney)).Convert<decimal>();
                    userRepaymentModel.RepaymentMoney = userRepaymentModel.RepaymentMoney + userRepaymentModel.BreakContract;
                    userRepaymentModel.Status = 2;
                    //逾期5天以上积分扣除1分
                    userRepaymentModel.Point = -1;
                }
                else
                {
                    userRepaymentModel.BreakContract = 0;
                    userRepaymentModel.RepaymentMoney = userRepaymentModel.RepaymentMoney;
                    userRepaymentModel.Status = 1;
                    //正常还款积分加1分
                    userRepaymentModel.Point = 1;
                }

                //从用户账户中扣除金额并更新还款期数，以及还款详情

                bool result = new UserRepaymentBLL().Update(userRepaymentModel, userLoanModel);

                return result;
            }
        }

        protected void objRepeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                UserRepaymentEntityEx model = e.Item.DataItem as UserRepaymentEntityEx;
                Literal objLiteral = e.Item.FindControl("objLiteral") as Literal;
                Literal litBreakContract = e.Item.FindControl("litBreakContract") as Literal;

                #region 计算显示逾期金额

                DateTime currentDateTime = DateTime.Now.ToString("yyyy-MM-dd").Convert<DateTime>();
                DateTime repaymentDateTime = model.RepaymentTime.ToString("yyyy-MM-dd").Convert<DateTime>();

                TimeSpan ts = currentDateTime - repaymentDateTime;

                if (ts.Days > 5)
                {

                    model.BreakContract = (0.005 * ts.Days * Convert.ToDouble(model.LoanMoney)).Convert<decimal>();
                }
                else
                {
                    model.BreakContract = 0;
                }

                //逾期还款后，显示截至到日期时逾期天数的费用
                if (model.Status == 2)
                {
                    ts = model.CreateTime - repaymentDateTime;

                    model.BreakContract = (0.005 * ts.Days * Convert.ToDouble(model.LoanMoney)).Convert<decimal>();
                }

                litBreakContract.Text = model.BreakContract.Convert<double>().ToString("C");

                #endregion

                if (model.Status == 0)
                {
                    objLiteral.Text = string.Format("<a href=\"UserBillList.aspx?loanid={0}&action=repayment&current={1}\">还款</a>", model.LoanId, model.CurrentAmortization);
                }
                else
                {
                    objLiteral.Text = "<a href=\"javascript:void(0);\">完成</a>";
                }

            }
        }
    }
}