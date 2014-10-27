using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;

namespace StudentLoan.Web.user
{
    public partial class AccountLog : BasePage
    {
        public int TotalLockMoney { get { return new DrawMoneyBLL().GetTotalLockMoney(base.GetUserModel().UserId); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }


    }
}