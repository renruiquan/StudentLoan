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
    /// dbo.sl_user_relationship实体
    /// </summary>
    public class UserRelationshipDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int userId, int type)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select UserId,Name,Relationship,Type From sl_user_relationship Where UserId = @UserId and Type = @Type");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            paramsList.Add(new SqlParameter("@Type", type));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.HasRows;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserRelationshipEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users set Point+=@Point where UserId = @UserId;");

            commandText.Append(" Insert Into sl_user_relationship( ");

            commandText.Append(" UserId,Name,Relationship,Mobile,Profession,Address,Type,Remark,CreateTime) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @UserId,@Name,@Relationship,@Mobile,@Profession,@Address,@Type,@Remark,@CreateTime) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Name", model.Name));

            paramsList.Add(new SqlParameter("@Relationship", model.Relationship));

            paramsList.Add(new SqlParameter("@Mobile", model.Mobile));

            paramsList.Add(new SqlParameter("@Profession", model.Profession));

            paramsList.Add(new SqlParameter("@Address", model.Address));

            paramsList.Add(new SqlParameter("@Type", model.Type));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            paramsList.Add(new SqlParameter("@Point", model.Point));

            #endregion

            SqlTransaction trans = base.GetTransaction();

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserRelationshipEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_relationship ");

            commandText.Append(" Where  UserId= @UserId and Name=@Name and Type=@Type ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Name", model.Name));

            paramsList.Add(new SqlParameter("@Type", model.Type));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserRelationshipIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_relationship ");

            commandText.Append("Where  in (" + UserRelationshipIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserRelationshipEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_user_relationship Set ");

            commandText.Append(" Name = @Name, ");

            commandText.Append(" Relationship = @Relationship, ");

            commandText.Append(" Mobile = @Mobile, ");

            commandText.Append(" Profession = @Profession ");

            commandText.Append(" Where  UserId = @UserId and Type = @Type ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Name", model.Name));

            paramsList.Add(new SqlParameter("@Relationship", model.Relationship));

            paramsList.Add(new SqlParameter("@Mobile", model.Mobile));

            paramsList.Add(new SqlParameter("@Profession", model.Profession));

            paramsList.Add(new SqlParameter("@Type", model.Type));



            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserRelationshipEntityEx GetModel(int userId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 ,UserId,Name,Relationship,Mobile,Profession,Address,Type,Remark,CreateTime From sl_user_relationship Where  UserId= @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserRelationshipEntityEx>() as UserRelationshipEntityEx;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserRelationshipEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select UserId,Name,Relationship,Mobile,Profession,Address,Type,Remark,CreateTime ");

            commandText.Append("From sl_user_relationship ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserRelationshipEntityEx>() as List<UserRelationshipEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserRelationshipEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" ,UserId,Name,Relationship,Mobile,Profession,Address,Type,Remark,CreateTime ");

            commandText.Append("From sl_user_relationship ");

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
                return objReader.ReaderToList<UserRelationshipEntityEx>() as List<UserRelationshipEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_relationship ");

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
        public List<UserRelationshipEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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

            commandText.Append(" )AS Row, T.*  From sl_user_relationship T ");

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
                return objReader.ReaderToList<UserRelationshipEntityEx>() as List<UserRelationshipEntityEx>;
            }
        }
    }
}



