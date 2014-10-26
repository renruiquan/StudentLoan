using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System.Text;
using StudentLoan.API;
using StudentLoan.Common.Logging;


namespace StudentLoan.Web.Admin
{
    public partial class DrawMoneyList : AdminBasePage
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
            string status = this.ddlStatus.SelectedValue;
            string startTime = this.txtStartTime.Text.Trim();
            string endTime = this.txtEndTime.Text.Trim();

            if (!string.IsNullOrEmpty(queryContent))
            {
                if (this.ddlQueryType.SelectedValue == "1")
                {
                    strWhere += string.Format(@" and T.UserId = '{0}'", new UsersBLL().GetUserId(queryContent));
                }

                if (this.ddlQueryType.SelectedValue == "2")
                {
                    strWhere += string.Format(@" and b.BankCardNo = '{0}'", queryContent);
                }
            }

            if (!string.IsNullOrEmpty(status))
            {
                strWhere += string.Format(@" and T.Status = {0}", status);
            }

            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(@" and T.ApplyTime >= '{0}'", startTime.Convert<DateTime>());
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(@" and T.ApplyTime <= '{0}'", endTime.Convert<DateTime>());
            }

            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<DrawMoneyEntityEx> sourceList = new DrawMoneyBLL().GetListByPage(strWhere, " ApplyTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new DrawMoneyBLL().GetRecordCount(strWhere);

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
                //  状态 0=审核中，1=提款失败，2=提款成功 
                return "审核中";
            }
            else if (status == 1)
            {
                return "失败";
            }
            else if (status == 2)
            {
                return "成功";
            }
            else
            {
                return "异常";
            }
        }

        protected void objRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DrawMoneyEntityEx model = e.Item.DataItem as DrawMoneyEntityEx;

                Literal objLiteral = e.Item.FindControl("objLiteral") as Literal;


                if (model.Status == 0)
                {
                    StringBuilder objSB = new StringBuilder();

                    objSB.AppendFormat(" <a onclick=\"return confirm('打款后将更新用户提现记录，请确保打款成功后，再执行此操作！')\" href=\"DrawMoneyList.aspx?Action=DrawMoney&DrawId={0}&UserId={1}\">完成打款</a>", model.DrawId, model.UserId);

                    objLiteral.Text = objSB.ToString();
                }
            }
        }

    }
}