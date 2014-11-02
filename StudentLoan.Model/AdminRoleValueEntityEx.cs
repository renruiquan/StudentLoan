using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    public class AdminRoleValueEntityEx : AdminRoleValueEntity
    {
        //扩展字段全部在 XXXXEntityEx.cs类里添加

        /// <summary>
        /// 导航菜单标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 导航URl地址
        /// </summary>
        public string LinkUrl { get; set; }
    }
}
