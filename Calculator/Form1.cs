using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private TextBox selectedTextBox;

        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            // 1. Convert 'string' to 'int'            
            int num1 = int.Parse(txtNumber1.Text);
            int num2 = int.Parse(txtNumber2.Text);

            // 2. Validate inputs

            // - Check we have values in both txtNumber1 and txtNumber2

            // 3. Perform calculation
            if (cmbOperator.Text == "+")
            {
                lblResult.Text = (num1 + num2).ToString(); // ==> 22
            } else if (cmbOperator.Text == "-")
            {
                lblResult.Text = (num1 - num2).ToString();
            } else if (cmbOperator.Text == "*")
            {
                lblResult.Text = (num1 * num2).ToString();
            } else if (cmbOperator.Text == "/")
            {
                // - Check that txtNumber2 is not 0
                if (num2 == 0)
                {
                    lblResult.Text = "Cannot divide by 0";
                    return;
                }
                
                lblResult.Text = (num1 / num2).ToString();
            }

            
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            selectedTextBox.Text += "1";
        }

        private void btnEquals_Enter(object sender, EventArgs e)
        {

        }

        private void txtNumber1_Enter(object sender, EventArgs e)
        {
            selectedTextBox = sender as TextBox;
        }

        private void txtNumber2_Enter(object sender, EventArgs e)
        {
            selectedTextBox = sender as TextBox;
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
