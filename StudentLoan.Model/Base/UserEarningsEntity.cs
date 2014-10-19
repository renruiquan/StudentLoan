using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UserEarningsEntity
    {
        
        private int _earningsId;

        /// <summary>
        /// 收益ID，主键自增
        /// </summary>
        public int EarningsId
        {
            get { return _earningsId; }
            set { _earningsId = value; }
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

        private int _productSchemeId;

        /// <summary>
        /// 购买的理财产品方案ID
        /// </summary>
        public int ProductSchemeId
        {
            get { return _productSchemeId; }
            set { _productSchemeId = value; }
        }

        private decimal _amount;

        /// <summary>
        /// 收益金额
        /// </summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private byte _type;

        /// <summary>
        /// 盈亏类型 0=亏损，1=盈利
        /// </summary>
        public byte Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private byte _status;

        /// <summary>
        /// 状态 0=未到账，1=已到账
        /// </summary>
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _remark;

        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 收益日期
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

    }
}
