using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shabbat
{
    internal class DBConnection
    {
        //המשתנה שמחזיק את החיבור
        private static SqlConnection sqlConnection;
        //מתשנה שמחזיק את הכתובת לשרת של הדאטה בייס
        private static string sqlConnectionString = "server = MATANEL_VATKIN\\SQLEXPRESS;initial catalog=shabbat;user id=sa;password=1234;TrustServerCertificate=Yes";

        //פונקציה שמבצעת את פתיחת החיבור
        private static bool Connect()
        {
            try
            {
                if (sqlConnection == null)
                {
                    sqlConnection = new SqlConnection(sqlConnectionString);
                }
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //מחזיר ערך בוד (עם יהיה כמה שורה 1 עמודה אחת
        public static string RunSqlSinglResult(string sql, string[] parmeters = null, string[] values = null)
        {
            if (Connect())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = sql;
                    if (parmeters != null && values != null)
                    {
                        for(int i = 0; i < parmeters.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(parmeters[i],values[i]);
                        }
                    }
                        return cmd.ExecuteScalar().ToString();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return ex.Message;
                }
            }
            return "";
        }

        //מחזיר מצביע שעובר על כל שורה שורה בטבלה
        public static SqlDataReader RunSqlAllResult(string sql, string[] parmeters = null, string[] values = null)
        {
            if (Connect())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = sql;
                    if (parmeters != null && values != null)
                    {
                        for (int i = 0; i < parmeters.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(parmeters[i], values[i]);
                        }
                    }
                        return cmd.ExecuteReader();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            return null;
        }
        //פונקציה שמחזירה טבלת נתונים בזיכרון
        public static DataTable RunSqlTableResult(string sql, string[] parmeters = null, string[] values = null)
        {
            if (Connect()) {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = sql;
                    if (parmeters != null && values != null)
                    {
                        for (int i = 0; i < parmeters.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(parmeters[i], values[i]);
                        }
                    }
                    SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adpter.Fill(dataTable);
                    return dataTable;

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
            return null;
        }

        public static void RunSqlNoReturn(string sql, string[] parmeters = null, string[] values = null)
        {
            if (Connect())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = sql;
                    if (parmeters != null && values != null)
                    {
                        for (int i = 0; i < parmeters.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(parmeters[i], values[i]);
                        }
                    }
                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
