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
    /// dbo.sl_users实体
    /// </summary>
    public class UsersBLL
    {

        UsersDAL dal = new UsersDAL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string userName)
        {
            return dal.Exists(userName);
        }

        /// <summary>
        /// 检测手机号是否被占用
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool ExistsMobile(string mobile)
        {
            return dal.ExistsMobile(mobile);
        }

        /// <summary>
        /// 检测身份证是否被占用
        /// </summary>
        /// <param name="identityCard"></param>
        /// <returns></returns>
        public bool ExistsIdentityCard(string identityCard)
        {
            return dal.ExistsIdentityCard(identityCard);
        }

        /// <summary>
        /// 检测邮箱是否被占用
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistsEMail(string email)
        {
            return dal.ExistsEMail(email);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UsersEntityEx model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UsersEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UsersIDList)
        {
            return dal.DeleteList(UsersIDList);
        }

        /// <summary>
        /// 更新用户积分
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool UpdatePoint(int userId, int point)
        {
            return dal.UpdatePoint(userId, point);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UsersEntityEx model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 更新用户头像
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAvatar(UsersEntityEx model)
        {
            return dal.UpdateAvatar(model);
        }

        public bool UpdateMobile(int userId, string mobile)
        {
            return dal.UpdateMobile(userId, mobile);
        }

        /// <summary>
        ///更新用户状态 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateStatus(int userId)
        {
            return dal.UpdateStatus(userId);
        }


        public bool UpdatePassword(UsersEntityEx model)
        {
            return dal.UpdatePassword(model);
        }

        /// <summary>
        /// 更新提现密码
        /// </summary>
        public bool UpdateWithDrawPassword(UsersEntityEx model)
        {
            return dal.UpdateWithDrawPassword(model);
        }

        /// <summary>
        ///管理员更新用户密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePasswordByAdmin(UsersEntityEx model)
        {
            return dal.UpdatePasswordByAdmin(model);
        }


        /// <summary>
        /// 是否可以更新用户资料
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="canModify"></param>
        /// <returns></returns>
        public bool UpdateCanModifyValue(UsersEntityEx model)
        {
            return dal.UpdateCanModifyValue(model);
        }

        /// <summary>
        /// 管理员放款时将借款金额直接打到用户账号中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAmount(UsersEntityEx model)
        {
            return dal.UpdateAmount(model);
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UsersEntityEx GetModel(int userId)
        {
            return dal.GetModel(userId);
        }

        public int GetUserId(string userName)
        {
            return dal.GetUserId(userName);
        }

        /// <summary>
        /// 根据用户真实姓名，获取用户ID集体
        /// </summary>
        /// <param name="trueName"></param>
        /// <returns></returns>
        public string GetUserIds(string trueName)
        {
            List<UsersEntityEx> list = dal.GetUserIds(trueName);

            StringBuilder objSB = new StringBuilder();

            foreach (UsersEntityEx model in list)
            {
                objSB.AppendFormat("'{0}',", model.UserId);
            }

            return objSB.ToString().TrimEnd(',');
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UsersEntityEx GetModel(string userName, string password, bool isEncrypt)
        {
            //检查一下是否需要加密
            if (isEncrypt)
            {
                //先取得该用户的随机密钥
                string salt = dal.GetSalt(userName);

                if (string.IsNullOrEmpty(salt))
                {
                    salt = dal.GetSaltByEmail(userName);
                }

                if (string.IsNullOrEmpty(salt))
                {
                    salt = dal.GetSaltByMobile(userName);
                }
                if (string.IsNullOrEmpty(salt))
                {
                    return null;
                }

                //把明文进行加密重新赋值
                password = DESHelper.Encrypt(password, salt);
            }

            UsersEntityEx model = dal.GetModel(userName, password);

            if (model == null)
            {
                model = dal.GetModelByEmail(userName, password);
            }

            if (model == null)
            {
                model = dal.GetModelByMobile(userName, password);
            }

            return model;
        }

        public UsersEntityEx GetModel(string userName)
        {
            return dal.GetModel(userName);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UsersEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UsersEntityEx> GetList(int top, string strWhere, string orderby)
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
        public List<UsersEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}



