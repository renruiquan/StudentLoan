using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Common;

namespace StudentLoan.Web.user
{
    public partial class Charge : BasePage
    {
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
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
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
                ChargeMoney = this.Amount.Text.Trim().Convert<decimal>(),
                ProductName = "学子易贷-用户充值",
                BankCode = this.Request<string>("bank"),
                Ext4 = "",
                ChannelId = channelModel.ChannelId,
                CreateTime = DateTime.Now,
                Ext5 = this.Request<string>("bank")

            };

            UserChargeBLL bll = new UserChargeBLL();

            bll.Insert(model);


            if (channelModel.ChannelFlag.ToLower() == "dinpay")
            {
                string postString = string.Format("merchant_code={0}&order_amount={1}&bank_code={2}&key={3}&product_name={4}&order_no={5}&order_time={6}",
                                                    channelModel.AppId, this.Amount.Text.Trim(), this.Request<string>("bank"), channelModel.AppKey,
                                                    model.ProductName, model.OrderNo, model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));

                Response.Redirect(string.Format("http://{0}/channel/dinpay.aspx?{1}", Request.Url.Authority, postString));
            }
            else if (channelModel.ChannelFlag.ToLower() == "alipay")
            {
                this.Alert("渠道未接入");
            }

        }
    }
}