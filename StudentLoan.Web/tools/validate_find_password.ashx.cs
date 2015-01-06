using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// validate_find_password 的摘要说明
    /// </summary>
    public class validate_find_password : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string mobile = context.Request.Params["param"];
            string username = context.Request.Params["txtusername"];

            if (string.IsNullOrEmpty(username))
            {
                context.Response.Write("{\"info\":\"请填写要找回的用户名！\",\"status\":\"n\",\"type\":\"0\"}");
                return;
            }

            if (string.IsNullOrEmpty(mobile))
            {
                context.Response.Write("{\"info\":\"请填写手机号码！\",\"status\":\"n\",\"type\":\"0\"}");
                return;
            }

            UsersEntityEx userModel = new UsersBLL().GetModel(username);

            if (userModel == null)
            {
                context.Response.Write("{\"info\":\"您填写的用户名不存在，无法找回！\",\"status\":\"n\",\"type\":\"0\"}");
                return;
            }

            if (userModel.Mobile != mobile)
            {
                context.Response.Write("{\"info\":\"该账号与绑定的手机号码不符！\",\"status\":\"n\",\"type\":\"1\"}");
            }
            else
            {
                context.Response.Write("{\"info\":\"填写正确！\",\"status\":\"y\",\"type\":\"2\"}");
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