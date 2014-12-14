using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.BLL;
using StudentLoan.Model;
using System.Text;

namespace StudentLoan.Web.user
{
    public partial class ModifyCert : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            int userId = base.GetUserModel().UserId;
            int type = this.Request<int>("tid");
            int certId = this.Request<int>("cid");

            List<UserCertificationEntityEx> list = new UserCertificationBLL().GetList(string.Format(" UserId={0} and Type={1} and Status =1", userId, type));

            if (list != null && list.Count > 0)
            {
                StringBuilder objSB = new StringBuilder();

                foreach (UserCertificationEntityEx item in list)
                {
                    objSB.Append("<li class=\"span4\">");
                    objSB.Append("<div class=\"thumbnail\">");
                    objSB.AppendFormat("<img src=\"{0}\" class=\"img-cert\" />", item.Images);
                    objSB.Append("</div>");
                    objSB.AppendFormat("<input id=\"{0}\" typeid=\"{1}\" for=\"imgMobile\" name=\"fileData\" type=\"file\" class=\"uploadify-button\" />", item.Id, item.Type);
                    objSB.Append("</li>");
                }

                this.objLiteral.Text = objSB.ToString();
            }
        }
    }
}