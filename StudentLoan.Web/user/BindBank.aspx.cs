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
    public partial class BindBank : BasePage
    {
        public UsersEntityEx UserModel { get { return base.GetUserModel(); } }

        public UserBankEntityEx BankModel { get; set; }

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

                this.BankModel = new UserBankBLL().GetModel(this.UserModel.UserId);

                this.BindBankList();

                this.BindData();
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string bankName = this.txtBankName.Text.Trim();
            int bankId = this.ddlBankTypeList.SelectedValue.Convert<int>();
            string bankCard = this.txtBankCard.Text.Trim();
            string province = this.Request<string>("ddlProvince");
            string city = this.Request<string>("ddlCity");

            UsersEntityEx userModel = base.GetUserModel();
            userModel = new UsersEntityEx()
            {
                
                UserId = userModel.UserId
            };

            this.BankModel = new UserBankBLL().GetModel(this.UserModel.UserId);

            if (this.BankModel == null)
            {
                this.BankModel = new UserBankEntityEx()
                {
                    UserId = userModel.UserId,
                    BankName = bankName,
                    BankCardNo = bankCard,
                    BankProvince = province,
                    BankCity = city,
                    BankId = bankId,
                    IsDefault = true
                };

                bool result = new UserBankBLL().Insert(this.BankModel, userModel);

                this.artDialog(string.Format("添加{0}", result == true ? "成功" : "失败"));
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            
        }

        /// <summary>
        /// 绑定银行列表
        /// </summary>
        public void BindBankList()
        {
            this.ddlBankTypeList.DataSource = new BaseBankBLL().GetList(" Status =1 ");
            this.ddlBankTypeList.DataTextField = "BankName";
            this.ddlBankTypeList.DataValueField = "BankId";
            this.ddlBankTypeList.DataBind();
        }
    }
}