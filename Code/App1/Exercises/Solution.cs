

namespace Solution
{
    class Product
    {
        // Fields
        public string productName;
        public double pricePerUnit;
        public int quantity;

        // Constructor
        public Product(string name, double price, int qty)
        {
            productName = name;
            pricePerUnit = price;
            quantity = qty;
        }

        // Instance Method: Calculate total cost
        public double CalculateTotal()
        {
            return pricePerUnit * quantity;
        }

        // Instance Method: Display purchase summary
        public void DisplayReceipt()
        {
            Console.WriteLine("\n--- PURCHASE RECEIPT ---");
            Console.WriteLine($"Product Name: {productName}");
            Console.WriteLine($"Price per Unit: {pricePerUnit}");
            Console.WriteLine($"Quantity: {quantity}");
            Console.WriteLine($"Total Cost: {CalculateTotal()}");
        }

        // Static Method: Get user input and create Product object
        public static Product? RequestProductData()
        {
            try
            {
                Console.Write("Enter Product Name: ");
                string nameInput = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter Price per Unit: ");
                double price = double.Parse(Console.ReadLine()?? string.Empty);

                Console.Write("Enter Quantity: ");
                int qty = int.Parse(Console.ReadLine() ?? string.Empty);

                return new Product(nameInput, price, qty);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Input Error: {ex.Message}");
                Console.WriteLine("Please restart the program and try again.");
                return null;
            }
        }

        // Static Run method
        public static void Run()
        {
            Product? p = RequestProductData();
            p?.DisplayReceipt();
        }
    }

    class Program
    {
        public static void Run()
        {
            Product.Run();
        }
    }
}
