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

            bool result = new UsersBLL().ExistsMobile(mobile);

            if (result)
            {
                context.Response.Write("{\"info\":\"手机号已被使用！\",\"status\":\"n\"}");
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