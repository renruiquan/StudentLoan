using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace StudentLoan.Common.Mail
{
    /// <summary>
    /// SmtpMail
    /// </summary>
    public class SmtpMail
    {
        #region Private Field
        private MailMessage objMailMessage = null;
        #endregion

        #region Constructor
        public SmtpMail()
        {
            this.objMailMessage = new MailMessage();
        }
        #endregion

        #region Public Method
        public void SetFrom(string fromAddress, string displayName)
        {
            this.objMailMessage.From = new MailAddress(fromAddress, displayName, Encoding.UTF8);
        }

        public void AddTo(string toAddress)
        {
            this.objMailMessage.To.Add(new MailAddress(toAddress, toAddress, Encoding.UTF8));
        }

        public void AddTo(string toAddress, string displayName)
        {
            this.objMailMessage.To.Add(new MailAddress(toAddress, displayName, Encoding.UTF8));
        }

        public void AddCc(string ccAddress)
        {
            this.objMailMessage.CC.Add(new MailAddress(ccAddress, ccAddress, Encoding.UTF8));
        }

        public void AddBcc(string bccAddress)
        {
            this.objMailMessage.Bcc.Add(new MailAddress(bccAddress, bccAddress, Encoding.UTF8));
        }

        public void SetSubject(string subject)
        {
            this.objMailMessage.Subject = subject;
            this.objMailMessage.SubjectEncoding = Encoding.UTF8;
        }

        public void SetBody(string body)
        {
            this.objMailMessage.Body = body;
            this.objMailMessage.BodyEncoding = Encoding.UTF8;
            this.objMailMessage.IsBodyHtml = true;
        }

        public MailMessage ToMailMessage()
        {
            return this.objMailMessage;
        }
        #endregion
    }
}
