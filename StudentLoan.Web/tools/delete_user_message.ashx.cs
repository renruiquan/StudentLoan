using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLoan.BLL;
using StudentLoan.Model;
using StudentLoan.Common;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// delete_user_message 的摘要说明
    /// </summary>
    public class delete_user_message : IHttpHandler
    {
        //删除用户短消息

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int Id = context.Request.Params["Id"].Convert<int>();

            if (Id == 0)
            {
                context.Response.Write("参数不正确");
                return;
            }
            else
            {
                bool result = new UserMessageBLL().Update(new UserMessageEntityEx() { Id = Id });

                context.Response.Write(string.Format("操作{0}", result == true ? "成功" : "失败"));
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