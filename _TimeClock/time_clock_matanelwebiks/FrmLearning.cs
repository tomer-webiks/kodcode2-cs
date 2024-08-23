using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace time_clock
{
    public partial class FrmLearning : Form
    {
        public FrmLearning()
        {
            InitializeComponent();
        }

        private void frmLearning_Load(object sender, EventArgs e)
        {
            //TestTimeClock();
            LearnSqlDataReader();
        }

        private void LearnSqlDataReader()
        {
            List<string> categories = HostManager.GetCategories();

            foreach (string category in categories)
            {
                MessageBox.Show($"Name: {category}");
            }
        }

        private void TestTimeClock()
        {
            string sql = "select * from Employees";
            SqlDataReader reader = DBConnection.RunSQLAllResults(sql);

            while (reader.Read())
            {
                // תביא לי את העמודה הראשונה בסוג INT
                int code = reader.GetInt32(0); // 'code'
                string id = reader.GetString(1); // 'id'
                string fullName = reader.GetString(2); // 'full_name'

                MessageBox.Show($"code: {code} | id: {id} | full_name: {fullName}");
            }
        }
    }
}
