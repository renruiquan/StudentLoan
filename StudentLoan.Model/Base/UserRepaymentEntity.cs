using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    [Serializable]
    public class UserRepaymentEntity
    {

        private int _loanId;

        /// <summary>
        /// 借款记录ID
        /// </summary>
        public int LoanId
        {
            get { return _loanId; }
            set { _loanId = value; }
        }


        public int _currentAmortization;

        /// <summary>
        /// 当前还款期数
        /// </summary>
        public int CurrentAmortization
        {
            get { return _currentAmortization; }
            set { _currentAmortization = value; }
        }

        private decimal _repaymentMondy;

        /// <summary>
        /// 还款金额
        /// </summary>
        public decimal RepaymentMoney
        {
            get { return _repaymentMondy; }
            set { _repaymentMondy = value; }
        }

        private decimal _breakContract;

        /// <summary>
        /// 违约金
        /// </summary>
        public decimal BreakContract
        {
            get { return _breakContract; }
            set { _breakContract = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 实际还款日期
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private int _status;

        /// <summary>
        ///还款状态 0=正常未还款，1=正常已还款，2=违约已还款
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
