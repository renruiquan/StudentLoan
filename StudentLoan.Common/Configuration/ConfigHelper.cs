using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace StudentLoan.Common
{
    /// <summary>
    /// 获取或设置Web.config类
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// 获取AppSettings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T AppSettings<T>(string key, T defaultValue = default(T))
        {
            T result = default(T);

            if (!string.IsNullOrEmpty(key))
            {
                try
                {
                    result = (T)System.Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T), CultureInfo.InvariantCulture);
                }
                catch
                {
                    return defaultValue;
                }
            }

            return result;
        }


        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ConnectionStrings(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key] != null)
            {
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            return null;
        }
    }
}
