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
    public partial class ProductSchemeList : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action = this.Request<string>("Action");
                int schemeId = this.Request<int>("SchemeId");

                if (action == "Delete" && schemeId > 0)
                {
                    bool result = new ProductSchemeBLL().Delete(new ProductSchemeEntityEx() { SchemeId = schemeId });

                    this.Alert(string.Format("删除{0}", result == true ? "成功" : "失败"), "ProductSchemeList.aspx");
                }

                this.BindData();
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


            string strWhere = "1 = 1";


            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(" and  StartTime >='{0}' ", startTime.Convert<DateTime>());
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(" and  EndTime <='{0}' ", endTime.Convert<DateTime>());
            }

            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<ProductSchemeEntityEx> sourceList = new ProductSchemeBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new ProductSchemeBLL().GetRecordCount(strWhere);

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

        protected void objRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal objLiteral = e.Item.FindControl("objLiteral") as Literal;

                ProductSchemeEntityEx model = e.Item.DataItem as ProductSchemeEntityEx;

                if (model.Status == 0)
                {
                    objLiteral.Text = "禁用";
                }
                else
                {
                    if (model.StartTime <= DateTime.Now && model.EndTime >= DateTime.Now)
                    {
                        objLiteral.Text = "正常";
                    }
                    else
                    {
                        objLiteral.Text = "已过期";
                    }
                }
            }
        }
    }
}