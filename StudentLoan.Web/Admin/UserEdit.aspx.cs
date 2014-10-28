using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web.Admin
{
    public partial class UserEdit : AdminBasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = this.Request<int>("UserId");

                if (userId <= 0)
                {
                    this.Alert("参数不正确");
                    return;
                }

                UsersEntityEx model = new UsersBLL().GetModel(userId);
                if (model == null)
                {
                    this.Alert("用户不存在");
                    return;
                }
                this.ddlStatus.SelectedValue = model.Status.ToString();
                this.txtNewPassword.Text = DESHelper.Decrypt(model.Password, model.Salt);
                this.txtDrawMoneyPassword.Text = DESHelper.Decrypt(model.DrawMoneyPassword, model.Salt);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int userId = this.Request<int>("UserId");
            string salt = new UsersBLL().GetModel(userId).Salt;

            UsersEntityEx model = new Model.UsersEntityEx()
            {
                UserId = userId,
                Password = DESHelper.Encrypt(this.txtNewPassword.Text.Trim(), salt),
                Status = this.ddlStatus.SelectedValue.Convert<int>(),
                DrawMoneyPassword = DESHelper.Encrypt(this.txtDrawMoneyPassword.Text.Trim(), salt)
            };

            bool result = new UsersBLL().UpdatePasswordByAdmin(model);

            this.Alert(string.Format("更新{0}", result == true ? "成功" : "失败"), "UserList.aspx");
        }
    }
}