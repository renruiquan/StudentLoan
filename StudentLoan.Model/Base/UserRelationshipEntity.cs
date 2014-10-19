using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UserRelationshipEntity
    {
        
        private int _userId;

        /// <summary>
        /// 用户ID 对应sl_users中的user_id
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _name;

        /// <summary>
        /// 与用户关系人的姓名
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _relationship;

        /// <summary>
        /// 与用户的关系
        /// </summary>
        public string Relationship
        {
            get { return _relationship; }
            set { _relationship = value; }
        }

        private string _mobile;

        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private string _profession;

        /// <summary>
        /// 职业
        /// </summary>
        public string Profession
        {
            get { return _profession; }
            set { _profession = value; }
        }

        private string _address;

        /// <summary>
        /// 工作单位、居住地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private int _type;

        /// <summary>
        /// 关系类型  0=直系亲属，1=其他亲属，2=同班同学，3=同寝同学，4=朋友1,5=朋友2
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
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

        private System.DateTime _createTime;

        /// <summary>
        /// 建档日期
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

    }
}
