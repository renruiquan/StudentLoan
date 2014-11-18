using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web
{
    public partial class FindPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFindPassword_ServerClick(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text.Trim();
            string mobile = this.txtMobile.Text.Trim();

            string validateCode = this.txtValidatecode.Text.Trim();

            string mobileCode = CacheHelper.Get<string>("MobileCode");

            if (string.IsNullOrEmpty(mobile))
            {
                this.artDialog("手机号码不能为空！");
                return;
            }

            if (mobileCode == null)
            {
                this.artDialog("验证码已过期,请重新获取！");
                return;
            }

            if (validateCode != mobileCode)
            {
                this.artDialog("手机验证码不正确！");
                return;
            }

            UsersBLL bll = new UsersBLL();

            int userId = bll.GetUserId(userName);

            if (userId != 0)
            {
                this.artDialog("提示", "该用户不存在，无法找回密码！");
                return;
            }

            UsersEntityEx userModel = bll.GetModel(userId);

            if (userModel == null)
            {
                this.artDialog("提示", "该用户不存在，无法找回密码！");
                return;
            }

            //写入Cookies
            this.WriteCookie("SLRememberName", userModel.UserName, 14400);
            this.WriteCookie("UserName", "StudentLoan", userModel.UserName);
            this.WriteCookie("UserPwd", "StudentLoan", userModel.Password);
            Response.Redirect("/user/ChangePassword.aspx?type=findpassword");
        }
    }
}