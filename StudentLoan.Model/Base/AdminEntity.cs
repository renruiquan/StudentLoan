using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class AdminEntity
    {
        
        private int _adminId;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int AdminId
        {
            get { return _adminId; }
            set { _adminId = value; }
        }

        private int _roleId;

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        
        private string _adminName;

        /// <summary>
        /// 用户名
        /// </summary>
        public string AdminName
        {
            get { return _adminName; }
            set { _adminName = value; }
        }

        private string _password;

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _salt;

        /// <summary>
        /// 6位随机字符串,加密用到
        /// </summary>
        public string Salt
        {
            get { return _salt; }
            set { _salt = value; }
        }

        private string _realName;

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string RealName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        private string _telephone;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        private string _email;

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _isLock;

        /// <summary>
        /// 是否锁定
        /// </summary>
        public int IsLock
        {
            get { return _isLock; }
            set { _isLock = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 添加时间
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

    }
}
