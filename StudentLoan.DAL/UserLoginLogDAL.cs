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
    /// dbo.sl_user_login_log实体
    /// </summary>
    public class UserLoginLogDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select Id From sl_user_login_log Where Id = @Id");
            
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
        public bool Insert(UserLoginLogEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_user_login_log( ");
            
            commandText.Append(" UserId,UserName,LoginIP) ");
            
            commandText.Append(" Values ( ");
            
            commandText.Append(" @UserId,@UserName,@LoginIP) ");

            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));
            
            paramsList.Add(new SqlParameter("@UserName", model.UserName));
            
            paramsList.Add(new SqlParameter("@LoginIP", model.LoginIP));
            
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserLoginLogEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_login_log ");
            
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
        public bool DeleteList(string UserLoginLogIDList)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_login_log ");
            
            commandText.Append( "Where Id in ("+ UserLoginLogIDList + ") ");
            
            #endregion
                       
            return base.ExecuteNonQuery(commandText.ToString(), null);
        }
        
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserLoginLogEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_user_login_log Set ");  
            
            commandText.Append(" UserId = @UserId, ");
            
            commandText.Append(" UserName = @UserName, ");
            
            commandText.Append(" Remark = @Remark, ");
            
            commandText.Append(" CreateTime = @CreateTime, ");
            
            commandText.Append(" LoginIP = @LoginIP ");
            
            commandText.Append(" Where Id = @Id ");

            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", model.Id));
            
            paramsList.Add(new SqlParameter("@UserId", model.UserId));
            
            paramsList.Add(new SqlParameter("@UserName", model.UserName));
            
            paramsList.Add(new SqlParameter("@Remark", model.Remark));
            
            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));
            
            paramsList.Add(new SqlParameter("@LoginIP", model.LoginIP));
            
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserLoginLogEntityEx GetModel(int userId)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 Id,UserId,UserName,Remark,CreateTime,LoginIP From sl_user_login_log Where UserId = @UserId order by id desc  ");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));
 
            #endregion
            
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString,CommandType.Text,commandText.ToString(),paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserLoginLogEntityEx>() as UserLoginLogEntityEx;
            }
        }
        
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserLoginLogEntityEx> GetList(string strWhere)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Id,UserId,UserName,Remark,CreateTime,LoginIP ");
            
            commandText.Append( "From sl_user_login_log ");
            
            if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				commandText.AppendFormat(" WHERE {0}", strWhere);
			}
            
            #endregion
            
            #region SqlParameters
            
            
            #endregion
           
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserLoginLogEntityEx>() as List<UserLoginLogEntityEx>;
            }  
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserLoginLogEntityEx> GetList(int top,string strWhere,string orderby)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");
            
            if(top > 0)
            {
                commandText.AppendFormat(" Top {0}",top);
            }
            
            
            commandText.Append(" Id,UserId,UserName,Remark,CreateTime,LoginIP ");
            
            commandText.Append( "From sl_user_login_log ");
            
            if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				commandText.AppendFormat(" WHERE {0}", strWhere);
			}
            
            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} ", orderby.Replace("-",""));
            }
            
            #endregion
            
            #region SqlParameters
            
            
            #endregion
           
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserLoginLogEntityEx>() as List<UserLoginLogEntityEx>;
            }  
        }
        
        
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_login_log ");
            
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
        public List<UserLoginLogEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select * from ( ");
            
            commandText.Append(" Select ROW_NUMBER() OVER ( ");
            
            if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				commandText.AppendFormat(" Order By T.{0} ",orderby );
			}
			else
			{
				commandText.Append(" Order By T.Id Desc");
			}
            
            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} Desc", orderby.Replace("-",""));
            }
            
            commandText.Append(" )AS Row, T.*  From sl_user_login_log T ");
            
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				commandText.AppendFormat(" WHERE {0}", strWhere);
			}
			
            commandText.Append(" ) TT");
			
            commandText.Append(" WHERE TT.Row between @startIndex and @endIndex");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@startIndex",startIndex));
 
            paramsList.Add(new SqlParameter("@endIndex",endIndex));
            
            #endregion
            
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToList<UserLoginLogEntityEx>() as List<UserLoginLogEntityEx>;
            }   
        }
    }
}



