using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class Form1 : Form
    {
        private string selectedCupSize = ""; // Stores the selected cup size
        private Dictionary<string, int> toppings = new Dictionary<string, int>(); // Stores toppings and their grams
        private List<Order> orders = new List<Order>(); // Stores all orders

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

        // Add topping and its grams
        private void btnToppingsSprinkles_Click(object sender, EventArgs e)
        {
            AddTopping("Sprinkles");
        }

        private void btnToppingsMango_Click(object sender, EventArgs e)
        {
            AddTopping("Mango");
        }

        private void btnToppingsChocolateSyrup_Click(object sender, EventArgs e)
        {
            AddTopping("Chocolate Syrup");
        }

        private void btnToppingsCrushedCookies_Click(object sender, EventArgs e)
        {
            AddTopping("Crushed Cookies");
        }

        private void btnToppingsMarshmallow_Click(object sender, EventArgs e)
        {
            AddTopping("Marshmallow");
        }

        private void btnToppingsBiscoffSyrup_Click(object sender, EventArgs e)
        {
            AddTopping("Biscoff Syrup");
        }

        // Open `addToppingsForm` to add toppings
        private void AddTopping(string toppingName)
        {
            using (addToppingsForm toppingsForm = new addToppingsForm())
            {
                if (toppingsForm.ShowDialog() == DialogResult.OK)
                {
                    if (int.TryParse(toppingsForm.EnteredGrams, out int grams) && grams > 0)
                    {
                        if (toppings.ContainsKey(toppingName))
                            toppings[toppingName] += grams; // Add to existing grams
                        else
                            toppings[toppingName] = grams; // Add new topping
                    }
                }
            }
        }

        // Add the current order to the list and clear inputs for a new order
        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedCupSize))
            {
                MessageBox.Show("Please select a cup size before adding to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (toppings.Count == 0)
            {
                MessageBox.Show("Please add at least one topping before adding to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new order
            var newOrder = new Order
            {
                CupSize = selectedCupSize,
                Toppings = new Dictionary<string, int>(toppings) // Copy toppings
            };

            // Add the order to the list
            orders.Add(newOrder);

            // Display all orders
            string allOrders = "Current Orders:\n";
            for (int i = 0; i < orders.Count; i++)
            {
                allOrders += $"Order {i + 1}:\n";
                allOrders += $"- Cup Size: {orders[i].CupSize}\n";
                allOrders += "- Toppings:\n";
                foreach (var topping in orders[i].Toppings)
                {
                    allOrders += $"  * {topping.Key}: {topping.Value}g\n";
                }
                allOrders += "\n";
            }

            MessageBox.Show(allOrders, "All Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear inputs for a new order
            selectedCupSize = "";
            toppings.Clear();
        }

        private void btn8ozCup_Click_1(object sender, EventArgs e)
        {
            selectedCupSize = "8oz";
        }

        private void btn12ozCup_Click_1(object sender, EventArgs e)
        {
            selectedCupSize = "12oz";
        }

        private void btn16ozCup_Click_1(object sender, EventArgs e)
        {
            selectedCupSize = "16oz";
        }

        // Keep all existing method signatures intact
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // Placeholder for any click event on PictureBox
        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
            // Placeholder for any click event on PictureBox
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            // Placeholder for any click event on PictureBox
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Placeholder for any text change event in TextBox
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            // Placeholder for any click event on PictureBox
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {
            // Placeholder for any Paint event in Panel
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }
    }

    // Order class to store cup size and toppings
    public class Order
    {
        public string CupSize { get; set; }
        public Dictionary<string, int> Toppings { get; set; } = new Dictionary<string, int>();
    }
}
