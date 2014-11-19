using StudentLoan.BLL;
using StudentLoan.Model;
using StudentLoan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Common.Logging;
using StudentLoan.API;

namespace StudentLoan.Web.user
{
    public partial class ManageMoneyList_3 : BasePage
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

                Control objControl = Master.FindControl(id.Replace("_3", ""));

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
            string strWhere = @" 1=1 and T.Status=2 ";

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
            else if (status == 1)
            {
                return "已付款";
            }
            else if (status == 2)
            {
                return "转出申请中";
            }
            else if (status == 3)
            {
                return "转出成功";
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
                    objLiteral.Text = string.Format("<a onclick=\"return confirm('确定转出？');\" href=\"ManageMoneyList_2.aspx?buyId={0}&action=drawMoney\">申请转出</a>", model.BuyId);
                }
                else if (model.Status == 2)
                {
                    objLiteral.Text = "";
                }
                else if (model.Status == 3)
                {
                    objLiteral.Text = "";
                }

            }
        }
    }
}