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
    /// dbo.sl_admin_role_value实体
    /// </summary>
    public class AdminRoleValueDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select Id From sl_admin_role_value Where Id = @Id");
            
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
        public bool Insert(AdminRoleValueEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_admin_role_value( ");
            
            commandText.Append(" RoleId,NavName,ActionType) ");
            
            commandText.Append(" Values ( ");
            
            commandText.Append(" @RoleId,@NavName,@ActionType) ");

            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", model.Id));
            
            paramsList.Add(new SqlParameter("@RoleId", model.RoleId));
            
            paramsList.Add(new SqlParameter("@NavName", model.NavName));
            
            paramsList.Add(new SqlParameter("@ActionType", model.ActionType));
            
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(AdminRoleValueEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_admin_role_value ");
            
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
        public bool DeleteList(string AdminRoleValueIDList)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_admin_role_value ");
            
            commandText.Append( "Where Id in ("+ AdminRoleValueIDList + ") ");
            
            #endregion
                       
            return base.ExecuteNonQuery(commandText.ToString(), null);
        }
        
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdminRoleValueEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_admin_role_value Set ");  
            
            commandText.Append(" RoleId = @RoleId, ");
            
            commandText.Append(" NavName = @NavName, ");
            
            commandText.Append(" ActionType = @ActionType ");
            
            commandText.Append(" Where Id = @Id ");

            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", model.Id));
            
            paramsList.Add(new SqlParameter("@RoleId", model.RoleId));
            
            paramsList.Add(new SqlParameter("@NavName", model.NavName));
            
            paramsList.Add(new SqlParameter("@ActionType", model.ActionType));
            
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 获取一个实体
        /// </summary>
        public AdminRoleValueEntityEx GetModel(int Id)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 Id,RoleId,NavName,ActionType From sl_admin_role_value Where Id = @Id ");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", Id));
 
            #endregion
            
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString,CommandType.Text,commandText.ToString(),paramsList.ToArray()))
            {
                return objReader.ReaderToModel<AdminRoleValueEntityEx>() as AdminRoleValueEntityEx;
            }
        }
        
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminRoleValueEntityEx> GetList(string strWhere)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Id,RoleId,NavName,ActionType ");
            
            commandText.Append( "From sl_admin_role_value ");
            
            if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				commandText.AppendFormat(" WHERE {0}", strWhere);
			}
            
            #endregion
            
            #region SqlParameters
            
            
            #endregion
           
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<AdminRoleValueEntityEx>() as List<AdminRoleValueEntityEx>;
            }  
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminRoleValueEntityEx> GetList(int top,string strWhere,string orderby)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");
            
            if(top > 0)
            {
                commandText.AppendFormat(" Top {0}",top);
            }
            
            
            commandText.Append(" Id,RoleId,NavName,ActionType ");
            
            commandText.Append( "From sl_admin_role_value ");
            
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
                return objReader.ReaderToList<AdminRoleValueEntityEx>() as List<AdminRoleValueEntityEx>;
            }  
        }
        
        
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_admin_role_value ");
            
            if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				commandText.AppendFormat(" WHERE {0}", strWhere);
			}
            
            #endregion
            
            #region SqlParameters
            
            #endregion
           
            return (int)(int)base.ExecuteScalar(commandText.ToString());
        }
        
        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<AdminRoleValueEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
            
            commandText.Append(" )AS Row, T.*  From sl_admin_role_value T ");
            
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
                return objReader.ReaderToList<AdminRoleValueEntityEx>() as List<AdminRoleValueEntityEx>;
            }   
        }
    }
}



