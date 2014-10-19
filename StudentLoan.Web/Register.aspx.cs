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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim().HtmlEncode();
            string userTelephone = txtUserTelephone.Text.Trim().HtmlEncode();
            string userEmail = txtUserEmail.Text.Trim().HtmlEncode();
            string userCon_pwd = txtConfirm_Password.Text.Trim().HtmlEncode();
            string userPwd = txtPassword.Text.Trim().HtmlEncode();

            if (userName.Equals("") || userPwd.Equals("") || userTelephone.Equals("") || userEmail.Equals("") || userCon_pwd.Equals(""))
            {
                this.artDialog("错误", "请填写完整信息");
                return;
            }
            if (!userPwd.Equals(userCon_pwd))
            {
                this.artDialog("错误", "两次密码不同");
                return;
            }
            if (!ckbAgreement.Checked)
            {
                this.artDialog("错误", "尚未同意学子易贷协议");
                return;
            }
            if (Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] == null)
            {
                Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] = 1;
            }

            else
            {
                Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] = Convert.ToInt32(Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM]) + 1;
            }
            //判断登录错误次数
            //if (Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] != null && Convert.ToInt32(Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM]) > 5)
            //{
            //    this.artDialog("错误超过5次，关闭浏览器重新登录！");
            //    return;
            //}
            //UsersBLL bll = new UsersBLL();
            //UsersEntityEx model = bll.GetModel(userName, userPwd, true);
            //if (model == null)
            //{
            //    this.artDialog("用户名或密码有误，请重试！");
            //    return;
            //}
            //Session[StudentLoanKeys.SESSION_USER_INFO] = model;
            //Session.Timeout = 45;

            UsersEntityEx model = new UsersEntityEx();
            model.Salt = Guid.NewGuid().ToString().Split('-')[1];
            model.UserName = userName;
            model.Password = DESHelper.Encrypt(userPwd, model.Salt);
            model.Telphone = userTelephone;
            model.Email = userEmail;
            model.RegIP = Request.UserHostAddress;
            model.CreateTime = DateTime.Now;
            model.Birthday = DateTime.Now;

            bool result = new UsersBLL().Insert(model);
            if (result)
            {
                this.artDialog("注册成功");
            }
            else
            {
                this.artDialog("注册失败，请联系管理员");
            }
            //写入Cookies
            //this.WriteCookie("SLRememberName", model.UserName, 14400);
            //this.WriteCookie("UserName", "StudentLoan", model.UserName);
            //this.WriteCookie("UserPwd", "StudentLoan", model.Password);
            Response.Redirect("default.aspx");
            return;
        }
    }
}