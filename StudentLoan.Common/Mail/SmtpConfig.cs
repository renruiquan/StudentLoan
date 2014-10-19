using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace StudentLoan.Common.Mail
{
    /// <summary>
    /// SmtpConfig
    /// </summary>
    public class SmtpConfig
    {
        #region Private Field
        private SmtpClient objSmtpClient = null;
        #endregion

        #region Constructor
        public SmtpConfig(string host, int port, string userName, string password, bool isSsl)
        {
            objSmtpClient = new SmtpClient()
            {
                Host = host,
                Port = port,
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = isSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
        }
        #endregion

        #region Public Method
        public SmtpClient ToSmtpClient()
        {
            return this.objSmtpClient;
        }
        #endregion
    }
}
