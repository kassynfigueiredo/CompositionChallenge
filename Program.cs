using System;
using System.Globalization;
using CompositionChallenge.Entities;
using CompositionChallenge.Entities.Enums;

namespace CompositionChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client cli = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, OrderStatus.Processing, cli);

            Console.WriteLine("Enter order data:");
            Console.WriteLine($"Status: {OrderStatus.Processing}");
            Console.Write("How many items to order? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product p = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(quantity, productPrice, p);
                order.AddItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine("Order sumary: ");
            Console.WriteLine(order);
        }
    }
}
