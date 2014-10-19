using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web
{
    public partial class Main : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public UsersEntityEx UserModel { get { return new BasePage().GetUserModel(); } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}