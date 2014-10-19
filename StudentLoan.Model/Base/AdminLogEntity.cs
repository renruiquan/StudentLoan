using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class AdminLogEntity
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

        private int _adminId;

        /// <summary>
        /// 管理员ID
        /// </summary>
        public int AdminId
        {
            get { return _adminId; }
            set { _adminId = value; }
        }

        private string _adminName;

        /// <summary>
        /// 管理员名称
        /// </summary>
        public string AdminName
        {
            get { return _adminName; }
            set { _adminName = value; }
        }

        private string _actionType;

        /// <summary>
        /// 操作类型
        /// </summary>
        public string ActionType
        {
            get { return _actionType; }
            set { _actionType = value; }
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

        private string _userIP;

        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserIP
        {
            get { return _userIP; }
            set { _userIP = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 操作时间
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

    }
}
