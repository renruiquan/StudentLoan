using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace StudentLoan.Common
{
    /// <summary>
    /// 页面类
    /// </summary>
    public static class PageExtension
    {
        /// <summary>
        /// Javascript中的Alert方法
        /// </summary>
        /// <param name="objPage"></param>
        /// <param name="message"></param>
        public static void Alert(this Page objPage, string message)
        {
            string key = "AlertMessage";
            string script = string.Format("alert('{0}')", message);
            objPage.ClientScript.RegisterStartupScript(typeof(Page), key, script, true);
        }

        /// <summary>
        /// Javascript中的Alert方法
        /// </summary>
        /// <param name="objPage"></param>
        /// <param name="message"></param>
        /// <param name="url"></param>
        public static void Alert(this Page objPage, string message, string url)
        {
            string key = "AlertMessage";
            string script = String.Format("alert('{0}');window.location='{1}';", message, url);
            objPage.ClientScript.RegisterStartupScript(typeof(Page), key, script, true);
        }


        /// <summary>
        /// 动态调用artDialog插件
        /// </summary>
        /// <param name="objPage"></param>
        /// <param name="content">内容</param>
        /// <param name="title">标题</param>
        /// <param name="isModal">是否显示遮罩</param>
        public static void artDialog(this Page objPage, string content, bool isModal = true)
        {
            string key = "artDialog";
            StringBuilder script = new StringBuilder();
            script.AppendFormat(@"var d = dialog({{");
            script.AppendFormat(@"title: '消息',content:'{0}',width:320}});", content);

            if (isModal)
            {
                script.Append("d.showModal();");
            }
            else
            {
                script.Append("d.show();");
            }

            objPage.ClientScript.RegisterStartupScript(typeof(Page), key, script.ToString(), true);
        }


        /// <summary>
        /// 动态调用artDialog插件
        /// </summary>
        /// <param name="objPage"></param>
        /// <param name="content">内容</param>
        /// <param name="title">标题</param>
        /// <param name="isModal">是否显示遮罩</param>
        public static void artDialog(this Page objPage, string title, string content, bool isModal = true)
        {
            string temp_title = "消息";

            if (!string.IsNullOrEmpty(title))
            {
                temp_title = title;
            }

            string key = "artDialog";
            StringBuilder script = new StringBuilder();
            script.AppendFormat(@"var d = dialog({{");
            script.AppendFormat(@"title: '{0}',content:'{1}',width:320}});", temp_title, content);

            if (isModal)
            {
                script.Append("d.showModal();");
            }
            else
            {
                script.Append("d.show();");
            }

            objPage.ClientScript.RegisterStartupScript(typeof(Page), key, script.ToString(), true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objPage"></param>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="title"></param>
        /// <param name="isModal"></param>
        public static void artDialog(this Page objPage, string title, string content, string url, bool isModal = true)
        {
            string temp_title = "消息";

            if (!string.IsNullOrEmpty(title))
            {
                temp_title = title;
            }

            string key = "artDialog";
            StringBuilder script = new StringBuilder();
            script.AppendFormat(@"var d = dialog({{");
            script.AppendFormat(@"onclose:function(){{ window.location.href='{0}'; }},", url);
            script.AppendFormat(@"title: '{0}',content:'{1}',width:320}});", temp_title, content);

            if (isModal)
            {
                script.Append("d.showModal();");
            }
            else
            {
                script.Append("d.show();");
            }

            objPage.ClientScript.RegisterStartupScript(typeof(Page), key, script.ToString(), true);
        }


        /// <summary>
        /// 获取请求参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objPage"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="needUrlEncode"></param>
        /// <returns></returns>
        public static T Request<T>(this Page objPage, string key, T defaultValue = default(T), bool needUrlEncode = false)
        {
            T result = (T)defaultValue;

            if (needUrlEncode)
            {
                return objPage.Request.Params[key].UrlEncode().Convert<T>(result);
            }

            return objPage.Request.Params[key].Convert<T>(defaultValue);
        }

        /// <summary>
        /// 获取请求参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objHandler"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <param name="needUrlEncode"></param>
        /// <returns></returns>
        public static T Request<T>(this IHttpHandler objHandler, string key, object defaultValue, bool needUrlEncode = false)
        {
            T result = (T)defaultValue;

            if (needUrlEncode)
            {
                return HttpContext.Current.Request.Params[key].UrlEncode().Convert<T>(result);

            }

            return HttpContext.Current.Request.Params[key].Convert<T>(result);
        }

        #region 读取或写入cookie
        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(this Page objPage, string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(this Page objPage, string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(this Page objPage, string strName, string key, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="strValue">过期时间(分钟)</param>
        public static void WriteCookie(this Page objPage, string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(this Page objPage, string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName].Value.ToString());
            return "";
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(this Page objPage, string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
                return UrlDecode(HttpContext.Current.Request.Cookies[strName][key].ToString());

            return "";
        }
        #endregion

        #region URL处理
        /// <summary>
        /// URL字符编码
        /// </summary>
        public static string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            str = str.Replace("'", "");
            return HttpContext.Current.Server.UrlEncode(str);
        }

        /// <summary>
        /// URL字符解码
        /// </summary>
        public static string UrlDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return HttpContext.Current.Server.UrlDecode(str);
        }


        #endregion
    }
}
