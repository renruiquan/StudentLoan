using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.Common.Logging;
using StudentLoan.BLL;
using StudentLoan.Model;
using StudentLoan.API;


namespace StudentLoan.Web.user
{
    public partial class UserManageMoneyBuy : BasePage
    {
        public int ProductId { get { return this.Request<int>("ProductId"); } }

        public int ProductSchemeId { get { return this.Request<int>("ProductSchemeId"); } }

        //        public int BuyPart { get { return this.Request<int>("part"); } }

        /// <summary>
        /// 金买金额
        /// </summary>
        public int purchaseMoney { get { return this.Request<int>("purchaseMoney"); } }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ProductId == 0 || this.ProductSchemeId == 0)
            {
                this.Alert("参数不正确", "ProductSchemeList.aspx");
                return;
            }

            //int part = this.BuyPart;

            //if (part == 0)
            //{
            //    this.Alert("最少购买一份", "ProductSchemeList.aspx");
            //    return;
            //}

            ProductSchemeEntityEx schemeModel = new ProductSchemeBLL().GetModel(this.ProductSchemeId);
            UsersEntityEx userModel = base.GetUserModel();
            UserManageMoneyEntityEx model = new UserManageMoneyEntityEx()
            {
                UserId = userModel.UserId,
                ProductId = this.ProductId,
                ProductSchemeId = this.ProductSchemeId,
                // Count = part,
                // Amount = schemeModel.Price * part,
                Count = 1,
                Amount = this.purchaseMoney,
                CreateTime = DateTime.Now,
                Status = 0
            };

            int buyId = new UserManageMoneyBLL().Insert(model);

            if (buyId > 0)
            {
                //下单成功，准备支付

                userModel = new UsersBLL().GetModel(model.UserId);

                if (userModel.Amount >= Math.Abs(model.Amount))
                {
                    //扣费操作
                    bool result = new UsersBLL().UpdateAmount(new UsersEntityEx() { Amount = -model.Amount, UserId = userModel.UserId });

                    if (result)
                    {
                        //扣费成功后更新订单状态 
                        result = new UserManageMoneyBLL().Update(new UserManageMoneyEntityEx() { BuyId = buyId, PayTime = DateTime.Now, EndTime = DateTime.Now.AddMonths(schemeModel.Deadline), Status = 1 });

                        if (result)
                        {
                            string code = new Message().Send(userModel.Telphone, string.Format("亲，你购买了理财产品{0},共消费了{1}元。【学子易贷】", schemeModel.SchemeName, model.Amount));
                            LogHelper.Default.Info("短信内容：" + code);

                            this.Alert("购买成功", "UserManageMoneyList.aspx");
                        }
                        else
                        {
                            this.Alert("亲，对不起，由于系统原因，扣费成功，但购买失败，请联系在线客服！给您带来困扰，请谅解！");
                        }

                    }
                }
                else
                {
                    this.Alert("对不起，你的余额不足，请先充值！", "Charge.aspx");
                }
            }
        }
    }
}