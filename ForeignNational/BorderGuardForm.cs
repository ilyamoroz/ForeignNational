using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForeignNational
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddNewCitizenButton_Click(object sender, EventArgs e)
        {
            Validation val = new Validation();
            DB db = new DB();

            string name = Name.Text;
            string secondName = SecondName.Text;
            string fatherName = FatherName.Text;
            string country = Country.Text;
            string city = City.Text;
            string birthDate = String.Empty;
            string martialStatus = String.Empty;
            string termOfStay = TermOfStay.Text;

            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0:
                        if (!val.isSymbolic(name, 3, 16))
                        {
                            MessageBox.Show("Enter name correct");
                        }
                        break;
                    case 1:
                        if (!val.isSymbolic(secondName, 3, 16))
                        {
                            MessageBox.Show("Enter second name correct");
                        }
                        break;
                    case 2:
                        if (!val.isSymbolic(secondName, 3, 16))
                        {
                            MessageBox.Show("Enter father name correct");
                        }
                        break;
                    case 3:
                        if (!val.isSymbolic(country, 3, 16))
                        {
                            MessageBox.Show("Enter country correct");
                        }
                        break;
                    case 4:
                        if (!val.isSymbolic(city, 3, 16))
                        {
                            MessageBox.Show("Enter city correct");
                        }
                        break;
                    case 5:
                        if (!val.isSymbolic(termOfStay, 3, 16))
                        {
                            MessageBox.Show("Enter Term of stay correct");
                        }
                        break;

                }

            }
            try
            {
                birthDate = comboBoxDays.SelectedItem.ToString() + " " + comboBoxMonth.SelectedItem.ToString() + " " + comboBoxYears.SelectedItem.ToString();

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Enter your birth date!");
            }
            try
            {
                martialStatus = comboBox1.SelectedItem.ToString();

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Enter your martinal status!");
            }
            
            
            if (val.isSymbolic(name, 3, 16) && val.isSymbolic(secondName, 3, 16) && val.isSymbolic(fatherName, 3, 16)
                && val.isSymbolic(country, 3, 16) && val.isSymbolic(city, 3, 16) && val.isNumeric(termOfStay,3,16))
            {
                if (db.AddNewCitizen(name, secondName, fatherName, country, birthDate, martialStatus, city, termOfStay) == "Good")
                {
                    ClearAddForm();
                    MessageBox.Show("Successful");
                }
            }
            else
            {
                ClearAddForm();
                MessageBox.Show("Data entered incorrectly");
            }

        }
        private void ClearAddForm()
        {
            Name.Text = String.Empty;
            SecondName.Text = String.Empty;
            FatherName.Text = String.Empty;
            Country.Text = String.Empty;
            comboBoxDays.Text = String.Empty;
            comboBoxMonth.Text = String.Empty;
            comboBoxYears.Text = String.Empty;
            comboBox1.Text = String.Empty;
            City.Text = String.Empty;
        }
        private void ToLoginFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm LF = new LoginForm();
            LF.Show();
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
