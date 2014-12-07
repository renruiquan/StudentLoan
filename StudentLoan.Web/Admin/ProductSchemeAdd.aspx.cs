using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System.Web.Services;

namespace StudentLoan.Web.Admin
{
    public partial class ProductSchemeAdd : AdminBasePage
    {
        /// <summary>
        /// 理财产品列表
        /// </summary>
        public List<ProductEntityEx> ProductList { get { return new ProductBLL().GetList(" ProductType = 2 and Status=1 "); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindProductList();
            }
        }

        private void BindProductList()
        {
            this.ddlProductId.DataSource = this.ProductList;
            this.ddlProductId.DataTextField = "ProductName";
            this.ddlProductId.DataValueField = "ProductId";
            this.ddlProductId.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AdminEntityEx adminModel = base.GetAdminInfo();
            ProductEntityEx productModel = new ProductBLL().GetModel(this.ddlProductId.SelectedValue.Convert<int>());

            if (adminModel == null)
            {
                this.Alert("登录超时，请重新登录", "login.aspx");
                return;
            }

            ProductSchemeEntityEx schemeModel = new ProductSchemeEntityEx()
            {
                SchemeName = txtSchemeName.Text.Trim(),
                InitiatorAdminId = adminModel.AdminId,
                ProductId = ddlProductId.SelectedValue.Convert<int>(),
                PlanType = ddlPlanType.SelectedValue.Convert<int>(),
                Amount = txtAmount.Text.Trim().Convert<decimal>(),
                Part = txtPart.Text.Trim().Convert<int>(),
                LimitPart = 0,
                MinDeadline = txtMinDeadline.Text.Trim().Convert<int>(),
                MaxDeadline = txtMaxDeadline.Text.Trim().Convert<int>(),
                NumberOfPeople = 0,//购买人数 
                StartTime = txtStartTime.Text.Trim().Convert<DateTime>(),
                EndTime = txtEndTime.Text.Trim().Convert<DateTime>(),
                SchemeDescription = txtSchemeDescription.Text.Trim(),
                Remark = txtRemark.Text.Trim(),
                CreateTime = DateTime.Now,
                Status = 1
            };


            schemeModel.Price = schemeModel.Amount / schemeModel.Part;

            if (this.txtMaxYield.Text != productModel.BaseAnnualFee.ToString())
            {
                schemeModel.MaxYield = this.txtMaxYield.Text.Convert<decimal>();//取理财产品中的费率，最小收益率没有用到
            }
            else
            {
                schemeModel.MaxYield = productModel.BaseAnnualFee;
            }

            bool result = new ProductSchemeBLL().Insert(schemeModel);

            this.Alert(string.Format("添加理财方案{0}", result == true ? "成功" : "失败"), "ProductSchemeList.aspx");
        }



        protected void ddlProductId_TextChanged(object sender, EventArgs e)
        {
            ListControl objControl = sender as ListControl;

            this.txtMaxYield.Text = this.ProductList.Where(s => s.ProductId == objControl.SelectedValue.Convert<decimal>()).First().BaseAnnualFee.ToString();

        }
    }
}