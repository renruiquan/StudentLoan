using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Common
{
    /// <summary>
    /// 权重类
    /// 备注：源数据集合必须继承BaseRandom类
    /// </summary>
    public static class RandomExtension
    {
        private static Random rand = new Random();

        #region 普通随机抽取
        /// <summary>
        /// 随机抽取
        /// </summary>
        /// <param name="rand">随机数生成器</param>
        /// <returns></returns>
        public static List<T> RandomExtract<T>(this List<T> list, int count)
        {
            if (list == null || list.Count <= count || count <= 0)
            {
                return list;
            }

            List<T> result = new List<T>();
            if (rand != null)
            {
                for (int i = count; i > 0; )
                {
                    T item = list[rand.Next(list.Count)];
                    if (result.Contains(item))
                        continue;
                    else
                    {
                        result.Add(item);
                        i--;
                    }
                }
            }
            return result;
        }
        #endregion

        #region 受控随机抽取
        /// <summary>
        /// 随机抽取
        /// </summary>
        /// <param name="rand">随机数生成器</param>
        /// <returns></returns>
        public static List<T> RandomExtractByWeight<T>(this List<T> list, int count) where T : BaseRandom
        {
            if (list == null || list.Count <= count || count <= 0)
            {
                return list;
            }

            List<T> result = new List<T>();

            if (rand != null)
            {
                //临时变量
                Dictionary<T, int> dict = new Dictionary<T, int>();

                //为每个项算一个随机数并乘以相应的权值
                foreach (T item in list)
                {
                    dict.Add(item, rand.Next(100) * item.Weight);
                }

                //排序
                List<KeyValuePair<T, int>> listDict = SortByValue(dict);

                //拷贝抽取权值最大的前Count项
                foreach (KeyValuePair<T, int> kvp in listDict.GetRange(0, count))
                {
                    result.Add(kvp.Key);
                }
            }
            return result;
        }
        #endregion

        #region Tools
        /// <summary>
        /// 排序集合
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        private static List<KeyValuePair<T, int>> SortByValue<T>(Dictionary<T, int> dict)
        {
            List<KeyValuePair<T, int>> list = new List<KeyValuePair<T, int>>();

            if (dict != null)
            {
                list.AddRange(dict);

                list.Sort(
                  delegate(KeyValuePair<T, int> kvp1, KeyValuePair<T, int> kvp2)
                  {
                      return kvp2.Value - kvp1.Value;
                  });
            }
            return list;
        }
        #endregion
    }

    /// <summary>
    /// 权重基类
    /// </summary>
    public class BaseRandom
    {
        /// <summary>
        /// 权重
        /// </summary>
        public int Weight { set; get; }
    }
}
