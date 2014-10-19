using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class AdminRoleValueEntity
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

        private int _roleId;

        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        private string _navName;

        /// <summary>
        /// 导航名称
        /// </summary>
        public string NavName
        {
            get { return _navName; }
            set { _navName = value; }
        }

        private string _actionType;

        /// <summary>
        /// 权限类型
        /// </summary>
        public string ActionType
        {
            get { return _actionType; }
            set { _actionType = value; }
        }

    }
}
