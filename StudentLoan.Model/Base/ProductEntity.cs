using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class ProductEntity
    {

        private int _productId;

        /// <summary>
        /// 理财产品ID 主键自增
        /// </summary>
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
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


        private decimal _baseAnnualFee;

        /// <summary>
        /// 基础年费率（服务费）这里学生借款时会用到
        /// </summary>
        public decimal BaseAnnualFee
        {
            get { return _baseAnnualFee; }
            set { _baseAnnualFee = value; }
        }

        private string _productDescription;

        /// <summary>
        /// 理财产品描述
        /// </summary>
        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; }
        }


        private int _productType;
        /// <summary>
        /// 产品类型
        /// </summary>
        public int ProductType
        {
            get { return _productType; }
            set { _productType = value; }
        }


        private decimal _productMinMoney;
        /// <summary>
        /// ProductType=1时，最小借款金额
        /// </summary>
        public decimal ProductMinMoney
        {
            get { return _productMinMoney; }
            set { _productMinMoney = value; }
        }

        private decimal _productMaxMoney;

        /// <summary>
        /// ProductType=1时，最大借款金额
        /// </summary>
        public decimal ProductMaxMoney
        {
            get { return _productMaxMoney; }
            set { _productMaxMoney = value; }
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

        private byte _status;

        /// <summary>
        /// 状态 0=禁用，1=启用
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
