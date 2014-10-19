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
    /// dbo.sl_admin_log实体
    /// </summary>
    public class AdminLogDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select Id From sl_admin_log Where Id = @Id");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", Id));

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString()) > 0 ? true : false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(AdminLogEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_admin_log( ");

            commandText.Append(" AdminId,AdminName,ActionType,Remark,UserIP,CreateTime) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @AdminId,@AdminName,@ActionType,@Remark,@UserIP,@CreateTime) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", model.Id));

            paramsList.Add(new SqlParameter("@AdminId", model.AdminId));

            paramsList.Add(new SqlParameter("@AdminName", model.AdminName));

            paramsList.Add(new SqlParameter("@ActionType", model.ActionType));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            paramsList.Add(new SqlParameter("@UserIP", model.UserIP));

            paramsList.Add(new SqlParameter("@CreateTime", DateTime.Now));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(AdminLogEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_admin_log ");

            commandText.Append(" Where Id = @Id ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", model.Id));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string AdminLogIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_admin_log ");

            commandText.Append("Where Id in (" + AdminLogIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdminLogEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_admin_log Set ");

            commandText.Append(" AdminId = @AdminId, ");

            commandText.Append(" AdminName = @AdminName, ");

            commandText.Append(" ActionType = @ActionType, ");

            commandText.Append(" Remark = @Remark, ");

            commandText.Append(" UserIP = @UserIP, ");

            commandText.Append(" CreateTime = @CreateTime ");

            commandText.Append(" Where Id = @Id ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", model.Id));

            paramsList.Add(new SqlParameter("@AdminId", model.AdminId));

            paramsList.Add(new SqlParameter("@AdminName", model.AdminName));

            paramsList.Add(new SqlParameter("@ActionType", model.ActionType));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            paramsList.Add(new SqlParameter("@UserIP", model.UserIP));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public AdminLogEntityEx GetModel(int AdminId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 Id,AdminId,AdminName,ActionType,Remark,UserIP,CreateTime From sl_admin_log Where AdminId = @AdminId Order By Id desc");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@AdminId", AdminId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<AdminLogEntityEx>() as AdminLogEntityEx;
            }
        }

        /// <summary>
        /// 获取管理员登录次数
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public int GetLoginCount(int adminId)
        {
            #region CommandText

            string commandText = @"SELECT  count(0) from sl_admin_log where AdminId = @AdminId and ActionType='登录'";

            #endregion

            List<SqlParameter> paramsList = new List<SqlParameter>();
            paramsList.Add(new SqlParameter("@AdminId", adminId));

            return base.ExecuteScalar(commandText, paramsList.ToArray()).Convert<int>();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminLogEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Id,AdminId,AdminName,ActionType,Remark,UserIP,CreateTime ");

            commandText.Append("From sl_admin_log ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<AdminLogEntityEx>() as List<AdminLogEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminLogEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" Id,AdminId,AdminName,ActionType,Remark,UserIP,CreateTime ");

            commandText.Append("From sl_admin_log ");

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
                return objReader.ReaderToList<AdminLogEntityEx>() as List<AdminLogEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_admin_log ");

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
        public List<AdminLogEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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

            commandText.Append(" )AS Row, T.*  From sl_admin_log T ");

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
                return objReader.ReaderToList<AdminLogEntityEx>() as List<AdminLogEntityEx>;
            }
        }
    }
}



