using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudentLoan.Common
{
    /// <summary>
    /// OleDbHelper
    /// </summary>
    public sealed class AccessHelper
    {
        #region Private Field
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string connectionString = null;
        #endregion

        #region Public Property
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get { return AccessHelper.connectionString; }
            set { AccessHelper.connectionString = value; }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 获取连接对象
        /// </summary>
        /// <returns>连接对象</returns>
        private static OleDbConnection GetOleDbConnection()
        {
            return new OleDbConnection(AccessHelper.connectionString);
        }

        /// <summary>
        /// 初始化命令对象
        /// </summary>
        /// <param name="objOleDbCommand">命令对象</param>
        /// <param name="parameters">参数集合</param>
        /// <returns>命令对象</returns>
        private static OleDbCommand InitOleDbCommand(OleDbCommand objOleDbCommand, Dictionary<string, OleDbParameter> parameters)
        {
            objOleDbCommand.CommandTimeout = 60;

            /**/

            objOleDbCommand.Parameters.Clear();

            if (parameters != null && parameters.Count > 0)
            {
                foreach (OleDbParameter parameter in parameters.Values)
                {
                    objOleDbCommand.Parameters.Add(parameter);
                }
            }

            return objOleDbCommand;
        }
        #endregion

        #region Public Method

        #region Exec_NonQuery
        /// <summary>
        /// Exec_NonQuery
        /// </summary>
        /// <param name="commandText">commandText</param>
        /// <param name="parameters">parameters</param>
        /// <returns>int</returns>
        public static int Exec_NonQuery(string commandText, Dictionary<string, OleDbParameter> parameters)
        {
            int result = 0;

            using (OleDbConnection objOleDbConnection = AccessHelper.GetOleDbConnection())
            {
                try
                {
                    using (OleDbCommand objOleDbCommand = AccessHelper.InitOleDbCommand(new OleDbCommand(commandText, objOleDbConnection), parameters))
                    {
                        objOleDbConnection.Open();

                        result = objOleDbCommand.ExecuteNonQuery();

                        objOleDbCommand.Parameters.Clear();
                    }
                }

                finally
                {
                    if (objOleDbConnection.State != ConnectionState.Closed)
                    {
                        objOleDbConnection.Close();
                        objOleDbConnection.Dispose();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Exec_NonQuery
        /// </summary>
        /// <param name="commands">commands</param>
        /// <returns>bool</returns>
        public static bool Exec_NonQuery(List<OleDbCommand> commands)
        {
            bool result = false;

            using (OleDbConnection objOleDbConnection = AccessHelper.GetOleDbConnection())
            {
                objOleDbConnection.Open();

                using (OleDbTransaction objOleDbTransaction = objOleDbConnection.BeginTransaction())
                {
                    try
                    {
                        foreach (OleDbCommand objOleDbCommand in commands)
                        {
                            objOleDbCommand.Connection = objOleDbConnection;
                            objOleDbCommand.Transaction = objOleDbTransaction;

                            objOleDbCommand.ExecuteNonQuery();
                        }

                        objOleDbTransaction.Commit();

                        result = true;
                    }

                    catch
                    {
                        objOleDbTransaction.Rollback();

                        throw;
                    }

                    finally
                    {
                        if (objOleDbConnection.State != ConnectionState.Closed)
                        {
                            objOleDbConnection.Close();
                            objOleDbConnection.Dispose();
                        }
                    }
                }
            }

            return result;
        }
        #endregion

        #region Exec_Scalar
        /// <summary>
        /// Exec_Scalar
        /// </summary>
        /// <param name="commandText">commandText</param>
        /// <param name="parameters">parameters</param>
        /// <returns>object</returns>
        public static object Exec_Scalar(string commandText, Dictionary<string, OleDbParameter> parameters)
        {
            object result = null;

            using (OleDbConnection objOleDbConnection = AccessHelper.GetOleDbConnection())
            {
                try
                {
                    using (OleDbCommand objOleDbCommand = AccessHelper.InitOleDbCommand(new OleDbCommand(commandText, objOleDbConnection), parameters))
                    {
                        objOleDbConnection.Open();

                        result = objOleDbCommand.ExecuteScalar();

                        objOleDbCommand.Parameters.Clear();
                    }
                }

                finally
                {
                    if (objOleDbConnection.State != ConnectionState.Closed)
                    {
                        objOleDbConnection.Close();
                        objOleDbConnection.Dispose();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Exec_Scalar
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="commandText">commandText</param>
        /// <param name="parameters">parameters</param>
        /// <returns>T</returns>
        public static T Exec_Scalar<T>(string commandText, Dictionary<string, OleDbParameter> parameters)
        {
            T result = default(T);

            object temp = null;

            using (OleDbConnection objOleDbConnection = AccessHelper.GetOleDbConnection())
            {
                try
                {
                    using (OleDbCommand objOleDbCommand = AccessHelper.InitOleDbCommand(new OleDbCommand(commandText, objOleDbConnection), parameters))
                    {
                        objOleDbConnection.Open();

                        temp = objOleDbCommand.ExecuteScalar();

                        objOleDbCommand.Parameters.Clear();
                    }
                }

                finally
                {
                    if (objOleDbConnection.State != ConnectionState.Closed)
                    {
                        objOleDbConnection.Close();
                        objOleDbConnection.Dispose();
                    }
                }

                if (temp != null &&
                    (temp != DBNull.Value || typeof(T).IsAssignableFrom(typeof(DBNull))))
                {
                    switch (typeof(T).FullName)
                    {
                        case "System.Int32":
                            result = (T)(object)int.Parse(temp.ToString());
                            break;

                        case "System.Int64":
                            result = (T)(object)long.Parse(temp.ToString());
                            break;

                        case "System.String":
                            result = (T)(object)temp.ToString();
                            break;

                        default:
                            result = (T)temp;
                            break;
                    }
                }
            }

            return result;
        }
        #endregion

        #region Exec_DataReader
        /// <summary>
        /// Exec_DataReader
        /// </summary>
        /// <param name="commandText">commandText</param>
        /// <param name="parameters">parameters</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader Exec_DataReader(string commandText, Dictionary<string, OleDbParameter> parameters)
        {
            OleDbDataReader result = null;

            using (OleDbCommand objOleDbCommand = AccessHelper.InitOleDbCommand(new OleDbCommand(commandText, AccessHelper.GetOleDbConnection()), parameters))
            {
                objOleDbCommand.Connection.Open();

                result = objOleDbCommand.ExecuteReader(CommandBehavior.CloseConnection);

                objOleDbCommand.Parameters.Clear();
            }

            return result;
        }
        #endregion

        #region Exec_DataTable
        /// <summary>
        /// Exec_DataTable
        /// </summary>
        /// <param name="commandText">commandText</param>
        /// <param name="parameters">parameters</param>
        /// <returns>DataTable</returns>
        public static DataTable Exec_DataTable(string commandText, Dictionary<string, OleDbParameter> parameters)
        {
            DataTable result = new DataTable();

            using (OleDbConnection objOleDbConnection = AccessHelper.GetOleDbConnection())
            {
                try
                {
                    using (OleDbCommand objOleDbCommand = AccessHelper.InitOleDbCommand(new OleDbCommand(commandText, objOleDbConnection), parameters))
                    {
                        using (OleDbDataAdapter objDbDataAdapter = new OleDbDataAdapter(objOleDbCommand))
                        {
                            objDbDataAdapter.Fill(result);

                            objOleDbCommand.Parameters.Clear();
                        }
                    }
                }

                finally
                {
                    if (objOleDbConnection.State != ConnectionState.Closed)
                    {
                        objOleDbConnection.Close();
                        objOleDbConnection.Dispose();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Exec_DataTable_Page
        /// </summary>
        /// <param name="commandText">commandText</param>
        /// <param name="parameters">parameters</param>
        /// <param name="currentPageIndex">currentPageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>DataTable</returns>
        public static DataTable Exec_DataTable_Page(string commandText, Dictionary<string, OleDbParameter> parameters, int currentPageIndex, int pageSize)
        {
            DataTable result = new DataTable();

            //int count = int.Parse(this.Exec_Scalar("select count(*) " + commandText.Substring(commandText.ToLower().IndexOf("from")), parameters).ToString());

            using (OleDbDataReader reader = AccessHelper.Exec_DataReader(commandText, parameters))
            {
                try
                {
                    if (reader.HasRows)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            //result.Columns.Add(new DataColumn(reader.GetName(i), reader.GetFieldType(i)));

                            result.Columns.Add(new DataColumn(reader.GetName(i), typeof(string)));
                        }

                        int rowIndex = 0;
                        int start = pageSize * (currentPageIndex - 1);
                        int end = pageSize * currentPageIndex;

                        object[] currentRow = new object[reader.FieldCount];

                        while (reader.Read())
                        {
                            if (rowIndex >= start && rowIndex < end)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    currentRow[i] = reader.GetValue(i);
                                }

                                result.Rows.Add(currentRow);
                            }

                            else if (rowIndex > end)
                            {
                                break;
                            }

                            rowIndex++;
                        }
                    }
                }

                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            return result;
        }
        #endregion

        #region Exec_DataSet
        /// <summary>
        /// Exec_DataSet
        /// </summary>
        /// <param name="commandText">commandText</param>
        /// <param name="parameters">parameters</param>
        /// <returns>DataSet</returns>
        public static DataSet Exec_DataSet(string commandText, Dictionary<string, OleDbParameter> parameters)
        {
            DataSet result = new DataSet();

            using (OleDbConnection objOleDbConnection = AccessHelper.GetOleDbConnection())
            {
                try
                {
                    using (OleDbCommand objOleDbCommand = AccessHelper.InitOleDbCommand(new OleDbCommand(commandText, objOleDbConnection), parameters))
                    {
                        using (OleDbDataAdapter objDbDataAdapter = new OleDbDataAdapter(objOleDbCommand))
                        {
                            objDbDataAdapter.Fill(result);

                            objOleDbCommand.Parameters.Clear();
                        }
                    }
                }

                finally
                {
                    if (objOleDbConnection.State != ConnectionState.Closed)
                    {
                        objOleDbConnection.Close();
                        objOleDbConnection.Dispose();
                    }
                }
            }

            return result;
        }
        #endregion

        #region Exec_Object
        /// <summary>
        /// Exec_SingleObject
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="commandText">commandText</param>
        /// <param name="parameters">parameters</param>
        /// <returns>T</returns>
        public static T Exec_SingleObject<T>(string commandText, Dictionary<string, OleDbParameter> parameters) where T : class, new()
        {
            T result = null;

            using (OleDbDataReader reader = AccessHelper.Exec_DataReader(commandText, parameters))
            {
                try
                {
                    if (reader.HasRows)
                    {
                        result = new T();

                        PropertyInfo[] propertys = typeof(T).GetProperties();

                        if (reader.Read())
                        {
                            foreach (PropertyInfo objPropertyInfo in propertys)
                            {
                                if (objPropertyInfo.CanWrite &&
                                    reader[objPropertyInfo.Name] != null &&
                                    reader[objPropertyInfo.Name] != DBNull.Value)
                                {
                                    objPropertyInfo.SetValue(result, reader[objPropertyInfo.Name].ToString(), null);
                                }
                            }
                        }
                    }
                }

                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            return result;
        }

        /// <summary>
        /// Exec_ObjectList
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="commandText">commandText</param>
        /// <param name="parameters">parameters</param>
        /// <returns>List</returns>
        public static List<T> Exec_ObjectList<T>(string commandText, Dictionary<string, OleDbParameter> parameters) where T : class, new()
        {
            List<T> result = new List<T>();

            using (OleDbDataReader reader = AccessHelper.Exec_DataReader(commandText, parameters))
            {
                try
                {
                    if (reader.HasRows)
                    {
                        T objT = null;

                        PropertyInfo[] propertys = typeof(T).GetProperties();

                        while (reader.Read())
                        {
                            objT = new T();

                            foreach (PropertyInfo objPropertyInfo in propertys)
                            {
                                if (objPropertyInfo.CanWrite &&
                                    reader[objPropertyInfo.Name] != null &&
                                    reader[objPropertyInfo.Name] != DBNull.Value)
                                {
                                    objPropertyInfo.SetValue(objT, reader[objPropertyInfo.Name].ToString(), null);
                                }
                            }

                            result.Add(objT);
                        }
                    }
                }

                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            return result;
        }

        /// <summary>
        /// Exec_ObjectList
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="commandText">commandText</param>
        /// <param name="parameters">parameters</param>
        /// <param name="currentPageIndex">currentPageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <returns>T</returns>
        public static List<T> Exec_ObjectList<T>(string commandText, Dictionary<string, OleDbParameter> parameters, int currentPageIndex, int pageSize) where T : class, new()
        {
            List<T> result = new List<T>();

            using (OleDbDataReader reader = AccessHelper.Exec_DataReader(commandText, parameters))
            {
                try
                {
                    if (reader.HasRows)
                    {
                        T objT = null;

                        PropertyInfo[] propertys = typeof(T).GetProperties();

                        int rowIndex = 0;
                        int start = pageSize * (currentPageIndex - 1);
                        int end = pageSize * currentPageIndex;

                        while (reader.Read())
                        {
                            if (rowIndex >= start && rowIndex < end)
                            {
                                objT = new T();

                                foreach (PropertyInfo objPropertyInfo in propertys)
                                {
                                    if (objPropertyInfo.CanWrite &&
                                        reader[objPropertyInfo.Name] != null &&
                                        reader[objPropertyInfo.Name] != DBNull.Value)
                                    {
                                        objPropertyInfo.SetValue(objT, reader[objPropertyInfo.Name].ToString(), null);
                                    }
                                }

                                result.Add(objT);
                            }

                            else if (rowIndex > end)
                            {
                                break;
                            }

                            rowIndex++;
                        }
                    }
                }

                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }

            return result;
        }
        #endregion

        #endregion
    }
}
