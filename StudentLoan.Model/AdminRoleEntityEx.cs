using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    public class AdminRoleEntityEx : AdminRoleEntity
    {
        //扩展字段全部在 XXXXEntityEx.cs类里添加

        /// <summary>
        /// 角色权限集合
        /// </summary>
        public List<AdminRoleValueEntityEx> AdminRoleValueList { get; set; }
    }
}
