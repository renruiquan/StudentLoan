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
    /// dbo.sl_user_earnings实体
    /// </summary>
    public class UserEarningsBLL
    {

        UserEarningsDAL dal = new UserEarningsDAL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CreateTime)
        {
            return dal.Exists(CreateTime);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserEarningsEntityEx model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserEarningsEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserEarningsIDList)
        {
            return dal.DeleteList(UserEarningsIDList);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserEarningsEntityEx model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserEarningsEntityEx GetModel(int CreateTime)
        {
            return dal.GetModel(CreateTime);
        }


        /// <summary>
        /// 获取用户累计收益
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public decimal GetTotalEarnings(int userId)
        {
            return dal.GetTotalEarnings(userId);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserEarningsEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserEarningsEntityEx> GetList(int top, string strWhere, string orderby)
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
        public List<UserEarningsEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}



