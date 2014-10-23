using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    public class UserEarningsEntityEx : UserEarningsEntity
    {
        //扩展字段全部在 XXXXEntityEx.cs类里添加

        public string UserName { get; set; }

        public string SchemeName { get; set; }

        public decimal UserAmount { get; set; }

        public string ProductName { get; set; }

        public int BuyId { get; set; }

        /// <summary>
        /// 理财支付时间
        /// </summary>
        public DateTime PayTime { get; set; }

        /// <summary>
        /// 理财结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
