using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shabbat
{
    internal class Manager
    {
        public static List<string> GetAllCategories()
        {
            string sqlQuery = "select name from Categories";
            SqlDataReader reader = DBConnection.RunSqlAllResult(sqlQuery);
            List<string> categories = new List<string>();

            for (int i = 0; reader.Read(); i++)
            {
                categories.Add(reader.GetString(0));
            }
            reader.Close();
            return categories;
        }

        public static List<string> GetAllCategoriesByName(string filter)
        {
            string sqlQuery = "select name from Categories where name like '%'+@filter+'%'";
            string[] parameters = { "@filter" };
            string[] values = { filter };
            SqlDataReader reader = DBConnection.RunSqlAllResult(sqlQuery,parameters,values);
            List<string> categories = new List<string>();

            for (int i = 0; reader.Read(); i++)
            {
                categories.Add(reader.GetString(0));
            }
            reader.Close();
            return categories;
        }

        public static DataTable GetFoodsByCategory(string category)
        {
            string sqlQuery = "select Foods.name as name,count(Foods.name)as calculation \r\nfrom Foods\r\njoin Categories on Categories.id = Foods.category_id\r\nwhere @category_name1 = Categories.name\r\ngroup by Foods.name";
            string[] parameters = { "@category_name1" };
            string[] values = { category };
            return DBConnection.RunSqlTableResult(sqlQuery, parameters, values);
        }

        public static void AddCategory(string category)
        {
            string sqlQuery = "if not exists (select name from Categories where @name= name)\r\nbegin \r\n\tinsert into Categories(name) values (@name)\r\nend";
            string[] parameters = { "@name" };
            string[] values = { category };
            DBConnection.RunSqlNoReturn(sqlQuery, parameters, values);
        }


    }
}
