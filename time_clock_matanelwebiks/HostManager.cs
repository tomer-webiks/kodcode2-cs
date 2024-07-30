using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace time_clock
{
    internal class HostManager
    {
        public static List<string> GetCategories()
        {
            string sql = "select * from Categories";
            SqlDataReader reader = DBConnection.RunSQLAllResults(sql);
            List<string> categories = new List<string>();

            for (int i = 0; reader.Read() ; i++)
            {
                categories.Add(reader.GetString(1));
            }

            return categories;
        }

        public static string[] SearchCategoryByName(string name)
        {
            string sql = "select * from Categories where name like '%' + @letter + '%'";

            string[] parameters = { "@letter" };
            string[] values = { name };
            SqlDataReader reader = DBConnection.RunSQLAllResults(sql, parameters, values);

            string[] categories = new string[reader.GetSchemaTable().Rows.Count];

            for (int i = 0; i < categories.Length; i++, reader.Read())
            {
                categories[i] = reader.GetString(1);
            }

            return categories;
        }
    }
}
