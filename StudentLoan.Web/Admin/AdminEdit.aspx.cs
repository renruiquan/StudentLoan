using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;

namespace StudentLoan.Web.Admin
{
    public partial class AdminEdit : AdminBasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminEntityEx admin = base.GetAdminInfo();

                this.BindRoleList();

                if (admin.RoleId != 1)
                {
                    this.Alert("对不起，仅超级管理员才有权限修改其他管理员信息！", "AdminList.aspx");
                    return;
                }

                int adminId = this.Request<int>("AdminId");

                if (adminId <= 0)
                {
                    this.Alert("参数不正确", "AdminList.aspx");
                    return;
                }

                AdminEntityEx model = new AdminBLL().GetModel(adminId);
                this.ddlRoleId.SelectedValue = model.RoleId.ToString();
                this.txtAdminName.Text = model.AdminName;
                this.txtRealName.Text = model.RealName;
                this.txtTelephone.Text = model.Telephone;
                this.txtEmail.Text = model.Email;
                this.txtPassword.Text = DESHelper.Decrypt(model.Password, model.Salt);
                this.ddlIsLock.SelectedValue = model.IsLock.ToString();

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int AdminId = this.Request<int>("AdminId");

            string salt = new AdminBLL().GetModel(AdminId).Salt;

            AdminEntityEx model = new Model.AdminEntityEx()
            {
                AdminId = AdminId,
                Password = DESHelper.Encrypt(this.txtPassword.Text.Trim(), salt),
                RoleId = this.ddlRoleId.SelectedValue.Convert<int>(),
                AdminName = this.txtAdminName.Text.Trim(),
                RealName = this.txtRealName.Text.Trim(),
                Telephone = this.txtTelephone.Text.Trim(),
                Email = this.txtEmail.Text.Trim(),
                IsLock = this.ddlIsLock.SelectedValue.Convert<int>()
            };

            bool result = new AdminBLL().Update(model);

            this.Alert(string.Format("更新{0}", result == true ? "成功" : "失败"), "AdminList.aspx");
        }

        protected void BindRoleList()
        {
            this.ddlRoleId.DataSource = new AdminRoleBLL().GetList(string.Empty);

            this.ddlRoleId.DataTextField = "RoleName";
            this.ddlRoleId.DataValueField = "RoleId";

            this.ddlRoleId.DataBind();

        }
    }
}