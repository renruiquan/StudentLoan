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
    /// dbo.sl_draw_money实体
    /// </summary>
    public class DrawMoneyDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int DrawId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select DrawId From sl_draw_money Where DrawId = @DrawId");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@DrawId", DrawId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.HasRows;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(DrawMoneyEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" update sl_users set Amount -= @LockMoney where UserId =@UserId  ");

            commandText.Append(" Insert Into sl_draw_money( ");

            commandText.Append(" UserId,BindBankId,DrawMoney,Fee,LockMoney,ApplyTime,Status) ");

            commandText.Append(" Values ( ");

            commandText.Append(" @UserId,@BindBankId,@DrawMoney,@Fee,@LockMoney,getdate(),0) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@BindBankId", model.BindBankId));

            paramsList.Add(new SqlParameter("@DrawMoney", model.DrawMoney));

            paramsList.Add(new SqlParameter("@Fee", model.Fee));

            paramsList.Add(new SqlParameter("@LockMoney", model.LockMoney));

            #endregion

            SqlTransaction trans = base.GetTransaction();

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(DrawMoneyEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_draw_money ");

            commandText.Append(" Where DrawId = @DrawId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@DrawId", model.DrawId));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string DrawMoneyIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_draw_money ");

            commandText.Append("Where DrawId in (" + DrawMoneyIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DrawMoneyEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_draw_money Set ");

            commandText.Append(" BindBankId = @BindBankId, ");

            commandText.Append(" DrawMoney = @DrawMoney, ");

            commandText.Append(" Fee = @Fee, ");

            commandText.Append(" LockMoney = @LockMoney, ");

            commandText.Append(" ConfirmMoney = @ConfirmMoney, ");

            commandText.Append(" ApplyTime = @ApplyTime, ");

            commandText.Append(" PassTime = @PassTime, ");

            commandText.Append(" AdminId = @AdminId, ");

            commandText.Append(" Status = @Status ");

            commandText.Append(" Where DrawId = @DrawId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@DrawId", model.DrawId));

            paramsList.Add(new SqlParameter("@BindBankId", model.BindBankId));

            paramsList.Add(new SqlParameter("@DrawMoney", model.DrawMoney));

            paramsList.Add(new SqlParameter("@Fee", model.Fee));

            paramsList.Add(new SqlParameter("@LockMoney", model.LockMoney));

            paramsList.Add(new SqlParameter("@ConfirmMoney", model.ConfirmMoney));

            paramsList.Add(new SqlParameter("@ApplyTime", model.ApplyTime));

            paramsList.Add(new SqlParameter("@PassTime", model.PassTime));

            paramsList.Add(new SqlParameter("@AdminId", model.AdminId));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        public bool UpdateByAdmin(DrawMoneyEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_draw_money Set ");

            commandText.Append(" LockMoney = 0, ");

            commandText.Append(" PassTime = @PassTime, ");

            commandText.Append(" AdminId = @AdminId, ");

            commandText.Append(" Status = @Status ");

            commandText.Append(" Where DrawId = @DrawId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@DrawId", model.DrawId));

            paramsList.Add(new SqlParameter("@PassTime", DateTime.Now));

            paramsList.Add(new SqlParameter("@AdminId", model.AdminId));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        public DrawMoneyEntityEx GetModel(int DrawId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 DrawId,UserId,BindBankId,DrawMoney,Fee,LockMoney,ConfirmMoney,ApplyTime,PassTime,AdminId,Status  From sl_draw_money Where DrawId = @DrawId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@DrawId", DrawId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<DrawMoneyEntityEx>() as DrawMoneyEntityEx;
            }
        }

        /// <summary>
        /// 获取用户锁定资金总合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int GetTotalLockMoney(int userId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select sum(LockMoney) as LockMoney From sl_draw_money Where UserId=@UserId and Status=0");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            #endregion

            return base.ExecuteScalar(commandText.ToString(), paramsList.ToArray()).Convert<int>();
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<DrawMoneyEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(@" SELECT
	T.DrawId,
	c.UserName,
	c.TrueName,
	b.BankName,
	b.BankCardNo,
	b.BankProvince,
	b.BankCity,
	T.DrawMoney,
	T.ConfirmMoney,
	T.Fee,
	T.ApplyTime,
	T.PassTime,
	a.AdminName,
	T.Status ");

            commandText.Append("From sl_draw_money T,sl_admin a,sl_user_bank b,sl_users c  ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE T.BindBankId = b.BankId AND T.UserId = c.UserId AND t.AdminId = a.AdminId and {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<DrawMoneyEntityEx>() as List<DrawMoneyEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<DrawMoneyEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" DrawId,BindBankId,DrawMoney,Fee,LockMoney,ConfirmMoney,ApplyTime,PassTime,AdminId,Status ");

            commandText.Append("From sl_draw_money ");

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
                return objReader.ReaderToList<DrawMoneyEntityEx>() as List<DrawMoneyEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_draw_money T,sl_user_bank b,sl_users c,sl_base_bank d ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE T.BindBankId=b.BankId and b.BaseBankId = d.BankId and T.UserId = c.UserId and  {0}", strWhere);
            }

            #endregion

            #region SqlParameters

            #endregion

            return (int)base.ExecuteScalar(commandText.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<DrawMoneyEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T.DrawId Desc");
            }

            commandText.Append(" )AS Row, T.*,c.TrueName,c.UserName,d.BankName as 'BaseBankName', b.BankName ,b.BankCardNo,b.BankProvince,b.BankCity,c.Mobile ");

            commandText.Append(" From sl_draw_money T,sl_user_bank b,sl_users c,sl_base_bank d ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE T.BindBankId=b.BankId and b.BaseBankId = d.BankId and T.UserId = c.UserId and {0}", strWhere);
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
                return objReader.ReaderToList<DrawMoneyEntityEx>() as List<DrawMoneyEntityEx>;
            }
        }

        //select a.DrawId,a.UserId,a.BindBankId,a.DrawMoney,a.Fee,a.LockMoney,a.ConfirmMoney,a.ApplyTime,a.PassTime,a.AdminId,a.Status,b.BankName,b.BankCardNo,b.BankProvince,b.BankCity from sl_draw_money a ,sl_user_bank b where a.userid=b.UserId
    }
}



