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
            string userEmail = txtEmail.Text.Trim().HtmlEncode();
            string userCon_pwd = txtConfirmPassword.Text.Trim().HtmlEncode();
            string userPwd = txtPassword.Text.Trim().HtmlEncode();
            string userProvice = this.Request<string>("ddlProvince").HtmlEncode();
            string userCity = this.Request<string>("ddlCity").HtmlEncode();
            string userDist = this.Request<string>("ddlDist").HtmlEncode();
            string userAddress = string.Format("{0} {1} {2}", this.Request<string>("ddlBirthOrOriginProvince").HtmlEncode(), this.Request<string>("ddlBirthOrOriginCity").HtmlEncode(), this.Request<string>("ddlBirthOrOriginDist").HtmlEncode());
            string userDrawMoneyPassword = txtDrawMoneyPassword.Text.Trim().HtmlEncode();
            string ConfirmUserDrawMoneyPassword = txtConfirmDrawMoneyPassword.Text.Trim().HtmlEncode();
            string validateCode = txtValidateCode.Text.Trim().HtmlEncode();

            if (string.IsNullOrEmpty(userName))
            {
                this.artDialog("错误", "用户名不能空为，请重新填写");
                return;
            }

            if (string.IsNullOrEmpty(userPwd))
            {
                this.artDialog("错误", "密码不能空为，请重新填写");
                return;
            }

            if (string.IsNullOrEmpty(userEmail))
            {
                this.artDialog("错误", "邮箱地址不能为空，请重新填写");
                return;
            }

            if (string.IsNullOrEmpty(userCon_pwd))
            {
                this.artDialog("错误", "确认密码不能为空，请重新填写");
                return;
            }

            if (string.IsNullOrEmpty(userDrawMoneyPassword))
            {
                this.artDialog("错误", "提现密码不能为空，请重新填写");
                return;
            }

            if (string.IsNullOrEmpty(ConfirmUserDrawMoneyPassword))
            {
                this.artDialog("错误", "确认提现密码不能为空，请重新填写");
                return;
            }

            if (!userDrawMoneyPassword.Equals(ConfirmUserDrawMoneyPassword))
            {
                this.artDialog("错误", "两次提现密码不同，请重新填写");
                return;
            }


            if (string.IsNullOrEmpty(userAddress))
            {
                this.artDialog("错误", "家庭地址不能为空，请重新填写");
                return;
            }
            if (string.IsNullOrEmpty(userProvice))
            {
                this.artDialog("错误", "省份不能为空，请重新选择");
                return;
            }
           
            if (!userPwd.Equals(userCon_pwd))
            {
                this.artDialog("错误", "两次密码不同");
                return;
            }
            if (string.IsNullOrEmpty(validateCode))
            {
                this.artDialog("错误", "验证码不能为空");
                return;
            }
            if (validateCode.ToLower() != Session[StudentLoanKeys.SESSION_CODE].ToString().ToLower())
            {
                this.artDialog("错误", "验证码不正确");
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


            UsersEntityEx model = new UsersEntityEx();
            model.Salt = Guid.NewGuid().ToString().Split('-')[1];
            model.UserName = userName;
            model.Password = DESHelper.Encrypt(userPwd, model.Salt);
            model.Email = userEmail;
            model.RegIP = Request.UserHostAddress;
            model.CreateTime = DateTime.Now;
            model.Birthday = DateTime.Now;
            model.DrawMoneyPassword = DESHelper.Encrypt(userDrawMoneyPassword, model.Salt);
            model.Province = userProvice;
            model.City = userCity;
            model.Address = string.Format("{0}区{1}", userDist, userAddress);

            //判断用户是否存在
            bool result = new UsersBLL().Exists(model.UserName);

            if (result)
            {
                this.artDialog("错误", "用户名已存在，请修改后重试");
                return;
            }

            result = new UsersBLL().Insert(model);

            if (result)
            {
                model = new UsersBLL().GetModel(new UsersBLL().GetUserId(model.UserName));

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

                this.artDialog("提示", "注册成功", "RegSuccess.aspx");

            }
            else
            {
                this.artDialog("注册失败，请联系管理员");
            }
            //写入Cookies
            this.WriteCookie("SLRememberName", model.UserName, 14400);
            this.WriteCookie("UserName", "StudentLoan", model.UserName);
            this.WriteCookie("UserPwd", "StudentLoan", model.Password);

            return;
        }
    }
}