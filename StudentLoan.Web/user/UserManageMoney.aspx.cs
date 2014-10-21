using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Model;
using StudentLoan.Common;
using StudentLoan.API;
using StudentLoan.Common.Logging;

namespace StudentLoan.Web.user
{
    public partial class UserManageMoney : BasePage
    {
        public int ProductId { get { return this.Request<int>("ProductId"); } }

        public int ProductSchemeId { get { return this.Request<int>("ProductSchemeId"); } }

        protected void Page_Load(object sender, EventArgs e)
        {


        }
    }
}