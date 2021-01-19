using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ForeignNational
{
    public partial class EditForm : Form
    {
        private DB db = new DB();
        private DataTable FillTable() => db.GetPeople("forchange");
        public EditForm()
        {
            InitializeComponent();
        }
        private void EditForm_Load(object sender, EventArgs e) => LoadInfo();
        private void BackToAddForm_Click(object sender, EventArgs e)
        {
            AddForm AF = new AddForm();
            AF.Show();
            this.Hide();
        }
        private void LoadInfo()
        {
            dataGridView1.DataSource = FillTable();
            dataGridView1.Columns[0].Visible = false;
            addButtonToDataGrid(11, "Select", Color.Green);

        }
        private void addButtonToDataGrid(int dataSize, string text, Color color)
        {
            if (dataGridView1.Columns.Count < dataSize)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Text = text;
                btn.UseColumnTextForButtonValue = true;
                btn.FlatStyle = FlatStyle.Flat;
                btn.CellTemplate.Style.BackColor = color;
                btn.CellTemplate.Style.ForeColor = Color.White;
                dataGridView1.Columns.Add(btn);
            }
        }
        private void Request(string search)
        {
            try
            {
                DataView DV = new DataView(FillTable());
                DV.RowFilter = string.Format(SearchBox.Text + " LIKE'" + search + "%'");
                dataGridView1.DataSource = DV;
            }
            catch (SyntaxErrorException)
            {
                MessageBox.Show("Select a field!");
            }
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 && dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() == "Select")
            {
                if (MessageBox.Show("Change?", "Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int ID = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    EditChange EC = new EditChange(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                       dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(),
                       dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(), 
                       dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(), 
                       ID, dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                    EC.Show();
                    this.Hide();
                }
            }

        }
        private void Search_TextChanged_1(object sender, EventArgs e) => Request(Search.Text);
        private void SearchBox_SelectionChangeCommitted(object sender, EventArgs e) => Search.Text = "";

        private void Search_TextChanged(object sender, EventArgs e) => Request(Search.Text);

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    } 
}
