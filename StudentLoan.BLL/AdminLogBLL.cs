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
    /// dbo.sl_admin_log实体
    /// </summary>
    public class AdminLogBLL
    {

        AdminLogDAL dal = new AdminLogDAL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CreateTime)
        {
            return dal.Exists(CreateTime);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(AdminLogEntityEx model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(AdminLogEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string AdminLogIDList)
        {
            return dal.DeleteList(AdminLogIDList);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdminLogEntityEx model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public AdminLogEntityEx GetModel(int adminId)
        {
            return dal.GetModel(adminId);
        }

        /// <summary>
        /// 获取管理员登录次数
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public int GetLoginCount(int adminId)
        {
            return dal.GetLoginCount(adminId);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminLogEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminLogEntityEx> GetList(int top, string strWhere, string orderby)
        {
            return dal.GetList(top, strWhere, orderby);
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
        public List<AdminLogEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}



