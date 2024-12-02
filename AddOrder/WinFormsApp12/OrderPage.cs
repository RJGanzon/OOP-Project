using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            // Read and display orders from temp file
            List<Order> orders = ReadOrdersFromFile("tempOrders.txt");
            if (orders.Count > 0)
            {
                DisplayOrders(orders);
                DisplayTotalCost(orders);
            }
            else
            {
                MessageBox.Show("No orders available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<Order> ReadOrdersFromFile(string fileName)
        {
            List<Order> orders = new List<Order>();

            if (File.Exists(fileName))
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    Order currentOrder = null;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Order Timestamp:"))
                        {
                            // Start of a new order block
                            if (currentOrder != null)
                            {
                                orders.Add(currentOrder); // Add the previous order
                            }
                            currentOrder = new Order
                            {
                                Timestamp = line
                            };
                        }
                        else if (line.StartsWith("Cup Size:"))
                        {
                            if (currentOrder != null)
                            {
                                currentOrder.CupSize = line.Split(':')[1].Trim();
                            }
                        }
                        else if (line.StartsWith("Toppings:"))
                        {
                            if (currentOrder != null)
                            {
                                currentOrder.Toppings = new Dictionary<string, int>();
                            }
                        }
                        else if (line.StartsWith("  -"))
                        {
                            // Parse topping line
                            if (currentOrder?.Toppings != null)
                            {
                                string toppingInfo = line.Substring(4).Trim();
                                string[] parts = toppingInfo.Split(':');
                                string toppingName = parts[0].Trim();
                                int grams = int.Parse(parts[1].Replace("g", "").Trim());
                                currentOrder.Toppings[toppingName] = grams;
                            }
                        }
                    }

                    if (currentOrder != null)
                    {
                        orders.Add(currentOrder); // Add the last order
                    }
                }
            }

            return orders;
        }

        private void DisplayOrders(List<Order> orders)
        {
            listBox1.Items.Clear(); // Clear any existing items.

            foreach (var order in orders)
            {
                // Add a line for the cup size
                listBox1.Items.Add($"  Cup Size: {order.CupSize}");

                // Add lines for each topping
                if (order.Toppings != null && order.Toppings.Count > 0)
                {
                    listBox1.Items.Add("  Toppings:");
                    foreach (var topping in order.Toppings)
                    {
                        listBox1.Items.Add($"    - {topping.Key}: {topping.Value}g");
                    }
                }

                // Add a blank line for separation between orders
                listBox1.Items.Add(string.Empty);
            }
        }

        private void DisplayTotalCost(List<Order> orders)
        {
            float totalCost = 0;

            foreach (var order in orders)
            {
                totalCost += CalculateOrderCost(order);
            }

            lblTotalCost.Text = $"Cost: ₱{totalCost:0.00}";
        }

        private float CalculateOrderCost(Order order)
        {
            float cost = 0;

            // Add cost based on cup size
            switch (order.CupSize)
            {
                case "8oz":
                    cost += 50;
                    break;
                case "12oz":
                    cost += 100;
                    break;
                case "16oz":
                    cost += 150;
                    break;
            }

            // Add topping costs
            var toppingPrices = new Dictionary<string, int>
            {
                { "Sprinkles", 10 },
                { "Chocolate Syrup", 20 },
                { "Mango", 15 },
                { "Marshmallow", 10 },
                { "Biscoff Syrup", 25 }
            };

            foreach (var topping in order.Toppings)
            {
                if (toppingPrices.ContainsKey(topping.Key))
                {
                    cost += toppingPrices[topping.Key] * topping.Value;
                }
            }

            return cost;
        }

        private void btnGoToAdd_Click(object sender, EventArgs e)
        {
            AddToCart goToAddPage = new AddToCart();

            // Show AddToCart form
            goToAddPage.Show();

            this.Hide();
        }

        private void btnGoToHome_Click(object sender, EventArgs e)
        {
            HomePage goToHomePage = new HomePage();

            // Show HomePage
            goToHomePage.Show();

            this.Hide();
        }

        private void btnGoToCart_Click(object sender, EventArgs e)
        {
            OrderPage goToCartPage = new OrderPage();

            // Show AddToCart form
            goToCartPage.Show();

            this.Hide();
        }

        private void SaveOrdersToPermanentFile(List<Order> orders, string permanentFileName)
        {
            using (StreamWriter writer = new StreamWriter(permanentFileName, append: true))
            {
                foreach (var order in orders)
                {
                    writer.WriteLine(order.Timestamp); // Write the timestamp
                    writer.WriteLine($"  Cup Size: {order.CupSize}");
                    writer.WriteLine("  Toppings:");
                    foreach (var topping in order.Toppings)
                    {
                        writer.WriteLine($"    - {topping.Key}: {topping.Value}g");
                    }
                    writer.WriteLine(); // Add a blank line for separation between orders
                }
            }
        }

        private void ClearTempFile()
        {
            // Clear the content of the temporary file
            File.WriteAllText("tempOrders.txt", string.Empty);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderNow_Click_1(object sender, EventArgs e)
        {
            // Move orders from tempOrders.txt to permanent file
            List<Order> orders = ReadOrdersFromFile("tempOrders.txt");

            if (orders.Count > 0)
            {
                string permanentFileName = $"OrderHistory.txt";
                SaveOrdersToPermanentFile(orders, permanentFileName);

                listBox1.Items.Clear();
                ClearTempFile();

                MessageBox.Show("Orders have been placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No orders to place.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelOrder_Click_1(object sender, EventArgs e)
        {
            // Clear the temporary file when cancelling
            listBox1.Items.Clear();
            ClearTempFile();
            MessageBox.Show("Order has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }


}
