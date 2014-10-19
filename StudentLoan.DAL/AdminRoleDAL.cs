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
    /// dbo.sl_admin_role实体
    /// </summary>
    public class AdminRoleDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RoleId)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select RoleId From sl_admin_role Where RoleId = @RoleId");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@RoleId", RoleId));
 
            #endregion
           
            return (int)base.ExecuteScalar(commandText.ToString()) > 0 ? true : false;
        }
        
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(AdminRoleEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_admin_role( ");
            
            commandText.Append(" RoleName,RoleType,IsSystem) ");
            
            commandText.Append(" Values ( ");
            
            commandText.Append(" @RoleName,@RoleType,@IsSystem) ");

            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@RoleId", model.RoleId));
            
            paramsList.Add(new SqlParameter("@RoleName", model.RoleName));
            
            paramsList.Add(new SqlParameter("@RoleType", model.RoleType));
            
            paramsList.Add(new SqlParameter("@IsSystem", model.IsSystem));
            
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(AdminRoleEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_admin_role ");
            
            commandText.Append(" Where RoleId = @RoleId ");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@RoleId", model.RoleId));
            
             
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string AdminRoleIDList)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_admin_role ");
            
            commandText.Append( "Where RoleId in ("+ AdminRoleIDList + ") ");
            
            #endregion
                       
            return base.ExecuteNonQuery(commandText.ToString(), null);
        }
        
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdminRoleEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_admin_role Set ");  
            
            commandText.Append(" RoleName = @RoleName, ");
            
            commandText.Append(" RoleType = @RoleType, ");
            
            commandText.Append(" IsSystem = @IsSystem ");
            
            commandText.Append(" Where RoleId = @RoleId ");

            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@RoleId", model.RoleId));
            
            paramsList.Add(new SqlParameter("@RoleName", model.RoleName));
            
            paramsList.Add(new SqlParameter("@RoleType", model.RoleType));
            
            paramsList.Add(new SqlParameter("@IsSystem", model.IsSystem));
            
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 获取一个实体
        /// </summary>
        public AdminRoleEntityEx GetModel(int RoleId)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 RoleId,RoleName,RoleType,IsSystem From sl_admin_role Where RoleId = @RoleId ");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@RoleId", RoleId));
 
            #endregion
            
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString,CommandType.Text,commandText.ToString(),paramsList.ToArray()))
            {
                return objReader.ReaderToModel<AdminRoleEntityEx>() as AdminRoleEntityEx;
            }
        }
        
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminRoleEntityEx> GetList(string strWhere)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select RoleId,RoleName,RoleType,IsSystem ");
            
            commandText.Append( "From sl_admin_role ");
            
            if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				commandText.AppendFormat(" WHERE {0}", strWhere);
			}
            
            #endregion
            
            #region SqlParameters
            
            
            #endregion
           
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<AdminRoleEntityEx>() as List<AdminRoleEntityEx>;
            }  
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminRoleEntityEx> GetList(int top,string strWhere,string orderby)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");
            
            if(top > 0)
            {
                commandText.AppendFormat(" Top {0}",top);
            }
            
            
            commandText.Append(" RoleId,RoleName,RoleType,IsSystem ");
            
            commandText.Append( "From sl_admin_role ");
            
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
                return objReader.ReaderToList<AdminRoleEntityEx>() as List<AdminRoleEntityEx>;
            }  
        }
        
        
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_admin_role ");
            
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
        public List<AdminRoleEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
				commandText.Append(" Order By T.RoleId Desc");
			}
            
            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} Desc", orderby.Replace("-",""));
            }
            
            commandText.Append(" )AS Row, T.*  From sl_admin_role T ");
            
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
                return objReader.ReaderToList<AdminRoleEntityEx>() as List<AdminRoleEntityEx>;
            }   
        }
    }
}



