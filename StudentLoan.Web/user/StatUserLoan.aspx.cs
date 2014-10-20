using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Model;
using StudentLoan.BLL;
using System.Reflection;
using System.Web.UI.HtmlControls;

namespace StudentLoan.Web.user
{
    public partial class StatUserLoan : BasePage
    {

        public UserLoanEntityEx StatBreakContractUserLoan { get; set; }

        public UserLoanEntityEx StatNormalUserLoan { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式

                string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                Control objControl = Master.FindControl(id);

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion

                UserLoanBLL bll = new UserLoanBLL();

                UsersEntityEx model = base.GetUserModel();

                this.StatBreakContractUserLoan = bll.GetStatBreakContractUserLoan(model.UserId);
                this.StatNormalUserLoan = bll.GetStatNormalUserLoan(model.UserId);
            }
        }
    }
}