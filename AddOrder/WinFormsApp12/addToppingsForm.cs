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
    public partial class addToppingsForm : Form
    {
        public string EnteredGrams { get; private set; } = ""; // Stores the grams entered by the user

        public addToppingsForm()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // Placeholder for any click event on PictureBox
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Placeholder for any label click event
        }


        private void btnDone_Click_1(object sender, EventArgs e)
        {
            EnteredGrams = txtInputGrams.Text; // Get the grams from the textbox
            this.DialogResult = DialogResult.OK; // Set the result to OK
            this.Close(); // Close the form
        }
    }
}
