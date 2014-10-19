using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Model;
using StudentLoan.Common;

namespace StudentLoan.Web.Admin
{
    public partial class welcome : AdminBasePage
    {
        public int LoginCount { get; set; }

        public AdminLogEntityEx LoginInfo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int adminId = base.GetAdminInfo().AdminId;

                this.LoginCount = new AdminLogBLL().GetLoginCount(adminId);

                this.LoginInfo = new AdminLogBLL().GetModel(adminId);
            }
        }
    }
}