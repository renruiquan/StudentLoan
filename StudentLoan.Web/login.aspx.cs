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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string userPwd = txtPassword.Text.Trim();


            if (userName.Equals("") || userPwd.Equals(""))
            {
                this.artDialog("提示", "用户名或密码不能空");
                return;
            }
            /**
            if (string.IsNullOrEmpty(txtValidateCode.Text.Trim()))
            {
                this.artDialog("提示", "验证码不能为空！");
                return;
            }
            if (Session[StudentLoanKeys.SESSION_CODE] != null)
            {
                if (Session[StudentLoanKeys.SESSION_CODE].ToString().ToLower() != txtValidateCode.Text.Trim().ToLower())
                {
                    this.artDialog("提示", "验证码不正确！");
                    return;
                }
            }
            **/

            if (Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] == null)
            {
                Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] = 1;
            }
            else
            {
                Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] = Convert.ToInt32(Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM]) + 1;
            }
            //判断登录错误次数
            if (Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] != null && Convert.ToInt32(Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM]) > 5)
            {
                this.Alert("错误超过5次，关闭浏览器重新登录！");
                return;
            }
            UsersBLL bll = new UsersBLL();
            UsersEntityEx model = bll.GetModel(userName, userPwd, true);
            if (model == null)
            {
                this.artDialog("提示", "用户名或密码有误，请重试！");
                return;
            }
            Session[StudentLoanKeys.SESSION_USER_INFO] = model;
            Session.Timeout = 45;

            //写入登录日志
            UserLoginLogEntityEx ulModel = new UserLoginLogEntityEx()
            {
                UserId = model.UserId,
                UserName = model.UserName,
                LoginIP = Request.UserHostAddress
            };

            new UserLoginLogBLL().Insert(ulModel);

            //写入Cookies
            this.WriteCookie("SLRememberName", model.UserName, 14400);
            this.WriteCookie("UserName", "StudentLoan", model.UserName);
            this.WriteCookie("UserPwd", "StudentLoan", model.Password);
            Response.Redirect("/IvoryTower.aspx");

            return;
        }
    }
}