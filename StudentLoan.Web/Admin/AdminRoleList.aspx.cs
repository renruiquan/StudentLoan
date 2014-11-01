using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web.Admin
{
    public partial class AdminRoleList : AdminBasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action = this.Request<string>("Action");
                int userId = this.Request<int>("UserId");

                if (action == "Delete" && userId > 0)
                {
                    bool result = new UsersBLL().UpdateStatus(userId);

                    this.Alert(string.Format("锁定{0}", result == true ? "成功" : "失败"), "UserList.aspx");
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


            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<AdminRoleEntityEx> sourceList = new AdminRoleBLL().GetListByPage(string.Empty, " RoleId ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new AdminRoleBLL().GetRecordCount(string.Empty);

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            if (endIndex > this.objAspNetPager.RecordCount)
            {
                this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            }


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }

     
    }
}