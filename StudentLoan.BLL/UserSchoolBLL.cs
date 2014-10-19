//作者：Brazelren
//日期：2014/9/13 13:06:21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StudentLoan.Common;
using StudentLoan.Model;
using StudentLoan.DAL;

namespace StudentLoan.BLL
{
    /// <summary>
    /// dbo.sl_user_school实体
    /// </summary>
    public class UserSchoolBLL
    {
    
        UserSchoolDAL dal = new UserSchoolDAL();
        
        
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserSchoolEntityEx model)
        {
            return dal.Insert(model);
        }
        
        
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserSchoolEntityEx model)
        {
            return dal.Delete(model);
        }
        
        
        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserSchoolIDList)
        {
            return dal.DeleteList(UserSchoolIDList);
        }
        
        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserSchoolEntityEx model)
        {
            return dal.Update(model);
        }
        
        
        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserSchoolEntityEx GetModel(int userId)
        {
            return dal.GetModel(userId);
        }
        
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserSchoolEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserSchoolEntityEx> GetList(int top,string strWhere,string orderby)
        {
            return dal.GetList(top,strWhere,orderby); 
        }
        
        
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        
        
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<UserSchoolEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex,ref int RecordCount)
        {
            RecordCount = this.GetRecordCount(strWhere); 
            
            return dal.GetListByPage(strWhere,orderby,startIndex,endIndex);
        }
    }
}



