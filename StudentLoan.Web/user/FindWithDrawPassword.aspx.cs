using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web.user
{
    public partial class FindWithDrawPassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnFindPassword_ServerClick(object sender, EventArgs e)
        {

            string mobile = this.txtMobile.Text.Trim();

            string validateCode = this.txtValidatecode.Text.Trim();

            string mobileCode = Session["MobileCode"] == null ? string.Empty : Session["MobileCode"].ToString();

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

            Session["MobileCode"] = null;

            Response.Redirect("/user/ChangeWithDrawPassword.aspx?type=findwithdrawpassword");
        }
    }
}