using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class BaseBankEntity
    {
        
        private int _bankId;

        /// <summary>
        /// 银行编号 主键自增
        /// </summary>
        public int BankId
        {
            get { return _bankId; }
            set { _bankId = value; }
        }

        private string _bankName;

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        private int _orderNo;

        /// <summary>
        /// 排序号
        /// </summary>
        public int OrderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
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
        /// 状态 1=启用,0=禁用
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

    }
}
