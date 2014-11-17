using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    public class UserRelationshipEntityEx : UserRelationshipEntity
    {
        //扩展字段全部在 XXXXEntityEx.cs类里添加

        /// <summary>
        /// 填写用户联系人获取积分
        /// </summary>
        public int Point { get; set; }
    }
}
