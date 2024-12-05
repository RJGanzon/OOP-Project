using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class AdminForm : Form
    {
        public AdminForm()
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
                List<Order> orders = ReadOrdersFromFile(userHistoryFile);
                DisplayOrders(orders);
            }
            else
            {
                MessageBox.Show("No order history found for this user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Order? currentOrder = null;

                    while ((line = reader.ReadLine()) != null)
                    {
                        // If the line is a timestamp (assuming it's a date-time format)
                        if (DateTime.TryParse(line.Trim(), out _))
                        {
                            if (currentOrder != null)
                            {
                                orders.Add(currentOrder);
                            }

                            currentOrder = new Order(new Dictionary<string, float>
                            {
                                { "Sprinkles", 0.50F },
                                { "Chocolate Syrup", 0.75F },
                                { "Mango", 1.00F },
                                { "Marshmallow", 0.40F },
                                { "Biscoff Syrup", 1.20F },
                                { "Crushed Cookies", 0.60F }
                            });

                            currentOrder.Timestamp = line.Trim();  // Set the timestamp of the current order
                        }
                        else if (line.StartsWith("Cup Size:"))
                        {
                            if (currentOrder != null)
                                currentOrder.CupSize = line.Substring(9).Trim();
                        }
                        else if (line.StartsWith("  -"))
                        {
                            if (currentOrder != null)
                            {
                                string[] parts = line.Substring(4).Split(':');
                                string toppingName = parts[0].Trim();
                                int grams = int.Parse(parts[1].Replace("g", "").Trim());
                                currentOrder.AddTopping(toppingName, grams);
                            }
                        }
                    }

                    // Add the last order after reading all lines
                    if (currentOrder != null)
                        orders.Add(currentOrder);
                }
            }

            return orders;
        }

        private void DisplayOrders(List<Order> orders)
        {
            listBox1.Items.Clear();

            foreach (var order in orders)
            {
                listBox1.Items.Add(order.Timestamp);
                listBox1.Items.Add($"  Cup Size: {order.CupSize}");
                listBox1.Items.Add("  Toppings:");

                foreach (var topping in order.Toppings)
                {
                    listBox1.Items.Add($"    - {topping.Key}: {topping.Value}g");
                }

                listBox1.Items.Add("");  // Empty line between orders
            }
        }
    }
}
