using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;

namespace StudentLoan.Web
{
    public partial class RegSuccess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.artDialog("放假公告", "为欢度新春佳节，学子易贷平台将于2015年2月15日-2月25日放假，关于2月份申请贷款的用户将于年后审核，特此公告！ ");
            }
        }
    }
}