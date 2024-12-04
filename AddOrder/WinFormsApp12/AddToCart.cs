using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class AddToCart : Form
    {
        private string selectedCupSize = ""; // Stores the selected cup size
        private Dictionary<string, int> toppings = new Dictionary<string, int>(); // Stores toppings and their grams
        private List<Order> orders = new List<Order>(); // Stores all orders

        //Cup sizes Price
        private const int Price8oz = 50;
        private const int Price12oz = 100;
        private const int Price16oz = 150;

        private readonly Dictionary<string, int> ToppingPrices = new Dictionary<string, int>
        {
            { "Sprinkles", 10 },
            { "Chocolate Syrup", 20 },
            { "Mango", 15 },
            { "Marshmallow", 10 },
            { "Biscoff Syrup", 25 }
        };
        public AddToCart()
        {
            InitializeComponent();
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
            UpdateOrderCost();
        }

        private void btnToppingsMango_Click(object sender, EventArgs e)
        {
            AddTopping("Mango");
            UpdateOrderCost();
        }

        private void btnToppingsChocolateSyrup_Click(object sender, EventArgs e)
        {
            AddTopping("Chocolate Syrup");
            UpdateOrderCost();
        }

        private void btnToppingsCrushedCookies_Click(object sender, EventArgs e)
        {
            AddTopping("Crushed Cookies");
            UpdateOrderCost();
        }

        private void btnToppingsMarshmallow_Click(object sender, EventArgs e)
        {
            AddTopping("Marshmallow");
            UpdateOrderCost();
        }

        private void btnToppingsBiscoffSyrup_Click(object sender, EventArgs e)
        {
            AddTopping("Biscoff Syrup");
            UpdateOrderCost();
        }

        // Open addToppingsForm to add toppings
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

        //Calculates the total cost
        private float CalculateOrderCost()
        {
            float cost = 0;

            // Add cup size cost
            switch (selectedCupSize)
            {
                case "8oz":
                    cost += 50.00f;
                    break;
                case "12oz":
                    cost += 100.00f;
                    break;
                case "16oz":
                    cost += 150.00f;
                    break;
            }

            // Add topping costs
            foreach (var topping in toppings)
            {
                if (ToppingPrices.ContainsKey(topping.Key))
                {
                    cost += ToppingPrices[topping.Key] * topping.Value;
                }
            }

            return cost;
        }

        //Updates txtOrderCost
        private void UpdateOrderCost()
        {
            float totalCost = CalculateOrderCost();
            txtOrderCost.Text = $"Cost: ₱{totalCost:0.00}"; // Format to PHP with .00
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
                Toppings = new Dictionary<string, int>(toppings), // Copy toppings
                TotalCost = CalculateOrderCost()
            };

            // Add the order to the list
            orders.Add(newOrder);

            // Save the order to a file
            SaveOrderToFile(newOrder);


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

        //Saves the Order to a File
        private void SaveOrderToFile(Order order)
        {
            string fileName = "tempOrders.txt";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (var fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine($"Order Timestamp: {timestamp}");
                writer.WriteLine($"Cup Size: {order.CupSize}");
                writer.WriteLine("Toppings:");
                foreach (var topping in order.Toppings)
                {
                    writer.WriteLine($"  - {topping.Key}: {topping.Value}g");
                }
                writer.WriteLine(); // Blank line for separation
            }
        }

        private void btn8ozCup_Click_1(object sender, EventArgs e)
        {
            UpdateOrderCost();
            selectedCupSize = "8oz";
            UpdateOrderCost();
        }

        private void btn12ozCup_Click_1(object sender, EventArgs e)
        {
            selectedCupSize = "12oz";
            UpdateOrderCost();
        }

        private void btn16ozCup_Click_1(object sender, EventArgs e)
        {
            selectedCupSize = "16oz";
            UpdateOrderCost();
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

        private void guna2ImageButton1_Click(object sender, EventArgs e)  //btn go to home to
        {
            HomePage goToHomePage = new HomePage();

            // Show AddToCart form
            goToHomePage.Show();

            this.Hide();
        }

        private void btnGoToCart_Click(object sender, EventArgs e)
        {
            OrderPage goToOrderPage = new OrderPage();

            // Show AddToCart form
            goToOrderPage.Show();

            this.Hide();
        }

        private void btnGoToAdd_Click(object sender, EventArgs e)
        {

        }

        private void txtOrderCost_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }

    // Order class to store cup size and toppings
    public class Order
    {
        public string Timestamp { get; set; }
        public string CupSize { get; set; }
        public Dictionary<string, int> Toppings { get; set; } = new Dictionary<string, int>();
        public float TotalCost { get; set; }
    }
}