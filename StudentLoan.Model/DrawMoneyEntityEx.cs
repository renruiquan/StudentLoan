using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    public class DrawMoneyEntityEx : DrawMoneyEntity
    {
        //扩展字段全部在 XXXXEntityEx.cs类里添加

        public string UserName { get; set; }
        public string BankName { get; set; }
        public string BankCardNo { get; set; }
        public string BankProvince { get; set; }
        public string BankCity { get; set; }

        public string TrueName { get; set; }
    }
}
