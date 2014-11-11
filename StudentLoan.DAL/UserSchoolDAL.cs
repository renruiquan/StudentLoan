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
    /// dbo.sl_user_school实体
    /// </summary>
    public class UserSchoolDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int userid)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select UserID From sl_user_school Where UserID = @UserID");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserID", userid));

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString(),paramsList.ToArray()) > 0 ? true : false;
        }
       
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserSchoolEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_user_school( ");

            commandText.Append(" UserId,xuexinUsername,xuexinPassword,SchoolName,Education,Major,Class,SchoolId,SchoolAddress,BranchSchool,YearOfAdmission,SchoolSystem,Dormitory,CreateTime,Remark,Status) ");
            
            commandText.Append(" Values ( ");

            commandText.Append(" @UserId,@xuexinUsername,@xuexinPassword,@SchoolName,@Education,@Major,@Class,@SchoolId,@SchoolAddress,@BranchSchool,@YearOfAdmission,@SchoolSystem,@Dormitory,@CreateTime,@Remark,@Status) ");

            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));
            
            paramsList.Add(new SqlParameter("@Education", model.Education));
            
            paramsList.Add(new SqlParameter("@Major", model.Major));

            paramsList.Add(new SqlParameter("@xuexinUsername", model.XuexinUsername));

            paramsList.Add(new SqlParameter("@xuexinPassword", model.XuexinPassword));

            paramsList.Add(new SqlParameter("@SchoolName",model.SchoolName));

            paramsList.Add(new SqlParameter("@Class", model.Class));
            
            paramsList.Add(new SqlParameter("@SchoolId", model.SchoolId));
            
            paramsList.Add(new SqlParameter("@SchoolAddress", model.SchoolAddress));
            
            paramsList.Add(new SqlParameter("@BranchSchool", model.BranchSchool));
            
            paramsList.Add(new SqlParameter("@YearOfAdmission", model.YearOfAdmission));
            
            paramsList.Add(new SqlParameter("@SchoolSystem", model.SchoolSystem));
            
            paramsList.Add(new SqlParameter("@Dormitory", model.Dormitory));
            
            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));
            
            paramsList.Add(new SqlParameter("@Remark", model.Remark));
            
            paramsList.Add(new SqlParameter("@Status", model.Status));
            
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserSchoolEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_school ");
            
            commandText.Append(" Where  UserId= @UserId ");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));
            
             
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserSchoolIDList)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_school ");
            
            commandText.Append( "Where  in ("+ UserSchoolIDList + ") ");
            
            #endregion
                       
            return base.ExecuteNonQuery(commandText.ToString(), null);
        }
        
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserSchoolEntityEx model)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_user_school Set ");  
            
            commandText.Append(" Education = @Education, ");

            commandText.Append(" xuexinUsername = @xuexinUsername, ");

            commandText.Append(" xuexinPassword = @xuexinPassword, "); 
            
            commandText.Append(" Major = @Major, ");
          
            
            commandText.Append(" SchoolId = @SchoolId, ");
            
            commandText.Append(" SchoolAddress = @SchoolAddress, ");
            
            commandText.Append(" BranchSchool = @BranchSchool, ");
            
            commandText.Append(" YearOfAdmission = @YearOfAdmission, ");
            
            commandText.Append(" SchoolSystem = @SchoolSystem, ");
            
            commandText.Append(" Dormitory = @Dormitory, ");
            
            commandText.Append(" CreateTime = @CreateTime, ");
            
            commandText.Append(" Remark = @Remark, ");
            
            commandText.Append(" Status = @Status ");
            
            commandText.Append(" Where  UserId= @UserId ");

            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));
            
            paramsList.Add(new SqlParameter("@Education", model.Education));
            
            paramsList.Add(new SqlParameter("@Major", model.Major));
            
            paramsList.Add(new SqlParameter("@Class", model.Class));
            
            paramsList.Add(new SqlParameter("@SchoolId", model.SchoolId));
            
            paramsList.Add(new SqlParameter("@SchoolAddress", model.SchoolAddress));

            paramsList.Add(new SqlParameter("@xuexinUsername", model.XuexinUsername));

            paramsList.Add(new SqlParameter("@xuexinPassword", model.XuexinPassword));
            
            paramsList.Add(new SqlParameter("@BranchSchool", model.BranchSchool));
            
            paramsList.Add(new SqlParameter("@YearOfAdmission", model.YearOfAdmission));
            
            paramsList.Add(new SqlParameter("@SchoolSystem", model.SchoolSystem));
            
            paramsList.Add(new SqlParameter("@Dormitory", model.Dormitory));
            
            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));
            
            paramsList.Add(new SqlParameter("@Remark", model.Remark));
            
            paramsList.Add(new SqlParameter("@Status", model.Status));
            
            #endregion
           
            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }
        
        
        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserSchoolEntityEx GetModel(int userId)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 XuexinUserName,XuexinPassword, UserId,Education,Major,Class,SchoolId,SchoolName,SchoolAddress,BranchSchool,YearOfAdmission,SchoolSystem,Dormitory,CreateTime,Remark,Status From sl_user_school Where  userId= @userId ");
            
            #endregion
            
            #region SqlParameters
            
            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@userId",userId ));
 
            #endregion
            
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString,CommandType.Text,commandText.ToString(),paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserSchoolEntityEx>() as UserSchoolEntityEx;
            }
        }
        
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserSchoolEntityEx> GetList(string strWhere)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select UserId,Education,Major,Class,SchoolId,SchoolAddress,BranchSchool,YearOfAdmission,SchoolSystem,Dormitory,CreateTime,Remark,Status ");
            
            commandText.Append( "From sl_user_school ");
            
            if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				commandText.AppendFormat(" WHERE {0}", strWhere);
			}
            
            #endregion
            
            #region SqlParameters
            
            
            #endregion
           
            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserSchoolEntityEx>() as List<UserSchoolEntityEx>;
            }  
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserSchoolEntityEx> GetList(int top,string strWhere,string orderby)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");
            
            if(top > 0)
            {
                commandText.AppendFormat(" Top {0}",top);
            }
            
            
            commandText.Append(" ,UserId,Education,Major,Class,SchoolId,SchoolAddress,BranchSchool,YearOfAdmission,SchoolSystem,Dormitory,CreateTime,Remark,Status ");
            
            commandText.Append( "From sl_user_school ");
            
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
                return objReader.ReaderToList<UserSchoolEntityEx>() as List<UserSchoolEntityEx>;
            }  
        }
        
        
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText
            
            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_school ");
            
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
        public List<UserSchoolEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
				commandText.Append(" Order By T. Desc");
			}
            
            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} Desc", orderby.Replace("-",""));
            }
            
            commandText.Append(" )AS Row, T.*  From sl_user_school T ");
            
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
                return objReader.ReaderToList<UserSchoolEntityEx>() as List<UserSchoolEntityEx>;
            }   
        }
    }
}



