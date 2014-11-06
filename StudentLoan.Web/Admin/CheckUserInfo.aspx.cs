using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using System.Text;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace StudentLoan.Web.Admin
{
    public partial class CheckUserInfo : AdminBasePage
    {
        public int LoanId { get { return this.Request<int>("loanid"); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.LoanId > 0)
                {
                    this.BindData();
                }
                else
                {
                    this.Alert("参数不正确", "UserLoanApplyList.aspx");
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

            string strWhere = " 1=1 ";



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

        protected void btnPass_ServerClick(object sender, EventArgs e)
        {
            AdminEntityEx adminModel = Session[StudentLoanKeys.SESSION_ADMIN_INFO] as AdminEntityEx;

            UserLoanEntityEx userLoanModel = new UserLoanBLL().GetModel(this.LoanId);

            bool result = new UserLoanBLL().UpdateByAdmin(new UserLoanEntityEx()
              {
                  LoanId = this.LoanId,
                  Status = 1,
                  AdminId = adminModel.AdminId,
                  LoanMoney = userLoanModel.LoanMoney,
                  UserId = userLoanModel.UserId,
                  TotalAmortization = userLoanModel.TotalAmortization,
                  AnnualFee = userLoanModel.AnnualFee,
                  ProductId = userLoanModel.ProductId
              });

            //发短消息
            new UserMessageBLL().Insert(new UserMessageEntityEx()
            {
                PostUserName = "系统",
                Title = "材料通过",
                Content = "恭喜，您申请的借款通过审核。",
                Type = 0,
                AcceptUserName = new UsersBLL().GetModel(userLoanModel.UserId).UserName
            });

            this.Alert(string.Format("操作{0}", result == true ? "成功" : "失败"), "UserLoanApplyList.aspx");
        }

        protected void btnRefuse_ServerClick(object sender, EventArgs e)
        {
            AdminEntityEx adminModel = Session[StudentLoanKeys.SESSION_ADMIN_INFO] as AdminEntityEx;

            UserLoanEntityEx userLoanModel = new UserLoanBLL().GetModel(this.LoanId);

            if (string.IsNullOrEmpty(this.txtRefuse.Text.Trim()))
            {
                this.Alert("请填写驳回原因！");
                return;
            }
            bool result = new UserLoanBLL().UpdateByAdmin(new UserLoanEntityEx()
             {
                 LoanId = this.LoanId,
                 Status = 2,
                 AdminId = adminModel.AdminId,
                 LoanMoney = 0,
                 UserId = userLoanModel.UserId,
                 TotalAmortization = userLoanModel.TotalAmortization,
                 AnnualFee = userLoanModel.AnnualFee,
                 ProductId = userLoanModel.ProductId
             });

            //发短消息
            new UserMessageBLL().Insert(new UserMessageEntityEx()
            {
                PostUserName = "系统",
                Title = "材料驳回",
                Content = this.txtRefuse.Text.Trim(),
                Type = 0,
                AcceptUserName = new UsersBLL().GetModel(userLoanModel.UserId).UserName
            });

            this.Alert(string.Format("操作{0}", result == true ? "成功" : "失败"), "UserLoanApplyList.aspx");
        }
    }
}