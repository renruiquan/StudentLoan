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
    /// dbo.sl_user_manage_money实体
    /// </summary>
    public class UserManageMoneyDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int BuyId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select BuyId From sl_user_manage_money Where BuyId = @BuyId");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@BuyId", BuyId));

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString()) > 0 ? true : false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Insert(UserManageMoneyEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_user_manage_money( ");

            commandText.Append(" UserId,ProductId,ProductSchemeId,Period,Count,Amount,CreateTime,Status) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @UserId,@ProductId,@ProductSchemeId,@Period,@Count,@Amount,@CreateTime,@Status);SELECT @@Identity; ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@BuyId", model.BuyId));

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@ProductId", model.ProductId));

            paramsList.Add(new SqlParameter("@ProductSchemeId", model.ProductSchemeId));

            paramsList.Add(new SqlParameter("@Period", model.Period));

            paramsList.Add(new SqlParameter("@Count", model.Count));

            paramsList.Add(new SqlParameter("@Amount", model.Amount));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            #endregion

            return base.ExecuteScalar(commandText.ToString(), paramsList.ToArray()).Convert<int>();
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserManageMoneyEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_manage_money ");

            commandText.Append(" Where BuyId = @BuyId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@BuyId", model.BuyId));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserManageMoneyIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_manage_money ");

            commandText.Append("Where BuyId in (" + UserManageMoneyIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserManageMoneyEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set Amount -= @Amount where UserId = @UserId;");

            commandText.Append(" Update sl_user_manage_money Set ");

            commandText.Append(" PayTime = @PayTime, ");

            commandText.Append(" EndTime = @EndTime, ");

            commandText.Append(" Status = @Status ");

            commandText.Append(" Where BuyId = @BuyId ");


            SqlTransaction trans = base.GetTransaction();

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@BuyId", model.BuyId));

            paramsList.Add(new SqlParameter("@PayTime", model.PayTime));

            paramsList.Add(new SqlParameter("@EndTime", model.EndTime));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter(@"UserId", model.UserId));

            paramsList.Add(new SqlParameter(@"Amount", model.Amount));

            #endregion

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Withdrawal(UserManageMoneyEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_user_manage_money Set ");

            commandText.Append(" ApplyWithdrawalTime = getdate(), ");

            commandText.Append(" Status = @Status ");

            commandText.Append(" Where BuyId = @BuyId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@BuyId", model.BuyId));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 转出时管理员通过审核
        /// </summary>
        public bool PassApplyWithdrawal(UserManageMoneyEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set Amount += @Amount Where UserId=@UserId ");

            commandText.Append(" Update sl_user_manage_money Set ");

            commandText.Append(" ApplyWithdrawalTime = getdate(), ");

            commandText.Append(" AdminId = @AdminId, ");

            commandText.Append(" Status = @Status ");

            commandText.Append(" Where BuyId = @BuyId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();


            paramsList.Add(new SqlParameter("@BuyId", model.BuyId));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@Amount", model.Amount));

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@AdminId", model.AdminId));

            #endregion

            SqlTransaction trans = base.GetTransaction();

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }



        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserManageMoneyEntityEx GetModel(int BuyId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 BuyId,UserId,ProductId,ProductSchemeId,Count,period,Amount,CreateTime,PayTime,Status From sl_user_manage_money Where BuyId = @BuyId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@BuyId", BuyId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserManageMoneyEntityEx>() as UserManageMoneyEntityEx;
            }
        }


        /// <summary>
        /// 获取理财统计数据
        /// </summary>
        public UserManageMoneyEntityEx GetStatUserManageMoney(int userId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(@" 
                                SELECT

	                                SUM(Amount) AS 'TotalAmount',
	                                COUNT(0) AS TotalCount,
	                                (SELECT
		                                SUM(Amount)
	                                FROM sl_user_earnings
	                                WHERE UserId = @UserId)
	                                AS 'TotalInterest',
	                                (SELECT
		                                COUNT(0)
	                                FROM sl_user_earnings
	                                WHERE UserId = @UserId)
	                                AS 'TotalEarningsCount'
                                FROM sl_user_manage_money
                                WHERE UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserManageMoneyEntityEx>() as UserManageMoneyEntityEx;
            }
        }


        /// <summary>
        /// 获取总待收利息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal WaitTotalInterest(int userId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(@" 
                            SELECT
	                            SUM(amount) AS 'WaitTotalInterest'
                            FROM (SELECT
	                            (t.day * t.MaxYield * t.Amount / 365) AS 'amount'
                            FROM (SELECT
	                            DATEDIFF(DAY, GETDATE(), a.EndTime) AS day,
	                            b.MaxYield,
	                            b.Amount
                            FROM	sl_user_manage_money a,
		                            sl_product_scheme b
                            WHERE a.ProductSchemeId = b.SchemeId
                            AND a.UserId = @UserId
                            AND (a.Status = 1
                            OR a.Status = 2)
                            AND a.EndTime >= GETDATE()) t) t2 ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            #endregion

            return base.ExecuteScalar(commandText.ToString(), paramsList.ToArray()).Convert<decimal>();
        }

        /// <summary>
        /// 获取总待到期的理财产品数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal WaitTotalCount(int userId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(@" 
                            SELECT
	                            COUNT(0) AS 'WaitTotalCount'
                            FROM sl_user_manage_money
                            WHERE UserId = @UserId
                            AND (Status = 1
                            OR Status = 2)
                            AND EndTime >= GETDATE() ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            #endregion

            return base.ExecuteScalar(commandText.ToString(), paramsList.ToArray()).Convert<decimal>();
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserManageMoneyEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(@" SELECT  a.BuyId,a.UserId,a.ProductId,b.ProductName, a.ProductSchemeId,c.SchemeName,c.MaxYield,a.Period, a.count,a.Amount,a.CreateTime,a.PayTime,a.EndTime,a.Status ");

            commandText.Append("From sl_user_manage_money  a ,sl_product b,sl_product_scheme c ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE  a.ProductId = b.ProductId and a.ProductSchemeId = c.SchemeId  and {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserManageMoneyEntityEx>() as List<UserManageMoneyEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserManageMoneyEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" BuyId,UserId,ProductId,ProductSchemeId,Count,Amount,CreateTime,PayTime,Status ");

            commandText.Append("From sl_user_manage_money ");

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
                return objReader.ReaderToList<UserManageMoneyEntityEx>() as List<UserManageMoneyEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_manage_money T,sl_product a,sl_product_scheme b ,sl_users c");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE T.ProductId = a.ProductId AND T.ProductSchemeId = b.SchemeId and T.UserId=c.UserId and {0}", strWhere);
            }

            #endregion

            #region SqlParameters

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString());
        }


        /// <summary>
        /// 获取理财明细记录数
        /// </summary>
        public int GetRecordDetailCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_manage_money T,sl_user_earnings b");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE T.BuyId = b.BuyId and {0}", strWhere);
            }

            #endregion

            #region SqlParameters

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<UserManageMoneyEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T.BuyId Desc");
            }
            commandText.Append(" )AS Row, T.*,a.ProductName,b.SchemeName,c.UserName From sl_user_manage_money T ,sl_product a, sl_product_scheme b,sl_users c ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE T.ProductId = a.ProductId AND T.ProductSchemeId = b.SchemeId and T.UserId=c.UserId and 1=1 and {0}", strWhere);
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
                return objReader.ReaderToList<UserManageMoneyEntityEx>() as List<UserManageMoneyEntityEx>;
            }
        }


        /// <summary>
        /// 获取理财明细的分页获取数据列表
        /// </summary>
        public List<UserManageMoneyEntityEx> GetListByDetail(string strWhere, string orderby, int startIndex, int endIndex)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select * from ( ");

            commandText.Append(" Select ROW_NUMBER() OVER ( ");

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                commandText.AppendFormat(" Order By b.{0} ", orderby);
            }
            else
            {
                commandText.Append(" Order By T.BuyId Desc");
            }
            commandText.Append(" )AS Row, T.*,b.EarningsId,b.ProductName,b.Amount AS 'Interest' From sl_user_manage_money T,sl_user_earnings b ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE T.BuyId = b.BuyId and {0}", strWhere);
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
                return objReader.ReaderToList<UserManageMoneyEntityEx>() as List<UserManageMoneyEntityEx>;
            }
        }
    }
}



