using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using StudentLoan.Common;
using StudentLoan.BLL;
using StudentLoan.Model;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// validate_vcerification_code 的摘要说明
    /// </summary>
    public class validate_vcerification_code : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string code = context.Session[StudentLoanKeys.SESSION_CODE].ToString();

            string vcerify_code = context.Request.Params["param"];

            if (code.ToLower() != vcerify_code.ToLower())
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