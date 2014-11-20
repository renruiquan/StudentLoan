using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentLoan.Common;
using System.Drawing;
using System.Web.SessionState;
using KudyStudio;

namespace StudentLoan.Web.tools
{
    /// <summary>
    /// validate_code 的摘要说明
    /// </summary>
    public class validate_code : IHttpHandler, IRequiresSessionState
    {
        //用于生面网页中的验证码图片

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            CaptchaImage image = CaptchaImage.Create(CaptchaText.NumberAndLetter, Color.FromArgb(234, 237, 244));
           

            // 保存session

            HttpContext.Current.Session[StudentLoan.Common.StudentLoanKeys.SESSION_CODE] = image.Text;
            HttpContext.Current.Response.OutputStream.Write(image.Data, 0, image.Data.Length);


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