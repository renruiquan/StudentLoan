using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;

namespace StudentLoan.Web
{
    public partial class ProductSchemeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            int productId = this.Request<int>("ProductId");

            if (productId == 0)
            {
                this.artDialog("借误", "参数不正确", "/ManageMoneyNav.aspx");
                return;
            }

            string strWhere = string.Format("1 = 1 and T.ProductId={0} and StartTime <=getdate() and EndTime >=getdate() ", productId);

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

        public string GetStatusName(int target)
        {
            string result = "未知";

            switch (target)
            {
                default: break;
                case 0: result = "禁用"; break;
                case 1: result = "进行中"; break;
                case 2: result = "已过期"; break;
            }

            return result;
        }

        protected void objRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                ProductSchemeEntityEx model = e.Item.DataItem as ProductSchemeEntityEx;

                if (model.StartTime <= DateTime.Now && model.EndTime >= DateTime.Now)
                {
                    Literal objLiteral = e.Item.FindControl("objLiteral") as Literal;

                    objLiteral.Text = string.Format("<buttaon class=\"btn btn-danger\" type=\"button\" onclick=\"return window.location.href='/user/UserManageMoney.aspx?productId={0}&SchemeId={1}';\">购买</buttaon>", model.ProductId, model.SchemeId);
                }
            }
        }
    }
}