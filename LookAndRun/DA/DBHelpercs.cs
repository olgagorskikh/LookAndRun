using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Dozor
{
    public class DBHelper : IDisposable
    {
        #region Variables

        private static List<SqlParameter> sqlCommandParameters = null;

        #endregion

        #region Default constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DBHelper"/> class.
        /// </summary>
        public DBHelper()
        {
            sqlCommandParameters = new List<SqlParameter>();
        }

        #endregion

        #region Methods


        /// <summary>
        /// Gets the connection to database.
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            SqlConnection result = null;
            try
            {
                var conn = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
                result = new SqlConnection(conn);                
            }
            catch (SqlException SqlEx)
            {

                //Diagnostics.RegisterError("Connection to database failed: " + SqlEx.Message , SqlEx);
                //throw new CoreException(SqlEx.Message, SqlEx);
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("Connection to database failed: " + ex.Message, ex);
                //throw new CoreException(ex.Message, ex);
            }

            return result;
        }


        /// <summary>
        /// Adds the SQL command's parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        public void AddSQLCommandParameter(string parameterName, Object parameterValue)
        {
            try
            {
                sqlCommandParameters.Add(new SqlParameter("@" + parameterName, parameterValue));
            }
            catch (SqlException SqlEx)
            {
                //Diagnostics.RegisterError("SQL error during adding a new SqlParameter: " + SqlEx.Message, SqlEx);
                //throw new CoreException(SqlEx.Message, SqlEx);
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error during adding a new SqlParameter: " + ex.Message, ex);
                //throw new CoreException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Refreshes the SQL command's parameters.
        /// </summary>
        /// <param name="thisCommand">The this command.</param>
        private void RefreshCommandParameters(SqlCommand thisCommand)
        {
            try
            {
                for (int i = 0; i < sqlCommandParameters.Count; i++)
                {
                    thisCommand.Parameters.Add(sqlCommandParameters[i]);
                }
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error during adding a new SqlParameter: " + ex.Message, ex);
                //throw new CoreException(ex.Message, ex);
            }
        }


        /// <summary>
        /// Gets the data row collection.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public DataRowCollection GetDataRowCollection(string query)
        {
            DataRowCollection result = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            DataTable dataTable = null;
            try
            {
                connection = GetConnection();
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                RefreshCommandParameters(command);
                //
                dataReader = command.ExecuteReader();
                dataTable = new DataTable();
                dataTable.Load(dataReader);
                result = dataTable.Rows;
                //
                command.Parameters.Clear();
            }
            catch (SqlException SqlEx)
            {
                //Diagnostics.RegisterError("SQL error of getting the DataRowCollection: " + SqlEx.Message, SqlEx);
                //throw new CoreException(SqlEx.Message, SqlEx);
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error of getting the DataRowCollection: " + ex.Message, ex);
                //throw new CoreException(ex.Message, ex);
            }
            finally
            {
                CloseAll(connection, command, dataReader, dataTable);
            }

            return result;

        }

        /// <summary>
        /// Gets the data row collection.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        public DataTable GetTable(string query)
        {
            DataTable result = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader dataReader = null;
            DataTable dataTable = null;
            try
            {
                connection = GetConnection();
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                RefreshCommandParameters(command);
                //
                dataReader = command.ExecuteReader();
                dataTable = new DataTable();
                dataTable.Load(dataReader);
                result = dataTable;
                //
                command.Parameters.Clear();
            }
            catch (SqlException SqlEx)
            {
                //Diagnostics.RegisterError("SQL error of getting the DataRowCollection: " + SqlEx.Message, SqlEx);
                //throw new CoreException(SqlEx.Message, SqlEx);
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error of getting the DataRowCollection: " + ex.Message, ex);
                //throw new CoreException(ex.Message, ex);
            }
            finally
            {
                CloseAll(connection, command, dataReader, dataTable);
            }

            return result;

        }

        /// <summary>
        /// Executes the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        public void Execute(string query)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = GetConnection();
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                RefreshCommandParameters(command);
                //
                command.ExecuteNonQuery();
                //
            }
            catch (SqlException SqlEx)
            {
                //Diagnostics.RegisterError("SQL error of query execution: " + SqlEx.Message, SqlEx);
                //throw new CoreException(SqlEx.Message, SqlEx);
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error of query execution: " + ex.Message, ex);
                //throw new CoreException(ex.Message, ex);
            }
            finally
            {
                CloseAll(connection, command);
            }
        }


        /// <summary>
        /// Executes the query (Insert new row in table) and return the identity (ID of inserted row).
        /// </summary>
        /// <param name="insertQuery">The insertQuery.</param>
        /// <returns></returns>
        public int ExecuteAndReturnIdentity(string insertQuery)
        {
            int result = -1;
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = GetConnection();
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = insertQuery;
                command.CommandType = CommandType.Text;
                RefreshCommandParameters(command);
                //
                command.ExecuteNonQuery();
                //
                command.Parameters.Clear();
                command.CommandText = "SELECT @@IDENTITY";
                try
                {
                    string identity = command.ExecuteScalar().ToString();
                    Int32.TryParse(identity, out result);
                }
                catch (ArgumentException argEx)
                {
                    //Diagnostics.RegisterError("SQL error during getting the unique ID of record: " + argEx.Message, argEx);
                    //throw new CoreException(argEx.Message, argEx);
                }
            }
            catch (SqlException SqlEx)
            {
                //Diagnostics.RegisterError("SQL error during execution query: " + SqlEx.Message, SqlEx);
                //throw new CoreException(SqlEx.Message, SqlEx);
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error during execution query: " + ex.Message, ex);
                //throw new CoreException(ex.Message, ex);
            }
            finally
            {
                CloseAll(connection, command);
            }
            return result;
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public static void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null &&
                    connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    connection.Dispose();
                }
                connection = null;
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error. Dispose SqlConnection failed: " + ex.Message, ex);                
            }
        }

        /// <summary>
        /// Closes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public static void CloseCommand(SqlCommand command)
        {
            try
            {
                if (command != null)
                {
                    command.Parameters.Clear();
                    command.Dispose();
                }
                command = null;
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error. Dispose SqlCommand failed: " + ex.Message, ex);   
            }
        }

        ///// <summary>
        ///// Closes the result set.
        ///// </summary>
        ///// <param name="resultSet">The result set.</param>
        //public static void CloseResultSet(SqlSet resultSet)
        //{
        //    try
        //    {
        //        if (resultSet != null)
        //        {
        //            resultSet.Close();
        //            resultSet.Dispose();
        //        }
        //        resultSet = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Diagnostics.RegisterError("SQL error. Dispose SqlResultSet failed: " + ex.Message, ex);   
        //    }
        //}

        /// <summary>
        /// Closes the transaction.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        public static void CloseTransaction(SqlTransaction transaction)
        {
            try
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }
                transaction = null;
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error. Dispose SqlTransaction failed: " + ex.Message, ex);   
            }
        }

        /// <summary>
        /// Closes the data reader.
        /// </summary>
        /// <param name="dataReader">The data reader.</param>
        public static void CloseDataReader(SqlDataReader dataReader)
        {
            try
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                dataReader = null;
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error. Dispose SqlDataReader failed: " + ex.Message, ex);   
            }
        }

        /// <summary>
        /// Closes the data table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        public static void CloseDataTable(DataTable dataTable)
        {
            try
            {
                if (dataTable != null)
                {
                    dataTable.Dispose();
                }
                dataTable = null;
            }
            catch (Exception ex)
            {
                //Diagnostics.RegisterError("SQL error. Dispose DataTable failed: " + ex.Message, ex);   
            }
        }

        /// <summary>
        /// Closes all objects.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public static void CloseAll(SqlConnection connection)
        {
            CloseConnection(connection);
        }

        /// <summary>
        /// Closes all objects.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="command">The command.</param>
        public static void CloseAll(SqlConnection connection,
                                    SqlCommand command)
        {
            CloseConnection(connection);
            CloseCommand(command);
        }

        ///// <summary>
        ///// Closes all objects.
        ///// </summary>
        ///// <param name="connection">The connection.</param>
        ///// <param name="command">The command.</param>
        ///// <param name="resultSet">The result set.</param>
        //public static void CloseAll(SqlConnection connection,
        //                            SqlCommand command,
        //                            SqlResultSet resultSet)
        //{
        //    CloseConnection(connection);
        //    CloseCommand(command);
        //    CloseResultSet(resultSet);
        //}

        /// <summary>
        /// Closes all objects.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="command">The command.</param>
        /// <param name="transaction">The transaction.</param>
        public static void CloseAll(SqlConnection connection,
                                    SqlCommand command,
                                    SqlTransaction transaction)
        {
            CloseConnection(connection);
            CloseCommand(command);
            CloseTransaction(transaction);
        }

        ///// <summary>
        ///// Closes all objects.
        ///// </summary>
        ///// <param name="connection">The connection.</param>
        ///// <param name="command">The command.</param>
        ///// <param name="resultSet">The result set.</param>
        ///// <param name="transaction">The transaction.</param>
        //public static void CloseAll(SqlConnection connection,
        //                            SqlCommand command,
        //                            SqlResultSet resultSet,
        //                            SqlTransaction transaction)
        //{
        //    CloseConnection(connection);
        //    CloseCommand(command);
        //    CloseResultSet(resultSet);
        //    CloseTransaction(transaction);
        //}

        /// <summary>
        /// Closes all objects.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="command">The command.</param>
        /// <param name="dataReader">The data reader.</param>
        /// <param name="dataTable">The data table.</param>
        public static void CloseAll(SqlConnection connection,
                                    SqlCommand command,
                                    SqlDataReader dataReader,
                                    DataTable dataTable)
        {
            CloseConnection(connection);
            CloseCommand(command);
            CloseDataReader(dataReader);
            CloseDataTable(dataTable);
        }
        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            sqlCommandParameters = null;
        }

        #endregion
    }


}