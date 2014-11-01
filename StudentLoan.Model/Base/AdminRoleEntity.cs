using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class AdminRoleEntity
    {

        private int _roleId;

        /// <summary>
        /// 自增 角色ID
        /// </summary>
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        private string _roleName;

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }

        private int _roleType;

        /// <summary>
        /// 角色类型
        /// </summary>
        public int RoleType
        {
            get { return _roleType; }
            set { _roleType = value; }
        }

        private int _isSystem;

        /// <summary>
        /// 是否系统默认0否1是
        /// </summary>
        public int IsSystem
        {
            get { return _isSystem; }
            set { _isSystem = value; }
        }

        private List<AdminRoleValueEntity> _adminRoleValues;
        /// <summary>
        /// 权限子类 
        /// </summary>
        public List<AdminRoleValueEntity> AdminRoleValues
        {
            set { _adminRoleValues = value; }
            get { return _adminRoleValues; }
        }
    }
}
