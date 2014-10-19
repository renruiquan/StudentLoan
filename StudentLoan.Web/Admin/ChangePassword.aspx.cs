using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.BLL;

namespace StudentLoan.Web.Admin
{
    public partial class ChangePassword : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string oldPassword = this.txtOldPassword.Text.Trim();
            string newPassword = this.txtNewPassword.Text.Trim();
            string confirmNewPassword = this.txtConfirmNewPassword.Text.Trim();

            AdminEntityEx model = base.GetAdminInfo();

            if (DESHelper.Encrypt(oldPassword, model.Salt) != model.Password)
            {
                this.Alert("旧密码不正确，请修正后重试！");
                return;
            }

            if (!newPassword.Equals(confirmNewPassword))
            {
                this.Alert("新密码与确认密码不同，请修正后重试！");
                return;
            }

            AdminEntityEx adminModel = new AdminEntityEx()
            {
                AdminId = model.AdminId,
                Salt = Guid.NewGuid().ToString().Split('-')[1],
            };

            adminModel.Password = DESHelper.Encrypt(newPassword, adminModel.Salt);

            bool result = new AdminBLL().UpdatePassword(adminModel);

            if (result)
            {
                Session[StudentLoanKeys.SESSION_ADMIN_INFO] = null;
                this.WriteCookie("AdminName", "StudentLoan", -14400);
                this.WriteCookie("AdminPassword", "StudentLoan", -14400);
            }

            this.Alert(string.Format("密码修改{0}，请使用新密码重新登录", result == true ? "成功" : "失败"), "Login.aspx");
        }
    }
}