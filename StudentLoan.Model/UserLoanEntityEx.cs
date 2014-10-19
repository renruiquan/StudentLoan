using System;
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
    }
}
