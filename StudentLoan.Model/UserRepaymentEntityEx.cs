using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    [Serializable]
    public class UserRepaymentEntityEx : UserRepaymentEntity
    {
        //扩展字段全部在 XXXXEntityEx.cs类里添加

        /// <summary>
        /// 总期数
        /// </summary>
        public int TotalAmortization { get; set; }

        /// <summary>
        /// 已还期数
        /// </summary>
        public int AlreadyAmortization { get; set; }
        /// <summary>
        /// 类别ID
        /// </summary>
        public int LoanTypeId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        private System.DateTime _repaymentTime;

        /// <summary>
        /// 应该在某日还款的日期
        /// </summary>
        public System.DateTime RepaymentTime
        {
            get { return _repaymentTime; }
            set { _repaymentTime = value; }
        }

        /// <summary>
        /// 借款编号
        /// </summary>
        public string LoanNo { get; set; }

        /// <summary>
        /// 借款金额
        /// </summary>
        public decimal LoanMoney { get; set; }

        /// <summary>
        /// 年费率
        /// </summary>
        public decimal AnnualFee { get; set; }

        /// <summary>
        /// 借款人ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户信息积分，用于还款加（减）信用积分
        /// </summary>
        public int Point { get; set; }
    }
}
