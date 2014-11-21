using StudentLoan.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// validate_user_email 的摘要说明
    /// </summary>
    public class validate_user_email : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string email = context.Request.Params["param"];


            if (string.IsNullOrEmpty(email))
            {
                context.Response.Write("{\"info\":\"请填写邮箱信息！\",\"status\":\"n\"}");
                return;
            }

            bool result = new UsersBLL().ExistsEMail(email);

            if (result)
            {
                context.Response.Write("{\"info\":\"邮箱已被使用！\",\"status\":\"n\"}");
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