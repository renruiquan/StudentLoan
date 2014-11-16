using StudentLoan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.API;
using StudentLoan.BLL;
using StudentLoan.Model;

namespace StudentLoan.Web.user
{
    public partial class BindMobile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式

                string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                Control objControl = Master.FindControl(id);

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion

                this.BindMobileInfo();
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
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

            bool result = new UsersBLL().UpdateMobile(base.GetUserModel().UserId, mobile);

            if (result)
            {
                UsersEntityEx userModel = new UsersBLL().GetModel(base.GetUserModel().UserId);

                userModel.Mobile = mobile;

                //重新写入Cookies
                this.WriteCookie("SLRememberName", userModel.UserName, 14400);
                this.WriteCookie("UserName", "StudentLoan", userModel.UserName);
                this.WriteCookie("UserPwd", "StudentLoan", userModel.Password);

                this.artDialog("提示", "绑定手机成功", "BindMobile.aspx");
            }
            else
            {
                this.artDialog("提示", "绑定手机失败，请联系管理员！", "BindMobile.aspx");
            }
        }

        public void BindMobileInfo()
        {
            UsersEntityEx userModel = new UsersBLL().GetModel(base.GetUserModel().UserId);

            if (string.IsNullOrEmpty(userModel.Mobile))
            {
                this.objLiteral.Text = "您还绑定手机号码，如希望绑定手机号码，请输入以下信息";
            }
            else
            {
                this.objLiteral.Text = string.Format("已绑定手机号码：{0}，如希望绑定其他手机号码，请输入以下信息", EncryptionMobile(userModel.Mobile));
            }
        }

        public string EncryptionMobile(string mobile)
        {
            if (string.IsNullOrEmpty(mobile))
            {
                return mobile;
            }

            else if (mobile.Length != 11)
            {
                return mobile;
            }

            else
            {
                return string.Format("{0}****{1}", mobile.Substring(0, 3), mobile.Substring(7, 4));
            }
        }
    }
}