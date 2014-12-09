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
                if (sourceList.FirstOrDefault(s => s.Type == 4) != null)
                {
                    this.imgXuexin.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 4).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 5) != null)
                {
                    this.imgBank.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 5).Images;
                }

                if (sourceList.FirstOrDefault(s => s.Type == 6) != null)
                {
                    this.imgAlipay.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 6).Images;
                }

                
                if (sourceList.FirstOrDefault(s => s.Type == 8) != null)
                {
                    this.imgParents1.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 8).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 9) != null)
                {
                    this.imgParents2.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 9).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 10) != null)
                {
                    this.imgRoommate1.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 10).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 11) != null)
                {
                    this.imgRoommate2.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 11).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 12) != null)
                {
                    this.imgStudentId1.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 12).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 13) != null)
                {
                    this.imgStudentId2.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 13).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 14) != null)
                {
                    this.imgResidencebooklet.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 14).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 15) != null)
                {
                    this.imgDriversLicense.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 15).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 16) != null)
                {
                    this.imgAwards.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 16).Images;
                }
            }
        }
    }
}