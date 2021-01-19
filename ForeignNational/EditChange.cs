using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ForeignNational
{
    public partial class EditChange : Form
    {
        private string name;
        private string secondName;
        private string fatherName;
        private string country;
        private string city;
        private string birthDate;
        private string martialStatus;
        private string termOfStay;
        private string currentAddress;
        private int IDForDelete;
        Validation val = new Validation();
        DB db = new DB();
        StringBuilder sb = new StringBuilder();
        bool isOpen = true;
        public EditChange()
        {
            InitializeComponent();
        }
        public EditChange(string currentName, string currentSecondName, string currentFatherName, string currentCountry, string currentCity, string currentAddress,  string currentTermOfStay, string currentMartialStatus, int ID, string currentBirthDate)
        {
            
            InitializeComponent();

            sb.Append("Enter ");

            Name.Text = currentName;
            SecondName.Text = currentSecondName;
            FatherName.Text = currentFatherName;

            comboCountry.Text = currentCountry;
            City.Text = currentCity;
            
            currentAddressField.Text = currentAddress;
            
            string[] elements = Regex.Split(currentBirthDate, " ");

            try
            {
                comboBoxDays.Text = elements[0];
                comboBoxMonth.Text = elements[1];
                comboBoxYears.Text = elements[2];
            }
            catch (IndexOutOfRangeException)
            {
                comboBoxDays.SelectedIndex = -1;
                comboBoxMonth.SelectedIndex = -1;
                comboBoxYears.SelectedIndex = -1;
            }
            comboBox1.Text = currentMartialStatus;
            TermOfStay.Text = currentTermOfStay;

            IDForDelete = ID;
        }

        private void AddNewCitizenButton_Click(object sender, EventArgs e)
        {
            name = Name.Text;
            secondName = SecondName.Text;
            fatherName = FatherName.Text;
            country = "";
            city = City.Text;
            currentAddress = currentAddressField.Text;
            birthDate = "";
            martialStatus = "";
            termOfStay = TermOfStay.Text;

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
                            country = comboCountry.SelectedItem.ToString();
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
                        if (!val.isSymbolic(currentAddress, 3, 16))
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
                            martialStatus = comboBox1.SelectedItem.ToString();
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
            if (val.isSymbolic(name, 3, 16) && val.isSymbolic(secondName, 3, 16) && val.isSymbolic(fatherName, 3, 16)
                && val.isSymbolic(city, 3, 16) && val.isNumeric(currentAddress) && val.isNumbers(termOfStay))
            {
                if (db.AddNewCitizen(name, secondName, fatherName, country, birthDate, martialStatus, city, currentAddress, termOfStay))
                {
                    EditForm EF = new EditForm();
                    db.DeleteCitizen(IDForDelete, "forchange");
                    EF.Show();
                    isOpen = false;
                    this.Hide();
                }
            }
            else
            {
                sb.Append(" correct");
                MessageBox.Show(sb.ToString());
            }
        }
        private void ToEditForm_Click(object sender, EventArgs e)
        {
            if (isOpen == true && MessageBox.Show("Back to Edit?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isOpen = false;
                EditForm EF = new EditForm();
                EF.Show();
                this.Hide();
            }

        }

        private void EditChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isOpen == true && MessageBox.Show("Close?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isOpen = false;
                EditForm EF = new EditForm();
                EF.Show();
                this.Hide();
            }
        }
    }
}
