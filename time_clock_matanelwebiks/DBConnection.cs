using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace time_clock
{
    internal class DBConnection
    {
        static SqlConnection sqlConnection;
        static string connectionString = "server = DESKTOP-3JPK806\\SQLEXPRESS;initial catalog=TimeClock; user id=sa; password=1234;TrustServerCertificate=Yes";

        public static bool Connect()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
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
                    cmd.Connection = sqlConnection;
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
