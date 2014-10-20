using StudentLoan.BLL;
using StudentLoan.Model;
using StudentLoan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web.user
{
    public partial class UserLoanApply : BasePage
    {

        private int ProductId { get { return this.Request<int>("productId", 1); } }

        private ProductEntityEx ProductModel { get { return new ProductBLL().GetModel(this.ProductId); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindDropDownList();
            }
        }

        /// <summary>
        /// 绑定借款金额
        /// </summary>
        private void BindDropDownList()
        {
            if (this.ProductId == 0)
            {
                this.artDialog("提示", "参数不正确", "/LoanList.aspx");
                return;
            }

            ProductEntityEx productModel = new ProductBLL().GetModel(this.ProductId);

            this.ddlLoanMoney.Items.Clear();
            this.ddlTotalAmortization.Items.Clear();

            if (this.ProductId == 1)
            {
                //一般贷款

                this.ddlLoanMoney.Items.Add(new ListItem("1000元", "1000"));
                this.ddlLoanMoney.Items.Add(new ListItem("2000元", "2000"));
                this.ddlLoanMoney.Items.Add(new ListItem("3000元", "3000"));
                this.ddlLoanMoney.Items.Add(new ListItem("4000元", "4000"));
                this.ddlLoanMoney.Items.Add(new ListItem("5000元", "5000"));

                this.ddlTotalAmortization.Items.Add(new ListItem("1个月", "1"));
                this.ddlTotalAmortization.Items.Add(new ListItem("2个月", "2"));
                this.ddlTotalAmortization.Items.Add(new ListItem("3个月", "3"));
                this.ddlTotalAmortization.Items.Add(new ListItem("4个月", "4"));
            }
            else if (this.ProductId == 2)
            {
                //高额贷款

                this.ddlLoanMoney.Items.Add(new ListItem("6000元", "6000"));
                this.ddlLoanMoney.Items.Add(new ListItem("7000元", "7000"));
                this.ddlLoanMoney.Items.Add(new ListItem("8000元", "8000"));
                this.ddlLoanMoney.Items.Add(new ListItem("9000元", "9000"));
                this.ddlLoanMoney.Items.Add(new ListItem("10000元", "10000"));

                this.ddlTotalAmortization.Items.Add(new ListItem("1个月", "1"));
                this.ddlTotalAmortization.Items.Add(new ListItem("2个月", "2"));
                this.ddlTotalAmortization.Items.Add(new ListItem("3个月", "3"));
                this.ddlTotalAmortization.Items.Add(new ListItem("4个月", "4"));
                this.ddlTotalAmortization.Items.Add(new ListItem("5个月", "5"));
            }
            else if (this.ProductId == 3)
            {
                //随时贷款

                this.ddlLoanMoney.Items.Add(new ListItem("1000元", "1000"));
                this.ddlLoanMoney.Items.Add(new ListItem("2000元", "2000"));
                this.ddlLoanMoney.Items.Add(new ListItem("3000元", "3000"));
                this.ddlLoanMoney.Items.Add(new ListItem("4000元", "4000"));
                this.ddlLoanMoney.Items.Add(new ListItem("5000元", "5000"));
                this.ddlLoanMoney.Items.Add(new ListItem("6000元", "6000"));
                this.ddlLoanMoney.Items.Add(new ListItem("7000元", "7000"));
                this.ddlLoanMoney.Items.Add(new ListItem("8000元", "8000"));
                this.ddlLoanMoney.Items.Add(new ListItem("9000元", "9000"));
                this.ddlLoanMoney.Items.Add(new ListItem("10000元", "10000"));

                this.ddlTotalAmortization.Visible = false;
                this.txtTotalAmortization.Visible = true;
            }
        }

        protected void btnApply_ServerClick(object sender, EventArgs e)
        {
            UsersEntityEx userModel = userModel = base.GetUserModel();

            if (userModel == null)
            {
                this.artDialog("提示", "登录超时，请重新登录", "/login.aspx");
                return;
            }

            decimal shouldRepayMoney = 0;
            int loanTypeId = this.ddlLoanTypeId.SelectedValue.Convert<int>(this.ProductId);
            string loanTitle = this.txtLoanTitle.Text.Trim().HtmlEncode();
            decimal loanMoney = Math.Abs(this.ddlLoanMoney.SelectedValue.Convert<decimal>(0));
            int loanCategory = this.ddlLoanCategory.SelectedValue.Convert<int>(1);
            string loanDescription = this.txtLoanDescription.Text.Trim().HtmlEncode();
            int totalAmortization = 0;

            if (this.ProductId == 3)
            {
                totalAmortization = this.txtTotalAmortization.Text.Trim().Convert<int>(1);
            }
            else
            {
                totalAmortization = this.ddlTotalAmortization.SelectedValue.Convert<int>(1);
            }


            if (string.IsNullOrEmpty(loanTitle))
            {
                this.artDialog("贷款标题不能为空");
                return;
            }
            if (loanMoney < ProductModel.ProductMinMoney || loanMoney > ProductModel.ProductMaxMoney)
            {
                this.artDialog("贷款金额不正确");
                return;
            }

            //计算应用金额
            shouldRepayMoney = loanMoney * ProductModel.BaseAnnualFee * totalAmortization + loanMoney;


            UserLoanEntityEx userLoanModel = new UserLoanEntityEx();

            userLoanModel.LoanNo = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            userLoanModel.UserId = userModel.UserId;
            userLoanModel.ProductId = ProductModel.ProductId;
            userLoanModel.LoanTitle = loanTitle;
            userLoanModel.LoanMoney = loanMoney;
            userLoanModel.LoanTypeId = loanTypeId;
            userLoanModel.LoanCategory = loanCategory;
            userLoanModel.ShouldRepayMoney = shouldRepayMoney;
            userLoanModel.TotalAmortization = totalAmortization;
            userLoanModel.LoanDescription = loanDescription;
            userLoanModel.AnnualFee = ProductModel.BaseAnnualFee;
            UserLoanBLL bll = new UserLoanBLL();

            bool result = bll.Insert(userLoanModel);


            this.artDialog("提示", string.Format("提交申请{0}", result == true ? "成功，请等待管理员审核！" : "失败"), "UserLoanList.aspx");
        }
    }
}