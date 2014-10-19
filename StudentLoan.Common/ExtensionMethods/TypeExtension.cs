using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Common
{
    /// <summary>
    /// TypeExtension
    /// </summary>
    [Serializable]
    public static class TypeExtension
    {
        #region Public Static Method
        /// <summary>
        /// 是否是可空类型
        /// </summary>
        /// <param name="target">类型</param>
        /// <returns>true->可空,false->不可空</returns>
        public static bool IsNullableType(this Type target)
        {
            return
            (
                ((target != null) && target.IsGenericType) &&
                (target.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            );
        }
        #endregion
    }
}
