using StudentLoan.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// message_send 的摘要说明
    /// </summary>
    public class message_send : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string mobile = context.Request.Params["txtMobile"];
            string mobileCode = Guid.NewGuid().ToString().Split('-')[1];

            HttpRuntime.Cache.Add("MobileCode", mobileCode, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero, CacheItemPriority.NotRemovable, null);

            string content = string.Format("【UTL温馨提醒】欢迎注册学子易贷帐号，您的手机验证码为：{0}，请在注册页面填写，有效期为5分钟。", mobileCode);

            context.Response.Write(Message.Send(mobile, content));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}