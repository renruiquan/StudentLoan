using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using System.Text;

namespace StudentLoan.Web.Admin
{
    public partial class UserLoanApplyList : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtStartTime.Attributes.Add("ReadOnly", "true");
                this.txtEndTime.Attributes.Add("ReadOnly", "true");

                if (!IsPostBack)
                {
                    string action = this.Request<string>("action");

                    int loanId = this.Request<int>("loanid", 0);

                    if (loanId > 0)
                    {
                        bool result = false;

                        AdminEntityEx adminModel = Session[StudentLoanKeys.SESSION_ADMIN_INFO] as AdminEntityEx;

                        UserLoanEntityEx userLoanModel = new UserLoanBLL().GetModel(loanId);

                        switch (action)
                        {
                            case "pass":
                                result = new UserLoanBLL().UpdateByAdmin(new UserLoanEntityEx()
                                {
                                    LoanId = loanId,
                                    Status = 1,
                                    AdminId = adminModel.AdminId,
                                    LoanMoney = userLoanModel.LoanMoney,
                                    UserId = userLoanModel.UserId,
                                    TotalAmortization = userLoanModel.TotalAmortization,
                                    AnnualFee = userLoanModel.AnnualFee,
                                    ProductId = userLoanModel.ProductId
                                });
                                break;
                            case "refuse":
                                result = new UserLoanBLL().UpdateByAdmin(new UserLoanEntityEx()
                                {
                                    LoanId = loanId,
                                    Status = 2,
                                    AdminId = adminModel.AdminId,
                                    LoanMoney = 0,
                                    UserId = userLoanModel.UserId,
                                    TotalAmortization = userLoanModel.TotalAmortization,
                                    AnnualFee = userLoanModel.AnnualFee,
                                    ProductId = userLoanModel.ProductId
                                });
                                break;
                        }

                        this.Alert(string.Format("操作:{0}", result == true ? "成功" : "失败"), "UserLoanApplyList.aspx");


                    }

                    this.BindData();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {

            string startTime = txtStartTime.Text.Trim().HtmlEncode();
            string endTime = txtEndTime.Text.Trim().HtmlEncode();
            string loanCategory = this.ddlLoanCategory.SelectedValue.HtmlEncode();
            string queryContent = this.txtQueryContent.Text.Trim().HtmlEncode();

            string strWhere = "1 = 1";

            if (!string.IsNullOrEmpty(loanCategory))
            {
                strWhere += string.Format(" and  LoanCategory = {0}", loanCategory);
            }

            if (!string.IsNullOrEmpty(this.ddlStatus.SelectedValue))
            {
                strWhere += string.Format(" and T.Status ={0} ", this.ddlStatus.SelectedValue);
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(" and T.CreateTime >='{0}'", startTime.Convert<DateTime>());
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(" and T.CreateTime <='{0}'", endTime.Convert<DateTime>());
            }
            if (!string.IsNullOrEmpty(queryContent))
            {
                int userId = new UsersBLL().GetUserId(queryContent);

                if (this.ddlQueryType.SelectedValue == "1")
                {
                    strWhere += string.Format(" and T.UserId = '{0}'", userId);
                }
                else if (this.ddlQueryType.SelectedValue == "2")
                {
                    strWhere += string.Format(" and T.LoanNo = '{0}' ", queryContent);
                }
            }



            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserLoanEntityEx> sourceList = new UserLoanBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserLoanBLL().GetRecordCount(strWhere);

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            if (endIndex > this.objAspNetPager.RecordCount)
            {
                this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            }


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="loanCategory"></param>
        /// <returns></returns>
        public string GetLoanCategoryName(int loanCategory)
        {
            string result = string.Empty;

            switch (loanCategory)
            {
                case 1:
                    result = "因为爱情（恋爱贷款）";
                    break;
                case 2:
                    result = "游山玩水（旅游贷款）";
                    break;
                case 3:
                    result = "时尚达人（购物贷款）";
                    break;
                case 4:
                    result = "追求自我（娱乐贷款）";
                    break;
                case 5:
                    result = "急人所急（应急贷款）";
                    break;
            }

            return result;
        }

        /// <summary>
        /// 获取状态名称
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string GetStatusName(int status)
        {
            string result = string.Empty;

            switch (status)
            {
                case 0:
                    result = "<span>审核中</span>";
                    break;
                case 1:
                    result = "<span style='color:Green'>已放款</span>";
                    break;
                case 2:
                    result = "<span style='color:#ff0000'>已拒绝</span>";
                    break;
            }

            return result;
        }

        /// <summary>
        /// 获取管理员名称
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public string GetAdminName(int adminId)
        {
            string result = string.Empty;

            if (adminId == 0)
            {
                return string.Empty;
            }

            Dictionary<int, string> adminDictionary = new AdminBLL().GetAdminDictionary(" isLock = 1");

            return adminDictionary[adminId];
        }

        protected void objRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                UserLoanEntityEx model = e.Item.DataItem as UserLoanEntityEx;
                Literal objLiteral = e.Item.FindControl("objLiteral") as Literal;

                StringBuilder objSB = new StringBuilder();
                objSB.AppendFormat("<a href=\"UserLoanApplyList.aspx?action=check&loanid={0}\">审核资料</a> |", model.LoanId);

                if (model.Status == 0)
                {
                    objSB.AppendFormat(" <a href=\"UserLoanApplyList.aspx?action=pass&loanid={0}\">放款</a> |", model.LoanId);
                    objSB.AppendFormat(" <a href=\"UserLoanApplyList.aspx?action=refuse&loanid={0}\">拒绝</a> ", model.LoanId);

                    objLiteral.Text = objSB.ToString().TrimEnd('|');
                }
                if (model.Status == 1)
                {
                    objLiteral.Text = objSB.ToString().TrimEnd('|');
                }

                if (model.Status == 2)
                {
                    objSB.AppendFormat(" <a href=\"UserLoanApplyList.aspx?action=pass&loanid={0}\">放款</a>", model.LoanId);
                    objLiteral.Text = objSB.ToString().TrimEnd('|');
                }
            }
        }
    }
}