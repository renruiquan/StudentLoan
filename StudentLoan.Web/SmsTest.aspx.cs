using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.API;
using StudentLoan.Common;
using System.Net;
using System.IO;
using System.Text;
using System.Web.Security;

namespace StudentLoan.Web
{
    public partial class SmsTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string result =  Message.Send("15999557774", "XXXXX");

            this.Alert(result);
        }
    }
}