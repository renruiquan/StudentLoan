using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLoan.Common;
using System.Drawing;
using System.Web.SessionState;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// validate_code 的摘要说明
    /// </summary>
    public class validate_code : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            Captcha objCaptcha = new Captcha(4, true, false);

            objCaptcha.FontColor = Color.Blue;
            objCaptcha.FontSize = 12;
            

            HttpContext.Current.Session[StudentLoan.Common.StudentLoanKeys.SESSION_CODE] = objCaptcha.VerifyCodeText;

            objCaptcha.Output(HttpContext.Current.Response);

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