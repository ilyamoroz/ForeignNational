using System;
using System.Drawing;
using System.Windows.Forms;

namespace ForeignNational
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            
            InitializeComponent();
            Controls.Add(CreateImg1((PasswordInput.Left + PasswordInput.Width) + 5, PasswordInput.Top));
            Controls.Add(CreateImg2((PasswordInput.Left + PasswordInput.Width) + 5, PasswordInput.Top));
            

        }
        public PictureBox CreateImg1(int posX, int posY)
        {
            pb1.Left = posX;
            pb1.Top = posY;
            pb1.Width = 20;
            pb1.Height = 20;
            pb1.Image = Image.FromFile(@"..\..\img\icons8-показать-96.png");
            pb1.BringToFront();
            pb1.Visible = true;
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            return pb1;
        }
        public PictureBox CreateImg2(int posX, int posY)
        {
            pb2.Left = posX;
            pb2.Top = posY;
            pb2.Width = 20;
            pb2.Height = 20;
            pb2.Image = Image.FromFile(@"..\..\img\icons8-закрытый-глаз-96.png");
            pb2.BringToFront();
            pb2.Visible = false;
            pb2.SizeMode = PictureBoxSizeMode.StretchImage;
            return pb2;
        }

        private void CloseBTN_Click(object sender, EventArgs e) => Application.Exit();
        

        private void pb_Click(object sender, EventArgs e)
        {
            if (pb1.Visible)
            {
                pb1.Visible = false;
                pb2.Visible = true;
                PasswordInput.UseSystemPasswordChar = false;
            }    
        }

        private void pb2_Click(object sender, EventArgs e)
        {
            if (pb2.Visible)
            {
                pb1.Visible = true;
                pb2.Visible = false;
                PasswordInput.UseSystemPasswordChar = true;
            }
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            int checkPassAmount = 0;
            if (checkPassAmount <= 2)
            {
                if (LoginInput.Text == "admin" && PasswordInput.Text == "admin")
                {
                    AddForm BGF = new AddForm();
                    BGF.Show();
                    this.Hide();
                }
                else if (LoginInput.Text == "control" && PasswordInput.Text == "admin")
                {
                    ControlForm CF = new ControlForm();
                    CF.Show();
                    this.Hide();
                }
                else
                {
                    WrongLabel.Visible = true;
                }
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
