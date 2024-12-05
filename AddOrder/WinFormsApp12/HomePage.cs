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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }


        private void btnGoToAdd_Click(object sender, EventArgs e)
        {
            AddToCart goToAddPage = new AddToCart();

            // Show AddToCart form
            goToAddPage.Show();

            this.Hide();
        }

        private void btnGoToCart_Click(object sender, EventArgs e)
        {
            OrderPage goToCartPage = new OrderPage();

            // Show AddToCart form
            goToCartPage.Show();

            this.Hide();
        }

        private void guna2ImageButton11_Click(object sender, EventArgs e)
        {
            AdminForm OrderHistory = new AdminForm();
            OrderHistory.Show();
            this.Hide();
        }
    }
}
