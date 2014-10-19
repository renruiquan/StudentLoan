using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;
using System.IO;
using System.Text;
using StudentLoan.Common;
using StudentLoan.Model;
using StudentLoan.BLL;
using StudentLoan.Common.Logging;

namespace StudentLoan.Web
{
    public class Time_Task
    {
        public event System.Timers.ElapsedEventHandler ExecuteTask;
        private static readonly Time_Task _task = null;
        private Timer _timer = null;
        private int _interval = 1000;

        public int Interval { get; set; }

        //构造函数中出始化
        static Time_Task()
        {
            _task = new Time_Task();
        }

        public static Time_Task Instance()
        {
            return _task;
        }

        public void Start()
        {
            if (_timer == null)
            {
                _timer = new Timer(_interval);
                _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
                _timer.Enabled = true;
                _timer.Start();
            }
        }

        protected void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //获取小时，分种，秒;  如果等于设定时间就开始执行

            int Hour = e.SignalTime.Hour;
            int Minute = e.SignalTime.Minute;
            int Second = e.SignalTime.Second;

            string GetTime = ConfigHelper.AppSettings<string>("TastExtcueTime", "01:00:00");
            //截取字符到一个数组中
            string[] array = GetTime.Split(':');

            //数组的第一个元素为小时
            int setHour = Convert.ToInt32(array[0]);
            //数组的第二个元素为分钟
            int setMinute = Convert.ToInt32(array[1]);
            //数组的第三个元素为秒
            int setSecond = Convert.ToInt32(array[2]);

            if (Hour == setHour && Minute == setMinute && Second == setSecond)
            {
                if (null != ExecuteTask)
                {
                    // ExecuteTask(sender, e);

                    List<UserManageMoneyEntityEx> list = new UserManageMoneyBLL().GetList(" a.Status = 1");

                    foreach (UserManageMoneyEntityEx item in list)
                    {
                        UserEarningsEntityEx earningsModel = new UserEarningsEntityEx()
                        {
                            UserId = item.UserId,
                            ProductSchemeId = item.ProductSchemeId,
                            //计算每天的利息
                            Amount = item.Amount * item.MaxYield / 365,
                            Type = 1,
                            Status = 1,
                            CreateTime = DateTime.Now
                        };

                        bool result = new UserEarningsBLL().Insert(earningsModel);

                        if (result)
                        {
                            LogHelper.Default.Info(string.Format("用户ID:{0},用户名{1}:的利息:{2}打款到账", item.UserId, item.UserName, earningsModel.Amount));
                        }
                        else
                        {
                            LogHelper.Default.Warn(string.Format("用户ID:{0},用户名{1}:的利息:{2}打款失败", item.UserId, item.UserName, earningsModel.Amount));
                        }
                    }
                }
            }
        }


        //此方法没有调用，以备不时之需
        public void Stop()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
            }
        }

    }
}