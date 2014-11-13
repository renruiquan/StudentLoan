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

            if (sourceList != null && sourceList.Count > 0)
            {
                this.XueXin = sourceList.SingleOrDefault(s => s.Type == 4);
                this.Bank = sourceList.SingleOrDefault(s => s.Type == 5);
                this.Alipay = sourceList.SingleOrDefault(s => s.Type == 6);
                this.Mobile = sourceList.SingleOrDefault(s => s.Type == 7);
                this.Parents1 = sourceList.SingleOrDefault(s => s.Type == 8);
                this.Parents2 = sourceList.SingleOrDefault(s => s.Type == 9);
                this.Roommate1 = sourceList.SingleOrDefault(s => s.Type == 10);
                this.Roommate2 = sourceList.SingleOrDefault(s => s.Type == 11);
                this.StudentId1 = sourceList.SingleOrDefault(s => s.Type == 12);
                this.StudentId2 = sourceList.SingleOrDefault(s => s.Type == 13);
                this.Residencebooklet = sourceList.SingleOrDefault(s => s.Type == 14);
                this.DriversLicense = sourceList.SingleOrDefault(s => s.Type == 15);
                this.Awards = sourceList.SingleOrDefault(s => s.Type == 16);
            }
        }
    }
}