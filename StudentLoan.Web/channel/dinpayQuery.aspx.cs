using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Model;
using StudentLoan.Common;
using System.Text;
using System.Net;

namespace StudentLoan.Web.channel
{
    public partial class dinpayQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_query_Click(object sender, EventArgs e)
        {
            ChannelEntityEx channelModel = new BLL.ChannelBLL().GetModel(1);

            string key = "123456789a123456789_";

            if (channelModel != null)
            {
                key = channelModel.AppKey;
            }

            string service_type = "single_trade_query";
            string merchant_code = "1111110166";
            string interface_version = "V3.0";
            string sign_type = "MD5";
            string order_no = this.order_no.Text.Trim();

            string sign = string.Empty;

            StringBuilder objSB = new StringBuilder();

            objSB.AppendFormat("interface_version={0}&", interface_version);
            objSB.AppendFormat("merchant_code={0}&", merchant_code);
            objSB.AppendFormat("order_no={0}&", order_no);
            objSB.AppendFormat("service_type={0}", service_type);
            sign = string.Format("{0}&key={1}", objSB.ToString(), channelModel.AppKey).MD5();

            objSB.AppendFormat("&sign_type={0}&", sign_type);
            objSB.AppendFormat("sign={0}", sign);

            string result = WebExtension.Post("https://query.dinpay.com/query", objSB.ToString(), "application/x-www-form-urlencoded");

            Literal1.Text = result;
        }
    }
}