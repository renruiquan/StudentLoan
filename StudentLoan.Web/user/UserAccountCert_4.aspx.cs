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
using System.Text;

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
                this.BindBankPictureCert();
                this.BindAlipayPictureCert();
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

        public void BindBankPictureCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" UserId={0} and type=5 ", base.GetUserModel().UserId));

            if (sourceList == null || sourceList.Count == 0)
            {
                litBank.Text = "<div class=\"active item\"><img id=\"imgBank_0\" style='width:237px;height:168px;' src=\"../css/img/admin/card.jpg\" /></div>";
            }
            else
            {
                StringBuilder objSB = new StringBuilder();
                StringBuilder objSB2 = new StringBuilder();

                for (int i = 0; i < sourceList.Count; i++)
                {
                    if (i == 0)
                    {
                        objSB.AppendFormat("<div class=\"active item\"><a href=\"ModifyCert.aspx?uid={0}&cid={1}&tid={2}\"><img id=\"imgBank_0\"  style='width:237px;height:168px;' src=\"{3}\" /></a></div>", sourceList[i].UserId, sourceList[i].Id, sourceList[i].Type, sourceList[i].Images);                        
                        objSB2.AppendFormat("<li data-target=\"#myCarousel\" data-slide-to=\"{0}\" class=\"active\"></li>", i);
                    }
                    else
                    {
                        objSB.AppendFormat("<div class=\"item\"><a href=\"ModifyCert.aspx?uid={0}&cid={1}&tid={2}\"><img id=\"imgBank_{3}\"  style='width:237px;height:168px;' src=\"{4}\" /></a></div>", sourceList[i].UserId, sourceList[i].Id, sourceList[i].Type, i, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel\" data-slide-to=\"{0}\"></li>", i);
                    }

                }

                litBank.Text = objSB.ToString();
                litBankIndex.Text = objSB2.ToString();
            }
        }

        public void BindAlipayPictureCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" UserId={0} and type=6 ", base.GetUserModel().UserId));

            if (sourceList == null || sourceList.Count == 0)
            {
                litAlipay.Text = "<div class=\"active item\"><img id=\"imgAlipay_0\" style='width:237px;height:168px;' src=\"../css/img/admin/internetbank.jpg\" /></div>";
            }
            else
            {
                StringBuilder objSB = new StringBuilder();
                StringBuilder objSB2 = new StringBuilder();

                for (int i = 0; i < sourceList.Count; i++)
                {
                    if (i == 0)
                    {
                        objSB.AppendFormat("<div class=\"active item\"><a href=\"ModifyCert.aspx?uid={0}&cid={1}&tid={2}\"><img id=\"imgAlipay_0\"  style='width:237px;height:168px;' src=\"{3}\" /></a></div>", sourceList[i].UserId, sourceList[i].Id, sourceList[i].Type, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel2\" data-slide-to=\"{0}\" class=\"active\"></li>", i);
                    }
                    else
                    {
                        objSB.AppendFormat("<div class=\"item\"><a href=\"ModifyCert.aspx?uid={0}&cid={1}&tid={2}\"><img id=\"imgAlipay_{3}\"  style='width:237px;height:168px;' src=\"{4}\" /></a></div>", sourceList[i].UserId, sourceList[i].Id, sourceList[i].Type, i, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel2\" data-slide-to=\"{0}\"></li>", i);
                    }

                }

                litAlipay.Text = objSB.ToString();
                litAlipayIndex.Text = objSB2.ToString();
            }
        }
    }
}