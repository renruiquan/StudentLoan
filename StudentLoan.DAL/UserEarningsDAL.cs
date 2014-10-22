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
    /// dbo.sl_user_earnings实体
    /// </summary>
    public class UserEarningsDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int EarningsId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select EarningsId From sl_user_earnings Where EarningsId = @EarningsId");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@EarningsId", EarningsId));

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString()) > 0 ? true : false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserEarningsEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_user_earnings( ");

            commandText.Append(" UserId,ProductSchemeId,Amount,Type,Status) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @UserId,@ProductSchemeId,@Amount,@Type,@Status); ");

            commandText.Append(@"Update sl_users Set Amount += @Amount where UserId = @UserId");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@ProductSchemeId", model.ProductSchemeId));

            paramsList.Add(new SqlParameter("@Amount", model.Amount));

            paramsList.Add(new SqlParameter("@Type", model.Type));

            paramsList.Add(new SqlParameter("@Status", model.Status));
            #endregion

            SqlTransaction trans = base.GetTransaction();

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserEarningsEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_earnings ");

            commandText.Append(" Where EarningsId = @EarningsId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@EarningsId", model.EarningsId));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserEarningsIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_earnings ");

            commandText.Append("Where EarningsId in (" + UserEarningsIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserEarningsEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_user_earnings Set ");

            commandText.Append(" UserId = @UserId, ");

            commandText.Append(" ProductSchemeId = @ProductSchemeId, ");

            commandText.Append(" Amount = @Amount, ");

            commandText.Append(" Type = @Type, ");

            commandText.Append(" Status = @Status, ");

            commandText.Append(" Remark = @Remark, ");

            commandText.Append(" CreateTime = @CreateTime ");

            commandText.Append(" Where EarningsId = @EarningsId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@EarningsId", model.EarningsId));

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@ProductSchemeId", model.ProductSchemeId));

            paramsList.Add(new SqlParameter("@Amount", model.Amount));

            paramsList.Add(new SqlParameter("@Type", model.Type));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserEarningsEntityEx GetModel(int EarningsId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 EarningsId,UserId,ProductSchemeId,Amount,Type,Status,Remark,CreateTime From sl_user_earnings Where EarningsId = @EarningsId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@EarningsId", EarningsId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserEarningsEntityEx>() as UserEarningsEntityEx;
            }
        }

        /// <summary>
        /// 获取用户累计收益
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public decimal GetTotalEarnings(int userId)
        {
            string commandText = @"SELECT sum(amount) from sl_user_earnings where UserId = @UserId";

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            return base.ExecuteScalar(commandText, paramsList.ToArray()).Convert<decimal>();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserEarningsEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select EarningsId,UserId,ProductSchemeId,Amount,Type,Status,Remark,CreateTime ");

            commandText.Append("From sl_user_earnings ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserEarningsEntityEx>() as List<UserEarningsEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserEarningsEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" EarningsId,UserId,ProductSchemeId,Amount,Type,Status,Remark,CreateTime ");

            commandText.Append("From sl_user_earnings ");

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
                return objReader.ReaderToList<UserEarningsEntityEx>() as List<UserEarningsEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_earnings T,sl_users a,sl_product_scheme  b,sl_product c ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE t.UserId = a.UserId and t.ProductSchemeId = b.SchemeId and t.ProductSchemeId = c.ProductId  and {0}", strWhere);
            }

            #endregion

            #region SqlParameters

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<UserEarningsEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T.EarningsId Desc");
            }

            commandText.Append(" )AS Row, T.*,a.UserName,a.Amount as 'UserAmount' ,b.SchemeName ,c.ProductName  From sl_user_earnings T,sl_users a,sl_product_scheme b ,sl_product c");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE t.UserId = a.UserId and t.ProductSchemeId = b.SchemeId and t.ProductSchemeId = c.ProductId and {0}", strWhere);
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
                return objReader.ReaderToList<UserEarningsEntityEx>() as List<UserEarningsEntityEx>;
            }
        }
    }
}



