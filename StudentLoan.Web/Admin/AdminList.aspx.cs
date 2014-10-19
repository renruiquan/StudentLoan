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
    public partial class AdminList : AdminBasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action = this.Request<string>("Action");
                int adminId = this.Request<int>("AdminId");

                if (action == "Delete" && adminId > 0)
                {
                    bool result = new AdminBLL().Delete(new AdminEntityEx() { AdminId = adminId });

                    this.Alert(string.Format("删除{0}", result == true ? "成功" : "失败"), "AdminList.aspx");
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

            string userName = this.txtUserName.Text.Trim().HtmlEncode();


            string strWhere = "1 = 1";


            if (!string.IsNullOrEmpty(userName))
            {
                strWhere += string.Format(" and  AdminName like '%{0}%' ", userName);
            }


            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<AdminEntityEx> sourceList = new AdminBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new AdminBLL().GetRecordCount(strWhere);

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            if (endIndex > this.objAspNetPager.RecordCount)
            {
                this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            }


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        public string GetStatusName(int target)
        {
            string result = "未知";

            switch (target)
            {
                default: break;
                case 0: result = "禁用"; break;
                case 1: result = "启用"; break;
            }

            return result;
        }
    }
}