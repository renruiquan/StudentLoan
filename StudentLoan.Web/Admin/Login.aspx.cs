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
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session[StudentLoanKeys.SESSION_ADMIN_INFO] = null;
                this.WriteCookie("AdminName", "StudentLoan", -14400);
                this.WriteCookie("AdminPassword", "StudentLoan", -14400);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text.Trim();
            string userPwd = Password.Text.Trim();


            if (userName.Equals("") || userPwd.Equals(""))
            {
                this.artDialog("错误", "用户名或密码不能空");
                return;
            }
            if (string.IsNullOrEmpty(txtValidateCode.Text.Trim()))
            {
                this.artDialog("错误", "验证码不能为空！");
                return;
            }
            if (Session[StudentLoanKeys.SESSION_ADMIN_INFO] != null)
            {
                if (Session[StudentLoanKeys.SESSION_CODE].ToString().ToLower() != txtValidateCode.Text.Trim().ToLower())
                {
                    this.artDialog("错误", "验证码不正确！");
                    return;
                }
            }

            if (Session[StudentLoanKeys.SESSION_ADMIN_LOGIN_SUM] == null)
            {
                Session[StudentLoanKeys.SESSION_ADMIN_LOGIN_SUM] = 1;
            }
            else
            {
                Session[StudentLoanKeys.SESSION_ADMIN_LOGIN_SUM] = Convert.ToInt32(Session[StudentLoanKeys.SESSION_ADMIN_LOGIN_SUM]) + 1;
            }
            //判断登录错误次数
            if (Session[StudentLoanKeys.SESSION_ADMIN_LOGIN_SUM] != null && Convert.ToInt32(Session[StudentLoanKeys.SESSION_ADMIN_LOGIN_SUM]) > 5)
            {
                this.artDialog("错误超过5次，关闭浏览器重新登录！");
                return;
            }
            AdminBLL bll = new AdminBLL();
            AdminEntityEx model = bll.GetModel(userName, userPwd, true);
            if (model == null)
            {
                this.artDialog("用户名或密码有误，请重试！");
                return;
            }
            Session[StudentLoanKeys.SESSION_ADMIN_INFO] = model;
            Session.Timeout = 45;

            //写入登录日志
            AdminLogEntityEx adminLogModel = new AdminLogEntityEx()
            {
                AdminId = model.AdminId,
                AdminName = model.AdminName,
                UserIP = Request.UserHostAddress,
                ActionType = "登录"
            };

            new AdminLogBLL().Insert(adminLogModel);

            //写入Cookies
            this.WriteCookie("SLRememberName", model.AdminName, 14400);
            this.WriteCookie("AdminName", "StudentLoan", model.AdminName);
            this.WriteCookie("AdminPassword", "StudentLoan", model.Password);
            Response.Redirect("Default.aspx");
            return;
        }
    }
}