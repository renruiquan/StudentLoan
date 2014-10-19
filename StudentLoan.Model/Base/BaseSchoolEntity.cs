using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class BaseSchoolEntity
    {
        
        private int _schoolId;

        /// <summary>
        /// 学校ID 主键自增
        /// </summary>
        public int SchoolId
        {
            get { return _schoolId; }
            set { _schoolId = value; }
        }

        private string _province;

        /// <summary>
        /// 学校所属省份
        /// </summary>
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        private string _schoolName;

        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName
        {
            get { return _schoolName; }
            set { _schoolName = value; }
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

    }
}
