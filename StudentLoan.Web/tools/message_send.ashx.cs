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
        //发送短信

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string mobile = context.Request.Params["txtMobile"];
            string mobileCode = Guid.NewGuid().ToString().Split('-')[1];
            string type = context.Request.Params["type"];


            HttpRuntime.Cache.Add("MobileCode", mobileCode, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero, CacheItemPriority.NotRemovable, null);
            string content = string.Empty;

            if (type == "findpassword")
            {
                content = string.Format("您的手机验证码为：{0}，切勿将验证码泄露于他人。如非本人操作，建议及时修改账号密码。【学子易贷】", mobileCode);
            }
            else if (type == "BindMobile")
            {
                content = string.Format("您的手机验证码为：{0}，请在手机绑定页面填写，有效期为5分钟。【学子易贷】", mobileCode);
            }
            else if (type == "CertMobile")
            {
                content = string.Format("您的手机验证码为：{0}，请在基本信息认证页面填写，有效期为5分钟。【学子易贷】", mobileCode);
            }

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