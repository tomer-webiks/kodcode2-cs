using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employees
{
    public partial class EmployeesForm : Form
    {
        int employeeNumber = 0;
        Employee[] employees;
        public EmployeesForm()
        {
            InitializeComponent();
            if (employees == null)
                codetxt.Text = "1";
            else
            {
                ShowEmployee(employees[employeeNumber]);
            }

        }

        private void Hadash_Click(object sender, EventArgs e)
        {
            ClearFields(this);

        }
        private void ClearFields(Control control)
        {
            foreach (Control ctr in control.Controls)
            {
                if (ctr is TextBox)
                    ctr.Text = "";
                else if (ctr is RadioButton)
                    ((RadioButton)ctr).Checked = false;
                else if (ctr is Panel)
                    ClearFields(ctr);
                else if (ctr is DateTimePicker)
                    ((DateTimePicker)ctr).Value = DateTime.Now.AddYears(-25);
            }
            if (employees == null)
                codetxt.Text = "1";
            else
                codetxt.Text = (employees[employees.Length - 1].code + 1).ToString();
        }

        private void AddEmpButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee(IDtxt.Text, int.Parse(codetxt.Text), FirstNametxt.Text, LastNametxt.Text, BirthDate.Value, ZaharRadio.Checked, status, phoneNumber.Text, Citytxt.Text, streettxt.Text, HouseNumbertxt.Text);
            AddNewEMPtoArray(employee);
            ClearFields(this);
        }
        private void Update(Employee employee)
        {
            employee.FirstName = FirstNametxt.Text;
            employee.LastName = LastNametxt.Text;
            employee.ID = IDtxt.Text;
            employee.Birthday = BirthDate.Value;
            employee.City = Citytxt.Text;
            employee.Status = status;
            employee.isMale = ZaharRadio.Checked;
            employee.Cellphone = phoneNumber.Text;
            employee.Street = streettxt.Text;
            employee.HouseNumber = HouseNumbertxt.Text;

        }
        private void ShowEmployee(Employee employee)
        {
            if (employee == null) return;
            codetxt.Text = employee.code.ToString();
            IDtxt.Text = employee.ID.ToString();
            FirstNametxt.Text = employee.FirstName;
            LastNametxt.Text = employee.LastName;
            BirthDate.Value = employee.Birthday;
            ZaharRadio.Checked = employee.isMale;
            NekevaRadio.Checked = !employee.isMale;
            switch (employee.Status)
            {
                case "רווק":
                    {
                        RavakRadio.Checked = true;
                        break;
                    }
                case "נשוי":
                    {
                        NasuiRadio.Checked = true;
                        break;
                    }
                case "גרוש":
                    {
                        GaroshRadio.Checked = true;
                        break;
                    }
                case "אלמן":
                    {
                        AlmanRadio.Checked = true;
                        break;
                    }
            }
            phoneNumber.Text = employee.Cellphone;
            streettxt.Text = employee.Street;
            Citytxt.Text = employee.City;
            HouseNumbertxt.Text = employee.HouseNumber;

        }
        private void AddNewEMPtoArray(Employee employee)
        {
            if (employees == null)
                employees = new Employee[1];
            else
            {
                Employee[] temp = new Employee[employees.Length + 1];
                for (int i = 0; i < employees.Length; i++)
                {
                    temp[i] = employees[i];
                }
                employees = temp;
            }
            employees[employees.Length - 1] = employee;
        }
        private string status
        {
            get
            {
                foreach (Control ctr in statusPanel.Controls)
                {
                    if (ctr is RadioButton && ((RadioButton)ctr).Checked)
                        return ctr.Text;

                }
                return "";
            }
            set
            {

            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {

            try
            {
                int newLoc = int.Parse(codetxt.Text);
                ShowEmployee(employees[newLoc]);
            }
            catch
            {
                ShowEmployee(employees[employees.Length - 1]);
            }

        }

        private void beforeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int newLoc = int.Parse(codetxt.Text) - 2;
                ShowEmployee(employees[newLoc]);
            }
            catch
            {
                ShowEmployee(employees[0]);
            }

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Employee emp = searchEmployeeByCode(int.Parse(Searchtxt.Text));
            if (emp != null)
            {
                ShowEmployee(emp);
            }
        }
        private Employee searchEmployeeByCode(int code)
        {
            return employees.FirstOrDefault(x => x.code == code);
        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            Employee employee = employees.FirstOrDefault(x => x.code == int.Parse(codetxt.Text));
            Update(employee);
        }
        private void Delete(Employee emp)
        {
           employees = employees.Where(e => e != emp).ToArray();            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Employee employee = employees.FirstOrDefault(x => x.code == int.Parse(codetxt.Text));
            Delete(employee);
        }
        private int OnlyNumber()
        {
            int result = 0;
            try
            {
                result = int.Parse(Microsoft.VisualBasic.Interaction.InputBox("הכנס מספר", "דיר באלק"));
            } catch
            {
                return OnlyNumber();
            }
                Console.WriteLine(result);
                 return result;
           }

        private void button2_Click(object sender, EventArgs e)
        {

            Employee emp = searchEmployeeByCode(OnlyNumber());
            if (emp != null)
            {
                ShowEmployee(emp);
            }
        }
    }
}
