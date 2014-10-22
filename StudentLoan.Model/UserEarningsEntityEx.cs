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

    }
}
