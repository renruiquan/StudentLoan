using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UserManageMoneyEntity
    {

        private int _buyId;

        /// <summary>
        /// 购买ID 主键自增
        /// </summary>
        public int BuyId
        {
            get { return _buyId; }
            set { _buyId = value; }
        }


        private int _period;

        /// <summary>
        /// 理财期限
        /// </summary>
        public int Period
        {
            get { return _period; }
            set { _period = value; }
        }

        private int _userId;

        /// <summary>
        /// 消费者ID
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _productId;

        /// <summary>
        /// 用户购买的产品的ID
        /// </summary>
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        private int _productSchemeId;

        /// <summary>
        /// 产品方案ID
        /// </summary>
        public int ProductSchemeId
        {
            get { return _productSchemeId; }
            set { _productSchemeId = value; }
        }

        private int _count;

        /// <summary>
        /// 购买数量
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private decimal _amount;

        /// <summary>
        /// 购买理财产品消费的金额
        /// </summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 下单时间
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private System.DateTime _payTime;

        /// <summary>
        /// 支付时间
        /// </summary>
        public System.DateTime PayTime
        {
            get { return _payTime; }
            set { _payTime = value; }
        }

        private DateTime _endTime;

        /// <summary>
        /// 理财到期时间
        /// </summary>
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private DateTime _withdrawalTime;

        /// <summary>
        /// 转出日期
        /// </summary>
        public DateTime WithdrawalTime
        {
            get { return _withdrawalTime; }
            set { _withdrawalTime = value; }
        }


        private DateTime _applyWithdrawalTime;

        /// <summary>
        /// 申请转出日期
        /// </summary>
        public DateTime ApplyWithdrawalTime
        {
            get { return _applyWithdrawalTime; }
            set { _applyWithdrawalTime = value; }
        }

        private int _adminId;

        /// <summary>
        /// 审核人Id
        /// </summary>
        public int AdminId
        {
            get { return _adminId; }
            set { _adminId = value; }
        }

        private int _status;

        /// <summary>
        /// 0=等待付款，1=已付款，2=用户消费付款
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
