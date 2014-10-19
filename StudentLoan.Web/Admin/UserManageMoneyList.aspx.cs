using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.API;
using StudentLoan.Common.Logging;
using System.Text;

namespace StudentLoan.Web.Admin
{
    public partial class UserManageMoneyList : AdminBasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd");

                string action = this.Request<string>("Action");

                if (action == "DrawMoney")
                {
                    int drawId = this.Request<int>("DrawId");

                    if (drawId > 0)
                    {
                        DrawMoneyEntityEx model = new DrawMoneyEntityEx();
                        model.DrawId = drawId;
                        model.AdminId = base.GetAdminInfo().AdminId;
                        model.Status = 2;

                        bool result = new DrawMoneyBLL().UpdateByAdmin(model);

                        if (result)
                        {
                            int userId = this.Request<int>("UserId");
                            string userMobile = new UsersBLL().GetModel(userId).Mobile;

                            string code = new Message().Send(userMobile, "亲，你的提现申请已受理，请注意查收！【学子易贷】");

                            LogHelper.Default.Info("短信发送记录:" + code);
                        }

                        this.Alert(string.Format("更新提现记录状态{0}", result == true ? "成功" : "失败"));
                    }
                    else
                    {
                        this.Alert("参数不正确！", "DrawMoneyList.aspx");
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
            string strWhere = @" 1=1 ";

            string queryContent = this.txtQueryContent.Text.Trim().HtmlEncode();
            string startTime = this.txtStartTime.Text.Trim();
            string endTime = this.txtEndTime.Text.Trim();

            if (!string.IsNullOrEmpty(queryContent))
            {
                if (this.ddlQueryType.SelectedValue == "1")
                {
                    strWhere += string.Format(@" and c.UserName = '{0}'", queryContent);
                }

                if (this.ddlQueryType.SelectedValue == "2")
                {
                    strWhere += string.Format(@" and b.SchemeName = '{0}'", queryContent);
                }
            }

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

    }
}