using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;

namespace StudentLoan.Web.Admin
{
    public partial class UserList : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action = this.Request<string>("Action");
                int userId = this.Request<int>("UserId");

                if (action == "Delete" && userId > 0)
                {
                    bool result = new UsersBLL().UpdateStatus(userId);

                    this.Alert(string.Format("锁定{0}", result == true ? "成功" : "失败"), "UserList.aspx");
                }

                this.BindData();
            }
        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        public void BindData()
        {
            string strWhere = @" 1=1 ";

            string queryContent = this.txtQueryContent.Text.Trim();

            if (!string.IsNullOrEmpty(queryContent))
            {
                if (this.ddlQueryType.SelectedValue == "1")
                {
                    strWhere += string.Format(@" and UserName = '{0}'", queryContent);
                }

                if (this.ddlQueryType.SelectedValue == "2")
                {
                    strWhere += string.Format(@" and IdentityCard = '{0}'", queryContent);
                }

                if (this.ddlQueryType.SelectedValue == "3")
                {
                    strWhere += string.Format(@" and Mobile = '{0}'", queryContent);
                }
            }

            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UsersEntityEx> sourceList = new UsersBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UsersBLL().GetRecordCount(strWhere);

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            //if (endIndex > this.objAspNetPager.RecordCount)
            //{
            //    this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            //}


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }

        public string GetStatusName(int status)
        {
            if (status == 0)
            {
                // 0正常,1待验证,2待审核,3锁定
                return "正常";
            }
            else if (status == 1)
            {
                return "待验证";
            }
            else if (status == 2)
            {
                return "待审核";
            }
            else if (status == 3)
            {
                return "锁定";
            }
            else
            {
                return "异常";
            }
        }

    }
}