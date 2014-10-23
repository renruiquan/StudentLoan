using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    public class UserManageMoneyEntityEx : UserManageMoneyEntity
    {
        //扩展字段全部在 XXXXEntityEx.cs类里添加

        public string UserName { get; set; }

        public string ProductName { get; set; }

        public string SchemeName { get; set; }

        public decimal MaxYield { get; set; }

        /// <summary>
        /// 打利息的Id
        /// </summary>
        public int EarningsId { get; set; }

        /// <summary>
        /// 利息
        /// </summary>
        public decimal Interest { get; set; }

        /// <summary>
        /// 理财总金额
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 理财总次数
        /// </summary>
        public int TotalCount { get; set; }


        /// <summary>
        /// 理财总利息
        /// </summary>
        public decimal TotalInterest { get; set; }

        /// <summary>
        /// 理财总收益次数
        /// </summary>
        public int TotalEarningsCount { get; set; }

        /// <summary>
        /// 总待收利息
        /// </summary>
        public decimal WaitTotalInterest { get; set; }

        /// <summary>
        /// 进行中的理财笔数
        /// </summary>
        public int WaitTotalCount { get; set; }

    }
}
