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
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void btnLoginOut_Click(object sender, EventArgs e)
        {
            Session[StudentLoanKeys.SESSION_USER_INFO] = null;
            this.WriteCookie("UserName", "StudentLoan", -14400);
            this.WriteCookie("UserPwd", "StudentLoan", -14400);
            Response.Redirect("login.aspx");
        }
    }
}