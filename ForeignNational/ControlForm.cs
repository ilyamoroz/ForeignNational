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

namespace ForeignNational
{
    public partial class ControlForm : Form
    {
        private DB db = new DB();
        private DataTable FillTable() => db.GetPeople("citizen");
        public ControlForm()
        {
            InitializeComponent();
            SetDoubleBuffered(dataGridView1, true);
        }
        public void SetDoubleBuffered(Control c, bool value)
        {
            PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null)
            {
                pi.SetValue(c, value, null);

                MethodInfo mi = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
                if (mi != null)
                    mi.Invoke(c, new object[] { ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true });

                mi = typeof(Control).GetMethod("UpdateStyles", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic);
                if (mi != null)
                    mi.Invoke(c, null);
            }
        }

        private void ControlForm_Load(object sender, EventArgs e) 
        {
            LoadInfo();
        }
        private void LoadInfo()
        {
            dataGridView1.DataSource = FillTable();
            dataGridView1.Columns[0].Visible = false;
            addButtonToDataGrid(11, "Remove", Color.Red);
            addButtonToDataGrid(12, "To change", Color.CornflowerBlue);
            addButtonToDataGrid(13, "Battue", Color.DarkOrange);
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
        private void ToLoginFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm LF = new LoginForm();
            LF.Show();
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
                if (MessageBox.Show("Удалить?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.DeleteCitizen(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()), "citizen");
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }

            if (e.ColumnIndex == 11 && dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString() == "To change")
            {
                if (MessageBox.Show("Change?", "Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.SendTo(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()), "forchange");
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }

            if (e.ColumnIndex == 12 && dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString() == "Battue")
            {
                if (MessageBox.Show("Battue?", "Battue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.SendTo(Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()), "consideration");
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        private void CloseBTN_Click(object sender, EventArgs e) => Application.Exit();
        private void Search_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Count > 12)
            {
                dataGridView1.Columns.RemoveAt(10);
                dataGridView1.Columns.RemoveAt(10);
                dataGridView1.Columns.RemoveAt(10);
            }
            Request(Search.Text);
            addButtonToDataGrid(11, "Remove", Color.Red);
            addButtonToDataGrid(12, "To change", Color.CornflowerBlue);
            addButtonToDataGrid(13, "Battue", Color.DarkOrange);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BattueForm BF = new BattueForm();
            BF.Show();
            this.Hide();
        }
        private void SearchBox_SelectionChangeCommitted(object sender, EventArgs e) => Search.Text = "";//clear search_text    

        private void ControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
