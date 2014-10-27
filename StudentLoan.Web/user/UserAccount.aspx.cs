using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;

namespace StudentLoan.Web.user
{
    public partial class UserAccount : BasePage
    {
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

                this.BindData();
            }
        }

        public void BindData()
        {
            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserLoanEntityEx> sourceList = new UserLoanBLL().GetAccountLoan(base.GetUserModel().UserId, startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserLoanBLL().GetRecordCount(string.Format(" T.UserId={0}", base.GetUserModel().UserId));

            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();
        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}