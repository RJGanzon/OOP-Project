using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class Form1 : Form
    {
        private Panel amountAdjustmentPanel;
        private Button btnAddAmount;
        private Button btnLessenAmount;
        private TextBox txtAmount;
        private Button btnDone;

        public Form1()
        {
            InitializeComponent();
            Form2 Form2 = new Form2();
            Form2.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2Panel1.BackColor = ColorTranslator.FromHtml("#CDE8E5");
            guna2Panel4.BackColor = ColorTranslator.FromHtml("#EEF7FF");
            btnAddToCart.BackColor = ColorTranslator.FromHtml("#7AB2B2");
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnToppingsSprinkles_Click(object sender, EventArgs e)
        {
            addToppingsForm toppingsForm = new addToppingsForm();
            toppingsForm.ShowDialog(); 
        }

        private void btnToppingsMango_Click(object sender, EventArgs e)
        {
            addToppingsForm toppingsForm = new addToppingsForm();
            toppingsForm.ShowDialog(); 
        }

        private void btnToppingsChocolateSyrup_Click(object sender, EventArgs e)
        {
            addToppingsForm toppingsForm = new addToppingsForm();
            toppingsForm.ShowDialog(); 
        }

        private void btnToppingsCrushedCookies_Click(object sender, EventArgs e)
        {
            addToppingsForm toppingsForm = new addToppingsForm();
            toppingsForm.ShowDialog();  
        }

        private void btnToppingsMarshmallow_Click(object sender, EventArgs e)
        {
            addToppingsForm toppingsForm = new addToppingsForm();
            toppingsForm.ShowDialog();  
        }

        private void btnToppingsBiscoffSyrup_Click(object sender, EventArgs e)
        {
            addToppingsForm toppingsForm = new addToppingsForm();
            toppingsForm.ShowDialog();  
        }
    }
}
