using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using System.Text;
using System.Net;

namespace StudentLoan.Web
{
    public partial class Charge : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //获取用户信息
            UsersEntityEx userModel = base.GetUserModel();

            //获取充值渠道
            ChannelEntityEx channelModel = new ChannelBLL().GetList("").RandomExtractByWeight<ChannelEntityEx>(1).First();

            UserChargeEntityEx model = new UserChargeEntityEx()
            {
                Ext1 = channelModel.RequestUrl,
                Ext2 = channelModel.AppId,
                Ext3 = channelModel.AppKey,
                OrderNo = string.Format("{0}", DateTime.Now.ToString("yyyyMMddHHmmssffff")),
                UserId = userModel.UserId,
                ChargeMoney = this.order_amount.Text.Trim().Convert<decimal>(),
                ProductName = "学子易贷-用户充值",
                BankCode = this.bank_code.SelectedValue,
                Ext4 = this.product_name.Text,
                ChannelId = channelModel.ChannelId,
                CreateTime = DateTime.Now

            };

            UserChargeBLL bll = new UserChargeBLL();

            bll.Insert(model);


            if (channelModel.ChannelFlag.ToLower() == "dinpay")
            {
                string postString = string.Format("merchant_code={0}&order_amount={1}&bank_code={2}&key={3}&product_name={4}&order_no={5}&order_time={6}",
                                                    channelModel.AppId, this.order_amount.Text.Trim(), this.bank_code.SelectedValue, channelModel.AppKey, 
                                                    model.ProductName, model.OrderNo, model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));

                Response.Redirect(string.Format("http://{0}:8000/channel/dinpay.aspx?{1}", Request.Url.Authority, postString));
            }
            else if (channelModel.ChannelFlag.ToLower() == "alipay")
            {
                this.Alert("渠道未接入");
            }

        }
    }
}