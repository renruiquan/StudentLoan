using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.BLL;
using StudentLoan.Model;

namespace StudentLoan.Web.user
{
    public partial class UserAccountCert_4 : BasePage
    {
        #region 公共属性

        public UserCertificationEntityEx XueXin { get; set; }

        public UserCertificationEntityEx Bank { get; set; }

        public UserCertificationEntityEx Alipay { get; set; }

        public UserCertificationEntityEx Mobile { get; set; }

        public UserCertificationEntityEx Parents1 { get; set; }

        public UserCertificationEntityEx Parents2 { get; set; }

        public UserCertificationEntityEx Roommate1 { get; set; }

        public UserCertificationEntityEx Roommate2 { get; set; }

        public UserCertificationEntityEx StudentId1 { get; set; }

        public UserCertificationEntityEx StudentId2 { get; set; }

        public UserCertificationEntityEx Residencebooklet { get; set; }

        public UserCertificationEntityEx DriversLicense { get; set; }

        public UserCertificationEntityEx Awards { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式

                string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                Control objControl = Master.FindControl(id.Replace("_4", ""));

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion

                this.BindData();
            }
        }

        public void BindData()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" 1=1 and UserId = {0}", base.GetUserModel().UserId));

            if (sourceList != null)
            {
                this.XueXin = sourceList.Where(s => s.Type == 4).First();
                this.Bank = sourceList.Where(s => s.Type == 5).First();
                this.Alipay = sourceList.Where(s => s.Type == 6).First();
                this.Mobile = sourceList.Where(s => s.Type == 7).First();
                this.Parents1 = sourceList.Where(s => s.Type == 8).First();
                this.Parents2 = sourceList.Where(s => s.Type == 9).First();
                this.Roommate1 = sourceList.Where(s => s.Type == 10).First();
                this.Roommate2 = sourceList.Where(s => s.Type == 11).First();
                this.StudentId1 = sourceList.Where(s => s.Type == 12).First();
                this.StudentId2 = sourceList.Where(s => s.Type == 13).First();
                this.Residencebooklet = sourceList.Where(s => s.Type == 14).First();
                this.DriversLicense = sourceList.Where(s => s.Type == 15).First();
                this.Awards = sourceList.Where(s => s.Type == 16).First();
            }
        }
    }
}