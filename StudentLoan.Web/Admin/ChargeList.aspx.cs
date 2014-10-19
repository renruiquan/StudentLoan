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
    public partial class ChargeList : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
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

            string queryContent = this.txtQueryContent.Text.Trim();
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
                    strWhere += string.Format(@" and OrderNo = '{0}'", queryContent);
                }

                if (this.ddlQueryType.SelectedValue == "3")
                {
                    strWhere += string.Format(@" and ChannelOrderNo = '{0}'", queryContent);
                }
            }

            if (!string.IsNullOrEmpty(status))
            {
                strWhere += string.Format(@" and T.Status = {0}", status);
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

            List<UserChargeEntityEx> sourceList = new UserChargeBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserChargeBLL().GetRecordCount(strWhere);

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
                //  0=未支付，1=充值中，2=已完成充值
                return "未支付";
            }
            else if (status == 1)
            {
                return "充值中";
            }
            else if (status == 2)
            {
                return "已完成充值";
            }
            else
            {
                return "支付失败";
            }
        }

    }
}