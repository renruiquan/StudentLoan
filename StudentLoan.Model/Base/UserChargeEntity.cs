using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UserChargeEntity
    {
        
        private int _id;

        /// <summary>
        /// 主键 自增
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _userId;

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _orderNo;

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        private int _channelId;

        /// <summary>
        /// 充值渠道
        /// </summary>
        public int ChannelId
        {
            get { return _channelId; }
            set { _channelId = value; }
        }

        private string _channelOrderNo;

        /// <summary>
        /// 第三方支付订单号
        /// </summary>
        public string ChannelOrderNo
        {
            get { return _channelOrderNo; }
            set { _channelOrderNo = value; }
        }

        private string _productName;

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private decimal _chargeMoney;

        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal ChargeMoney
        {
            get { return _chargeMoney; }
            set { _chargeMoney = value; }
        }

        private decimal _confirmMoney;

        /// <summary>
        /// 确认金额
        /// </summary>
        public decimal ConfirmMoney
        {
            get { return _confirmMoney; }
            set { _confirmMoney = value; }
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

        private string _callbackCode;

        /// <summary>
        /// 第三方充值回调代码
        /// </summary>
        public string CallbackCode
        {
            get { return _callbackCode; }
            set { _callbackCode = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 充值日期
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private System.DateTime _callbackTime;

        /// <summary>
        /// 第三方充值平台回调时间
        /// </summary>
        public System.DateTime CallbackTime
        {
            get { return _callbackTime; }
            set { _callbackTime = value; }
        }

        private System.DateTime _payTime;

        /// <summary>
        /// 支付日期
        /// </summary>
        public System.DateTime PayTime
        {
            get { return _payTime; }
            set { _payTime = value; }
        }

        private byte _status;

        /// <summary>
        /// 支付状态 0=未支付，2=充值中，3=已完成充值
        /// </summary>
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _ext1;

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Ext1
        {
            get { return _ext1; }
            set { _ext1 = value; }
        }

        private string _ext2;

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Ext2
        {
            get { return _ext2; }
            set { _ext2 = value; }
        }

        private string _ext3;

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Ext3
        {
            get { return _ext3; }
            set { _ext3 = value; }
        }

        private string _ext4;

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Ext4
        {
            get { return _ext4; }
            set { _ext4 = value; }
        }

        private string _ext5;

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Ext5
        {
            get { return _ext5; }
            set { _ext5 = value; }
        }

    }
}
