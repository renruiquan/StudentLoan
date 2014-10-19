using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;


namespace StudentLoan.Common
{
    /// <summary>
    /// AdoNetExension
    /// </summary>
    [Serializable]
    public static class AdoNetExension
    {
        #region DataReader
        /// <summary>
        /// 获取实体实例
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="target">数据读取器</param>
        /// <returns>实体实例</returns>
        public static T GetModel<T>(this DbDataReader target) where T : class, new()
        {
            T result = new T();

            PropertyInfo[] propertys = typeof(T).GetProperties();

            foreach (PropertyInfo objPropertyInfo in propertys)
            {
                if (!IsNullOrDBNull(target[objPropertyInfo.Name]))
                {
                    if (objPropertyInfo.CanWrite)
                    {
                        objPropertyInfo.SetValue
                        (
                            result,
                            HackNullableType(target[objPropertyInfo.Name], objPropertyInfo.PropertyType),
                            null
                        );
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 获取实体实例
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="target">数据读取器</param>
        /// <param name="propertyIntoList">属性信息集合</param>
        /// <returns>实体实例</returns>
        public static T GetModel<T>(this DbDataReader target, PropertyInfo[] propertyIntoList) where T : class, new()
        {
            T result = new T();

            foreach (PropertyInfo objPropertyInfo in propertyIntoList)
            {
                if (!IsNullOrDBNull(target[objPropertyInfo.Name]))
                {
                    if (objPropertyInfo.CanWrite)
                    {
                        objPropertyInfo.SetValue
                        (
                            result,
                            HackNullableType(target[objPropertyInfo.Name], objPropertyInfo.PropertyType),
                            null
                        );
                    }
                }
            }

            return result;
        }
        #endregion

        #region Private Static Method
        /// <summary>
        /// 是否为Null
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>true->为Null,false->不为Null</returns>
        private static bool IsNullOrDBNull(object value)
        {
            //return ((value == null) || (value is DBNull) || value.ToString().IsNullOrEmpty());

            return ((value == null) || (value is DBNull));
        }

        /// <summary>
        /// 处理Nullable
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="type">类型</param>
        /// <returns>处理后的值</returns>
        private static object HackNullableType(object value, Type type)
        {
            object result = null;

            if (value != null)
            {
                Type temp = type;

                if (type.IsNullableType())
                {
                    temp = new NullableConverter(type).UnderlyingType;
                }

                result = Convert.ChangeType(value, temp);
            }

            return result;
        }
        #endregion
    }
}
