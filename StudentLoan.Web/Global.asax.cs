using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using StudentLoan.Common.Logging;

namespace StudentLoan.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //调用Time_Task类中的代码
            Time_Task.Instance().ExecuteTask += new System.Timers.ElapsedEventHandler(Global_ExecuteTask);
            Time_Task.Instance().Start();
        }

        void Global_ExecuteTask(object sender, System.Timers.ElapsedEventArgs e)
        {
            //向日志文件中写入当前日期;
            LogHelper.Default.Info("");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}