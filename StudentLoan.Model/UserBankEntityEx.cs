using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    public class UserBankEntityEx : UserBankEntity
    {
       //扩展字段全部在 XXXXEntityEx.cs类里添加

        public int NewBankId { get; set; }
    }
}
