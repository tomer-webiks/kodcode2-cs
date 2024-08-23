using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace time_clock
{

    public enum DATA_TYPES
    {
        INT,
        STRING,
        DATE,
        BOOL,
        DECIMAL
    }

    internal class DBConnection
    {
        static string connectionString = "server = DESKTOP-3JPK806\\SQLEXPRESS;initial catalog=ShabbatGuests; user id=sa; password=1234;TrustServerCertificate=Yes";

        private static SqlConnection _sqlConnection;

        private static SqlCommand CreateCommand(string sql, string[] parameters = null, string[] values = null, DATA_TYPES[] dataTypes = null)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = _sqlConnection,
                CommandText = sql
            };

            for (int i = 0; i < parameters.Length; i++)
            {
                switch (dataTypes[i])
                {
                    case DATA_TYPES.INT:
                        cmd.Parameters.AddWithValue(parameters[i], Convert.ToInt32(values[i]));
                        break;
                    case DATA_TYPES.STRING:
                        cmd.Parameters.AddWithValue(parameters[i], Convert.ToString(values[i]));
                        break;
                    case DATA_TYPES.DATE:
                        cmd.Parameters.AddWithValue(parameters[i], Convert.ToDateTime(values[i]));
                        break;
                    case DATA_TYPES.BOOL:
                        cmd.Parameters.AddWithValue(parameters[i], Convert.ToBoolean(values[i]));
                        break;
                    case DATA_TYPES.DECIMAL:
                        cmd.Parameters.AddWithValue(parameters[i], Convert.ToDecimal(values[i]));
                        break;
                    default:
                        cmd.Parameters.AddWithValue(parameters[i], values[i]);
                        break;
                }
            }

            return cmd;
        }

        private static bool Connect()
        {
            try
            {
                if (_sqlConnection == null)
                {
                    _sqlConnection = new SqlConnection(connectionString);
                }

                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }
                
                return true;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static SqlDataReader RunSQLAllResults(string sql, string[] parameters = null, string[] values = null, DATA_TYPES[] dataTypes = null)
        {
            if (Connect())
            {
                try
                {
                    SqlCommand cmd = CreateCommand(sql, parameters, values, dataTypes);
                    return cmd.ExecuteReader();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

            return null;
        }

        public static string RunSQLNoResult(string sql, string[] parameters = null, string[] values = null, DATA_TYPES[] dataTypes = null)
        {
            if (Connect())
            {
                try
                {
                    SqlCommand cmd = CreateCommand(sql, parameters, values, dataTypes);
                    object result = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    return ex.Message;
                }
            }

            return null;
        }


        public static string RunSQLSingleResult(string sql, string[] parameters = null, string[] values = null, DATA_TYPES[] dataTypes = null)
        {
            if (Connect())
            {
                try
                {
                    SqlCommand cmd = CreateCommand(sql, parameters, values, dataTypes);
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
