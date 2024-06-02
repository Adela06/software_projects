using System;
using System.Data;
using System.Data.SqlClient;

namespace gradinaTema1.Model.Repository
{
    public class Repository : IDisposable
    {
        private static readonly string CONNECTION_STRING = "Data Source=localhost;Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;Initial Catalog=";
        //private static readonly string CONNECTION_STRING = "Data Source=localhost;Initial Catalog=GradinaB;";

        private static readonly string USER = "dbo";
        //private static readonly string PASSWORD = "";

        private string dbName;
        private static Repository singleInstance;

        private Repository(string dbName)
        {
            this.dbName = dbName;
        }

        public static Repository GetInstance(string dbName)
        {
            if (singleInstance == null)
            {
                singleInstance = new Repository(dbName);
            }
            return singleInstance;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(CONNECTION_STRING + dbName + ";Trusted_Connection=True;");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error creating connection");
                Console.WriteLine(e.Message);
            }
            return connection;
        }

        public static SqlConnection GetConnection()
        {
            return singleInstance.CreateConnection();
        }

        public bool ExecuteCommand(string sql)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        if (sql.ToUpper().Contains("SELECT"))
                        {
                            command.ExecuteReader();
                        }
                        else
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    Console.WriteLine("SQL command executed successfully!");
                    return true;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }
        public DataTable GetTable(string commandSQL)
        {
            DataTable result = null;
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(commandSQL, conn);
                SqlDataAdapter readData = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                readData.Fill(table);
                result = table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public DataTable GetTable2(string sql)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            //adapter.Fill(dataTable);
                        }
                        SqlDataReader reader = command.ExecuteReader();
                        dataTable.Load(reader);

                    }
                    Console.WriteLine("SQL command executed successfully!");
                    return dataTable;
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public static void Close(SqlConnection connection)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                try
                {
                    connection.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Couldn't close the connection");
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Dispose()
        {
            Close(GetConnection());
        }
    }
}
