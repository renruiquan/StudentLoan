using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UserSchoolEntity
    {
        
        private int _userId;

        /// <summary>
        /// 用户ID 对应sl_users中的user_id
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _xuexinUsername;

        /// <summary>
        ///学信网账号
        /// </summary>
        public string XuexinUsername
        {
            get { return _xuexinUsername; }
            set { _xuexinUsername = value; }
        }
        private string _xuexinPassword;

        /// <summary>
        ///学信网密码
        /// </summary>
        public string XuexinPassword
        {
            get { return _xuexinPassword; }
            set { _xuexinPassword = value; }
        }
        private string _schoolname;

        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName
        {
            get { return _schoolname; }
            set { _schoolname = value; }
        }

        private int _education;

        /// <summary>
        /// 学历 1=本科，2=大专
        /// </summary>
        public int Education
        {
            get { return _education; }
            set { _education = value; }
        }

        private string _major;

        /// <summary>
        /// 专业(系)
        /// </summary>
        public string Major
        {
            get { return _major; }
            set { _major = value; }
        }

        private string _class;

        /// <summary>
        /// 班级
        /// </summary>
        public string Class
        {
            get { return _class; }
            set { _class = value; }
        }

        private int _schoolId;

        /// <summary>
        /// 学校ID 对应sl_base_school中的 school_id
        /// </summary>
        public int SchoolId
        {
            get { return _schoolId; }
            set { _schoolId = value; }
        }

        private string _schoolAddress;

        /// <summary>
        /// 学校地址
        /// </summary>
        public string SchoolAddress
        {
            get { return _schoolAddress; }
            set { _schoolAddress = value; }
        }

        private string _branchSchool;

        /// <summary>
        /// 分校（校区）
        /// </summary>
        public string BranchSchool
        {
            get { return _branchSchool; }
            set { _branchSchool = value; }
        }

        private DateTime _yearOfAdmission;

        /// <summary>
        /// 入学年份
        /// </summary>
        public DateTime YearOfAdmission
        {
            get { return _yearOfAdmission; }
            set { _yearOfAdmission = value; }
        }

        private int _schoolSystem;

        /// <summary>
        /// 学制几年
        /// </summary>
        public int SchoolSystem
        {
            get { return _schoolSystem; }
            set { _schoolSystem = value; }
        }

        private string _dormitory;

        /// <summary>
        /// 寝室
        /// </summary>
        public string Dormitory
        {
            get { return _dormitory; }
            set { _dormitory = value; }
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
        /// 状态 1=启用，0=禁用
        /// </summary>
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
