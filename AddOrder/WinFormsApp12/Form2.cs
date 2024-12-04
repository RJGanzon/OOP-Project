using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinFormsApp12
{
    public partial class Form2 : Form
    {
        string accountsPath = "users.txt";

        public Form2()
        {
            InitializeComponent();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //tracks the username of the person logged in
        public static string LoggedInUser { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                using (StreamReader reader = File.OpenText("users.txt"))
                {
                    string lblDisplay = reader.ReadToEnd();
                    var lines = lblDisplay.Split('\n');

                    var user = lines
                        .Select(line => line.Split(','))
                        .FirstOrDefault(u => u[0].Trim() == username && u[1].Trim() == password);

                    if (user != null)
                    {
                        LoggedInUser = username; // Save the logged-in username
                        string role = user[2].Trim();

                        if (role == "Admin")
                        {
                            AdminForm adminForm = new AdminForm();
                            adminForm.Show();
                        }
                        else if (role == "User")
                        {
                            this.Hide();
                            HomePage homePage = new HomePage();
                            homePage.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid user or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            
            SignUpForm SignUpForm = new SignUpForm(this);
            SignUpForm.Show();
            this.Hide();

        }
    }
}

