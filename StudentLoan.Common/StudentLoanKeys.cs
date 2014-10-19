using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Common
{
    public sealed class StudentLoanKeys
    {
        //Session=====================================================
        /// <summary>
        /// 网页验证码
        /// </summary>
        public const string SESSION_CODE = "sl_session_code";
        /// <summary>
        /// 短信验证码
        /// </summary>
        public const string SESSION_SMS_CODE = "sl_session_sms_code";
        /// <summary>
        /// 后台管理员
        /// </summary>
        public const string SESSION_ADMIN_INFO = "sl_session_admin_info";
        /// <summary>
        /// 会员用户
        /// </summary>
        public const string SESSION_USER_INFO = "sl_session_user_info";

        /// <summary>
        /// 用户登录错误次数
        /// </summary>
        public const string SESSION_USER_LOGIN_SUM = "sl_session_user_login_sum";

        /// <summary>
        /// 管理员登录错误次数
        /// </summary>
        public const string SESSION_ADMIN_LOGIN_SUM = "sl_session_admin_login_sum";

        //Cookies=====================================================
        /// <summary>
        /// 防重复评论KEY
        /// </summary>
        public const string COOKIE_COMMENT_KEY = "sl_cookie_comment_key";
        /// <summary>
        /// 防止下载重复扣各分
        /// </summary>
        public const string COOKIE_DOWNLOAD_KEY = "sl_download_attach_key";
        /// <summary>
        /// 记住会员用户名
        /// </summary>
        public const string COOKIE_USER_NAME_REMEMBER = "sl_cookie_user_name_remember";
        /// <summary>
        /// 记住会员密码
        /// </summary>
        public const string COOKIE_USER_PWD_REMEMBER = "sl_cookie_user_pwd_remember";
        /// <summary>
        /// 返回上一页
        /// </summary>
        public const string COOKIE_URL_REFERRER = "dt_cookie_url_referrer";
    }
}
