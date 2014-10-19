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
    /// dbo.sl_admin实体
    /// </summary>
    public class AdminDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string adminName)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select AdminName From sl_admin Where AdminName = @AdminName");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@AdminName", adminName));

            #endregion

            return base.ExecuteScalar(commandText.ToString(), paramsList.ToArray()).Convert<int>() > 0 ? true : false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(AdminEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_admin( ");

            commandText.Append(" RoleId,AdminName,Password,Salt,RealName,Telephone,Email,IsLock,CreateTime) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @RoleId,@AdminName,@Password,@Salt,@RealName,@Telephone,@Email,@IsLock,@CreateTime) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@AdminId", model.AdminId));

            paramsList.Add(new SqlParameter("@RoleId", model.RoleId));

            paramsList.Add(new SqlParameter("@AdminName", model.AdminName));

            paramsList.Add(new SqlParameter("@Password", model.Password));

            paramsList.Add(new SqlParameter("@Salt", model.Salt));

            paramsList.Add(new SqlParameter("@RealName", model.RealName));

            paramsList.Add(new SqlParameter("@Telephone", model.Telephone));

            paramsList.Add(new SqlParameter("@Email", model.Email));

            paramsList.Add(new SqlParameter("@IsLock", model.IsLock));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(AdminEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_admin ");

            commandText.Append(" Where AdminId = @AdminId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@AdminId", model.AdminId));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string AdminIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_admin ");

            commandText.Append("Where AdminId in (" + AdminIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdminEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_admin Set ");

            commandText.Append(" RoleId = @RoleId, ");

            commandText.Append(" AdminName = @AdminName, ");

            commandText.Append(" Password = @Password, ");

            commandText.Append(" RealName = @RealName, ");

            commandText.Append(" Telephone = @Telephone, ");

            commandText.Append(" Email = @Email, ");

            commandText.Append(" IsLock = @IsLock ");

            commandText.Append(" Where AdminId = @AdminId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@AdminId", model.AdminId));

            paramsList.Add(new SqlParameter("@RoleId", model.RoleId));

            paramsList.Add(new SqlParameter("@AdminName", model.AdminName));

            paramsList.Add(new SqlParameter("@Password", model.Password));

            paramsList.Add(new SqlParameter("@RealName", model.RealName));

            paramsList.Add(new SqlParameter("@Telephone", model.Telephone));

            paramsList.Add(new SqlParameter("@Email", model.Email));

            paramsList.Add(new SqlParameter("@IsLock", model.IsLock));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePassword(AdminEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_admin Set ");

            commandText.Append(" Password = @Password, ");

            commandText.Append(" Salt = @Salt ");

            commandText.Append(" Where AdminId = @AdminId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@AdminId", model.AdminId));

            paramsList.Add(new SqlParameter("@Password", model.Password));

            paramsList.Add(new SqlParameter("@Salt", model.Salt));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        public AdminEntityEx GetModel(int AdminId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 AdminId,RoleId,AdminName,Password,Salt,RealName,Telephone,Email,IsLock,CreateTime From sl_admin Where AdminId = @AdminId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@AdminId", AdminId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<AdminEntityEx>() as AdminEntityEx;
            }
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        public AdminEntityEx GetModel(string adminName, string password)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 b.RoleName, a.* From sl_admin a,sl_admin_role b  Where a.RoleId = b.RoleId and AdminName = @AdminName and Password =@Password and IsLock =1 ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@AdminName", adminName));

            paramsList.Add(new SqlParameter("@Password", password));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<AdminEntityEx>() as AdminEntityEx;
            }
        }


        public string GetSalt(string adminName)
        {
            #region CommandText

            string commandText = @"Select Salt From sl_admin Where AdminName = @AdminName ";

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@AdminName", adminName));

            #endregion

            object result = base.ExecuteScalar(commandText, paramsList.ToArray());

            if (result == null)
            {
                return string.Empty;
            }
            else
            {
                return result.ToString();
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select AdminId,RoleId,AdminName,Password,Salt,RealName,Telephone,Email,IsLock,CreateTime ");

            commandText.Append("From sl_admin ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<AdminEntityEx>() as List<AdminEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" AdminId,RoleId,AdminName,Password,Salt,RealName,Telephone,Email,IsLock,CreateTime ");

            commandText.Append("From sl_admin ");

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
                return objReader.ReaderToList<AdminEntityEx>() as List<AdminEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_admin ");

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
        public List<AdminEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T.AdminId Desc");
            }

            commandText.Append(" )AS Row, a.RoleName, T.*  From sl_admin T ,sl_admin_role a");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE  a.RoleId = t.RoleId and {0}", strWhere);
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
                return objReader.ReaderToList<AdminEntityEx>() as List<AdminEntityEx>;
            }
        }
    }
}



