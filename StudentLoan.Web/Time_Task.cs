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
                    this.Withdrawal();

                    this.PayInterest();
                }
            }
        }

        /// <summary>
        /// 支付利息
        /// </summary>
        public void PayInterest()
        {
            List<UserManageMoneyEntityEx> list = new UserManageMoneyBLL().GetList(" a.EndTime >=getdate() and (a.Status = 1 or a.Status = 2) ");

            foreach (UserManageMoneyEntityEx item in list)
            {
                UserEarningsEntityEx earningsModel = new UserEarningsEntityEx()
                {
                    UserId = item.UserId,
                    ProductSchemeId = item.ProductSchemeId,
                    //计算每天的利息
                    Amount = Math.Round(item.Amount * item.MaxYield / 365, 2),
                    Type = 1,
                    Status = 1,
                    ProductName = item.ProductName,
                    ProductId = item.ProductId,
                    CreateTime = DateTime.Now,
                    BuyId = item.BuyId
                };

                bool result = new UserEarningsBLL().Insert(earningsModel);

                if (result)
                {
                    LogHelper.Default.Info(string.Format("用户ID:{0},利息:{1}打款到账", item.UserId, Math.Round(earningsModel.Amount, 2)));
                }
                else
                {
                    LogHelper.Default.Warn(string.Format("用户ID:{0},利息:{1}打款失败", item.UserId, Math.Round(earningsModel.Amount, 2)));
                }
            }
        }

        /// <summary>
        /// 提现，将到期的理财产品，转到用户账户中
        /// </summary>
        public void Withdrawal()
        {
            List<UserManageMoneyEntityEx> list = new UserManageMoneyBLL().GetList(" a.EndTime <=getdate() and (a.Status = 1 or a.Status = 2) ");

            UserManageMoneyBLL bll = new UserManageMoneyBLL();

            foreach (UserManageMoneyEntityEx item in list)
            {
                UserManageMoneyEntityEx model = bll.GetModel(item.BuyId);

                if (model != null)
                {
                    model = new UserManageMoneyEntityEx()
                    {
                        //转出
                        Status = 3,
                        BuyId = item.BuyId,
                        UserId = item.UserId,
                        Amount = item.Amount,
                        //系统转款
                        AdminId = 1
                    };

                    bool result = bll.PassApplyWithdrawal(model);

                    LogHelper.Default.Info(string.Format("理财记录ID{0},用户ID{1},理财到期到账金额:{2}", item.BuyId, item.UserId, item.Amount));
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