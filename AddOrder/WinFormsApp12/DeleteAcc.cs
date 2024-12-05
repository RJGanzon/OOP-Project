using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class DeleteAcc : Form
    {
        private string userFilePath = "users.txt"; // Adjust path if needed

        public DeleteAcc()
        {
            InitializeComponent();
            LoadUsernames(); // Load user data into the ListBox
        }

        // Load non-admin usernames into the ListBox
        private void LoadUsernames()
        {
            listBox1.Items.Clear();

            // Check if the user file exists
            if (File.Exists(userFilePath))
            {
                // Open the file using StreamReader for better control over file reading
                using (StreamReader reader = new StreamReader(userFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line by comma and check if it's not an admin account
                        string[] parts = line.Split(',');

                        if (parts.Length >= 3 && parts[2] != "Admin")
                        {
                            listBox1.Items.Add(parts[0]); // Add username (first part) to the ListBox
                        }
                    }
                }
            }
        }

        // Event handler for the Delete Account button click
        private void btnDeleteAcc_Click_1(object sender, EventArgs e)
        {
            // Get the selected username from the ListBox
            string selectedUsername = listBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedUsername))
            {
                MessageBox.Show("Please select a user to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a list to store remaining lines
            List<string> remainingLines = new List<string>();

            // Open the file using StreamReader to read lines
            using (StreamReader reader = new StreamReader(userFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // If the line doesn't start with the selected username, add it to the list
                    if (!line.StartsWith(selectedUsername + ","))
                    {
                        remainingLines.Add(line);
                    }
                }
            }

            try
            {
                // Write the remaining lines back to the file using StreamWriter
                using (StreamWriter writer = new StreamWriter(userFilePath))
                {
                    foreach (string line in remainingLines)
                    {
                        writer.WriteLine(line); // Write each line back to the file
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Reload the ListBox to reflect the changes
            LoadUsernames();

            MessageBox.Show($"User '{selectedUsername}' has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
