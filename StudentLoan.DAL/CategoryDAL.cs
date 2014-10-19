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
    /// dbo.sl_category实体
    /// </summary>
    public class CategoryDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CategoryId)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select CategoryId From sl_category Where CategoryId = @CategoryId");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@CategoryId", CategoryId));
 
            #endregion
           
            return (int)base.ExecuteScalar(commandText.ToString()) > 0 ? true : false;
        }
        
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(CategoryEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_category( ");
            
            commandText.Append(" Parent_Id,CategoryName,Description,CreateTime,UpdateTime,Remark,Status) ");
            
            commandText.Append(" Values ( ");
            
            commandText.Append(" @Parent_Id,@CategoryName,@Description,@CreateTime,@UpdateTime,@Remark,@Status) ");

            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@CategoryId", model.CategoryId));
            
            paramsList.Add(new SqlParameter("@Parent_Id", model.ParentId));
            
            paramsList.Add(new SqlParameter("@CategoryName", model.CategoryName));
            
            paramsList.Add(new SqlParameter("@Description", model.Description));
            
            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));
            
            paramsList.Add(new SqlParameter("@UpdateTime", model.UpdateTime));
            
            paramsList.Add(new SqlParameter("@Remark", model.Remark));
            
            paramsList.Add(new SqlParameter("@Status", model.Status));
            
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(CategoryEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_category ");
            
            commandText.Append(" Where CategoryId = @CategoryId ");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@CategoryId", model.CategoryId));
            
             
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string CategoryIDList)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_category ");
            
            commandText.Append( "Where CategoryId in ("+ CategoryIDList + ") ");
            
            #endregion
                       
            return base.ExecuteNonQuery(commandText.ToString(), null);
        }
        
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CategoryEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_category Set ");  
            
            commandText.Append(" Parent_Id = @Parent_Id, ");
            
            commandText.Append(" CategoryName = @CategoryName, ");
            
            commandText.Append(" Description = @Description, ");
            
            commandText.Append(" CreateTime = @CreateTime, ");
            
            commandText.Append(" UpdateTime = @UpdateTime, ");
            
            commandText.Append(" Remark = @Remark, ");
            
            commandText.Append(" Status = @Status ");
            
            commandText.Append(" Where CategoryId = @CategoryId ");

            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@CategoryId", model.CategoryId));
            
            paramsList.Add(new SqlParameter("@Parent_Id", model.ParentId));
            
            paramsList.Add(new SqlParameter("@CategoryName", model.CategoryName));
            
            paramsList.Add(new SqlParameter("@Description", model.Description));
            
            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));
            
            paramsList.Add(new SqlParameter("@UpdateTime", model.UpdateTime));
            
            paramsList.Add(new SqlParameter("@Remark", model.Remark));
            
            paramsList.Add(new SqlParameter("@Status", model.Status));
            
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 获取一个实体
        /// </summary>
        public CategoryEntityEx GetModel(int CategoryId)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 CategoryId,Parent_Id,CategoryName,Description,CreateTime,UpdateTime,Remark,Status From sl_category Where CategoryId = @CategoryId ");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@CategoryId", CategoryId));
 
            #endregion
            
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString,CommandType.Text,commandText.ToString(),paramsList.ToArray()))
            {
                return objReader.ReaderToModel<CategoryEntityEx>() as CategoryEntityEx;
            }
        }
        
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<CategoryEntityEx> GetList(string strWhere)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select CategoryId,Parent_Id,CategoryName,Description,CreateTime,UpdateTime,Remark,Status ");
            
            commandText.Append( "From sl_category ");
            
            if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				commandText.AppendFormat(" WHERE {0}", strWhere);
			}
            
            #endregion
            
            #region SqlParameters
            
            
            #endregion
           
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<CategoryEntityEx>() as List<CategoryEntityEx>;
            }  
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<CategoryEntityEx> GetList(int top,string strWhere,string orderby)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");
            
            if(top > 0)
            {
                commandText.AppendFormat(" Top {0}",top);
            }
            
            
            commandText.Append(" CategoryId,Parent_Id,CategoryName,Description,CreateTime,UpdateTime,Remark,Status ");
            
            commandText.Append( "From sl_category ");
            
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
                return objReader.ReaderToList<CategoryEntityEx>() as List<CategoryEntityEx>;
            }  
        }
        
        
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_category ");
            
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
        public List<CategoryEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
				commandText.Append(" Order By T.CategoryId Desc");
			}
            
            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} Desc", orderby.Replace("-",""));
            }
            
            commandText.Append(" )AS Row, T.*  From sl_category T ");
            
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
                return objReader.ReaderToList<CategoryEntityEx>() as List<CategoryEntityEx>;
            }   
        }
    }
}



