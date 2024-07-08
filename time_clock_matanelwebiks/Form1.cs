using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace time_clock
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        string connectionString = "server = MATANEL_VATKIN\\SQLEXPRESS;initial catalog= time_clock; user id=sa; password=1234;" +
            "TrustServerCertificate=Yes";
        string loginText = "declare @time datetime = GETDATE(),@code int,@answer varchar(100)\r\nselect @code =(select code from Employees where id=@id)\r\n\r\nif(@code is null)\r\nbegin\r\n\tselect @answer = 'user not found'\r\nend\r\nif not exists (select code from Passwords where employee_code =@code and has_access =1 and password =@password)\r\nbegin\r\n\tselect @answer = 'user or password incorrect'\r\nend\r\nelse\r\nbegin\r\n\tif exists (select code from Passwords where employee_code=@code and has_access =1 and password =@password and expiry_date<=getdate())\r\n\tbegin\r\n\t\tselect @answer = 'you need to chang password'\r\n\tend\r\n\telse\r\n\tbegin\r\n\t\tif exists (select employee_code from Time where employee_code = @code and exit_time is null)\r\n\t\tbegin\r\n\t\t\tupdate Time set exit_time=@time where employee_code = @code and exit_time is null\r\n\t\t\tselect @answer = 'exit time is ' +  CONVERT(NVARCHAR, @time, 121)\r\n\t\tend\r\n\t\telse\r\n\t\tbegin\r\n\t\t\tinsert into Time values(@code, @time,null)\r\n\t\t\tselect @answer ='entry time is ' + CONVERT(NVARCHAR, @time, 121);\r\n\t\tend\r\n\tend\r\nend\r\nselect @answer\r\n";
        public Form1()
        {
            InitializeComponent();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;
            if (Connect())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = loginText;
                    cmd.Parameters.AddWithValue("@id", txtId.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    MessageBox.Show(cmd.ExecuteScalar().ToString());
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FrmChangePassword password = new FrmChangePassword();
            password.Show();
        }
    }
}
