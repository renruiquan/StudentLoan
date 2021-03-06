﻿//作者：Brazelren
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
    /// dbo.sl_admin_role实体
    /// </summary>
    public class AdminRoleBLL
    {

        AdminRoleDAL dal = new AdminRoleDAL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string roleName)
        {
            return dal.Exists(roleName);
        }

        /// <summary>
        /// 检查是否有权限
        /// </summary>
        public bool Exists(int roleid, string url)
        {
            AdminRoleEntityEx model = dal.GetModel(roleid);
            //if (model != null)
            //{
            //    if (model.RoleType == 1)
            //    {
            //        return true;
            //    }
            //    AdminRoleValueEntityEx modelt = model.AdminRoleValues.Find(p => p.NavId == url) as AdminRoleValueEntityEx;
            //    if (modelt != null)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Insert(AdminRoleEntityEx model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(AdminRoleEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string AdminRoleIDList)
        {
            return dal.DeleteList(AdminRoleIDList);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdminRoleEntityEx model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public AdminRoleEntityEx GetModel(int roleId)
        {
            return dal.GetModel(roleId);
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminRoleEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<AdminRoleEntityEx> GetList(int top, string strWhere, string orderby)
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
        public List<AdminRoleEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}



