using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Model;
using StudentLoan.Common;
using StudentLoan.API;
using StudentLoan.Common.Logging;

namespace StudentLoan.Web.user
{
    public partial class UserManageMoney : BasePage
    {
        #region 公共属性


        public int ProductId
        {
            get
            {
                return this.Request<int>("productId", 0, false);
            }
        }

        public int SchemeId
        {
            get
            {
                return this.Request<int>("SchemeId", 0, false);
            }
        }

        public ProductSchemeEntityEx SchemeModel
        {
            get
            {
                return new ProductSchemeBLL().GetModel(this.SchemeId);
            }
        }

        public UsersEntityEx UserModel
        {
            get
            {
                return new UsersBLL().GetModel(base.GetUserModel().UserId);
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if ((this.ProductId < 4) && (this.ProductId > 6))
                {
                    this.artDialog("错误", "参数不正确", "/ManageMoneyNav.aspx", true);
                }
                else if (this.SchemeId == 0)
                {
                    this.artDialog("错误", "参数不正确", "/ManageMoneyNav.aspx", true);
                }
                else
                {
                    this.BindPeriodList();
                }
            }
        }

        private void BindPeriodList()
        {
            this.ValidateBaseCert();


            ProductEntityEx productModel = new ProductBLL().GetModel(this.ProductId);

            this.lblMsg.Text = string.Format("(至少购买{0}元)", productModel.ProductMinMoney);

            if (this.ProductId == 4)
            {
                this.ddlPeriod.Items.Add(new ListItem("1个月", "1"));
                this.ddlPeriod.Items.Add(new ListItem("2个月", "2"));
                this.ddlPeriod.Items.Add(new ListItem("3个月", "3"));


            }
            else if (this.ProductId == 5)
            {
                this.ddlPeriod.Items.Add(new ListItem("4个月", "4"));
                this.ddlPeriod.Items.Add(new ListItem("5个月", "5"));
                this.ddlPeriod.Items.Add(new ListItem("6个月", "6"));
            }
            else if (this.ProductId == 6)
            {
                this.ddlPeriod.Items.Add(new ListItem("7个月", "7"));
                this.ddlPeriod.Items.Add(new ListItem("8个月", "8"));
                this.ddlPeriod.Items.Add(new ListItem("9个月", "9"));
                this.ddlPeriod.Items.Add(new ListItem("10个月", "10"));
                this.ddlPeriod.Items.Add(new ListItem("11个月", "11"));
                this.ddlPeriod.Items.Add(new ListItem("12个月", "12"));

            }
        }

        protected void btnConfirmBuy_ServerClick(object sender, EventArgs e)
        {
            decimal purchaseMoney = this.PurchaseMoney.Text.Trim().Convert<decimal>();

            ProductEntityEx productModel = new ProductBLL().GetModel(this.ProductId);

            if (purchaseMoney < productModel.ProductMinMoney)
            {
                this.artDialog("错误", string.Format("至小购买金额为{0}元", productModel.ProductMinMoney));
                return;
            }

            UsersEntityEx userModel = base.GetUserModel();
            UserManageMoneyEntityEx model = new UserManageMoneyEntityEx
            {
                UserId = userModel.UserId,
                ProductId = this.ProductId,
                ProductSchemeId = this.SchemeId,
                Period = this.ddlPeriod.SelectedValue.Convert<int>(0),
                Count = 1,
                Amount = purchaseMoney,
                CreateTime = DateTime.Now,
                Status = 0
            };
            int buyId = new UserManageMoneyBLL().Insert(model);
            if (buyId > 0)
            {
                userModel = new UsersBLL().GetModel(model.UserId);
                if (userModel.Amount >= Math.Abs(model.Amount))
                {
                    model = new UserManageMoneyEntityEx
                    {
                        BuyId = buyId,
                        UserId = userModel.UserId,
                        Amount = Math.Abs(model.Amount),
                        PayTime = DateTime.Now,
                        EndTime = DateTime.Now.AddMonths(model.Period),
                        Status = 1
                    };
                    if (new UserManageMoneyBLL().Update(model))
                    {
                        LogHelper.Default.Info("短信内容：" + Message.Send(userModel.Telphone, string.Format("亲，你购买了理财产品{0},共消费了{1}元。【学子易贷】", this.SchemeModel.SchemeName, model.Amount)));
                        this.artDialog("提示", "购买成功,详情请进入个人中心-理财记录查看", "ManageMoneyList.aspx", true);
                    }
                    else
                    {
                        this.artDialog("错误", "亲，对不起，由于系统原因，扣费成功，但购买失败，请联系在线客服！给您带来困扰，请谅解！", true);
                    }
                }
                else
                {
                    this.artDialog("提示", "对不起，你的余额不足，请先充值！", "Charge.aspx", true);
                }
            }
        }

        /// <summary>
        /// 校验基本认证信息
        /// </summary>
        protected void ValidateBaseCert()
        {
            UsersEntityEx model = base.GetUserModel();

            #region 校验用户基本信息

            if (model != null)
            {
                if (string.IsNullOrEmpty(model.TrueName))
                {
                    this.artDialog("提示", "对不起，您还没有填写真实姓名，请完善后重试！", "/user/UserAccountCert_2.aspx");
                    return;
                }
                if (string.IsNullOrEmpty(model.IdentityCard))
                {
                    this.artDialog("提示", "对不起，您还没有填写身份证号码，请完善后重试！", "/user/UserAccountCert_2.aspx");
                    return;
                }
                if (string.IsNullOrEmpty(model.Mobile))
                {
                    this.artDialog("提示", "对不起，您还没有绑定手机号码，请完善后重试！", "/user/BindMobile.aspx");
                    return;
                }
                if (string.IsNullOrEmpty(model.Birthday.ToString()) || model.Birthday == default(DateTime))
                {
                    this.artDialog("提示", "对不起，您还没有填写出生日期，请完善后重试！", "/user/UserAccountCert_2.aspx");
                    return;
                }
                if ((DateTime.Now - model.Birthday).Days < 365 * 18)
                {
                    this.artDialog("提示", "对不起，您还没满18周岁，无法申请借款！", "/user/UserAccount.aspx");
                    return;
                }
            }
            else
            {
                this.artDialog("提示", "用户不存在，无法完成校验,请重新登录后重试！", "/login.aspx");
                Session[StudentLoanKeys.SESSION_USER_INFO] = null;
                this.WriteCookie("UserName", "StudentLoan", -14400);
                this.WriteCookie("UserPwd", "StudentLoan", -14400);
                Response.Redirect("/login.aspx");
                return;
            }

            #endregion
        }
    }
}