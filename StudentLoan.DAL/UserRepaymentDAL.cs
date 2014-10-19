//作者：Brazelren
//日期：2014/9/28 0:58:29

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StudentLoan.Common;
using StudentLoan.Model;

namespace StudentLoan.DAL
{
    /// <summary>
    /// dbo.sl_user_repayment实体
    /// </summary>
    public class UserRepaymentDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int loanId, int currentAmortization)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select  From sl_user_repayment Where  LoanId= @LoanId and CurrentAmortization = @CurrentAmortization");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@LoanId", loanId));

            paramsList.Add(new SqlParameter("@CurrentAmortization", currentAmortization));

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString()) > 0 ? true : false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserRepaymentEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_user_repayment( ");

            commandText.Append(" LoanId,CurrentAmortization,RepaymentMoney,BreakContract,RepaymentTime,Status) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @LoanId,@CurrentAmortization,@RepaymentMoney,@BreakContract,@RepaymentTime,@Status) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@LoanId", model.LoanId));

            paramsList.Add(new SqlParameter("@CurrentAmortization", model.CurrentAmortization));

            paramsList.Add(new SqlParameter("@RepaymentMoney", model.RepaymentMoney));

            paramsList.Add(new SqlParameter("@BreakContract", model.BreakContract));

            paramsList.Add(new SqlParameter("@RepaymentTime", model.RepaymentTime));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserRepaymentEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_repayment ");

            commandText.Append(" Where  LoanID= @LoanID and CurrentAmortization=@CurrentAmortization ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@LoanId", model.LoanId));

            paramsList.Add(new SqlParameter("@CurrentAmortization", model.CurrentAmortization));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserRepaymentIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_repayment ");

            commandText.Append("Where LoanId in (" + UserRepaymentIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserRepaymentEntityEx model, UserLoanEntityEx userLoanModel)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            /**更新账户余额**/
            commandText.Append(@" Update sl_users Set Amount -= @Amount where UserId = @UserId;");

            /**更新还款期数**/
            commandText.Append(" Update sl_user_loan Set ");

            commandText.Append(" AlreadyAmortization += 1 ");

            commandText.Append(" Where LoanId = @LoanId ");

            /**更新还款详情**/
            commandText.Append(" Update sl_user_repayment Set ");

            commandText.Append(" LoanId = @LoanId, ");

            commandText.Append(" CurrentAmortization = @CurrentAmortization, ");

            commandText.Append(" RepaymentMoney = @RepaymentMoney, ");

            commandText.Append(" BreakContract = @BreakContract, ");

            commandText.Append(" CreateTime = @CreateTime, ");

            commandText.Append(" Status = @Status ");

            commandText.Append(" Where LoanId = @LoanId and  CurrentAmortization=@CurrentAmortization");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userLoanModel.UserId));

            paramsList.Add(new SqlParameter("@Amount", model.RepaymentMoney));

            paramsList.Add(new SqlParameter("@LoanId", model.LoanId));

            paramsList.Add(new SqlParameter("@CurrentAmortization", model.CurrentAmortization));

            paramsList.Add(new SqlParameter("@RepaymentMoney", model.RepaymentMoney));

            paramsList.Add(new SqlParameter("@BreakContract", model.BreakContract));

            paramsList.Add(new SqlParameter("@CreateTime", DateTime.Now));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            #endregion

            SqlTransaction trans = base.GetTransaction();

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserRepaymentEntityEx GetModel(int loanId, int currentAmortization)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 LoanId,CurrentAmortization,RepaymentMoney,BreakContract,RepaymentTime,CreateTime,Status From sl_user_repayment Where LoanId = @LoanId and  CurrentAmortization = @CurrentAmortization ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@LoanId", loanId));

            paramsList.Add(new SqlParameter("@CurrentAmortization", currentAmortization));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserRepaymentEntityEx>() as UserRepaymentEntityEx;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserRepaymentEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ,LoanId,CurrentAmortization,RepaymentMoney,BreakContract,RepaymentTime,CreateTime,Status ");

            commandText.Append("From sl_user_repayment ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserRepaymentEntityEx>() as List<UserRepaymentEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserRepaymentEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" ,LoanId,CurrentAmortization,RepaymentMoney,BreakContract,RepaymentTime,CreateTime,Status ");

            commandText.Append("From sl_user_repayment ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} ", orderby.Replace("-", ""));
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserRepaymentEntityEx>() as List<UserRepaymentEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_repayment T,sl_user_loan a,sl_product b");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE t.LoanId = a.LoanId and a.ProductId=b.ProductId and {0}", strWhere);
            }

            #endregion

            #region SqlParameters

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<UserRepaymentEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select * from ( ");

            commandText.Append(" Select ROW_NUMBER() OVER ( ");

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                commandText.AppendFormat(" Order By T.{0} ", orderby);
            }
            else
            {
                commandText.Append(" Order By T.LoanID Desc");
            }

            commandText.Append(" )AS Row, T.* , a.TotalAmortization,a.LoanTypeId,a.LoanNo,a.LoanMoney,a.AnnualFee,a.AlreadyAmortization,b.ProductName ");

            commandText.Append(" From sl_user_repayment T,sl_user_loan a,sl_product b");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE t.LoanId = a.LoanId and a.ProductId=b.ProductId and {0}", strWhere);
            }

            commandText.Append(" ) TT");

            commandText.Append(" WHERE TT.Row between @startIndex and @endIndex");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@startIndex", startIndex));

            paramsList.Add(new SqlParameter("@endIndex", endIndex));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToList<UserRepaymentEntityEx>() as List<UserRepaymentEntityEx>;
            }
        }
    }
}



