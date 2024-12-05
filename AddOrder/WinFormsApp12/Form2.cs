using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class Form2 : Form
    {
        string accountsPath = "users.txt";

        public Form2()
        {
            InitializeComponent();
        }

        public static string LoggedInUser { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                // Open the file for reading using StreamReader
                bool userFound = false;
                string role = "";

                // Open the file using a StreamReader in a using block to ensure proper closing
                using (StreamReader reader = new StreamReader(accountsPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var user = line.Split(',');
                        if (user.Length >= 3 && user[0].Trim() == username && user[1].Trim() == password)
                        {
                            LoggedInUser = username;
                            role = user[2].Trim();
                            userFound = true;
                            break;
                        }
                    }
                }

                if (userFound)
                {
                    if (role == "Admin")
                    {
                        this.Hide();
                        DeleteAcc deleteAcc = new DeleteAcc();
                        deleteAcc.ShowDialog();
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm(this);
            signUpForm.Show();
            this.Hide();
        }
    }
}
