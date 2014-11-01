using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using System.Text;

namespace StudentLoan.Web.Admin
{
    public partial class AdminRoleAdd : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AdminRoleEntityEx model = new AdminRoleEntityEx()
            {
                RoleName = this.txtAdminRoleName.Text.Trim(),
                RoleType = this.ddlRoleType.SelectedValue.Convert<int>(),
                IsSystem = this.ddlIsSystem.SelectedValue.Convert<int>(),
            };

            bool result = new AdminRoleBLL().Exists(model.RoleName);

            if (result)
            {
                this.Alert("角色名已存在，请修改后重试！");
                return;
            }

            int roleId = new AdminRoleBLL().Insert(model);

            List<AdminRoleValueEntityEx> roleValueList = new List<AdminRoleValueEntityEx>();

            for (int i = 0; i < objRepeater.Items.Count; i++)
            {
                CheckBox objCheckBox = objRepeater.Items[i].FindControl("objCheckBox") as CheckBox;

                if (objCheckBox.Checked == true)
                {
                    result = new AdminRoleValueBLL().Insert(new AdminRoleValueEntityEx() { RoleId = roleId, NavId = objCheckBox.Attributes["value"].Convert<int>() });
                }
            }

            this.Alert(string.Format("添加{0}", result == true ? "成功" : "失败"), "AdminRoleList.aspx");


        }

        protected void BindData()
        {
            this.objRepeater.DataSource = new AdminRoleValueBLL().GetNavList(" 1=1 ");
            this.objRepeater.DataBind();
        }
    }
}