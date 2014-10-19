using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Common;

//官方地址：http://www.sms.cn

namespace StudentLoan.API
{
    public class Message
    {
        public string Send(string mobile, string content)
        {
            try
            {
                string sendurl = ConfigHelper.AppSettings<string>("SendMessageUrl");

                StringBuilder sbTemp = new StringBuilder();
                string uid = ConfigHelper.AppSettings<string>("SendMessageID");
                string pwd = ConfigHelper.AppSettings<string>("SendMessageKey");

                string Pass = string.Format("{0}{1}", pwd, uid).MD5(); //密码进行MD5加密

                sbTemp.Append("uid=" + uid + "&pwd=" + Pass + "&mobile=" + mobile + "&content=" + content);

                string postReturn = WebExtension.Post(sendurl, sbTemp.ToString());

                return postReturn;
            }
            catch
            {
                return "短信发送异常";
            }
        }
    }
}
