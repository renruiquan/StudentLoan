using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    public class UserChargeEntityEx : UserChargeEntity
    {
        //扩展字段全部在 XXXXEntityEx.cs类里添加

        /// <summary>
        /// 银行代码 参见B2C银行代码对照表，当该参数为空并与对照表中银行编码不一致，则直接跳转到银行支付页面。 
        /// </summary>
        public string BankCode { get; set; }

        public string ChannelName { get; set; }

        public string UserName { get; set; }
    }
}
