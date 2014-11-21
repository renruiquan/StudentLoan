using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using System.Text;

namespace StudentLoan.Web.callback
{
    public partial class ReturnUrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取智付反馈信息
            //商户号
            string merchant_code = this.Request<string>("merchant_code");

            //通知类型
            string notify_type = this.Request<string>("notify_type");

            //通知校验ID
            string notify_id = this.Request<string>("notify_id");

            //接口版本
            string interface_version = this.Request<string>("interface_version");

            //签名方式
            string sign_type = this.Request<string>("sign_type");

            //签名
            string dinpaySign = this.Request<string>("sign");

            //商家订单号
            string order_no = this.Request<string>("order_no");

            //商家订单时间
            string order_time = this.Request<string>("order_time");

            //商家订单金额
            string order_amount = this.Request<string>("order_amount");

            //回传参数
            string extra_return_param = this.Request<string>("extra_return_param");

            //智付交易定单号
            string trade_no = this.Request<string>("trade_no");

            //智付交易时间
            string trade_time = this.Request<string>("trade_time");

            //交易状态 SUCCESS 成功  FAILED 失败
            string trade_status = this.Request<string>("trade_status");

            //银行交易流水号
            string bank_seq_no = this.Request<string>("bank_seq_no");

            /**
             *签名顺序按照参数名a到z的顺序排序，若遇到相同首字母，则看第二个字母，以此类推，
            *同时将商家支付密钥key放在最后参与签名，组成规则如下：
            *参数名1=参数值1&参数名2=参数值2&……&参数名n=参数值n&key=key值
            **/


            //组织订单信息
            string signStr = "";

            if (null != bank_seq_no && bank_seq_no != "")
            {
                signStr = signStr + "bank_seq_no=" + bank_seq_no.ToString().Trim() + "&";
            }

            if (null != extra_return_param && extra_return_param != "")
            {
                signStr = signStr + "extra_return_param=" + extra_return_param + "&";
            }
            signStr = signStr + "interface_version=V3.0" + "&";
            signStr = signStr + "merchant_code=" + merchant_code + "&";


            if (null != notify_id && notify_id != "")
            {
                signStr = signStr + "notify_id=" + notify_id + "&notify_type=" + notify_type + "&";
            }

            signStr = signStr + "order_amount=" + order_amount + "&";
            signStr = signStr + "order_no=" + order_no + "&";
            signStr = signStr + "order_time=" + order_time + "&";
            signStr = signStr + "trade_no=" + trade_no + "&";
            signStr = signStr + "trade_status=" + trade_status + "&";

            if (null != trade_time && trade_time != "")
            {
                signStr = signStr + "trade_time=" + trade_time + "&";
            }

            string key = "123456789a123456789_";

            signStr = signStr + "key=" + key;
            string signInfo = signStr;

            //将组装好的信息MD5签名
            string sign = FormsAuthentication.HashPasswordForStoringInConfigFile(signInfo, "md5").ToLower(); //注意与支付签名不同  此处对String进行加密

            //比较智付返回的签名串与商家这边组装的签名串是否一致
            if (dinpaySign == sign)
            {
                //验签成功   

                if (trade_status == "SUCCESS" || trade_status == "success")
                {
                    StringBuilder objSB = new StringBuilder();

                    objSB.Append("<div class=\"box succss-box\">");
                    objSB.Append("<ul><li><img src=\"/img/check.png\" /></li> <li>");
                    objSB.AppendFormat("<p>恭喜你，您支付成功！本次充值<span style=\"color: Red;\">{0}元</span></p>", order_amount);
                    objSB.Append("<p>祝你玩的愉快！</p>");
                    objSB.Append("<p>如有其他疑问.欢迎致电：0527-88802678</p>");
                    objSB.Append("<p> <a href=\"/user/ChargeLog.aspx\">查看充值记录</a></p>");
                    objSB.Append("</li> </ul></div>");

                    this.objLiteral.Text = objSB.ToString();

                }
                else
                {
                    StringBuilder objSB = new StringBuilder();

                    objSB.Append("<div class=\"box error-box\">");
                    objSB.Append("<ul><li><img src=\"/img/error.png\" /></li> <li>");
                    objSB.Append("<p>对不起，支付失败！<span style=\"color: Red;\">请联系客服</span></p>");
                    objSB.Append("<p>如有其他疑问.欢迎致电：0527-88802678</p>");
                    objSB.Append("<p> <a href=\"/user/ChargeLog.aspx\">查看充值记录</a></p>");
                    objSB.Append("</li> </ul></div>");

                    this.objLiteral.Text = objSB.ToString();
                }
            }
            else
            {
                //验签失败 业务结束
            }

        }
    }
}