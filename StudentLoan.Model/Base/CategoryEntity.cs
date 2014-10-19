using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class CategoryEntity
    {
        
        private int _categoryId;

        /// <summary>
        /// 分类ID，主键自增长
        /// </summary>
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        private int _parentId;

        /// <summary>
        /// 父分类ID
        /// </summary>
        public int ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        private string _categoryName;

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        private string _description;

        /// <summary>
        /// 分类描述
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
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

        private System.DateTime _updateTime;

        /// <summary>
        /// 更新日期
        /// </summary>
        public System.DateTime UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
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
        /// 状态 0=禁用,1=启用
        /// </summary>
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
