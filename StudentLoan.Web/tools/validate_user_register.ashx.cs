using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLoan.Common;
using StudentLoan.Model;
using StudentLoan.BLL;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// validate_user_register 的摘要说明
    /// </summary>
    public class validate_user_register : IHttpHandler
    {
        //用于Ajax检测用户名是否存在

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string userName = context.Request.Params["param"];

            bool result = new UsersBLL().Exists(userName);

            if (result)
            {
                context.Response.Write("{\"info\":\"用户名已存在！\",\"status\":\"n\"}");
            }
            else
            {
                context.Response.Write("{\"info\":\"可以注册！\",\"status\":\"y\"}");
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