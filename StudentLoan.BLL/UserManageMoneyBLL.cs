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
    /// dbo.sl_user_manage_money实体
    /// </summary>
    public class UserManageMoneyBLL
    {

        UserManageMoneyDAL dal = new UserManageMoneyDAL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Status)
        {
            return dal.Exists(Status);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Insert(UserManageMoneyEntityEx model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserManageMoneyEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserManageMoneyIDList)
        {
            return dal.DeleteList(UserManageMoneyIDList);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserManageMoneyEntityEx model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserManageMoneyEntityEx GetModel(int buyId)
        {
            return dal.GetModel(buyId);
        }

        /// <summary>
        /// 获取理财统计数据
        /// </summary>
        public UserManageMoneyEntityEx GetStatUserManageMoney(int userId)
        {
            return dal.GetStatUserManageMoney(userId);
        }

        /// <summary>
        /// 获取总待收利息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal WaitTotalInterest(int userId)
        {
            return dal.WaitTotalInterest(userId);
        }

        /// <summary>
        /// 获取总待到期的理财产品数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal WaitTotalCount(int userId)
        {
            return dal.WaitTotalCount(userId);
        }

        /// <summary>
        /// 用户申请转出操作
        /// </summary>
        public bool Withdrawal(UserManageMoneyEntityEx model)
        {
            return dal.Withdrawal(model);
        }

        /// <summary>
        /// 转出时管理员通过审核
        /// </summary>
        public bool PassApplyWithdrawal(UserManageMoneyEntityEx model)
        {
            return dal.PassApplyWithdrawal(model);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserManageMoneyEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

          /// <summary>
        /// 获取导出数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<UserManageMoneyEntityEx> GetExportList(string strWhere)
        {
            return dal.GetExportList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserManageMoneyEntityEx> GetList(int top, string strWhere, string orderby)
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
        /// 获取理财明细记录数
        /// </summary>
        public int GetRecordDetailCount(string strWhere)
        {
            return dal.GetRecordDetailCount(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<UserManageMoneyEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 获取理财明细的分页获取数据列表
        /// </summary>
        public List<UserManageMoneyEntityEx> GetListByDetail(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByDetail(strWhere, orderby, startIndex, endIndex);
        }
    }
}



