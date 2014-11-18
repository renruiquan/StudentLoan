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
using StudentLoan.BLL;
using System.Text;

namespace StudentLoan.Web.user
{
    public partial class UserLoanList : BasePage
    {
        private string StartTime
        {
            get
            {
                if (string.IsNullOrEmpty(txtStartTime.Text.Trim().HtmlEncode()))
                {
                    return DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    return txtStartTime.Text.Trim().HtmlEncode().Convert<DateTime>().ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }

        private string EndTime
        {
            get
            {
                if (string.IsNullOrEmpty(txtEndTime.Text.Trim().HtmlEncode()))
                {
                    return DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    return txtEndTime.Text.Trim().HtmlEncode().Convert<DateTime>().AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }

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

                //日期文本框设置只读
                this.txtStartTime.Attributes.Add("ReadOnly", "true");
                this.txtEndTime.Attributes.Add("ReadOnly", "true");
                this.txtStartTime.Text = this.StartTime.Convert<DateTime>().ToString("yyyy-MM-dd");
                this.txtEndTime.Text = this.EndTime.Convert<DateTime>().ToString("yyyy-MM-dd");

               
            }


            //绑定数据
            this.BindData(this.StartTime, this.EndTime);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData(this.StartTime, this.EndTime);
        }

        protected void BindData(string startTime, string endTime)
        {
            UsersEntityEx userModel = base.GetUserModel();

            if (userModel == null)
            {
                this.artDialog("提示", "登录超时，请重新登录", "login.aspx");
                return;
            }


            string loanCategory = this.ddlLoanCategory.SelectedValue.HtmlEncode();

            string strWhere = string.Format(" T.UserId='{0}' and  T.CreateTime Between '{1}' and '{2}' ", userModel.UserId, startTime, endTime);

            if (!string.IsNullOrEmpty(loanCategory))
            {
                strWhere += string.Format(" and T.LoanCategory = {0}", loanCategory);
            }

            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserLoanEntityEx> sourceList = new UserLoanBLL().GetListByPage(strWhere, "", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserLoanBLL().GetRecordCount(strWhere);

            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();
        }

        public string GetStatusName(int status)
        {
            string result = string.Empty;

            switch (status)
            {
                case 0:
                    result = "<span style='color:#000000'>审核中</span>";
                    break;
                case 1:
                    result = "<span style='color:Green'>审核通过</span>";
                    break;
                case 2:
                    result = "<span style='color:#ff0000'>借款失败</span>";
                    break;
            }

            return result;
        }

        public string GetButtonByStatus(int status, int loanId)
        {
            if (status == 1)
            {
                return @"<a href='UserLoanList.aspx?loanid=" + loanId + "&action=repayment'>还款</a>";
            }
            else
            {
                return "";
            }
        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData(this.StartTime, this.EndTime);
        }
    }
}