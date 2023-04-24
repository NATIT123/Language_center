using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace English_center
{
    public partial class SignIn : Form
    {
        private UserController userController = new UserController();
        public SignIn()
        {
            InitializeComponent();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signup=new SignUp();
            this.Hide();
            signup.Show();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            txtName.Text = Properties.Settings.Default.username;
            txtPass.Text = Properties.Settings.Default.password;
            if (txtName.Text != "")
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
            if (txtPass.Text != "")
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnlogin.ForeColor = Color.Red;
        }


        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtName.Text.Trim();
            string pass = txtPass.Text.Trim();
            if(username=="admin123"&& pass=="123@Asd"){
                    MessageBox.Show("Successfully");
                    Main main = new Main();
                    this.Hide();
                    return;
                }
            if (username == "" || pass == "")
            {
                MessageBox.Show("Username or pass can not empty");
            }
            else
            {
                if (userController.check(username, pass))
                {
                    if (checkBox1.Checked == true)
                    {
                        Properties.Settings.Default.username = txtName.Text;
                        Properties.Settings.Default.password = txtPass.Text;
                        Properties.Settings.Default.Save();

                    }
                    else
                    {
                        Properties.Settings.Default.username = "";
                        Properties.Settings.Default.password = "";
                        Properties.Settings.Default.Save();
                    }
                    MessageBox.Show("Successfully");
                    Main main = new Main();
                    this.Hide();
                    main.Data= txtName.Text;
                    Forgetpass forgetpass=new Forgetpass();
                    forgetpass.Data1 = txtName.Text;
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Username or password are incorrect");
                }
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_MouseLeave(object sender, EventArgs e)
        {
        }

        private void txtPass_MouseEnter(object sender, EventArgs e)
        {
        }

        private void txtName_MouseLeave(object sender, EventArgs e)
        {
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtPass.PasswordChar = '\0';
            }
        }

        private void btnHide_Click_1(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtPass.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgetpass forget=new Forgetpass();
            this.Hide();
            forget.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SignIn_Resize(object sender, EventArgs e)
        {

        }

        private void SignIn_SizeChanged(object sender, EventArgs e)
        {

        }
        private void resizeControl(Rectangle r, Control c)
        {
        }

    }
}
