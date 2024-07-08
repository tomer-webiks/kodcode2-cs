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

namespace time_clock
{
    public partial class FrmChangePassword : Form
    {
        SqlConnection sqlConnection;
        string connectionString = "server = MATANEL_VATKIN\\SQLEXPRESS;initial catalog= time_clock; user id=sa; password=1234;" +
            "TrustServerCertificate=Yes";
        string changPassword = "declare @code int,@answer varchar(100)\r\n\r\nselect @code = (select code from Employees where id = @id)\r\nif @code is not null\r\nbegin \r\n\tif exists (select * from Passwords where @code=employee_code and @old_password=password and  has_access=1)\r\n\t\tbegin\r\n\t\t\tif not exists (select * from Passwords where @code=employee_code and @new_password=password)\r\n\t\t\t\tbegin\r\n\t\t\t\t\tupdate Passwords set has_access=0 where employee_code=@code and @old_password=password\r\n\t\t\t\t\tinsert into Passwords values (@code,@new_password,DATEADD(day, 180, GETDATE()),1)\r\n\t\t\t\t\tselect @answer = 'the expirde date is 180 days'\r\n\t\t\t\tend\r\n\t\t\telse\r\n\t\t\t\tbegin\r\n\t\t\t\t\tselect @answer = 'you alrady used with this password'\r\n\t\t\t\tend\r\n\t\tend\r\n\telse\r\n\t\tbegin\r\n\t\t\tselect @answer = ' password incorrect'\r\n\t\tend\r\nend\r\nelse\r\n\tbegin\r\n\t\tselect @answer = 'username or password incorrect'\r\n\tend\r\n\r\nselect @answer";
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private void FrmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfrimPassword.Text)
            {
                try
                {
                    if (Connect())
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = sqlConnection;
                        cmd.CommandText = changPassword;
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.Parameters.AddWithValue("@old_password", txtOldPassword.Text);
                        cmd.Parameters.AddWithValue("@new_password", txtPassword.Text);

                        MessageBox.Show(cmd.ExecuteScalar().ToString());
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("the passwords does not mutch");
        }
        private bool Connect()
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
    }
}
