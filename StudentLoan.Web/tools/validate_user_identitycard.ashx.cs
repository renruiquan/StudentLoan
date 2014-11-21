using StudentLoan.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// validate_user_identitycard 的摘要说明
    /// </summary>
    public class validate_user_identitycard : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string identity_card = context.Request.Params["param"];

            if (string.IsNullOrEmpty(identity_card))
            {
                context.Response.Write("{\"info\":\"请填写身份证号码！\",\"status\":\"n\"}");
                return;
            }

            bool result = new UsersBLL().ExistsIdentityCard(identity_card);

            if (result)
            {
                context.Response.Write("{\"info\":\"身份证号已被使用！\",\"status\":\"n\"}");
            }
            else
            {
                context.Response.Write("{\"info\":\"可以使用！\",\"status\":\"y\"}");
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