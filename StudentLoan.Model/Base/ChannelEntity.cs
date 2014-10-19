using StudentLoan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class ChannelEntity : BaseRandom
    {

        private int _channelId;

        /// <summary>
        /// 充值渠道ID
        /// </summary>
        public int ChannelId
        {
            get { return _channelId; }
            set { _channelId = value; }
        }

        private string _channelName;

        /// <summary>
        /// 充值渠道名称
        /// </summary>
        public string ChannelName
        {
            get { return _channelName; }
            set { _channelName = value; }
        }

        private string _channelFlag;

        /// <summary>
        /// 充值渠道标识
        /// </summary>
        public string ChannelFlag
        {
            get { return _channelFlag; }
            set { _channelFlag = value; }
        }

        private string _appId;

        /// <summary>
        /// 充值渠道提供的APPID
        /// </summary>
        public string AppId
        {
            get { return _appId; }
            set { _appId = value; }
        }

        private string _appKey;

        /// <summary>
        /// 充值渠道提供的AppKey
        /// </summary>
        public string AppKey
        {
            get { return _appKey; }
            set { _appKey = value; }
        }

        private decimal _rate;

        /// <summary>
        /// 费率
        /// </summary>
        public decimal Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

   
        private string _requestUrl;

        /// <summary>
        /// 充值接口请求地址
        /// </summary>
        public string RequestUrl
        {
            get { return _requestUrl; }
            set { _requestUrl = value; }
        }

        private byte _status;

        /// <summary>
        /// 状态 0=禁用，1=启用
        /// </summary>
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _remark;

        /// <summary>
        /// 备注信息
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
