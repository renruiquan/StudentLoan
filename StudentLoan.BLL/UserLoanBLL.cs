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
    /// dbo.sl_user_loan实体
    /// </summary>
    public class UserLoanBLL
    {

        UserLoanDAL dal = new UserLoanDAL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PassTime)
        {
            return dal.Exists(PassTime);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserLoanEntityEx model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserLoanEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserLoanIDList)
        {
            return dal.DeleteList(UserLoanIDList);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserLoanEntityEx model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 更新一条数据 管理员放款操作
        /// </summary>
        public bool UpdateByAdmin(UserLoanEntityEx model)
        {
            //管理员放款后，将贷款金额直接打到用户账号中
            int status = new UserLoanDAL().GetModel(model.LoanId).Status;
            //防止重复放款
            if (status != model.Status)
            {
                return dal.UpdateByAdmin(model);
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserLoanEntityEx GetModel(int loanId)
        {
            return dal.GetModel(loanId);
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserLoanEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserLoanEntityEx> GetList(int top, string strWhere, string orderby)
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
        public List<UserLoanEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}



