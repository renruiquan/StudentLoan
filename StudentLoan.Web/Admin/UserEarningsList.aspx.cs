using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;

namespace StudentLoan.Web.Admin
{
    public partial class UserEarningsList : AdminBasePage
    {
        public int UserId { get { return this.Request<int>("UserId"); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.UserId == 0)
                {
                    this.Alert("参数不正确", "UserEarningsList.aspx");
                    return;
                }
                this.BindData();
            }
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {

            string startTime = txtStartTime.Text.Trim().HtmlEncode();
            string endTime = txtEndTime.Text.Trim().HtmlEncode();


            string strWhere = "1 = 1";

            strWhere += string.Format(@" and T.UserId = '{0}'", this.UserId);

            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(" and  T.CreateTime >='{0}' ", startTime.Convert<DateTime>());
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(" and  T.CreateTime <='{0}' ", endTime.Convert<DateTime>());
            }

            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserEarningsEntityEx> sourceList = new UserEarningsBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserEarningsBLL().GetRecordCount(strWhere);

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            //if (endIndex > this.objAspNetPager.RecordCount)
            //{
            //    this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            //}


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

    }
}