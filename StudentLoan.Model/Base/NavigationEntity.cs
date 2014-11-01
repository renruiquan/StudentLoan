using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class NavigationEntity
    {
        /// <summary>
        /// 导航ID
        /// </summary>
        public int NavId { get; set; }

        /// <summary>
        /// 标题 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkUrl { get; set; }
    }
}
