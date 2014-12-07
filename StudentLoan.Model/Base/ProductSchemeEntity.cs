using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class ProductSchemeEntity
    {

        private int _schemeId;

        /// <summary>
        /// 方案ID　主键自增
        /// </summary>
        public int SchemeId
        {
            get { return _schemeId; }
            set { _schemeId = value; }
        }

        private string _schemeName;

        /// <summary>
        /// 方案名称
        /// </summary>
        public string SchemeName
        {
            get { return _schemeName; }
            set { _schemeName = value; }
        }

        private int _initiatorAdminId;

        /// <summary>
        /// 发起方案的管理员ID
        /// </summary>
        public int InitiatorAdminId
        {
            get { return _initiatorAdminId; }
            set { _initiatorAdminId = value; }
        }

        private int _productId;

        /// <summary>
        /// 理财产品ID
        /// </summary>
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        private int _planType;

        /// <summary>
        /// 计划ID
        /// </summary>
        public int PlanType
        {
            get { return _planType; }
            set { _planType = value; }
        }

        private decimal _minYield;

        /// <summary>
        /// 最小收益率
        /// </summary>
        public decimal MinYield
        {
            get { return _minYield; }
            set { _minYield = value; }
        }

        private decimal _maxYield;

        /// <summary>
        /// 最大收益率
        /// </summary>
        public decimal MaxYield
        {
            get { return _maxYield; }
            set { _maxYield = value; }
        }

        private decimal _amount;

        /// <summary>
        /// 最小理财金额
        /// </summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private decimal _price;

        /// <summary>
        /// 单份理财产品金额
        /// </summary>
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _part;

        /// <summary>
        /// 份数 默认1份
        /// </summary>
        public int Part
        {
            get { return _part; }
            set { _part = value; }
        }

        private int _limitPart;

        /// <summary>
        /// 每人购买限制 0=无限制
        /// </summary>
        public int LimitPart
        {
            get { return _limitPart; }
            set { _limitPart = value; }
        }

        private int _numberOfPeople;

        /// <summary>
        /// 人数
        /// </summary>
        public int NumberOfPeople
        {
            get { return _numberOfPeople; }
            set { _numberOfPeople = value; }
        }

        private System.DateTime _startTime;

        /// <summary>
        /// 购买开始时间
        /// </summary>
        public System.DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private System.DateTime _endTime;

        /// <summary>
        /// 购买截止时间
        /// </summary>
        public System.DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private System.DateTime _lockStartTime;

        /// <summary>
        /// 锁定开始时间
        /// </summary>
        public System.DateTime LockStartTime
        {
            get { return _lockStartTime; }
            set { _lockStartTime = value; }
        }

        private System.DateTime _lockEndTime;

        /// <summary>
        /// 锁定结束时间
        /// </summary>
        public System.DateTime LockEndTime
        {
            get { return _lockEndTime; }
            set { _lockEndTime = value; }
        }

        private string _schemeDescription;

        /// <summary>
        /// 方案描述
        /// </summary>
        public string SchemeDescription
        {
            get { return _schemeDescription; }
            set { _schemeDescription = value; }
        }

        private decimal _fee;

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Fee
        {
            get { return _fee; }
            set { _fee = value; }
        }

        private string _remark;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private byte _status;

        /// <summary>
        /// 方案状态 0=禁用，1=进行中，2=已过期
        /// </summary>
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 建档日期
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        /// <summary>
        /// 最小理财期限
        /// </summary>
        public int MinDeadline { get; set; }

        /// <summary>
        /// 最大理财期限
        /// </summary>
        public int MaxDeadline { get; set; }
    }
}
