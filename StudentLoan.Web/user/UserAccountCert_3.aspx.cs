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
using System.Text;

namespace StudentLoan.Web.user
{
    public partial class UserAccountCert_3 : BasePage
    {
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

                this.BindMobilePictureCert();
            }
        }

        public void BindData()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" 1=1 and UserId = {0}", base.GetUserModel().UserId));

            if (sourceList != null && sourceList.Count > 0)
            {
                if (sourceList.FirstOrDefault(s => s.Type == 0) != null)
                {
                    this.imgIdentityCard.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 0).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 1) != null)
                {
                    this.imgIdentityCard2.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 1).Images;
                }
                if (sourceList.FirstOrDefault(s => s.Type == 17) != null)
                {
                    this.imgIdentityCard3.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 17).Images;
                }

                if (sourceList.FirstOrDefault(s => s.Type == 2) != null)
                {
                    this.imgStudentId_1.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 2).Images;
                }

                if (sourceList.FirstOrDefault(s => s.Type == 3) != null)
                {
                    this.imgStudentId_2.ImageUrl = sourceList.FirstOrDefault(s => s.Type == 3).Images;
                }
            }
        }

        public void BindMobilePictureCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" UserId={0} and type=7 ", base.GetUserModel().UserId));

            if (sourceList == null || sourceList.Count == 0)
            {
                litMobile.Text = "<div class=\"active item\"><img id=\"imgMobile_0\" style='width:237px;height:168px;' src=\"../css/img/admin/telephone.jpg\" /></div>";
            }
            else
            {
                StringBuilder objSB = new StringBuilder();
                StringBuilder objSB2 = new StringBuilder();

                for (int i = 0; i < sourceList.Count; i++)
                {
                    if (i == 0)
                    {
                        objSB.AppendFormat("<div class=\"active item\"><a href=\"ModifyCert.aspx?uid={0}&cid={1}&tid={2}\"><img id=\"imgMobile_0\"  style='width:237px;height:168px;' src=\"{3}\" /></a></div>", sourceList[i].UserId, sourceList[i].Id, sourceList[i].Type, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel\" data-slide-to=\"{0}\" class=\"active\"></li>", i);
                    }
                    else
                    {
                        objSB.AppendFormat("<div class=\"item\"><a href=\"ModifyCert.aspx?uid={0}&cid={1}&tid={2}\"><img id=\"imgMobile_{3}\"  style='width:237px;height:168px;' src=\"{4}\" /></a></div>", sourceList[i].UserId, sourceList[i].Id, sourceList[i].Type, i, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel\" data-slide-to=\"{0}\"></li>", i);
                    }

                }

                litMobile.Text = objSB.ToString();
                litMobileIndex.Text = objSB2.ToString();

            }
        }
    }
}