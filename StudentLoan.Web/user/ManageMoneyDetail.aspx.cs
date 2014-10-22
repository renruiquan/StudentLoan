using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.Model;
using StudentLoan.BLL;

namespace StudentLoan.Web.user
{
    public partial class ManageMoneyDetail : BasePage
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

                this.BindData();
            }
        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }


        private void BindData()
        {

            string startTime = txtStartTime.Text.Trim().HtmlEncode();
            string endTime = txtEndTime.Text.Trim().HtmlEncode();


            string strWhere = "1 = 1";

            strWhere += string.Format(@" and T.UserId = '{0}'", base.GetUserModel().UserId);

            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(" and  b.CreateTime >='{0}' ", startTime.Convert<DateTime>());
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(" and  b.CreateTime <='{0}' ", endTime.Convert<DateTime>());
            }

            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserManageMoneyEntityEx> sourceList = new UserManageMoneyBLL().GetListByDetail(strWhere, " EarningsId  Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserManageMoneyBLL().GetRecordDetailCount(strWhere);

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            if (endIndex > this.objAspNetPager.RecordCount)
            {
                this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            }


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();
        }

        protected void btnQuery_ServerClick(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}