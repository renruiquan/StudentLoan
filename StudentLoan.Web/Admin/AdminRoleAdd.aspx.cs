using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;

namespace StudentLoan.Web.Admin
{
    public partial class AdminRoleAdd : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AdminRoleEntityEx model = new AdminRoleEntityEx()
            {
                RoleName = this.txtAdminRoleName.Text.Trim(),
                RoleType = this.ddlRoleType.SelectedValue.Convert<int>(),
                IsSystem = this.ddlIsSystem.SelectedValue.Convert<int>()
            };

            bool result = new AdminRoleBLL().Insert(model);

            this.Alert(string.Format("添加{0}", result == true ? "成功" : "失败"), "AdminRoleList.aspx");
        }
    }
}