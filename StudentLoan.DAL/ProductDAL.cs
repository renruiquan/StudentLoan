//作者：Brazelren
//日期：2014/09/13 22:48:58

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
    /// dbo.sl_product实体
    /// </summary>
    public class ProductDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ProductId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select ProductId From sl_product Where ProductId = @ProductId");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@ProductId", ProductId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.HasRows;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(ProductEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_product( ");

            commandText.Append(" ProductName,BaseAnnualFee,ProductDescription,ProductType,ProductMinMoney,ProductMaxMoney,MinPeriod,MaxPeriod,Remark,Status,CreateTime) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @ProductName,@BaseAnnualFee,@ProductDescription,@ProductType,@ProductMinMoney,@ProductMaxMoney,@MinPeriod,@MaxPeriod,@Remark,@Status,@CreateTime) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@ProductId", model.ProductId));

            paramsList.Add(new SqlParameter("@ProductName", model.ProductName));

            paramsList.Add(new SqlParameter("@BaseAnnualFee", model.BaseAnnualFee));

            paramsList.Add(new SqlParameter("@ProductDescription", model.ProductDescription));

            paramsList.Add(new SqlParameter("@ProductType", model.ProductType));

            paramsList.Add(new SqlParameter("@ProductMinMoney", model.ProductMinMoney));

            paramsList.Add(new SqlParameter("@ProductMaxMoney", model.ProductMaxMoney));

            paramsList.Add(new SqlParameter("@MinPeriod", model.MinPeriod));

            paramsList.Add(new SqlParameter("@MaxPeriod", model.MaxPeriod));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(ProductEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_product ");

            commandText.Append(" Where ProductId = @ProductId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@ProductId", model.ProductId));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string ProductIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_product ");

            commandText.Append("Where ProductId in (" + ProductIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ProductEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_product Set ");

            commandText.Append(" ProductName = @ProductName, ");

            commandText.Append(" BaseAnnualFee = @BaseAnnualFee, ");

            commandText.Append(" ProductDescription = @ProductDescription, ");

            commandText.Append(" ProductType = @ProductType, ");

            commandText.Append(" ProductMinMoney = @ProductMinMoney, ");

            commandText.Append(" ProductMaxMoney = @ProductMaxMoney, ");

            commandText.Append(" MinPeriod = @MinPeriod, ");

            commandText.Append(" MaxPeriod = @MaxPeriod, ");

            commandText.Append(" Remark = @Remark, ");

            commandText.Append(" Status = @Status, ");

            commandText.Append(" CreateTime = @CreateTime ");

            commandText.Append(" Where ProductId = @ProductId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@ProductId", model.ProductId));

            paramsList.Add(new SqlParameter("@ProductName", model.ProductName));

            paramsList.Add(new SqlParameter("@BaseAnnualFee", model.BaseAnnualFee));

            paramsList.Add(new SqlParameter("@ProductDescription", model.ProductDescription));

            paramsList.Add(new SqlParameter("@ProductType", model.ProductType));

            paramsList.Add(new SqlParameter("@ProductMinMoney", model.ProductMinMoney));

            paramsList.Add(new SqlParameter("@ProductMaxMoney", model.ProductMaxMoney));

            paramsList.Add(new SqlParameter("@MinPeriod", model.MinPeriod));

            paramsList.Add(new SqlParameter("@MaxPeriod", model.MaxPeriod));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public ProductEntityEx GetModel(int ProductId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 ProductId,ProductName,BaseAnnualFee,ProductDescription,ProductType,ProductMinMoney,ProductMaxMoney,MinPeriod,MaxPeriod,Remark,Status,CreateTime From sl_product Where ProductId = @ProductId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@ProductId", ProductId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<ProductEntityEx>() as ProductEntityEx;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ProductEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ProductId,ProductName,BaseAnnualFee,ProductDescription,ProductType,ProductMinMoney,ProductMaxMoney,MinPeriod,MaxPeriod,Remark,Status,CreateTime ");

            commandText.Append("From sl_product ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<ProductEntityEx>() as List<ProductEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ProductEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" ProductId,ProductName,BaseAnnualFee,ProductDescription,ProductType,ProductMinMoney,ProductMaxMoney,MinPeriod,MaxPeriod,Remark,Status,CreateTime ");

            commandText.Append("From sl_product ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} ", orderby.Replace("-", ""));
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<ProductEntityEx>() as List<ProductEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_product ");

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
        public List<ProductEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select * from ( ");

            commandText.Append(" Select ROW_NUMBER() OVER ( ");

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                commandText.AppendFormat(" Order By T.{0} ", orderby);
            }
            else
            {
                commandText.Append(" Order By T.ProductId Desc");
            }

            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} Desc", orderby.Replace("-", ""));
            }

            commandText.Append(" )AS Row, T.*  From sl_product T ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            commandText.Append(" ) TT");

            commandText.Append(" WHERE TT.Row between @startIndex and @endIndex");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@startIndex", startIndex));

            paramsList.Add(new SqlParameter("@endIndex", endIndex));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToList<ProductEntityEx>() as List<ProductEntityEx>;
            }
        }
    }
}



