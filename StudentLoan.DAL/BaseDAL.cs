using StudentLoan.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StudentLoan.DAL
{
    public class BaseDAL
    {
        public string ConnectionString { get { return ConfigHelper.ConnectionStrings("ConnectionString"); } }

        /// <summary>
        /// 获取一个SqlTransaction事务对象
        /// </summary>
        /// <returns></returns>
        public SqlTransaction GetTransaction()
        {
            SqlConnection connection = new SqlConnection(this.ConnectionString);

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection.BeginTransaction();
        }

        /// <summary>
        /// 执行带参数的非查询的SQL语句
        /// </summary>
        /// <param name="commandText">SQL语句</param>
        /// <param name="paramsArray">参数集合</param>
        /// <returns>执行成功返回True,失败返回False</returns>
        public bool ExecuteNonQuery(string commandText, SqlParameter[] paramsArray)
        {
            int result = SqlHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, commandText, paramsArray);

            return result > 0 ? true : false;
        }

        public bool ExecuteNonQuery(SqlTransaction trans, string commandText, SqlParameter[] paramsArray)
        {
            int result = SqlHelper.ExecuteNonQuery(trans, CommandType.Text, commandText, paramsArray);

            if (result > 0)
            {
                trans.Commit();
            }
            else
            {
                trans.Rollback();                
            }

            return result > 0 ? true : false;
        }


        public object ExecuteScalar(string commandText)
        {
            return SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, commandText);
        }

        public object ExecuteScalar(string commandText, SqlParameter[] paramsArray)
        {
            return SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, commandText, paramsArray);
        }
    }
}
