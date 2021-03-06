﻿using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Common.Logging;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web.callback
{
    public partial class DinPayNotifyUrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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

                ChannelEntityEx channelModel = new BLL.ChannelBLL().GetModel(1);

                string key = "123456789a123456789_";

                if (channelModel != null)
                {
                    key = channelModel.AppKey;
                }

                signStr = signStr + "key=" + key;
                string signInfo = signStr;

                //将组装好的信息MD5签名
                string sign = FormsAuthentication.HashPasswordForStoringInConfigFile(signInfo, "md5").ToLower(); //注意与支付签名不同  此处对String进行加密

                LogHelper.Default.Info(signInfo + "&sign=" + dinpaySign);

                //比较智付返回的签名串与商家这边组装的签名串是否一致
                if (dinpaySign == sign)
                {
                    //验签成功   
                    /**
		
                    此处进行商户业务操作
		
                    业务结束
                    */

                    try
                    {
                        UserChargeEntityEx chargeModel = new UserChargeBLL().GetModel(order_no);

                        if (chargeModel == null)
                        {
                            Response.Write("Fail:订单不存在");
                            return;
                        }

                        //封装订单信息，准备更新订单状态
                        UserChargeEntityEx model = new UserChargeEntityEx()
                        {
                            UserId = chargeModel.UserId,
                            ChannelOrderNo = trade_no,
                            OrderNo = order_no,
                            ConfirmMoney = Math.Abs(order_amount.Convert<decimal>()),
                            CallbackCode = trade_status,
                            CallbackTime = DateTime.Now,
                            PayTime = trade_time.Convert<DateTime>(),
                            Status = 2
                        };


                        //更新用户账号余额及订单状态

                        bool result = new UserChargeBLL().UpdateOrderStatus(model);

                        LogHelper.Default.Info(string.Format("校验成功，订单状态：{0}", result));
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Default.Error(string.Format("充值回调时发生错误：{0}", ex.ToString()));
                    }
                }
                else
                {
                    //验签失败 业务结束
                    LogHelper.Default.Info("校验失败");
                }

                Response.Write("SUCCESS");
            }
        }
    }
}