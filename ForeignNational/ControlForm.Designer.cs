namespace ForeignNational
{
    partial class ControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Search = new System.Windows.Forms.TextBox();
            this.SearchBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ToLoginFormButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1245, 416);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Search
            // 
            this.Search.ForeColor = System.Drawing.Color.Black;
            this.Search.Location = new System.Drawing.Point(1040, 9);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(138, 20);
            this.Search.TabIndex = 1;
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
            this.SearchBox.Location = new System.Drawing.Point(913, 9);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(121, 21);
            this.SearchBox.TabIndex = 7;
            this.SearchBox.SelectionChangeCommitted += new System.EventHandler(this.SearchBox_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(578, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Control";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(93, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "Battue";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ToLoginFormButton
            // 
            this.ToLoginFormButton.FlatAppearance.BorderSize = 0;
            this.ToLoginFormButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ToLoginFormButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ToLoginFormButton.Image = ((System.Drawing.Image)(resources.GetObject("ToLoginFormButton.Image")));
            this.ToLoginFormButton.Location = new System.Drawing.Point(1, 6);
            this.ToLoginFormButton.Name = "ToLoginFormButton";
            this.ToLoginFormButton.Size = new System.Drawing.Size(86, 23);
            this.ToLoginFormButton.TabIndex = 2;
            this.ToLoginFormButton.Text = "Logout";
            this.ToLoginFormButton.UseVisualStyleBackColor = true;
            this.ToLoginFormButton.Click += new System.EventHandler(this.ToLoginFormButton_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1245, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ToLoginFormButton);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ControlForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ControlForm_FormClosed);
            this.Load += new System.EventHandler(this.ControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.Button ToLoginFormButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox SearchBox;
        private System.Windows.Forms.Label label1;
    }
}