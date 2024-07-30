using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TestConsoleApp
{

    internal class DBConnection
    {
        static string connectionString = "server = DESKTOP-3JPK806\\SQLEXPRESS;initial catalog=TimeClock; user id=sa; password=1234;TrustServerCertificate=Yes";

        private static SqlConnection _sqlConnection;
        public static bool Connect()
        {
            try
            {
                if (_sqlConnection == null)
                {
                    _sqlConnection = new SqlConnection(connectionString);
                }

                _sqlConnection.Open();
                return true;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static string runSQL(string sql, string[] parameters, string[] values)
        {
            if (Connect())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _sqlConnection;
                    cmd.CommandText = sql;

                    // Add parameters
                    for (int i=0; i<parameters.Length; i++) {
                        cmd.Parameters.AddWithValue(parameters[i], values[i]);
                    }

                    object result = cmd.ExecuteScalar();
                    return result.ToString();
                }
                catch (SqlException ex)
                {
                    return ex.Message;
                }
            }

            return null;
        }
    }
}
