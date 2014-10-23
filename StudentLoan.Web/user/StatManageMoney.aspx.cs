using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;

namespace StudentLoan.Web.user
{
    public partial class StatManageMoney : BasePage
    {
        /// <summary>
        /// 统计理财数据
        /// </summary>
        public UserManageMoneyEntityEx StatUserManageMoney { get; set; }

        /// <summary>
        /// 总待收利息
        /// </summary>
        public decimal WaitTotalInterest { get; set; }

        /// <summary>
        /// 进行中的理财总笔数
        /// </summary>
        public decimal WaitTotalCount { get; set; }

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

                UserManageMoneyBLL bll = new UserManageMoneyBLL();
                UsersEntityEx model = base.GetUserModel();

                this.StatUserManageMoney = bll.GetStatUserManageMoney(model.UserId);
                this.WaitTotalInterest = bll.WaitTotalInterest(model.UserId);
                this.WaitTotalCount = bll.WaitTotalCount(model.UserId);

            }
        }
    }
}