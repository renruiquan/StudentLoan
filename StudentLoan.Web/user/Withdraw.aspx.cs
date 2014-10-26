using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Common;

namespace StudentLoan.Web.user
{
    public partial class Withdraw : BasePage
    {
        public UsersEntityEx UserModel { get { return base.GetUserModel(); } }

        public UserBankEntityEx BankModel { get { return new UserBankBLL().GetModel(this.UserModel.UserId); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式



                Control objControl = Master.FindControl("Charge");

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion


                this.BindData();

                this.BindBankList();
            }
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

        private void BindData()
        {
            if (!string.IsNullOrEmpty(this.UserModel.TrueName))
            {
                this.TrueName.Text = this.UserModel.TrueName;
                this.TrueName.Enabled = false;
            }


            if (this.BankModel != null)
            {
                this.txtCardNo.Text = this.BankModel.BankCardNo;
                this.hidBankId.Value = this.BankModel.BankId.ToString();
                this.ddlBankTypeList.SelectedValue = this.BankModel.BankId.ToString();
            }
        }

        protected void btnWithdraw_ServerClick(object sender, EventArgs e)
        {
            DrawMoneyEntityEx model = new DrawMoneyEntityEx()
            {
                UserId = this.UserModel.UserId,
                BindBankId = this.hidBankId.Value.Convert<int>(),
                DrawMoney = this.WithdrawMoney.Text.Trim().Convert<decimal>(),
                Fee = 0,
                LockMoney = this.WithdrawMoney.Text.Trim().Convert<decimal>(),
                ApplyTime = DateTime.Now,
                Status = 0
            };

            bool result = new DrawMoneyBLL().Insert(model);

            this.artDialog("提示", string.Format("提现申请{0}", result == true ? "成功" : "失败"), "Withdraw.aspx");
        }
    }
}