using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.BLL;
using StudentLoan.Model;

namespace StudentLoan.Web
{
    public partial class ManageMoneyNav : System.Web.UI.Page
    {
        public List<ProductEntityEx> ProductList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }
        }


        private void BindData()
        {
            string strWhere = @" 1=1 and Status = 1 and ProductType=2";

            this.objReapter.DataSource = new ProductBLL().GetList(strWhere);
            this.objReapter.DataBind();
        }

        public string SetClass(int productId)
        {
            string result = string.Empty;

            //理财产品ID

            switch (productId)
            {
                case 4:
                    result = "less-to-multi";
                    break;
                case 5:
                    result = "money-drawing";
                    break;
                case 6:
                    result = "top-full";
                    break;
            }

            return result;
        }
    }
}