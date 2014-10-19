﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.Model;
using StudentLoan.BLL;

namespace StudentLoan.Web.Admin
{
    public partial class ProductSchemeEdit : AdminBasePage
    {
        public int SchemeID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindProductList();
                this.BindData();
            }
        }

        private void BindProductList()
        {

            List<ProductEntityEx> productList = new ProductBLL().GetList(" ProductType = 2 and Status=1 ");
            this.ddlProductId.DataSource = productList;
            this.ddlProductId.DataTextField = "ProductName";
            this.ddlProductId.DataValueField = "ProductId";
            this.ddlProductId.DataBind();
        }


        public void BindData()
        {
            this.SchemeID = this.Request<int>("schemeId");

            if (this.SchemeID == 0)
            {
                this.Alert("参数不正确", "ProductSchemeList.aspx");
                return;
            }

            ProductSchemeEntityEx model = new ProductSchemeBLL().GetModel(this.SchemeID);

            if (model != null)
            {
                this.txtSchemeName.Text = model.SchemeName;
                this.ddlProductId.SelectedValue = model.ProductId.ToString();
                this.txtAmount.Text = model.Amount.ToString();
                this.txtPrice.Text = model.Price.ToString();
                this.txtPart.Text = model.Part.ToString();
                this.txtLimitPart.Text = model.LimitPart.ToString();
                this.txtDeadline.Text = model.Deadline.ToString();
                this.txtStartTime.Text = model.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.txtEndTime.Text = model.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
                this.txtSchemeDescription.Text = model.SchemeDescription;
                this.txtRemark.Text = model.Remark;
            }
            else
            {
                this.Alert("没有找到该记录", "ProductSchemeList.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductSchemeEntityEx model = new ProductSchemeEntityEx()
            {
                SchemeId = this.Request<int>("schemeId"),
                SchemeName = this.txtSchemeName.Text.Trim(),
                ProductId = this.ddlProductId.SelectedValue.Convert<int>(),
                PlanType = this.ddlPlanType.SelectedValue.Convert<int>(),
                Amount = this.txtAmount.Text.Trim().Convert<decimal>(),
                Price = this.txtPrice.Text.Trim().Convert<decimal>(),
                Part = this.txtPart.Text.Trim().Convert<int>(),
                LimitPart = this.txtLimitPart.Text.Trim().Convert<int>(),
                Deadline = this.txtDeadline.Text.Trim().Convert<int>(),
                StartTime = this.txtStartTime.Text.Trim().Convert<DateTime>(),
                EndTime = this.txtEndTime.Text.Trim().Convert<DateTime>(),
                SchemeDescription = this.txtSchemeDescription.Text.Trim(),
                Remark = this.txtRemark.Text.Trim()
            };

            bool result = new ProductSchemeBLL().Update(model);

            this.Alert(string.Format("修改{0}", result == true ? "成功" : "失败"), "ProductSchemeList.aspx");

        }
    }
}