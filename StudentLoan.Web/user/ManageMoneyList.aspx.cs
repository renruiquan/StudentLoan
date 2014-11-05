using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.API;
using StudentLoan.Common.Logging;


namespace StudentLoan.Web.user
{
    public partial class ManageMoneyList : BasePage
    {

        private string StartTime
        {
            get
            {
                if (string.IsNullOrEmpty(txtStartTime.Text.Trim().HtmlEncode()))
                {
                    return DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    return txtStartTime.Text.Trim().HtmlEncode().Convert<DateTime>().ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }

        private string EndTime
        {
            get
            {
                if (string.IsNullOrEmpty(txtEndTime.Text.Trim().HtmlEncode()))
                {
                    return DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    return txtEndTime.Text.Trim().HtmlEncode().Convert<DateTime>().AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }

        }
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

                //日期文本框设置只读
                this.txtStartTime.Attributes.Add("ReadOnly", "true");
                this.txtEndTime.Attributes.Add("ReadOnly", "true");
                this.txtStartTime.Text = this.StartTime.Convert<DateTime>().ToString("yyyy-MM-dd");
                this.txtEndTime.Text = this.EndTime.Convert<DateTime>().ToString("yyyy-MM-dd");

                string action = this.Request<string>("action");

                if (action == "pay")
                {
                    int buyId = this.Request<int>("buyId", 0);

                    if (buyId == 0)
                    {
                        this.artDialog("提示", "参数不正确！", "ManageMoneyList.aspx");
                        return;
                    }
                    else
                    {
                        //付款操作

                        UsersEntityEx userModel = new UsersBLL().GetModel(base.GetUserModel().UserId);
                        UserManageMoneyEntityEx userManageMoneyModel = new UserManageMoneyBLL().GetModel(buyId);

                        if (userManageMoneyModel != null)
                        {
                            if (userModel.Amount < userManageMoneyModel.Amount)
                            {
                                this.artDialog("提示", string.Format("对不起，你的账户余额不足，无法完成还款，前账号的余额为{0}，还需充值{1}元", userModel.Amount.ToString("C"), Convert.ToDecimal(userManageMoneyModel.Amount - userModel.Amount).ToString("C")), "Charge.aspx");
                                return;
                            }
                            else
                            {
                                //扣费并更新理财订单状态
                                userManageMoneyModel = new UserManageMoneyEntityEx()
                                {
                                    BuyId = buyId,
                                    UserId = userModel.UserId,
                                    Amount = Math.Abs(userManageMoneyModel.Amount),
                                    PayTime = DateTime.Now,
                                    EndTime = DateTime.Now.AddMonths(userManageMoneyModel.Period),
                                    Status = 1
                                };

                                bool result = new UserManageMoneyBLL().Update(userManageMoneyModel);

                                if (result)
                                {
                                    string code =  Message.Send(userModel.Telphone, string.Format("亲，你购买了理财产品{0},共消费了{1}元。【学子易贷】", userManageMoneyModel.SchemeName, userManageMoneyModel.Amount));
                                    LogHelper.Default.Info("短信内容：" + code);

                                    this.Alert("购买成功", "ManageMoneyList.aspx");
                                }
                                else
                                {
                                    this.Alert("亲，对不起，由于系统原因，扣费成功，但购买失败，请联系在线客服！给您带来困扰，请谅解！");
                                }
                            }
                        }
                    }
                }

                this.BindData();
            }
        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        public void BindData()
        {
            string strWhere = string.Format(@" 1=1 and T.Status=0  and T.UserId = {0}", base.GetUserModel().UserId);

            string startTime = this.txtStartTime.Text.Trim();
            string endTime = this.txtEndTime.Text.Trim();

            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(@" and T.CreateTime >= '{0}'", startTime.Convert<DateTime>());
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(@" and T.CreateTime <= '{0}'", endTime.Convert<DateTime>());
            }

            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserManageMoneyEntityEx> sourceList = new UserManageMoneyBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserManageMoneyBLL().GetRecordCount(strWhere);

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            if (endIndex > this.objAspNetPager.RecordCount)
            {
                this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            }


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }

        public string GetStatusName(int status)
        {
            if (status == 0)
            {
                //  0=等待付款，1=已付款，2=用户消费付款
                return "等待付款";
            }
            else if (status == 0)
            {
                return "等待付款";
            }
            else if (status == 1)
            {
                return "已付款";
            }
            else if (status == 2)
            {
                return "用户消费付款";
            }
            else
            {
                return "异常";
            }
        }

        protected void objRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                UserManageMoneyEntityEx model = e.Item.DataItem as UserManageMoneyEntityEx;
                Literal objLiteral = e.Item.FindControl("objLiteral") as Literal;

                if (model.Status == 0)
                {
                    objLiteral.Text = string.Format("<a href=\"ManageMoneyList.aspx?buyId={0}&action=pay\">支付</a>", model.BuyId);
                }
                else if (model.Status == 1)
                {
                    objLiteral.Text = string.Format("<a href=\"ManageMoneyList_2.aspx?buyId={0}&action=drawMoney\">申请转出</a>", model.BuyId);
                }
                else if (model.Status == 2)
                {
                    objLiteral.Text = "转出申请中";
                }
                else if (model.Status == 3)
                {
                    objLiteral.Text = "转出成功";
                }

            }
        }
    }
}