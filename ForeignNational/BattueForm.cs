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
    public partial class BattueForm : Form
    {
        private DB db = new DB();
        private DataTable FillTable() => db.GetPeople("consideration");
        public BattueForm()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, EventArgs e)
        {
            ControlForm CF = new ControlForm();
            CF.Show();
            this.Hide();
        }
        private void LoadInfo()
        {
            dataGridView1.DataSource = FillTable();
            dataGridView1.Columns[0].Visible = false;
            addButtonToDataGrid(11, "Remove", Color.Red);
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
            if (e.ColumnIndex == 10 && dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString() == "Remove")
            {
                if (MessageBox.Show("Remove?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.DeleteCitizen(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()), "consideration");
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        private void Search_TextChanged(object sender, EventArgs e) => Request(Search.Text);
        private void BattueForm_Load(object sender, EventArgs e) => LoadInfo();
        private void SearchBox_SelectionChangeCommitted(object sender, EventArgs e) => Search.Text = "";

        private void BattueForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
