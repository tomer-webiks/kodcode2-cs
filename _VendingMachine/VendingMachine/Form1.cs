using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VendingMachine
{
    public partial class Form1 : Form
    {
        private DrinksManager drinksManager;
        public Form1()
        {
            InitializeComponent();
            XmlDocument drinksDocument = MainProject.Main();
            drinksManager = new DrinksManager(drinksDocument);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<List<string>> drinksList = drinksManager.GetDrinksData();
            foreach(List<string> drink in drinksList)
            {
                dgvMenu.Rows.Add(drink.ToArray());
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtPrice.Text = (float.Parse(txtPrice.Text)+0.5).ToString();

        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (float.Parse(txtPrice.Text) > 0.5)
                txtPrice.Text = (float.Parse(txtPrice.Text) - 0.5).ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> drinks = new List<string>()
            {
                txtDreankName.Text,
                cmbSoger.Text,
                cmbCoffee.Text,
                cmbCacao.Text,
                cmbMilk.Text,
                txtPrice.Text
            };
            drinksManager.AddDrink(drinks);
            dgvMenu.Rows.Add(drinks.ToArray());

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            drinksManager.Save();
        }

        private void txtDreankName_TextChanged(object sender, EventArgs e)
        {
            List<string> drinks = drinksManager.GetDrinkByName(txtDreankName.Text);
            if (drinks == null) return;
            DialogResult showDialog = MessageBox.Show("האם ברצונך לעדכן את המשקה?",
                 "עדכן משקה",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (showDialog == DialogResult.Yes)
            {
                cmbSoger.Text = drinks[1];
                cmbCoffee.Text = drinks[2];
                cmbCacao.Text = drinks[3];
                cmbMilk.Text = drinks[4];
                txtPrice.Text = drinks[5];
                btnUpdate.Visible = true;
                btnAdd.Visible = false;
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<string> drinks = new List<string>()
            {
                txtDreankName.Text,
                cmbSoger.Text,
                cmbCoffee.Text,
                cmbCacao.Text,
                cmbMilk.Text,
                txtPrice.Text
            };
            drinksManager.UpdateDrink(drinks);
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            dgvMenu.Rows.Clear();
            List<List<string>> drinksList = drinksManager.GetDrinksData();
            foreach (List<string> drink in drinksList)
            {
                dgvMenu.Rows.Add(drink.ToArray());
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
