using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp12
{
    public partial class AddToCart : Form
    {
        private string selectedCupSize = ""; // Stores the selected cup size
        private Dictionary<string, int> toppings = new Dictionary<string, int>(); // Stores toppings and their grams
        private List<BaseOrder> orders = new List<BaseOrder>(); // Stores all orders

        // Cup sizes Price
        private const float Price8oz = 50;
        private const float Price12oz = 100;
        private const float Price16oz = 150;

        private readonly Dictionary<string, float> ToppingPrices = new Dictionary<string, float>
        {
            { "Sprinkles", 0.50F },
            { "Chocolate Syrup", 0.75F },
            { "Mango", 1.00F },
            { "Marshmallow", 0.40F },
            { "Biscoff Syrup", 1.20F },
            { "Crushed Cookies", 0.60F }
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

        // Calculates the total cost
        private float CalculateOrderCost()
        {
            float cost = 0;

            // Add cup size cost
            switch (selectedCupSize)
            {
                case "8oz":
                    cost += Price8oz;
                    break;
                case "12oz":
                    cost += Price12oz;
                    break;
                case "16oz":
                    cost += Price16oz;
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

        // Updates txtOrderCost
        private void UpdateOrderCost()
        {
            float totalCost = CalculateOrderCost();
            txtOrderCost.Text = $"Cost: ₱{totalCost:0.00}"; // Format to PHP with .00
        }

        // Add the current order to the list and clear inputs for a new order
        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            if (selectedCupSize == "")
            {
                MessageBox.Show("Please select a cup size before adding to cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add toppings to the current order
            BaseOrder currentOrder = GetCurrentOrder();
            currentOrder.CupSize = selectedCupSize;

            // Add toppings from the toppings dictionary to the current order
            foreach (var topping in toppings)
            {
                currentOrder.AddTopping(topping.Key, topping.Value);
            }

            // Save the order to a file
            SaveOrderToFile(currentOrder);

            // Display all orders
            string allOrders = "Current Orders:\n";
            foreach (var order in orders)
            {
                allOrders += $"Order:\n";
                allOrders += $"- Cup Size: {order.CupSize}\n";
                allOrders += "- Toppings:\n";
                foreach (var topping in order.Toppings)
                {
                    allOrders += $"  * {topping.Key}: {topping.Value}g\n";
                }
                allOrders += $"- Total Cost: ₱{order.TotalCost:0.00}\n\n";
            }

            MessageBox.Show(allOrders, "All Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear inputs for a new order
            selectedCupSize = "";
            toppings.Clear();
            txtOrderCost.Text = "Cost: ";
        }

        // Saves the Order to a File
        private void SaveOrderToFile(BaseOrder order)
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
                writer.WriteLine($"Total Cost: ₱{order.TotalCost:0.00}");
                writer.WriteLine(); // Blank line for separation
            }
        }

        private void btn8ozCup_Click_1(object sender, EventArgs e)
        {
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

        // Helper method to get the current order
        private BaseOrder GetCurrentOrder()
        {
            if (orders.Count == 0)
            {
                orders.Add(new Order(ToppingPrices)); // Pass ToppingPrices when creating a new Order
            }
            return orders[orders.Count - 1];
        }
    }

    // Abstract base class for Order
    public abstract class BaseOrder
    {
        public string Timestamp { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        public string CupSize { get; set; }
        public Dictionary<string, int> Toppings { get; set; } = new Dictionary<string, int>();
        public float TotalCost { get; set; }

        public abstract void AddTopping(string toppingName, int grams);
        public abstract void UpdateTotalCost();
    }

    // Concrete Order class with specific behavior
    public class Order : BaseOrder
    {
        private readonly Dictionary<string, float> ToppingPrices; // Declare ToppingPrices

        public Order(Dictionary<string, float> toppingPrices)
        {
            ToppingPrices = toppingPrices; // Initialize ToppingPrices in the constructor
        }

        public override void AddTopping(string toppingName, int grams)
        {
            if (Toppings.ContainsKey(toppingName))
                Toppings[toppingName] += grams;
            else
                Toppings[toppingName] = grams;

            UpdateTotalCost();
        }

        public override void UpdateTotalCost()
        {
            TotalCost = 0;

            // Add cup size cost
            switch (CupSize)
            {
                case "8oz":
                    TotalCost += 50;
                    break;
                case "12oz":
                    TotalCost += 100;
                    break;
                case "16oz":
                    TotalCost += 150;
                    break;
            }

            // Add topping costs
            foreach (var topping in Toppings)
            {
                if (ToppingPrices.ContainsKey(topping.Key))
                {
                    TotalCost += ToppingPrices[topping.Key] * topping.Value;
                }
            }
        }
    }
}
