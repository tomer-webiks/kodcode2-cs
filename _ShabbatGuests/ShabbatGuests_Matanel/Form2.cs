using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shabbat
{
    public partial class Form2 : Form
    {
        public List<Form2> Forms2;
        public int Position;
        public Form2(List<Form2> forms2,int position, string categoryName)
        {
            InitializeComponent();
            Forms2 = forms2;
            Position = position;
            lblCategoryName.Text = categoryName;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dgvAllGuests.DataSource = Manager.GetFoodsByCategory(lblCategoryName.Text);
        }

        private void btnFowred_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (Position < Forms2.Count() && Position > 0)
            {
                Forms2[Position - 1].Visible = true;
            }
            else
            {
                Forms2[Forms2.Count() - 1].Visible = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (Position >= 0 && Position < Forms2.Count() - 1)
            {
                Forms2[Position + 1].Visible = true;
            }
            else
            {
                Forms2[0].Visible = true;

            }
        }
    }
}
