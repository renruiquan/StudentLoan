//作者：Brazelren
//日期：2014/9/28 0:30:57

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
    /// dbo.sl_user_repayment实体
    /// </summary>
    public class UserRepaymentBLL
    {

        UserRepaymentDAL dal = new UserRepaymentDAL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int loanId, int currentAmortization)
        {
            return dal.Exists(loanId, currentAmortization);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserRepaymentEntityEx model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserRepaymentEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserRepaymentIDList)
        {
            return dal.DeleteList(UserRepaymentIDList);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserRepaymentEntityEx model, UserLoanEntityEx userLoanModel)
        {
            return dal.Update(model, userLoanModel);
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserRepaymentEntityEx GetModel(int loanId, int currentAmortization)
        {
            return dal.GetModel(loanId, currentAmortization);
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserRepaymentEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserRepaymentEntityEx> GetList(int top, string strWhere, string orderby)
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
        public List<UserRepaymentEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}



