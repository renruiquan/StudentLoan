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
    /// dbo.sl_user_charge实体
    /// </summary>
    public class UserChargeBLL
    {

        UserChargeDAL dal = new UserChargeDAL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int userid)
        {
            return dal.Exists(userid);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserChargeEntityEx model)
        {
            return dal.Insert(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserChargeEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserChargeIDList)
        {
            return dal.DeleteList(UserChargeIDList);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserChargeEntityEx model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 根据订单号更新订单状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOrderStatus(UserChargeEntityEx model)
        {
            return dal.UpdateOrderStatus(model);
        }

        /// <summary>
        /// 获取一个实体 根据订单号获取充值记录
        /// </summary>
        public UserChargeEntityEx GetModel(string orderNo)
        {
            return dal.GetModel(orderNo);
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserChargeEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserChargeEntityEx> GetList(int top, string strWhere, string orderby)
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
        public List<UserChargeEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {

            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}



