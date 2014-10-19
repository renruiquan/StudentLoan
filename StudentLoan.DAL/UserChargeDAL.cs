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
    /// dbo.sl_user_charge实体
    /// </summary>
    public class UserChargeDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select Id From sl_user_charge Where Id = @Id");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", Id));

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString()) > 0 ? true : false;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UserChargeEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_user_charge( ");

            commandText.Append(" UserId,OrderNo,ChannelId,ProductName,ChargeMoney,CreateTime) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @UserId,@OrderNo,@ChannelId,@ProductName,@ChargeMoney,@CreateTime ) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@OrderNo", model.OrderNo));

            paramsList.Add(new SqlParameter("@ChannelId", model.ChannelId));

            paramsList.Add(new SqlParameter("@ProductName", model.ProductName));

            paramsList.Add(new SqlParameter("@ChargeMoney", model.ChargeMoney));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime == default(DateTime) ? DateTime.Now : model.CreateTime));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UserChargeEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_charge ");

            commandText.Append(" Where Id = @Id ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", model.Id));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UserChargeIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_user_charge ");

            commandText.Append("Where Id in (" + UserChargeIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserChargeEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_user_charge Set ");

            commandText.Append(" UserId = @UserId, ");

            commandText.Append(" OrderNo = @OrderNo, ");

            commandText.Append(" ChannelId = @ChannelId, ");

            commandText.Append(" ChannelOrderNo = @ChannelOrderNo, ");

            commandText.Append(" ProductName = @ProductName, ");

            commandText.Append(" ChargeMoney = @ChargeMoney, ");

            commandText.Append(" ConfirmMoney = @ConfirmMoney, ");

            commandText.Append(" Fee = @Fee, ");

            commandText.Append(" CallbackCode = @CallbackCode, ");

            commandText.Append(" CreateTime = @CreateTime, ");

            commandText.Append(" CallbackTime = @CallbackTime, ");

            commandText.Append(" PayTime = @PayTime, ");

            commandText.Append(" Status = @Status, ");

            commandText.Append(" Ext1 = @Ext1, ");

            commandText.Append(" Ext2 = @Ext2, ");

            commandText.Append(" Ext3 = @Ext3, ");

            commandText.Append(" Ext4 = @Ext4, ");

            commandText.Append(" Ext5 = @Ext5 ");

            commandText.Append(" Where Id = @Id ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Id", model.Id));

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@OrderNo", model.OrderNo));

            paramsList.Add(new SqlParameter("@ChannelId", model.ChannelId));

            paramsList.Add(new SqlParameter("@ChannelOrderNo", model.ChannelOrderNo));

            paramsList.Add(new SqlParameter("@ProductName", model.ProductName));

            paramsList.Add(new SqlParameter("@ChargeMoney", model.ChargeMoney));

            paramsList.Add(new SqlParameter("@ConfirmMoney", model.ConfirmMoney));

            paramsList.Add(new SqlParameter("@Fee", model.Fee));

            paramsList.Add(new SqlParameter("@CallbackCode", model.CallbackCode));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            paramsList.Add(new SqlParameter("@CallbackTime", model.CallbackTime));

            paramsList.Add(new SqlParameter("@PayTime", model.PayTime));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@Ext1", model.Ext1));

            paramsList.Add(new SqlParameter("@Ext2", model.Ext2));

            paramsList.Add(new SqlParameter("@Ext3", model.Ext3));

            paramsList.Add(new SqlParameter("@Ext4", model.Ext4));

            paramsList.Add(new SqlParameter("@Ext5", model.Ext5));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }

        public bool UpdateOrderStatus(UserChargeEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set Amount += @Amount where UserId = @UserId;");

            commandText.Append(" Update sl_user_charge Set ");

            commandText.Append(" ChannelOrderNo = @ChannelOrderNo, ");

            commandText.Append(" ConfirmMoney = @ConfirmMoney, ");

            commandText.Append(" CallbackCode = @CallbackCode, ");

            commandText.Append(" CallbackTime = @CallbackTime, ");

            commandText.Append(" PayTime = @PayTime, ");

            commandText.Append(" Status = @Status ");

            commandText.Append(" Where OrderNo = @OrderNo; ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Amount", model.ConfirmMoney));

            paramsList.Add(new SqlParameter("@OrderNo", model.OrderNo));

            paramsList.Add(new SqlParameter("@ChannelOrderNo", model.ChannelOrderNo));

            paramsList.Add(new SqlParameter("@ConfirmMoney", model.ConfirmMoney));

            paramsList.Add(new SqlParameter("@CallbackCode", model.CallbackCode));

            paramsList.Add(new SqlParameter("@CallbackTime", model.CallbackTime));

            paramsList.Add(new SqlParameter("@PayTime", model.PayTime));

            paramsList.Add(new SqlParameter("@Status", model.Status));


            #endregion


            SqlTransaction trans = base.GetTransaction();

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }



        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UserChargeEntityEx GetModel(string orderNo)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 Id,UserId,OrderNo,ChannelId,ChannelOrderNo,ProductName,ChargeMoney,ConfirmMoney,Fee,CallbackCode,CreateTime,CallbackTime,PayTime,Status,Ext1,Ext2,Ext3,Ext4,Ext5 From sl_user_charge Where OrderNo = @OrderNo  and Status = 0");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@OrderNo", orderNo));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UserChargeEntityEx>() as UserChargeEntityEx;
            }
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserChargeEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Id,UserId,OrderNo,ChannelId,ChannelOrderNo,ProductName,ChargeMoney,ConfirmMoney,Fee,CallbackCode,CreateTime,CallbackTime,PayTime,Status,Ext1,Ext2,Ext3,Ext4,Ext5 ");

            commandText.Append("From sl_user_charge ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UserChargeEntityEx>() as List<UserChargeEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UserChargeEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" Id,UserId,OrderNo,ChannelId,ChannelOrderNo,ProductName,ChargeMoney,ConfirmMoney,Fee,CallbackCode,CreateTime,CallbackTime,PayTime,Status,Ext1,Ext2,Ext3,Ext4,Ext5 ");

            commandText.Append("From sl_user_charge ");

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
                return objReader.ReaderToList<UserChargeEntityEx>() as List<UserChargeEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_user_charge T");

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
        public List<UserChargeEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T.Id Desc");
            }

            commandText.Append(" )AS Row, a.UserName,b.ChannelName, T.*  From sl_user_charge T ,sl_users a,sl_channel b ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE a.UserId=t.UserId and b.ChannelId=t.ChannelId  and {0}", strWhere);
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
                return objReader.ReaderToList<UserChargeEntityEx>() as List<UserChargeEntityEx>;
            }
        }
    }
}



