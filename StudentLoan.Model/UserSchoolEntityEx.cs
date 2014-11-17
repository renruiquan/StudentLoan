using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Model.Base;

namespace StudentLoan.Model
{
    public class UserSchoolEntityEx : UserSchoolEntity
    {
       //扩展字段全部在 XXXXEntityEx.cs类里添加

        /// <summary>
        /// 填写学校信息所获得的信用积分
        /// </summary>
        public int Point { get; set; }
    }
}
