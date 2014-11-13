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
    /// dbo.sl_channel实体
    /// </summary>
    public class ChannelDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ChannelId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select ChannelId From sl_channel Where ChannelId = @ChannelId");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@ChannelId", ChannelId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.HasRows;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(ChannelEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_channel( ");

            commandText.Append(" ChannelName,ChannelFlag,AppId,AppKey,Rate,Weight,RequestUrl,Status,Remark,CreateTime) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @ChannelName,@ChannelFlag,@AppId,@AppKey,@Rate,@Weight,@RequestUrl,@Status,@Remark,@CreateTime) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@ChannelId", model.ChannelId));

            paramsList.Add(new SqlParameter("@ChannelName", model.ChannelName));

            paramsList.Add(new SqlParameter("@ChannelFlag", model.ChannelFlag));

            paramsList.Add(new SqlParameter("@AppId", model.AppId));

            paramsList.Add(new SqlParameter("@AppKey", model.AppKey));

            paramsList.Add(new SqlParameter("@Rate", model.Rate));

            paramsList.Add(new SqlParameter("@Weight", model.Weight));

            paramsList.Add(new SqlParameter("@RequestUrl", model.RequestUrl));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(ChannelEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_channel ");

            commandText.Append(" Where ChannelId = @ChannelId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@ChannelId", model.ChannelId));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string ChannelIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_channel ");

            commandText.Append("Where ChannelId in (" + ChannelIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ChannelEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_channel Set ");

            commandText.Append(" ChannelName = @ChannelName, ");

            commandText.Append(" ChannelFlag = @ChannelFlag, ");

            commandText.Append(" AppId = @AppId, ");

            commandText.Append(" AppKey = @AppKey, ");

            commandText.Append(" Rate = @Rate, ");

            commandText.Append(" Weight = @Weight, ");

            commandText.Append(" RequestUrl = @RequestUrl, ");

            commandText.Append(" Status = @Status, ");

            commandText.Append(" Remark = @Remark, ");

            commandText.Append(" CreateTime = @CreateTime ");

            commandText.Append(" Where ChannelId = @ChannelId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@ChannelId", model.ChannelId));

            paramsList.Add(new SqlParameter("@ChannelName", model.ChannelName));

            paramsList.Add(new SqlParameter("@ChannelFlag", model.ChannelFlag));

            paramsList.Add(new SqlParameter("@AppId", model.AppId));

            paramsList.Add(new SqlParameter("@AppKey", model.AppKey));

            paramsList.Add(new SqlParameter("@Rate", model.Rate));

            paramsList.Add(new SqlParameter("@Weight", model.Weight));

            paramsList.Add(new SqlParameter("@RequestUrl", model.RequestUrl));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@Remark", model.Remark));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 获取一个实体
        /// </summary>
        public ChannelEntityEx GetModel(int ChannelId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 ChannelId,ChannelName,ChannelFlag,AppId,AppKey,Rate,Weight,RequestUrl,Status,Remark,CreateTime From sl_channel Where ChannelId = @ChannelId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@ChannelId", ChannelId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<ChannelEntityEx>() as ChannelEntityEx;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ChannelEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ChannelId,ChannelName,ChannelFlag,AppId,AppKey,Rate,Weight,RequestUrl,Status,Remark,CreateTime ");

            commandText.Append("From sl_channel Where Status = 1 ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat("  and  {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<ChannelEntityEx>() as List<ChannelEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<ChannelEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" ChannelId,ChannelName,ChannelFlag,AppId,AppKey,Rate,Weight,RequestUrl,Status,Remark,CreateTime ");

            commandText.Append("From sl_channel ");

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
                return objReader.ReaderToList<ChannelEntityEx>() as List<ChannelEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_channel ");

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
        public List<ChannelEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T.ChannelId Desc");
            }

            if (!string.IsNullOrEmpty(orderby))
            {
                commandText.AppendFormat(" Order By  {0} Desc", orderby.Replace("-", ""));
            }

            commandText.Append(" )AS Row, T.*  From sl_channel T ");

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
                return objReader.ReaderToList<ChannelEntityEx>() as List<ChannelEntityEx>;
            }
        }
    }
}



