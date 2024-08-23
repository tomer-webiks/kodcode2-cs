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
    public partial class FrmClockIn : Form
    {
        public FrmClockIn()
        {
            InitializeComponent();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)13) return;

            // Collect TextBox inputs from form
            string result = EmployeeManager.Login(txtId.Text, txtPassword.Text);
            MessageBox.Show(result);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            FrmChangePassword password = new FrmChangePassword();
            password.Show();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
