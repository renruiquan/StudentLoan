using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web.Admin
{
    public partial class LoginLog : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<AdminLogEntityEx> sourceList = new AdminLogBLL().GetListByPage(" 1=1 ", " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new AdminLogBLL().GetRecordCount(" 1=1 ");

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            //if (endIndex > this.objAspNetPager.RecordCount)
            //{
            //    this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            //}


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }
    }
}