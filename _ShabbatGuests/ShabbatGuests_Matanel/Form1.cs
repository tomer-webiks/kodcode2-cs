using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shabbat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            List<Form2> forms = new List<Form2>();
            List<string> categories = Manager.GetAllCategories();
            for (int i = 0; i < categories.Count; i++)
            {
                forms.Add(new Form2(forms, i, categories[i]));
            }
            forms.First().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> categries = Manager.GetAllCategories();
            int i = 0;
            while (i < categries.Count())
            {
                listBoxCategory.Items.Add(i+1+") "+categries[i]);
                i++;
            }
            listBoxCategory.DoubleClick += (Sender, E) =>
            {
                string selectedItem = listBoxCategory.SelectedItem.ToString();
                if (selectedItem == "") return;
                txtCategory.Text = selectedItem.Substring(selectedItem.IndexOf(") ") + 2);
            };
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            List<string> categries = Manager.GetAllCategoriesByName(txtCategory.Text);
            int i = 0;
            listBoxCategory.Items.Clear();
            while (i < categries.Count())
            {
                listBoxCategory.Items.Add(i + 1 + ") " + categries[i]);
                i++;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Manager.AddCategory(txtCategory.Text);
            List<string> categries = Manager.GetAllCategories();
            int i = 0;
            listBoxCategory.Items.Clear();
            while (i < categries.Count())
            {
                listBoxCategory.Items.Add(i + 1 + ") " + categries[i]);
                i++;
            }
            txtCategory.Text = null;
        }
    }
}
