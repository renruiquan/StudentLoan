using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.BLL;
using StudentLoan.Model;
using System.Text.RegularExpressions;

namespace StudentLoan.Web.user
{
    public partial class ChangePassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置样式

                string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                Control objControl = Master.FindControl(id);

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion

            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string oldPassword = this.txtOldPassword.Text.Trim();
            string newPassword = this.txtNewPassword.Text.Trim();
            string confirmPassword = this.txtConfirmPassword.Text.Trim();

            UsersEntityEx model = base.GetUserModel();

            if (DESHelper.Encrypt(oldPassword, model.Salt) != model.Password)
            {
                this.artDialog("旧密码不正确，请修正后重试！");
                return;
            }

            if (!newPassword.Equals(confirmPassword))
            {
                this.artDialog("新密码与确认密码不同，请修正后重试！");
                return;
            }

            if (newPassword.Length < 8 || newPassword.Length > 16)
            {
                this.artDialog("密码长度最短为8位，最长16位，且包含字母和数字，请修正后重试！");
                return;
            }

            Regex regex = new Regex(@"^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,16}$");

            if (!regex.IsMatch(newPassword))
            {
                this.artDialog("密码长度最短为8位，最长16位，且包含字母和数字，请修正后重试！");
                return;
            }

            model = new UsersEntityEx()
            {
                UserId = model.UserId,
                Salt = Guid.NewGuid().ToString().Split('-')[1],
            };

            model.Password = DESHelper.Encrypt(newPassword, model.Salt);

            bool result = new UsersBLL().UpdatePassword(model);

            if (result)
            {
                Session[StudentLoanKeys.SESSION_USER_INFO] = null;
                this.WriteCookie("UserName", "StudentLoan", -14400);
                this.WriteCookie("UserPwd", "StudentLoan", -14400);
            }

            this.artDialog("提示", string.Format("密码修改{0}，请使用新密码重新登录", result == true ? "成功" : "失败"), "Login.aspx");
        }
    }
}