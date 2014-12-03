using StudentLoan.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// validate_user_mobile 的摘要说明
    /// </summary>
    public class validate_user_mobile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string mobile = context.Request.Params["param"];

            if (string.IsNullOrEmpty(mobile))
            {
                context.Response.Write("{\"info\":\"请填写手机号码！\",\"status\":\"n\",\"type\":\"0\"}");
                return;
            }

            bool result = new UsersBLL().ExistsMobile(mobile);

            if (result)
            {
                context.Response.Write("{\"info\":\"手机号已被使用！\",\"status\":\"n\",\"type\":\"1\"}");
            }
            else
            {
                context.Response.Write("{\"info\":\"可以使用！\",\"status\":\"y\",\"type\":\"2\"}");
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