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

                this.txtConfirmPassword.Attributes.Add("recheck", this.txtNewPassword.UniqueID);

                string type = this.Request<string>("type");

                if (!string.IsNullOrEmpty(type) && type == "findpassword")
                {
                    this.divOldPassword.Visible = false;
                }
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string oldPassword = this.txtOldPassword.Text.Trim();
            string newPassword = this.txtNewPassword.Text.Trim();
            string confirmPassword = this.txtConfirmPassword.Text.Trim();
            string type = this.Request<string>("type");

            UsersEntityEx model = base.GetUserModel();

            if (string.IsNullOrEmpty(type))
            {
                if (oldPassword == newPassword)
                {
                    this.artDialog("错误", "旧密码与新密码不能相同，请修正后重试！");
                    return;
                }

                if (DESHelper.Encrypt(oldPassword, model.Salt) != model.Password)
                {
                    this.artDialog("错误", "旧密码不正确，请修正后重试！");
                    return;
                }
            }

            if (!newPassword.Equals(confirmPassword))
            {
                this.artDialog("错误", "新密码与确认密码不同，请修正后重试！");
                return;
            }

            if (newPassword.Length < 6 || newPassword.Length > 18)
            {
                this.artDialog("错误", "密码长度最短为6位，最长18位，请修正后重试！");
                return;
            }

            //Regex regex = new Regex(@"^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,18}$");

            //if (!regex.IsMatch(newPassword))
            //{
            //    this.artDialog("密码长度最短为6位，最长18位，且包含字母和数字，请修正后重试！");
            //    return;
            //}

            model = new UsersEntityEx()
            {
                UserId = model.UserId,
                Password = DESHelper.Encrypt(newPassword, model.Salt)
            };

            bool result = new UsersBLL().UpdatePassword(model);

            if (result)
            {
                this.artDialog("提示", string.Format("密码修改{0}，请使用新密码重新登录", result == true ? "成功" : "失败"), "/LoginOut.aspx");

            }
        }
    }
}