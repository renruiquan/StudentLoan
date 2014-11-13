using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Model;
using StudentLoan.Common;
using StudentLoan.BLL;

namespace StudentLoan.Web.user
{
    public partial class UserAccountCert_3 : BasePage
    {
        public UserCertificationEntityEx IdentityCard_1 { get; set; }
        public UserCertificationEntityEx IdentityCard_2 { get; set; }

        public UserCertificationEntityEx StudentId_1 { get; set; }
        public UserCertificationEntityEx StudentId_2 { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式

                string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                Control objControl = Master.FindControl(id.Replace("_3", ""));

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
                IdentityCard_1 = sourceList.FirstOrDefault(s => s.Type == 0);
                IdentityCard_2 = sourceList.FirstOrDefault(s => s.Type == 1);

                StudentId_1 = sourceList.FirstOrDefault(s => s.Type == 2);
                StudentId_2 = sourceList.FirstOrDefault(s => s.Type == 3);

            }
        }
    }
}