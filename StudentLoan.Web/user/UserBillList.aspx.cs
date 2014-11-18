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

                Control objControl = Master.FindControl(id.Replace("_2", ""));

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

                    //检查用户余额并还款

                    UsersEntityEx userModel = base.GetUserModel();
                    UserLoanEntityEx userLoanModel = new UserLoanBLL().GetModel(loanId);

                    if (userModel == null)
                    {
                        this.artDialog("提示", "登录超时，请重新登录后再试", "login.aspx");
                        return;
                    }
                    else
                    {
                        //从数据库中读取用户余额信息，防止提示用户重复充值
                        userModel = new UsersBLL().GetModel(userModel.UserId);

                        decimal repaymentMoney = userLoanModel.LoanMoney * userLoanModel.AnnualFee;
                        decimal last_repaymentMoney = userLoanModel.LoanMoney * userLoanModel.AnnualFee + userLoanModel.LoanMoney;

                        if (userLoanModel != null)
                        {
                            bool result = false;

                            if (userLoanModel.TotalAmortization == userLoanModel.AlreadyAmortization)
                            {
                                this.artDialog("提示", "借款编号" + userLoanModel.LoanNo + "已完成还款，无需再还款！祝您生活愉快 O(∩_∩)O", this.Request.UrlReferrer.LocalPath);
                                return;
                            }

                            //处理用户最后一期还款
                            if (userLoanModel.AlreadyAmortization == userLoanModel.TotalAmortization - 1)
                            {
                                //最后一期利息+本金一起还款
                                result = this.Repayment(userModel, userLoanModel, userModel.Amount, last_repaymentMoney);
                            }
                            else
                            {
                                //只还利息
                                result = this.Repayment(userModel, userLoanModel, userModel.Amount, repaymentMoney);
                            }

                            this.artDialog("提示", string.Format("还款{0}", result == true ? "成功" : "失败"), "UserBillList.aspx");
                        }
                        else
                        {
                            this.artDialog("订单信息错误");
                            return;
                        }
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

        private bool Repayment(UsersEntityEx userModel, UserLoanEntityEx userLoanModel, decimal userAmount, decimal repaymentMoney)
        {
            if (userAmount < repaymentMoney)
            {
                this.artDialog("提示", string.Format("对不起，你的账户余额不足，无法完成还款，当前账号的余额为{0}，还需充值{1}元", userAmount.ToString("C"), Convert.ToDecimal(repaymentMoney - userAmount).ToString("C")), "Charge.aspx");
                return false;
            }
            else
            {
                //当前第N期还款期数
                int currentAmortization = userLoanModel.AlreadyAmortization + 1;

                //逾期天数
                int overdueDay = 0;

                //获取用户还款详情
                UserRepaymentEntityEx userRepaymentModel = new UserRepaymentBLL().GetModel(userLoanModel.LoanId, currentAmortization);

                if (userRepaymentModel == null)
                {
                    return false;
                }

                DateTime currentDateTime = DateTime.Now.ToString("yyyy-MM-dd").Convert<DateTime>();
                DateTime repaymentDateTime = userRepaymentModel.RepaymentTime.ToString("yyyy-MM-dd").Convert<DateTime>();

                TimeSpan ts = currentDateTime - repaymentDateTime;

                userRepaymentModel = new UserRepaymentEntityEx()
                {
                    LoanId = userLoanModel.LoanId,
                    CurrentAmortization = currentAmortization
                };


                if (ts.Days > 5)
                {
                    overdueDay = ts.Days;
                    userRepaymentModel.BreakContract = (0.005 * overdueDay * Convert.ToDouble(userLoanModel.LoanMoney)).Convert<decimal>();
                    userRepaymentModel.RepaymentMoney = repaymentMoney + userRepaymentModel.BreakContract;
                    userRepaymentModel.Status = 2;
                    userRepaymentModel.UserId = userLoanModel.UserId;
                }
                else
                {
                    userRepaymentModel.BreakContract = 0;
                    userRepaymentModel.RepaymentMoney = repaymentMoney;
                    userRepaymentModel.Status = 1;
                    userRepaymentModel.UserId = userLoanModel.UserId;
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


                if (model.Status == 0)
                {
                    objLiteral.Text = string.Format("<a href=\"UserBillList_2.aspx?loanid={0}&action=repayment\">还款</a>", model.LoanId);
                }
                else
                {
                    objLiteral.Text = "<a href=\"javascript:void(0);\">完成</a>";
                }

            }
        }
    }
}