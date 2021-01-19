namespace ForeignNational
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Search = new System.Windows.Forms.TextBox();
            this.SearchBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Back = new System.Windows.Forms.Button();
            this.BackToAddForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Search
            // 
            this.Search.ForeColor = System.Drawing.Color.Black;
            this.Search.Location = new System.Drawing.Point(843, 8);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(138, 20);
            this.Search.TabIndex = 14;
            this.Search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // SearchBox
            // 
            this.SearchBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchBox.FormattingEnabled = true;
            this.SearchBox.Items.AddRange(new object[] {
            "Name",
            "Surname",
            "FatherName",
            "Country",
            "City",
            "CurrentAddress",
            "MartialStatus",
            "BirthDate",
            "TermOfStay"});
            this.SearchBox.Location = new System.Drawing.Point(716, 7);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(121, 21);
            this.SearchBox.TabIndex = 13;
            this.SearchBox.SelectionChangeCommitted += new System.EventHandler(this.SearchBox_SelectionChangeCommitted);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1043, 416);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(-108, 7);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
            this.Back.TabIndex = 11;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            // 
            // BackToAddForm
            // 
            this.BackToAddForm.FlatAppearance.BorderSize = 0;
            this.BackToAddForm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BackToAddForm.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BackToAddForm.Image = global::ForeignNational.Properties.Resources.btntemp;
            this.BackToAddForm.Location = new System.Drawing.Point(12, 5);
            this.BackToAddForm.Name = "BackToAddForm";
            this.BackToAddForm.Size = new System.Drawing.Size(82, 23);
            this.BackToAddForm.TabIndex = 16;
            this.BackToAddForm.Text = "Back";
            this.BackToAddForm.UseVisualStyleBackColor = true;
            this.BackToAddForm.Click += new System.EventHandler(this.BackToAddForm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(433, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Incorrect information";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1027, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackToAddForm);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditForm_FormClosed);
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.ComboBox SearchBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button BackToAddForm;
        private System.Windows.Forms.Label label1;
    }
}