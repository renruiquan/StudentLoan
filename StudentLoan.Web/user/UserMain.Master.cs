using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Model;

namespace StudentLoan.Web.user
{
    public partial class UserMain : System.Web.UI.MasterPage
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