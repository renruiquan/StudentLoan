using StudentLoan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// validate_message_send 的摘要说明
    /// </summary>
    public class validate_message_send : IHttpHandler, IReadOnlySessionState
    {
        //验证Ajax用户输入的短信验证码是否正确

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string code = CacheHelper.Get<string>("MobileCode");

            string vcerify_code = context.Request.Params["param"];

            if (string.IsNullOrEmpty(code))
            {
                context.Response.Write("{\"info\":\"请先获取验证码！\",\"status\":\"n\"}");
            }
            else if (code.ToLower() != vcerify_code.ToLower())
            {
                context.Response.Write("{\"info\":\"验证码错误！\",\"status\":\"n\"}");
            }
            else
            {
                context.Response.Write("{\"info\":\"验证码正确！\",\"status\":\"y\"}");
            }
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