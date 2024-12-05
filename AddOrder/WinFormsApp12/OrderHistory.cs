using System;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class OrderHistory : Form
    {
        public OrderHistory()
        {
            InitializeComponent();
            this.Load += OrderHistory_Load;
        }

        private void OrderHistory_Load(object? sender, EventArgs? e)
        {
            if (string.IsNullOrEmpty(Form2.LoggedInUser))
            {
                MessageBox.Show("No user is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string userHistoryFile = $"{Form2.LoggedInUser}_OrderHistory.txt";

            if (File.Exists(userHistoryFile))
            {
                DisplayOrderHistory(userHistoryFile);
            }
            else
            {
                MessageBox.Show("No order history found for this user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayOrderHistory(string fileName)
        {
            listBox1.Items.Clear();

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line.Trim());  // Just add each line to the ListBox
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
