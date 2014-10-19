using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UserLoginLogEntity
    {
        
        private int _id;

        /// <summary>
        /// 自增ID
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

        private string _userName;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _remark;

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 登录时间
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private string _loginIP;

        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIP
        {
            get { return _loginIP; }
            set { _loginIP = value; }
        }

    }
}
