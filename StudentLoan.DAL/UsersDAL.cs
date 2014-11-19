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
    /// dbo.sl_users实体
    /// </summary>
    public class UsersDAL : BaseDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string userName)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append("Select UserName From sl_users Where UserName = @UserName");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserName", userName));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.HasRows;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Insert(UsersEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Insert Into sl_users( ");

            commandText.Append(" GroupId,UserName,Password,DrawMoneyPassword,Salt,Email,IdentityCard,Telphone,Province,City,Address,Amount,Point,Exp,Status,CreateTime,RegIP) ");

            commandText.Append(" Values ( ");

            commandText.Append(" 1,@UserName,@Password,@DrawMoneyPassword,@Salt,@Email,@IdentityCard,@Telphone,@Province,@City,@Address,@Amount,@Point,@Exp,@Status,@CreateTime,@RegIP) ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserName", model.UserName));


            paramsList.Add(new SqlParameter("@Password", model.Password));

            paramsList.Add(new SqlParameter("@DrawMoneyPassword", model.DrawMoneyPassword));

            paramsList.Add(new SqlParameter("@Salt", model.Salt));

            paramsList.Add(new SqlParameter("@Email", model.Email));

            paramsList.Add(new SqlParameter("@IdentityCard", model.IdentityCard));

            paramsList.Add(new SqlParameter("@Telphone", model.Telphone));



            paramsList.Add(new SqlParameter("@QQ", model.Qq));



            paramsList.Add(new SqlParameter("@Province", model.Province));

            paramsList.Add(new SqlParameter("@City", model.City));

            paramsList.Add(new SqlParameter("@Address", model.Address));

            paramsList.Add(new SqlParameter("@Amount", model.Amount));

            paramsList.Add(new SqlParameter("@Point", model.Point));

            paramsList.Add(new SqlParameter("@Exp", model.Exp));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            paramsList.Add(new SqlParameter("@RegIP", model.RegIP));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(UsersEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_users ");

            commandText.Append(" Where UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }


        /// <summary>
        /// 批量删数据
        /// </summary>
        public bool DeleteList(string UsersIDList)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Delete From sl_users ");

            commandText.Append("Where UserId in (" + UsersIDList + ") ");

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), null);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UsersEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set ");

            commandText.Append(" GroupId = @GroupId, ");

            commandText.Append(" UserName = @UserName, ");

            commandText.Append(" NickName = @NickName, ");

            commandText.Append(" TrueName = @TrueName, ");

            commandText.Append(" Password = @Password, ");

            commandText.Append(" DrawMoneyPassword = @DrawMoneyPassword, ");

            commandText.Append(" Salt = @Salt, ");

            commandText.Append(" Email = @Email, ");

            commandText.Append(" IdentityCard = @IdentityCard, ");

            commandText.Append(" Avatar = @Avatar, ");

            commandText.Append(" Gender = @Gender, ");

            commandText.Append(" Nation = @Nation, ");

            commandText.Append(" Birthday = @Birthday, ");

            commandText.Append(" Telphone = @Telphone, ");

            commandText.Append(" Mobile = @Mobile, ");

            commandText.Append(" QQ = @QQ, ");

            commandText.Append(" Country = @Country, ");

            commandText.Append(" Province = @Province, ");

            commandText.Append(" City = @City, ");

            commandText.Append(" Address = @Address, ");

            commandText.Append(" SafeQuestion = @SafeQuestion, ");

            commandText.Append(" SafeAnswer = @SafeAnswer, ");

            commandText.Append(" Amount = @Amount, ");

            commandText.Append(" Exp = @Exp, ");

            commandText.Append(" Status = @Status, ");

            commandText.Append(" CreateTime = @CreateTime, ");

            commandText.Append(" RegIP = @RegIP ");

            commandText.Append(" Where UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@GroupId", model.GroupId));

            paramsList.Add(new SqlParameter("@UserName", model.UserName));

            paramsList.Add(new SqlParameter("@NickName", model.NickName));

            paramsList.Add(new SqlParameter("@TrueName", model.TrueName));

            paramsList.Add(new SqlParameter("@Password", model.Password));

            paramsList.Add(new SqlParameter("@DrawMoneyPassword", model.DrawMoneyPassword));

            paramsList.Add(new SqlParameter("@Salt", model.Salt));

            paramsList.Add(new SqlParameter("@Email", model.Email));

            paramsList.Add(new SqlParameter("@IdentityCard", model.IdentityCard));

            paramsList.Add(new SqlParameter("@Avatar", model.Avatar));

            paramsList.Add(new SqlParameter("@Gender", model.Gender));

            paramsList.Add(new SqlParameter("@Nation", model.Nation));

            paramsList.Add(new SqlParameter("@Birthday", model.Birthday));

            paramsList.Add(new SqlParameter("@Telphone", model.Telphone));

            paramsList.Add(new SqlParameter("@Mobile", model.Mobile));

            paramsList.Add(new SqlParameter("@QQ", model.Qq));

            paramsList.Add(new SqlParameter("@Country", model.Country));

            paramsList.Add(new SqlParameter("@Province", model.Province));

            paramsList.Add(new SqlParameter("@City", model.City));

            paramsList.Add(new SqlParameter("@Address", model.Address));

            paramsList.Add(new SqlParameter("@SafeQuestion", model.SafeQuestion));

            paramsList.Add(new SqlParameter("@SafeAnswer", model.SafeAnswer));

            paramsList.Add(new SqlParameter("@Amount", model.Amount));

            paramsList.Add(new SqlParameter("@Point", model.Point));

            paramsList.Add(new SqlParameter("@Exp", model.Exp));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@CreateTime", model.CreateTime));

            paramsList.Add(new SqlParameter("@RegIP", model.RegIP));


            #endregion

            SqlTransaction trans = base.GetTransaction();

            return base.ExecuteNonQuery(trans, commandText.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// 更新用户积分
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool UpdatePoint(int userId, int point)
        {
            string commandText = @"Update sl_users set Point+=@Point,Remark='true' where UserId = @UserId";

            List<SqlParameter> paramsList = new List<SqlParameter>();
            paramsList.Add(new SqlParameter("@UserId", userId));
            paramsList.Add(new SqlParameter("@Point", point));

            return base.ExecuteNonQuery(commandText, paramsList.ToArray());
        }

        public bool UpdateAvatar(UsersEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set ");

            commandText.Append(" Avatar = @Avatar ");

            commandText.Append(" Where UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Avatar", model.Avatar));


            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateMobile(int userId, string mobile)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set ");

            commandText.Append(" Mobile = @Mobile");

            commandText.Append(" Where UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            paramsList.Add(new SqlParameter("@Mobile", mobile));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStatus(int userId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set ");

            commandText.Append(" Status = 3");

            commandText.Append(" Where UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", userId));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdatePasswordByAdmin(UsersEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set ");

            commandText.Append(" Status = @Status, ");

            commandText.Append(" Password = @Password, ");

            commandText.Append(" DrawMoneyPassword = @DrawMoneyPassword ");

            commandText.Append(" Where UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Status", model.Status));

            paramsList.Add(new SqlParameter("@Password", model.Password));

            paramsList.Add(new SqlParameter("@DrawMoneyPassword", model.DrawMoneyPassword));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// 更新登录密码
        /// </summary>
        public bool UpdatePassword(UsersEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set ");

            commandText.Append(" Password = @Password, ");

            commandText.Append(" Salt = @Salt ");

            commandText.Append(" Where UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@Password", model.Password));

            paramsList.Add(new SqlParameter("@Salt", model.Salt));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// 更新提现密码
        /// </summary>
        public bool UpdateWithDrawPassword(UsersEntityEx model)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Update sl_users Set ");

            commandText.Append(" DrawMoneyPassword = @DrawMoneyPassword ");

            commandText.Append(" Where UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            paramsList.Add(new SqlParameter("@DrawMoneyPassword", model.DrawMoneyPassword));

            #endregion

            return base.ExecuteNonQuery(commandText.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// 管理员放款时将借款金额直接打到用户账号中
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAmount(UsersEntityEx model)
        {
            #region CommandText

            string commandText = @"Update sl_users Set Amount += @Amount where UserId = @UserId";

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@Amount", model.Amount));

            paramsList.Add(new SqlParameter("@UserId", model.UserId));

            #endregion

            return base.ExecuteNonQuery(commandText, paramsList.ToArray());
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        public UsersEntityEx GetModel(int UserId)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 UserId,GroupId,UserName,NickName,TrueName,Password,DrawMoneyPassword,Salt,Email,IdentityCard,Avatar,Gender,Nation,Birthday,Telphone,Mobile,QQ,Country,Province,City,Address,SafeQuestion,SafeAnswer,Amount,Point,Exp,Status,CreateTime,RegIP,Remark From sl_users Where UserId = @UserId ");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserId", UserId));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UsersEntityEx>() as UsersEntityEx;
            }
        }

        /// <summary>
        /// 获取一个实体
        /// </summary>
        public int GetUserId(string userName)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 UserId from sl_users Where UserName =@UserName");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserName", userName));

            #endregion

            return base.ExecuteScalar(commandText.ToString(), paramsList.ToArray()).Convert<int>();
        }


        public UsersEntityEx GetModel(string userName, string password)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select Top 1 UserId,GroupId,UserName,NickName,TrueName,Password,DrawMoneyPassword,Salt,Email,IdentityCard,Avatar,Gender,Nation,Birthday,Telphone,Mobile,QQ,Country,Province,City,Address,SafeQuestion,SafeAnswer,Amount,Point,Exp,Status,CreateTime,RegIP,Remark From sl_users Where UserName = @UserName and Password = @Password and Status = 0");

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserName", userName));

            paramsList.Add(new SqlParameter("@Password", password));

            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), paramsList.ToArray()))
            {
                return objReader.ReaderToModel<UsersEntityEx>() as UsersEntityEx;
            }
        }

        public string GetSalt(string userName)
        {
            #region CommandText

            string commandText = @"Select Salt From sl_users Where UserName = @UserName ";

            #endregion

            #region SqlParameters

            List<SqlParameter> paramsList = new List<SqlParameter>();

            paramsList.Add(new SqlParameter("@UserName", userName));

            #endregion

            object result = base.ExecuteScalar(commandText, paramsList.ToArray());

            if (result == null)
            {
                return string.Empty;
            }
            else
            {
                return result.ToString();
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UsersEntityEx> GetList(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select UserId,GroupId,UserName,NickName,TrueName,Password,DrawMoneyPassword,Salt,Email,IdentityCard,Avatar,Gender,Nation,Birthday,Telphone,Mobile,QQ,Country,Province,City,Address,SafeQuestion,SafeAnswer,Amount,Point,Exp,Status,CreateTime,RegIP,Remark ");

            commandText.Append("From sl_users ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                commandText.AppendFormat(" WHERE {0}", strWhere);
            }

            #endregion

            #region SqlParameters


            #endregion

            using (SqlDataReader objReader = SqlHelper.ExecuteReader(base.ConnectionString, CommandType.Text, commandText.ToString(), null))
            {
                return objReader.ReaderToList<UsersEntityEx>() as List<UsersEntityEx>;
            }
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        public List<UsersEntityEx> GetList(int top, string strWhere, string orderby)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select ");

            if (top > 0)
            {
                commandText.AppendFormat(" Top {0}", top);
            }


            commandText.Append(" UserId,GroupId,UserName,NickName,TrueName,Password,DrawMoneyPassword,Salt,Email,IdentityCard,Avatar,Gender,Nation,Birthday,Telphone,Mobile,QQ,Country,Province,City,Address,SafeQuestion,SafeAnswer,Amount,Point,Exp,Status,CreateTime,RegIP,Remark ");

            commandText.Append("From sl_users ");

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
                return objReader.ReaderToList<UsersEntityEx>() as List<UsersEntityEx>;
            }
        }


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            #region CommandText

            StringBuilder commandText = new StringBuilder();

            commandText.Append(" Select count(0) From sl_users ");

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
        public List<UsersEntityEx> GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
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
                commandText.Append(" Order By T.UserId Desc");
            }

            commandText.Append(" )AS Row, T.*  From sl_users T ");

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
                return objReader.ReaderToList<UsersEntityEx>() as List<UsersEntityEx>;
            }
        }
    }
}



