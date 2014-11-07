using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Common;

namespace StudentLoan.Web.user
{
    public partial class UserMessage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式

                string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                Control objControl = Master.FindControl(id.Replace("_2", ""));

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion

                this.BindData();
            }
        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        public void BindData()
        {
            UsersEntityEx userModel = base.GetUserModel();

            if (userModel == null)
            {
                this.artDialog("提示", "登录超时，请重新登录", "login.aspx");
                return;
            }

            string strWhere = string.Format(" 1=1 and Type=0  and AcceptUserName = '{0}' and IsRead=0", base.GetUserModel().UserName);

            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserMessageEntityEx> sourceList = new UserMessageBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserMessageBLL().GetRecordCount(strWhere);

            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }

        protected void btnHidn_ServerClick(object sender, EventArgs e)
        {

        }
    }
}