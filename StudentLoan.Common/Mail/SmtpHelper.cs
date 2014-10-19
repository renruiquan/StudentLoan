using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mail;

namespace StudentLoan.Common.Mail
{
    /// <summary>
    /// SmtpHelper
    /// </summary>
    public class SmtpHelper
    {
        private static readonly object locker = new object();

        /// <summary>
        /// 是否发送完成
        /// </summary>
        public static bool SendCompleted
        {
            get;
            set;
        }

        static SmtpHelper()
        {
            SmtpHelper.SendCompleted = true;
        }

        #region Private Delegate
        private delegate void AsyncSendEmail(SmtpConfig objSmtpConfig, SmtpMail objSmtpMail);
        #endregion

        #region Public Method
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="objSmtpConfig"></param>
        /// <param name="objSmtpMail"></param>
        public void SendEmail(SmtpConfig objSmtpConfig, SmtpMail objSmtpMail)
        {
            lock (SmtpHelper.locker)
            {
                try
                {
                    SmtpHelper.SendCompleted = false;

                    objSmtpConfig.ToSmtpClient().Send(objSmtpMail.ToMailMessage());

                    SmtpHelper.SendCompleted = true;
                }

                catch
                {
                    SmtpHelper.SendCompleted = true;
                }
            }
        }

        /// <summary>
        /// 开始发送邮件
        /// </summary>
        /// <param name="objSmtpConfig"></param>
        /// <param name="objSmtpMail"></param>
        public void BeginSendEmail(SmtpConfig objSmtpConfig, SmtpMail objSmtpMail)
        {
            new AsyncSendEmail(this.SendEmail).BeginInvoke(objSmtpConfig, objSmtpMail, null, null);
        }
        #endregion
    }
}
