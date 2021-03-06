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
    /// dbo.sl_user_certification实体
    /// </summary>
    public class UserCertificationBLL
    {

        UserCertificationDAL dal = new UserCertificationDAL();

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
        public bool Insert(UserCertificationEntityEx model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserCertificationEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserCertificationIDList)
        {
            return dal.DeleteList(UserCertificationIDList);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserCertificationEntityEx model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update2(UserCertificationEntityEx model)
        {
            return dal.Update2(model);
        }

        /// <summary>
        /// 用于设置用户认证是否可以修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByAdmin(UserCertificationEntityEx model)
        {
            return dal.UpdateByAdmin(model);
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserCertificationEntityEx GetModel(int userId, int type)
        {
            return dal.GetModel(userId, type);
        }

        /// <summary>
        /// 获取用户上传指定类型的截图数据
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int GetPictureCertCount(int userId, int type)
        {
            List<UserCertificationEntityEx> list = dal.GetList(string.Format(" UserId={0} and type ={1}", userId, type));

            if (list == null)
            {
                return 0;
            }
            else
            {
                return list.Count;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserCertificationEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserCertificationEntityEx> GetList(int top, string strWhere, string orderby)
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
        public List<UserCertificationEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, ref int RecordCount)
        {
            RecordCount = this.GetRecordCount(strWhere);

            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}



