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
    /// dbo.sl_draw_money实体
    /// </summary>
    public class DrawMoneyBLL
    {

        DrawMoneyDAL dal = new DrawMoneyDAL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Status)
        {
            return dal.Exists(Status);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(DrawMoneyEntityEx model)
        {
            return dal.Insert(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(DrawMoneyEntityEx model)
        {
            return dal.Delete(model);
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string DrawMoneyIDList)
        {
            return dal.DeleteList(DrawMoneyIDList);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DrawMoneyEntityEx model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 管理员打款时更新提款记录的相关信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateByAdmin(DrawMoneyEntityEx model)
        {
            return dal.UpdateByAdmin(model);
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public DrawMoneyEntityEx GetModel(int Status)
        {
            return dal.GetModel(Status);
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<DrawMoneyEntityEx> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<DrawMoneyEntityEx> GetList(int top, string strWhere, string orderby)
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
        public List<DrawMoneyEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
    }
}



