using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UserLoanEntity
    {

        private int _loanId;

        /// <summary>
        /// 贷款ID 主键自增
        /// </summary>
        public int LoanId
        {
            get { return _loanId; }
            set { _loanId = value; }
        }


        private int _productId;

        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        private int _userId;

        /// <summary>
        /// 贷款人ID
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _loanNo;

        /// <summary>
        /// 贷款编号
        /// </summary>
        public string LoanNo
        {
            get { return _loanNo; }
            set { _loanNo = value; }
        }

        private string _loanTitle;

        /// <summary>
        /// 贷款标题
        /// </summary>
        public string LoanTitle
        {
            get { return _loanTitle; }
            set { _loanTitle = value; }
        }

        private decimal _loanMoney;

        /// <summary>
        /// 贷款金额
        /// </summary>
        public decimal LoanMoney
        {
            get { return _loanMoney; }
            set { _loanMoney = value; }
        }

        private decimal _loanTypeId;

        /// <summary>
        /// 贷款类型ID
        /// </summary>
        public decimal LoanTypeId
        {
            get { return _loanTypeId; }
            set { _loanTypeId = value; }
        }

        private int _loanCategory;

        /// <summary>
        /// 借款分类
        /// </summary>
        public int LoanCategory
        {
            get { return _loanCategory; }
            set { _loanCategory = value; }
        }

        private decimal _annualFee;

        /// <summary>
        /// 年费率
        /// </summary>
        public decimal AnnualFee
        {
            get { return _annualFee; }
            set { _annualFee = value; }
        }

        private decimal _shouldRepayMoney;

        /// <summary>
        /// 应还金额
        /// </summary>
        public decimal ShouldRepayMoney
        {
            get { return _shouldRepayMoney; }
            set { _shouldRepayMoney = value; }
        }

        private int _alreadyAmortization;

        /// <summary>
        /// 已还款期数
        /// </summary>
        public int AlreadyAmortization
        {
            get { return _alreadyAmortization; }
            set { _alreadyAmortization = value; }
        }

        private int _totalAmortization;

        /// <summary>
        /// 总分期还款的期数
        /// </summary>
        public int TotalAmortization
        {
            get { return _totalAmortization; }
            set { _totalAmortization = value; }
        }

        private string _loanDescription;

        /// <summary>
        ///贷款描述
        /// </summary>
        public string LoanDescription
        {
            get { return _loanDescription; }
            set { _loanDescription = value; }
        }

        private byte _status;

        /// <summary>
        /// 贷款状态 0=审核中，1=成功，2=失败
        /// </summary>
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _adminId;

        /// <summary>
        /// 管理员ID，用于标记是哪位管理员进行的放款操作
        /// </summary>
        public int AdminId
        {
            get { return _adminId; }
            set { _adminId = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 申请日期
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private System.DateTime _passTime;

        /// <summary>
        /// 审核通过日期
        /// </summary>
        public System.DateTime PassTime
        {
            get { return _passTime; }
            set { _passTime = value; }
        }

    }
}
