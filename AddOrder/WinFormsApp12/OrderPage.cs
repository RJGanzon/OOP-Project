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
                            currentOrder = new Order(new Dictionary<string, float>
                            {
                                { "Sprinkles", 0.50F },
                                { "Chocolate Syrup", 0.75F },
                                { "Mango", 1.00F },
                                { "Marshmallow", 0.40F },
                                { "Biscoff Syrup", 1.20F }
                            });
                            currentOrder.Timestamp = line;
                        }
                        else if (line.StartsWith("Cup Size:"))
                        {
                            if (currentOrder != null)
                            {
                                // Assign the correct cup size
                                string cupSize = line.Split(':')[1].Trim();
                                currentOrder.CupSize = cupSize;
                            }
                        }
                        else if (line.StartsWith("Toppings:"))
                        {
                            if (currentOrder != null)
                            {
                                currentOrder.Toppings.Clear(); // Clear previous toppings
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

                                currentOrder.AddTopping(toppingName, grams);
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

            string lastTimestamp = string.Empty; // Store the last timestamp to check for grouping

            foreach (var order in orders)
            {
                // Only display the timestamp if it's different from the last one
                if (order.Timestamp != lastTimestamp)
                {
                    listBox1.Items.Add(order.Timestamp);
                    lastTimestamp = order.Timestamp; // Update the last timestamp
                }

                // Display cup size and toppings for the order
                listBox1.Items.Add($"  Cup Size: {order.CupSize}");

                if (order.Toppings != null && order.Toppings.Count > 0)
                {
                    listBox1.Items.Add("  Toppings:");
                    foreach (var topping in order.Toppings)
                    {
                        listBox1.Items.Add($"    - {topping.Key}: {topping.Value}g");
                    }
                }

                listBox1.Items.Add(string.Empty); // Blank line for separation between orders
            }
        }

        private void DisplayTotalCost(List<Order> orders)
        {
            float totalCost = 0;

            foreach (var order in orders)
            {
                totalCost += order.TotalCost;
            }

            lblTotalCost.Text = $"Cost: ₱{totalCost:0.00}";
        }

        private void btnGoToAdd_Click(object sender, EventArgs e)
        {
            AddToCart goToAddPage = new AddToCart();
            goToAddPage.Show();
            this.Hide();
        }

        private void btnGoToHome_Click(object sender, EventArgs e)
        {
            HomePage goToHomePage = new HomePage();
            goToHomePage.Show();
            this.Hide();
        }

        private void btnGoToCart_Click(object sender, EventArgs e)
        {
            OrderPage goToCartPage = new OrderPage();
            goToCartPage.Show();
            this.Hide();
        }

        private void SaveOrdersToPermanentFile(List<Order> orders, string permanentFileName)
        {
            using (StreamWriter writer = new StreamWriter(permanentFileName, append: true))
            {
                string lastTimestamp = string.Empty; // Store the last timestamp to check for grouping

                foreach (var order in orders)
                {
                    // Only write the timestamp if it's different from the last one
                    if (order.Timestamp != lastTimestamp)
                    {
                        writer.WriteLine(order.Timestamp);
                        lastTimestamp = order.Timestamp; // Update the last timestamp
                    }

                    writer.WriteLine($"  Cup Size: {order.CupSize}");
                    writer.WriteLine("  Toppings:");
                    foreach (var topping in order.Toppings)
                    {
                        writer.WriteLine($"    - {topping.Key}: {topping.Value}g");
                    }
                    writer.WriteLine(); // Blank line for separation between orders
                }
            }
        }

        private void ClearTempFile()
        {
            File.WriteAllText("tempOrders.txt", string.Empty);
        }

<<<<<<< HEAD
        private void label2_Click(object sender, EventArgs e)
        {
            // Placeholder method for event
        }
=======
>>>>>>> 58ae4e8a3bbae7175908bb8b5587d5ce94e5758f

        private void btnOrderNow_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Form2.LoggedInUser))
            {
                MessageBox.Show("No user is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set a fixed timestamp for all orders
            string currentTimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Read orders from temp file
            List<Order> orders = ReadOrdersFromFile("tempOrders.txt");

            if (orders.Count > 0)
            {
                // Update all orders with the same timestamp
                foreach (var order in orders)
                {
                    order.Timestamp = currentTimestamp;  // Set the same timestamp for all orders
                }

                // Save the orders to the user's permanent file
                string userHistoryFile = $"{Form2.LoggedInUser}_OrderHistory.txt";
                SaveOrdersToPermanentFile(orders, userHistoryFile);

                listBox1.Items.Clear();
                ClearTempFile();

                MessageBox.Show("Orders have been placed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No orders to place.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblTotalCost.Text = "Cost: ";
        }


        private void btnCancelOrder_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ClearTempFile();
            MessageBox.Show("Order has been cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblTotalCost.Text = "Cost: ";
        }

        // Loads the current user's purchase history
        private void LoadOrderHistoryForUser(string username)
        {
            string userHistoryFile = $"{username}_OrderHistory.txt";

            if (File.Exists(userHistoryFile))
            {
                List<Order> orders = ReadOrdersFromFile(userHistoryFile);
                DisplayOrders(orders);
            }
            else
            {
                MessageBox.Show("No order history found for this user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
