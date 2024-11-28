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
    public partial class OrderPage : Form
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void OrderPage_Load(object sender, EventArgs e)
        {

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

        }

        private void btnGoToHome_Click(object sender, EventArgs e)
        {
            HomePage goToHomePage = new HomePage();

            // Show AddToCart form
            goToHomePage.Show();

            this.Hide();
        }
    }
}
