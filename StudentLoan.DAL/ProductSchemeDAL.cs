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
    /// dbo.sl_product_scheme实体
    /// </summary>
    public class ProductSchemeDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int schemeName)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select SchemeName From sl_product_scheme Where  SchemeName= @SchemeName");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@SchemeName", schemeName));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.HasRows;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(ProductSchemeEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_product_scheme( ");

            commandText.Append(" SchemeName,InitiatorAdminId,ProductId,PlanType,MaxYield,Amount,Price,Part,LimitPart,NumberOfPeople,StartTime,EndTime,SchemeDescription,Remark,Status) ");

            commandText.Append(" Values ( ");

            commandText.Append("@SchemeName,@InitiatorAdminId,@ProductId,@PlanType,@MaxYield,@Amount,@Price,@Part,@LimitPart,@NumberOfPeople,@StartTime,@EndTime,@SchemeDescription,@Remark,@Status) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@SchemeName", model.SchemeName));

            paramsList.Add(new SqlParameter("@InitiatorAdminId", model.InitiatorAdminId));

            paramsList.Add(new SqlParameter("@ProductId", model.ProductId));

            paramsList.Add(new SqlParameter("@PlanType", model.PlanType));

            paramsList.Add(new SqlParameter("@MaxYield", model.MaxYield));

            paramsList.Add(new SqlParameter("@Amount", model.Amount));

            paramsList.Add(new SqlParameter("@Price", model.Price));

            paramsList.Add(new SqlParameter("@Part", model.Part));

            paramsList.Add(new SqlParameter("@LimitPart", model.LimitPart));

            paramsList.Add(new SqlParameter("@NumberOfPeople", model.NumberOfPeople));

            paramsList.Add(new SqlParameter("@StartTime", model.StartTime));

            paramsList.Add(new SqlParameter("@EndTime", model.EndTime));

            paramsList.Add(new SqlParameter("@SchemeDescription", model.SchemeDescription));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(ProductSchemeEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_product_scheme ");

            commandText.Append(" Where  SchemeId= @SchemeId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@SchemeId", model.SchemeId));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string ProductSchemeIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_product_scheme ");

            commandText.Append("Where  in (" + ProductSchemeIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ProductSchemeEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_product_scheme Set ");

            commandText.Append(" SchemeName = @SchemeName, ");

            commandText.Append(" ProductId = @ProductId, ");

            commandText.Append(" PlanType = @PlanType, ");

            commandText.Append(" Amount = @Amount, ");

            commandText.Append(" MaxYield =@MaxYield, ");

            commandText.Append(" Price = @Price, ");

            commandText.Append(" Part = @Part, ");

            commandText.Append(" LimitPart = @LimitPart, ");

            commandText.Append(" StartTime = @StartTime, ");

            commandText.Append(" EndTime = @EndTime, ");

            commandText.Append(" SchemeDescription = @SchemeDescription, ");

            commandText.Append(" Remark = @Remark ");

            commandText.Append(" Where  SchemeID= @SchemeID ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@SchemeId", model.SchemeId));

            paramsList.Add(new SqlParameter("@SchemeName", model.SchemeName));

            paramsList.Add(new SqlParameter("@ProductId", model.ProductId));

            paramsList.Add(new SqlParameter("@PlanType", model.PlanType));

            paramsList.Add(new SqlParameter("@Amount", model.Amount));

            paramsList.Add(new SqlParameter("@MaxYield", model.MaxYield));

            paramsList.Add(new SqlParameter("@Price", model.Price));

            paramsList.Add(new SqlParameter("@Part", model.Part));

            paramsList.Add(new SqlParameter("@LimitPart", model.LimitPart));

            paramsList.Add(new SqlParameter("@StartTime", model.StartTime));

            paramsList.Add(new SqlParameter("@EndTime", model.EndTime));

            paramsList.Add(new SqlParameter("@SchemeDescription", model.SchemeDescription));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public ProductSchemeEntityEx GetModel(int schemeId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(@"Select Top 1 SchemeId,SchemeName,InitiatorAdminId,a.ProductId,b.ProductName,PlanType,MinYield,MaxYield,Amount,Price,Part,LimitPart,NumberOfPeople,StartTime,EndTime,LockStartTime,LockEndTime,SchemeDescription,Fee,a.Remark,a.Status,a.CreateTime From sl_product_scheme a,sl_product b Where  SchemeId= @SchemeId
            and a.Status=1 and a.ProductId = b.ProductId and b.Status=1 ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@SchemeId", schemeId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<ProductSchemeEntityEx>() as ProductSchemeEntityEx;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ProductSchemeEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select SchemeId,SchemeName,InitiatorAdminId,ProductId,PlanType,MinYield,MaxYield,Amount,Price,Part,LimitPart,NumberOfPeople,StartTime,EndTime,LockStartTime,LockEndTime,SchemeDescription,Fee,Remark,Status,CreateTime ");

            commandText.Append("From sl_product_scheme ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<ProductSchemeEntityEx>() as List<ProductSchemeEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ProductSchemeEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" ,SchemeId,SchemeName,InitiatorAdminId,ProductId,PlanType,MinYield,MaxYield,Amount,Price,Part,LimitPart,NumberOfPeople,StartTime,EndTime,LockStartTime,LockEndTime,SchemeDescription,Fee,Remark,Status,CreateTime ");

            commandText.Append("From sl_product_scheme ");

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
                return objReader.ReaderToList<ProductSchemeEntityEx>() as List<ProductSchemeEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_product_scheme ");

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
        public List<ProductSchemeEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T. Desc");
            }

            commandText.Append(" )AS Row, sl_admin.AdminName, sl_product.ProductName, T.*  From sl_product_scheme T,sl_admin,sl_product ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE sl_admin.AdminId=T.InitiatorAdminId  and sl_product.ProductId = T.ProductId and {0}", strWhere);
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
                return objReader.ReaderToList<ProductSchemeEntityEx>() as List<ProductSchemeEntityEx>;
            }
        }
    }
}



