using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UserBankEntity
    {

        private int _bankId;

        /// <summary>
        /// 银行ID
        /// </summary>
        public int BankId
        {
            get { return _bankId; }
            set { _bankId = value; }
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

        private string _bankName;

        /// <summary>
        /// 开户行名称
        /// </summary>
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        private string _bankCardNo;

        /// <summary>
        /// 银行卡卡号
        /// </summary>
        public string BankCardNo
        {
            get { return _bankCardNo; }
            set { _bankCardNo = value; }
        }

        private string _bankProvince;

        /// <summary>
        /// 开户行所在省份
        /// </summary>
        public string BankProvince
        {
            get { return _bankProvince; }
            set { _bankProvince = value; }
        }

        private string _bankCity;

        /// <summary>
        /// 开户行所在城市
        /// </summary>
        public string BankCity
        {
            get { return _bankCity; }
            set { _bankCity = value; }
        }

        private byte _status;

        /// <summary>
        /// 状态 0=禁用，1=启用
        /// </summary>
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private bool _isDefault;

        /// <summary>
        /// 是否为默认提款到此银行卡 0=否，1=是
        /// </summary>
        public bool IsDefault
        {
            get { return _isDefault; }
            set { _isDefault = value; }
        }

        private string _createTime;

        /// <summary>
        /// 建档日期
        /// </summary>
        public string CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
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

    }
}
