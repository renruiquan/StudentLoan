//作者：Brazelren
//日期：2014/9/13 13:06:21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StudentLoan.Common;
using StudentLoan.Model;
using StudentLoan.DAL;

namespace StudentLoan.BLL
{
    /// <summary>
    /// dbo.sl_admin实体
    /// </summary>
    public class AdminBLL
    {

        AdminDAL dal = new AdminDAL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string adminName)
        {
            return dal.Exists(adminName);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(AdminEntityEx model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(AdminEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string AdminIDList)
        {
            return dal.DeleteList(AdminIDList);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdminEntityEx model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePassword(AdminEntityEx model)
        {
            return dal.UpdatePassword(model);
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public AdminEntityEx GetModel(int adminId)
        {
            return dal.GetModel(adminId);
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        public AdminEntityEx GetModel(string userName, string password, bool isEncrypt)
        {
            //检查一下是否需要加密
            if (isEncrypt)
            {
                //先取得该用户的随机密钥
                string salt = dal.GetSalt(userName);
                if (string.IsNullOrEmpty(salt))
                {
                    return null;
                }
                //把明文进行加密重新赋值
                password = DESHelper.Encrypt(password, salt);
            }

            return dal.GetModel(userName, password);
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public List<AdminEntityEx> GetListByCache(string strWhere)
        {
            List<AdminEntityEx> adminList = CacheHelper.Get<List<AdminEntityEx>>("AdminList");

            if (adminList == null)
            {
                adminList = this.GetList(strWhere);

                CacheHelper.Set("AdminList", adminList);
            }

            return adminList;
        }


        /// <summary>
        /// 获取管理员字典列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetAdminDictionary(string strWhere)
        {
            if (CacheHelper.Get<Dictionary<int, string>>("AdminDictionary") == null)
            {
                Dictionary<int, string> dic = this.GetList(strWhere).ToDictionary(s => s.AdminId, s => s.AdminName);

                CacheHelper.Set("AdminDictionary", dic);

                return dic;
            }
            else
            {
                return CacheHelper.Get<Dictionary<int, string>>("AdminDictionary");
            }


        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminEntityEx> GetList(int top, string strWhere, string orderby)
        {
            return dal.GetList(top, strWhere, orderby);
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<AdminEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}



