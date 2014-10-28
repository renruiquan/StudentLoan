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
    public partial class SchoolInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string SchoolName = txtSchoolName.Text.Trim().HtmlEncode();
            string SchoolAddress = txtSchoolAddress.Text.Trim().HtmlEncode();
            string YearOfAdmission = txtYearOfAdmission.Text.Trim().HtmlEncode();
            int SchoolSystem = Convert.ToInt32(drpSchoolSystem.SelectedValue);
            int Education = Convert.ToInt32(drpEducation.SelectedValue);
            string BranchSchool = txtBranchSchool.Text.Trim().HtmlEncode();
        }
    }
}