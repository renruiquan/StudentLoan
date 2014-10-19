using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentLoan.Common
{
    /// <summary>
    /// CollectionExtension
    /// </summary>
    [Serializable]
    public static class CollectionExtension
    {
        #region Common
        /// <summary>
        /// 是否在集合内
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="target">对象</param>
        /// <param name="c">集合</param>
        /// <returns>true->在,false->不在</returns>
        public static bool In<T>(this T target, IEnumerable<T> c)
        {
            bool result = false;

            if (c != null)
            {
                result = c.Any(i => i.Equals(target));
            }

            return result;
        }
        #endregion

        #region 遍历集合
        /// <summary>
        /// 遍历集合
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="target">集合</param>
        /// <param name="a">操作</param>
        public static void ForEach<T>(this IEnumerable<T> target, Action<T> a)
        {
            foreach (T e in target)
            {
                a(e);
            }
        }

        /// <summary>
        /// 遍历集合
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="target">集合</param>
        /// <param name="a">操作</param>
        public static void ForEach<T>(this IEnumerable<T> target, Action<T, int> a)
        {
            int i = 0;

            foreach (T e in target)
            {
                a(e, i++);
            }
        }
        #endregion
    }
}
