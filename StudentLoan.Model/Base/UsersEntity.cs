using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class UsersEntity
    {
        
        private int _userId;

        /// <summary>
        /// 用户ID主键自增长
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _groupId;

        /// <summary>
        /// 用户组别
        /// </summary>
        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        private string _userName;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _nickName;

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string NickName
        {
            get { return _nickName; }
            set { _nickName = value; }
        }

        private string _trueName;

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName
        {
            get { return _trueName; }
            set { _trueName = value; }
        }

        private string _password;

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private string _drawMoneyPassword;

        /// <summary>
        /// 提现密码
        /// </summary>
        public string DrawMoneyPassword
        {
            get { return _drawMoneyPassword; }
            set { _drawMoneyPassword = value; }
        }

        private string _salt;

        /// <summary>
        /// 6位随机字符串,加密用到
        /// </summary>
        public string Salt
        {
            get { return _salt; }
            set { _salt = value; }
        }

        private string _email;

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _identityCard;

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdentityCard
        {
            get { return _identityCard; }
            set { _identityCard = value; }
        }

        private string _avatar;

        /// <summary>
        /// 用户头像
        /// </summary>
        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        private string _gender;

        /// <summary>
        /// 用户性别
        /// </summary>
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _nation;

        /// <summary>
        /// 民族
        /// </summary>
        public string Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }

        private System.DateTime _birthday;

        /// <summary>
        /// 生日
        /// </summary>
        public System.DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        private string _telphone;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telphone
        {
            get { return _telphone; }
            set { _telphone = value; }
        }

        private string _mobile;

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        private string _qq;

        /// <summary>
        /// QQ号码
        /// </summary>
        public string Qq
        {
            get { return _qq; }
            set { _qq = value; }
        }

        private string _country;

        /// <summary>
        /// 用户所在国家
        /// </summary>
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private string _province;

        /// <summary>
        /// 用户所在省份
        /// </summary>
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }

        private string _city;

        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _address;

        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _safeQuestion;

        /// <summary>
        /// 安全问题
        /// </summary>
        public string SafeQuestion
        {
            get { return _safeQuestion; }
            set { _safeQuestion = value; }
        }

        private string _safeAnswer;

        /// <summary>
        /// 问题答案
        /// </summary>
        public string SafeAnswer
        {
            get { return _safeAnswer; }
            set { _safeAnswer = value; }
        }

        private decimal _amount;

        /// <summary>
        /// 用户余额
        /// </summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private int _point;

        /// <summary>
        /// 用户积分
        /// </summary>
        public int Point
        {
            get { return _point; }
            set { _point = value; }
        }

        private int _exp;

        /// <summary>
        /// 经验值
        /// </summary>
        public int Exp
        {
            get { return _exp; }
            set { _exp = value; }
        }

        private int _status;

        /// <summary>
        /// 用户状态,0正常,1待验证,2待审核,3锁定
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private System.DateTime _createTime;

        /// <summary>
        /// 注册时间
        /// </summary>
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }

        private string _regIP;

        /// <summary>
        /// 注册IP
        /// </summary>
        public string RegIP
        {
            get { return _regIP; }
            set { _regIP = value; }
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

        /// <summary>
        /// 用户资料是否可以更新，0=否，1=是
        /// </summary>
        public int CanModify { get; set; }
    }
}
