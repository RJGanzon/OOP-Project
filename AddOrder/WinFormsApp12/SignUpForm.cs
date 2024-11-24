using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class SignUpForm : Form
    {
        string accountsPath = "users.txt";

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void btnLogInPage_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (txtUsername.Text.Length < 8 && txtPassword.Text.Length < 8 ) {
                MessageBox.Show($"Error: User and Password length must be greater than 8 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (password == txtConfirmPassword.Text)
            {
                using (var fs = new FileStream(accountsPath, FileMode.Append))
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"{username},{password},User");
                }
                MessageBox.Show($"Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show($"Error: Password must be the same as Confirm Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
