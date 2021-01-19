using System;
using System.Text;
using System.Windows.Forms;

namespace ForeignNational
{
    public partial class AddForm : Form
    {
        Validation val = new Validation();
        StringBuilder sb = new StringBuilder();
        DB db = new DB();

        private string name;
        private string secondName;
        private string fatherName;
        private string country;
        private string city;
        private string birthDate;
        private string martialStatus;
        private string termOfStay;
        private string currentAddress;




       
        private string[] days31 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", };
        private string[] days30 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"};
        private string[] FebruaryleapDays = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29"};
        private string[] FebruaryDays = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28"};
        private string[] month31 = { "January", "March", "May", "July", "August", "October", "December" };

        public AddForm()
        {
            InitializeComponent();
            comboBoxDays.DataSource = days31;
            comboBoxDays.SelectedIndex = -1;
        }
        private void checkDate()
        {
            string month = "";
            string years = "";
            bool leapDays = false;

            try
            {
                month = comboBoxMonth.SelectedItem.ToString();
                years = comboBoxYears.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
            }

           

            try
            {
                if (Int32.Parse(years) % 4 == 0)
                {
                    leapDays = true;

                }
            }
            catch (FormatException)
            {
            }

            for (int j = 0; j < 7; j++)
            {
                if (month == month31[j])
                { 
                    comboBoxDays.DataSource = null;
                    comboBoxDays.DataSource = days31;
                    break;
                }
                else if(month != "February")
                {
                    comboBoxDays.DataSource = null;
                    comboBoxDays.DataSource = days30;
                }
            }
            for (int i = 0; i < 13; i++)
            {
                if (leapDays && month == "February")
                {
                    comboBoxDays.DataSource = null;
                    comboBoxDays.DataSource = FebruaryleapDays;
                    break;
                }
                else if(month == "February")
                {
                    comboBoxDays.DataSource = null;
                    comboBoxDays.DataSource = FebruaryDays;
                    break;
                }
            } 
        }
        private void ClearAddForm()
        {
            NameField.Text = String.Empty;
            SecondNameField.Text = String.Empty;
            FatherNameField.Text = String.Empty;
            CountryDropDown.SelectedIndex = -1;
            comboBoxDays.SelectedIndex = -1;
            comboBoxMonth.SelectedIndex = -1;
            comboBoxYears.SelectedIndex = -1;
            CountryDropDown.SelectedIndex = -1;
            CityField.Text = String.Empty;
            CurrentAddressField.Text = String.Empty;
            TermOfStayField.Text = String.Empty;
        }
        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AddNewCitizenButton_Click_1(object sender, EventArgs e)
        {

            name = NameField.Text;
            secondName = SecondNameField.Text;
            fatherName = FatherNameField.Text;
            city = CityField.Text;
            currentAddress = CurrentAddressField.Text;
            birthDate = "";
            martialStatus = "";
            termOfStay = TermOfStayField.Text;

            sb.Append("Enter ");
            for (int i = 0; i < 9; i++)
            {
                switch (i)
                {
                    case 0:
                        if (!val.isSymbolic(name, 3, 16))
                        {
                            sb.Append("Name, ");
                        }
                        break;
                    case 1:
                        if (!val.isSymbolic(secondName, 3, 16))
                        {
                            sb.Append("Surname, ");
                        }
                        break;
                    case 2:
                        if (!val.isSymbolic(fatherName, 3, 16))
                        {
                            sb.Append("Father Name, ");
                        }
                        break;
                    case 3:
                        try
                        {
                            country = CountryDropDown.SelectedItem.ToString();
                        }
                        catch (NullReferenceException)
                        {
                            sb.Append("Country, ");
                        }
                        break;
                    case 4:
                        if (!val.isSymbolic(city, 3, 16))
                        {
                            sb.Append("City, ");
                        }
                        break;
                    case 5:
                        if (!val.isNumeric(currentAddress))
                        {
                            sb.Append("Current Address, ");
                        }
                        break;
                    case 6:
                        try
                        {
                            birthDate = comboBoxDays.SelectedItem.ToString() + " " + comboBoxMonth.SelectedItem.ToString() + " " + comboBoxYears.SelectedItem.ToString();

                        }
                        catch (NullReferenceException)
                        {
                            sb.Append("Birth Date, ");
                        }
                        break;
                    case 7:
                        try
                        {
                            martialStatus = CountryDropDown.SelectedItem.ToString();
                        }
                        catch (NullReferenceException)
                        {
                            sb.Append("Martial Status, ");
                        }
                        break;
                    case 8:
                        if (!val.isNumbers(termOfStay))
                        {
                            sb.Append("Term of stay");
                        }
                        break;
                }

            }
            if (val.isSymbolic(name, 3, 16) && val.isSymbolic(secondName, 3, 16) && val.isSymbolic(fatherName, 3, 16) && val.isSymbolic(city, 3, 16) && val.isNumeric(currentAddress) && val.isNumbers(termOfStay))
            {
                if (db.AddNewCitizen(name, secondName, fatherName, country, birthDate, martialStatus, city, currentAddress, termOfStay))
                {
                    MessageBox.Show("Successful");
                    ClearAddForm();
                }
            }
            else
            {
                sb.Append(" correctly");
                MessageBox.Show(sb.ToString());
                sb.Clear();
            }
        }

        private void EditButton_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Go to Edit?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EditForm EF = new EditForm();
                EF.Show();
                this.Hide();
            }
        }

        private void ToLoginFormButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                LoginForm LF = new LoginForm();
                LF.Show();
            }
        }

        private void comboBoxMonth_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            checkDate();
        }

        private void comboBoxYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkDate();
        }
    }
}
