using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Drink
{
    public partial class MyDrinks : Form
    {
        string path = Directory.GetCurrentDirectory() + "\\drinks.xml";
        XmlDocument XmlDocument = new XmlDocument();
        public MyDrinks()
        {
            InitializeComponent();
            if (File.Exists(path))
                XmlDocument.Load(path);
            else
            {
                XmlNode root = XmlDocument.CreateElement("Drinks");
                XmlDocument.AppendChild(root);
            }
            CleanAllControls();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            double result = 0;
            if (!double.TryParse(txtPrice.Text, out result) || result < 2)
                txtPrice.Text = "2";
        }

        private void btPlus_Click(object sender, EventArgs e)
        {
            txtPrice.Text = (double.Parse(txtPrice.Text) + 0.5).ToString();
        }

        private void btMinus_Click(object sender, EventArgs e)
        {
            txtPrice.Text = (double.Parse(txtPrice.Text) - 0.5).ToString();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            XmlDocument.Save(path);
        }
        private void CleanAllControls()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox) control.Text = "";
                if (control is ComboBox) control.Text = "1.0";
            }
        }
        private void btAddDrink_Click(object sender, EventArgs e)
        {
            XmlNode drink = XmlDocument.CreateElement("drink");
            drink.AppendChild(XmlDocument.CreateElement("name")).InnerText = txtNewDrink.Text;
            drink.AppendChild(XmlDocument.CreateElement("sugar")).InnerText = cmbSugar.Text;
            drink.AppendChild(XmlDocument.CreateElement("coffee")).InnerText = cmbCoffee.Text;
            drink.AppendChild(XmlDocument.CreateElement("cocoa")).InnerText = cmbCocoa.Text;
            drink.AppendChild(XmlDocument.CreateElement("milk")).InnerText = cmbMilk.Text;
            drink.AppendChild(XmlDocument.CreateElement("price")).InnerText = txtPrice.Text;
            XmlDocument.FirstChild.AppendChild(drink);
        }
        private void ShowAllDrinks()
        {
            dgvAllDrinks.Rows.Clear();
            foreach (XmlNode drink in XmlDocument.FirstChild.ChildNodes)
            {
                
                

                string name = "", sugar = "", coffee = "", cocoa = "", milk = "",price = "";
                foreach (XmlNode node in drink.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "name":
                            name = node.InnerText;
                            break;
                        case "sugar":
                            sugar = node.InnerText;
                            break ;
                        case "cocoa":
                            coffee = node.InnerText;
                            break ;
                        case "coffee":
                            cocoa = node.InnerText;
                            break ;
                        case "milk":
                            milk = node.InnerText;
                            break ;
                        case "price":
                            price = node.InnerText;
                            break ;
                        default:
                            break;
                    }

                }
                dgvAllDrinks.Rows.Add(name,sugar,cocoa,coffee,milk,price);
            }
        }

        private void txtNewDrink_TextChanged(object sender, EventArgs e)
        {
            if (txtNewDrink.Text == "") return;
          
            
            
            XmlNode drink = null;
            foreach (XmlNode xmlnode in XmlDocument.FirstChild.ChildNodes)
            {
                if (xmlnode.SelectSingleNode("name").InnerText == txtNewDrink.Text)
                {
                    var dialog = MessageBox.Show("האם ברצונך לעדכן את המשקה המהולל " + txtNewDrink.Text, "עדכון משקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        cmbSugar.Text = xmlnode.SelectSingleNode("sugar").InnerText;
                        cmbMilk.Text = xmlnode.SelectSingleNode("milk").InnerText;
                        cmbCocoa.Text = xmlnode.SelectSingleNode("cocoa").InnerText;
                        cmbCoffee.Text = xmlnode.SelectSingleNode("coffee").InnerText;
                        txtPrice.Text = xmlnode.SelectSingleNode("price").InnerText;

                        btAddDrink.Visible = false;
                        btUpdateDrink.Visible = true;
                        btDeleteDrink.Visible = true;
                    }
                }
            }

        }

        private void btUpdateDrink_Click(object sender, EventArgs e)
        {
            // XmlNode update=
               // fore XmlDocument.FirstChild
        }
    }
}
