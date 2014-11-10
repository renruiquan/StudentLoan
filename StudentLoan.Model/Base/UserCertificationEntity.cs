using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UserCertificationEntity
    {
        
        private int _id;

        /// <summary>
        /// 主键 自增
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

        private int _type;

        /// <summary>
        /// 信息类型 0=基本信息，1=必要信用认证，2=可选信用认证，3=学子易贷记录
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _certificationName;

        /// <summary>
        /// 认证名称
        /// </summary>
        public string CertificationName
        {
            get { return _certificationName; }
            set { _certificationName = value; }
        }

        private string _images;

        /// <summary>
        /// 认证相关证件图片
        /// </summary>
        public string Images
        {
            get { return _images; }
            set { _images = value; }
        }

        private int _point;

        /// <summary>
        /// 信用积分
        /// </summary>
        public int Point
        {
            get { return _point; }
            set { _point = value; }
        }

        private int _count;

        /// <summary>
        /// 还清笔数、逾期次数、严重逾期次数
        /// </summary>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private byte _status;

        /// <summary>
        /// 状态 0=待完成，1=已完成
        /// </summary>
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
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
        /// 认证时间
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

    }
}
