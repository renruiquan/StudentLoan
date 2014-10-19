using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace StudentLoan.Common
{
    /// <summary>
    /// CacheHelper
    /// </summary>
    [Serializable]
    public class CacheHelper
    {
        #region Public Static Method
        /// <summary>
        /// 根据缓存键获取缓存项
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns>缓存项</returns>
        public static T Get<T>(string key)
        {
            T result = default(T);

            if (HttpRuntime.Cache[key] != null)
            {
                result = HttpRuntime.Cache[key].Convert<T>();
            }

            return result;
        }
        /// <summary>
        /// 设置缓存项
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存值</param>
        public static void Set(string key, object value)
        {
            if (HttpRuntime.Cache[key] != null)
            {
                HttpRuntime.Cache.Insert(key, value);
            }

            else
            {
                HttpRuntime.Cache.Add
                (
                    key,
                    value,
                    null,
                    DateTime.Now.AddHours(1.0),
                    TimeSpan.Zero,
                    CacheItemPriority.NotRemovable,
                    null
                );
            }
        }
        /// <summary>
        /// 根据缓存键移除缓存项
        /// </summary>
        /// <param name="key">缓存键</param>
        public static void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
        /// <summary>
        /// 根据关键字移除缓存项
        /// </summary>
        /// <param name="keyword">关键字</param>
        public static void RemoveByKeyword(string keyword)
        {
            IDictionaryEnumerator objEnumerators = HttpRuntime.Cache.GetEnumerator();

            while (objEnumerators.MoveNext())
            {
                if (objEnumerators.Key.ToString().ToLower().Contains(keyword.ToLower()))
                {
                    HttpRuntime.Cache.Remove(objEnumerators.Key.ToString());
                }
            }
        }
        /// <summary>
        /// 移除全部缓存项
        /// </summary>
        public static void RemoveAll()
        {
            IDictionaryEnumerator objEnumerators = HttpRuntime.Cache.GetEnumerator();

            while (objEnumerators.MoveNext())
            {
                HttpRuntime.Cache.Remove(objEnumerators.Key.ToString());
            }
        }
        #endregion
    }
}
