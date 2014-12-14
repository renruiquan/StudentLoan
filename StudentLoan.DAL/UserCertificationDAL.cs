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
    /// dbo.sl_user_certification实体
    /// </summary>
    public class UserCertificationDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select Id From sl_user_certification Where Id = @Id");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", Id));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.HasRows;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserCertificationEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users set Point+=@Point where UserId = @UserId;");

            commandText.Append(" Insert Into sl_user_certification( ");

            commandText.Append(" UserId,Type,CertificationName,Images,Point,Status,CreateTime) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @UserId,@Type,@CertificationName,@Images,@Point,1,getdate()) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Type", model.Type));

            paramsList.Add(new SqlParameter("@CertificationName", model.CertificationName));

            paramsList.Add(new SqlParameter("@Images", model.Images));

            paramsList.Add(new SqlParameter("@Point", model.Point));

            #endregion

            SqlTransaction trans = base.GetTransaction();

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserCertificationEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_certification ");

            commandText.Append(" Where UserId = @UserId and Type=@Type ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Type", model.Type));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserCertificationIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_certification ");

            commandText.Append("Where Id in (" + UserCertificationIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserCertificationEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_user_certification Set ");

            commandText.Append(" Images = @Images, ");

            commandText.Append(" CanModify = @CanModify ");

            commandText.Append(" Where UserId = @UserId and Type = @Type and Id = @Id");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Type", model.Type));

            paramsList.Add(new SqlParameter("@Images", model.Images));

            paramsList.Add(new SqlParameter("@CanModify", model.CanModify));

            paramsList.Add(new SqlParameter("@Id", model.Id));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update2(UserCertificationEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_user_certification Set ");

            commandText.Append(" Images = @Images, ");

            commandText.Append(" CanModify = @CanModify ");

            commandText.Append(" Where UserId = @UserId and Type = @Type ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Type", model.Type));

            paramsList.Add(new SqlParameter("@Images", model.Images));

            paramsList.Add(new SqlParameter("@CanModify", model.CanModify));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// 用于设置用户认证是否可以修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByAdmin(UserCertificationEntityEx model)
        {
            string commandText = @"Update sl_user_certification set CanModify = @CanModify where UserId=@UserId";

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@CanModify", model.CanModify));

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            return base.ExecuteNonQuery(commandText, paramsList.ToArray());
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserCertificationEntityEx GetModel(int userId, int type)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 Id,UserId,Type,CertificationName,Images,Point,Count,Status,Remark,CreateTime,CanModify From sl_user_certification Where UserId = @UserId and Type = @Type ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            paramsList.Add(new SqlParameter("@Type", type));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserCertificationEntityEx>() as UserCertificationEntityEx;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserCertificationEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Id,UserId,Type,CertificationName,Images,Point,Count,Status,Remark,CreateTime,CanModify ");

            commandText.Append("From sl_user_certification ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserCertificationEntityEx>() as List<UserCertificationEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserCertificationEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" Id,UserId,Type,CertificationName,Images,Point,Count,Status,Remark,CreateTime ");

            commandText.Append("From sl_user_certification ");

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
                return objReader.ReaderToList<UserCertificationEntityEx>() as List<UserCertificationEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_certification ");

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
        public List<UserCertificationEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T.Id Desc");
            }

            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} Desc", orderby.Replace("-", ""));
            }

            commandText.Append(" )AS Row, T.*  From sl_user_certification T ");

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
                return objReader.ReaderToList<UserCertificationEntityEx>() as List<UserCertificationEntityEx>;
            }
        }
    }
}



