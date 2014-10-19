//作者：Brazelren
//日期：2014/9/13 18:28:27

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
    /// dbo.sl_user_loan实体
    /// </summary>
    public class UserLoanDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int LoanId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select LoanId From sl_user_loan Where LoanId = @LoanId");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@LoanId", LoanId));

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString()) > 0 ? true : false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserLoanEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" DECLARE @i int,@LoanId int; set @i = 1;");

            commandText.Append(" Insert Into sl_user_loan( ");

            commandText.Append(" LoanNo, ProductId, UserId,LoanTitle,LoanMoney,LoanTypeId,LoanCategory,ShouldRepayMoney,TotalAmortization,LoanDescription) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @LoanNo,@ProductId,@UserId,@LoanTitle,@LoanMoney,@LoanTypeId,@LoanCategory,@ShouldRepayMoney,@TotalAmortization,@LoanDescription); ");

            commandText.Append(@"SELECT @LoanId= @@IDENTITY; ");

            commandText.Append(@" while @i<= @TotalAmortization");

            commandText.Append(@" Begin ");

            commandText.Append(" Insert Into sl_user_repayment( ");

            commandText.Append(" LoanId,CurrentAmortization,RepaymentMoney,BreakContract,RepaymentTime,Status) ");

            commandText.Append(" Values ( ");

            commandText.Append(@" @LoanId,@i,0,0,DATEADD(Month,@i,getdate()),0); ");

            commandText.Append(@" set @i+=1;");

            commandText.Append(@" End; ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@LoanNo", model.LoanNo));

            paramsList.Add(new SqlParameter("@ProductId", model.ProductId));

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@LoanTitle", model.LoanTitle));

            paramsList.Add(new SqlParameter("@LoanMoney", model.LoanMoney));

            paramsList.Add(new SqlParameter("@LoanTypeId", model.LoanTypeId));

            paramsList.Add(new SqlParameter("@LoanCategory", model.LoanCategory));

            paramsList.Add(new SqlParameter("@ShouldRepayMoney", model.ShouldRepayMoney));

            paramsList.Add(new SqlParameter("@TotalAmortization", model.TotalAmortization));

            paramsList.Add(new SqlParameter("@LoanDescription", model.LoanDescription));

            #endregion

            SqlTransaction trans = base.GetTransaction();

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserLoanEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_loan ");

            commandText.Append(" Where LoanId = @LoanId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@LoanId", model.LoanId));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserLoanIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_loan ");

            commandText.Append("Where LoanId in (" + UserLoanIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserLoanEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(@" Update sl_users Set Amount -= @Amount where UserId = @UserId;");

            commandText.Append(" Update sl_user_loan Set ");

            commandText.Append(" AlreadyAmortization += 1 ");

            commandText.Append(" Where LoanId = @LoanId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@LoanId", model.LoanId));

            paramsList.Add(new SqlParameter("@Amount", model.ShouldRepayMoney));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 更新一条数据 管理员放款操作
        /// </summary>
        public bool UpdateByAdmin(UserLoanEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set Amount += @Amount where UserId = @UserId;");

            commandText.Append(" Update sl_user_loan Set ");

            commandText.Append(" AdminId = @AdminId, ");

            commandText.Append(" PassTime = @PassTime, ");

            commandText.Append(" Status = @Status ");

            commandText.Append(" Where LoanId = @LoanId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Amount", model.LoanMoney));

            paramsList.Add(new SqlParameter("@LoanId", model.LoanId));

            paramsList.Add(new SqlParameter("@AdminId", model.AdminId));

            paramsList.Add(new SqlParameter("@PassTime", DateTime.Now));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            #endregion

            SqlTransaction trans = base.GetTransaction();

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserLoanEntityEx GetModel(int LoanId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 LoanId,LoanNo,ProductId,UserId,LoanTitle,LoanMoney,AnnualFee,ShouldRepayMoney,AlreadyAmortization,TotalAmortization,Status,AdminId,CreateTime,PassTime From sl_user_loan Where LoanId = @LoanId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@LoanId", LoanId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserLoanEntityEx>() as UserLoanEntityEx;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserLoanEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select LoanId,LoanNo,LoanTitle,LoanMoney,AnnualFee,ShouldRepayMoney,AlreadyAmortization,TotalAmortization,Status,AdminId,CreateTime,PassTime ");

            commandText.Append("From sl_user_loan ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserLoanEntityEx>() as List<UserLoanEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserLoanEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" LoanId,LoanNo,LoanTitle,LoanMoney,AnnualFee,ShouldRepayMoney,AlreadyAmortization,TotalAmortization,Status,AdminId,CreateTime,PassTime ");

            commandText.Append("From sl_user_loan ");

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
                return objReader.ReaderToList<UserLoanEntityEx>() as List<UserLoanEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_loan T ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<UserLoanEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T.LoanId Desc");
            }

            commandText.Append(" )AS Row,a.UserName, T.*  From sl_user_loan T,sl_users a ");

            if (!string.IsNullOrEmpty(strWhere))
            {
                commandText.AppendFormat(" Where T.UserId = a.UserId and {0} ", strWhere);
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
                return objReader.ReaderToList<UserLoanEntityEx>() as List<UserLoanEntityEx>;
            }
        }
    }
}



