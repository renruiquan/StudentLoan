using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UserMessageEntity
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

        private byte _type;

        /// <summary>
        /// 短信息类型 0=系统消息,1=收件箱,2=发件箱
        /// </summary>
        public byte Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _postUserName;

        /// <summary>
        /// 发件人
        /// </summary>
        public string PostUserName
        {
            get { return _postUserName; }
            set { _postUserName = value; }
        }

        private string _acceptUserName;

        /// <summary>
        /// 收件人
        /// </summary>
        public string AcceptUserName
        {
            get { return _acceptUserName; }
            set { _acceptUserName = value; }
        }

        private byte _isRead;

        /// <summary>
        /// 是否查看 0=未阅,1=已阅
        /// </summary>
        public byte IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }

        private string _title;

        /// <summary>
        /// 短信息标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _content;

        /// <summary>
        /// 短信息内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 发送时间
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private System.DateTime _readTime;

        /// <summary>
        /// 阅读时间
        /// </summary>
        public System.DateTime ReadTime
        {
            get { return _readTime; }
            set { _readTime = value; }
        }

    }
}
