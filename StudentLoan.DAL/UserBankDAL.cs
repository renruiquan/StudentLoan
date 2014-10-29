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
    /// dbo.sl_user_bank实体
    /// </summary>
    public class UserBankDAL : BaseDAL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserBankEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_user_bank( ");

            commandText.Append(" UserId,BaseBankId,BankName,BankCardNo,BankProvince,BankCity,Status,IsDefault,CreateTime) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @UserId,@BaseBankId,@BankName,@BankCardNo,@BankProvince,@BankCity,1,@IsDefault,getdate()) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@BaseBankId", model.BaseBankId));

            paramsList.Add(new SqlParameter("@BankName", model.BankName));

            paramsList.Add(new SqlParameter("@BankCardNo", model.BankCardNo));

            paramsList.Add(new SqlParameter("@BankProvince", model.BankProvince));

            paramsList.Add(new SqlParameter("@BankCity", model.BankCity));

            paramsList.Add(new SqlParameter("@IsDefault", model.IsDefault));



            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserBankEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_bank ");

            commandText.Append(" Where  UserId= @UserId and BankCardNo=@BankCardNo ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@BankCardNo", model.BankCardNo));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserBankIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_bank ");

            commandText.Append("Where  in (" + UserBankIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserBankEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_user_bank Set ");

            commandText.Append(" BankName = @BankName, ");

            commandText.Append(" BankCardNo = @BankCardNo, ");

            commandText.Append(" BankProvince = @BankProvince, ");

            commandText.Append(" BankId = @NewBankId, ");

            commandText.Append(" BankCity = @BankCity ");

            commandText.Append(" Where  BankId = @BankId and UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@BankId", model.BankId));

            paramsList.Add(new SqlParameter("@NewBankId", model.NewBankId));

            paramsList.Add(new SqlParameter("@BankName", model.BankName));

            paramsList.Add(new SqlParameter("@BankCardNo", model.BankCardNo));

            paramsList.Add(new SqlParameter("@BankProvince", model.BankProvince));

            paramsList.Add(new SqlParameter("@BankCity", model.BankCity));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@IsDefault", model.IsDefault));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserBankEntityEx GetModel(int userId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 UserId,BankId,BankName,BankCardNo,BankProvince,BankCity,Status,IsDefault,CreateTime,Remark From sl_user_bank Where UserId = @UserId  and IsDefault =1;");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserBankEntityEx>() as UserBankEntityEx;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserBankEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select UserId,BankId,BankName,BankCardNo,BankProvince,BankCity,Status,IsDefault,CreateTime,Remark ");

            commandText.Append("From sl_user_bank ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserBankEntityEx>() as List<UserBankEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserBankEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" ,UserId,BankId,BankName,BankCardNo,BankProvince,BankCity,Status,IsDefault,CreateTime,Remark ");

            commandText.Append("From sl_user_bank ");

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
                return objReader.ReaderToList<UserBankEntityEx>() as List<UserBankEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_bank ");

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
        public List<UserBankEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T. Desc");
            }

            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} Desc", orderby.Replace("-", ""));
            }

            commandText.Append(" )AS Row, T.*  From sl_user_bank T ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
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
                return objReader.ReaderToList<UserBankEntityEx>() as List<UserBankEntityEx>;
            }
        }
    }
}



