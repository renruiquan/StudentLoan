﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    public class UserLoanEntityEx : UserLoanEntity
    {
        //扩展字段全部在 XXXXEntityEx.cs类里添加
        public string UserName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 总借款金额
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 总借款次数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 已还款本息
        /// </summary>
        public decimal RepaymentMoney { get; set; }

        /// <summary>
        /// 成功借款次数
        /// </summary>
        public int LoanSuccessCount { get; set; }

        /// <summary>
        /// 未还款金额
        /// </summary>
        public decimal WaitMoney { get; set; }

        /// <summary>
        /// 未还款次数
        /// </summary>
        public int WaitLoanCount { get; set; }
        /// <summary>
        /// 正常还款次数
        /// </summary>
        public int NormalLoanCount { get; set; }

        /// <summary>
        /// 逾期次数
        /// </summary>
        public int TotalBreakCount { get; set; }

        /// <summary>
        /// 逾期费用
        /// </summary>
        public decimal TotalBreakContract { get; set; }

        /// <summary>
        /// 严重逾期次数，即逾期天数>5天
        /// </summary>
        public int TotalSevereBreakCount { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 还款日期
        /// </summary>
        public DateTime RepaymentTime { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        public string AdminName { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// 用户是否可以更新资料  1=是，0=否
        /// </summary>
        public int CanModify { get; set; }
    }
}
