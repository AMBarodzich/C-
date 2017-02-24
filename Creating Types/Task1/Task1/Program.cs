using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{

    public class Customer
    {
        public static void Main()
        {
            var customer1 = new Product() { Name = "Borodich" };
            customer1.Orders.Add(new Order("Book"));
            customer1.Orders.Add(new Order("Cat"));
            customer1.Orders.Add(new Order("Beer"));

            var customer2 = new Product() { Name = "Sashas" };
            customer2.Orders.Add(new Order("meat"));
            customer2.Orders.Add(new Order("cheese"));
            customer2.Orders.Add(new Order("oil"));

            var customers = new List<Product>() { customer1, customer2 };

            var orders = new List<Order>();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.Name,customer.Products);
                Console.WriteLine("Orders:");
                orders = customer.Orders;
                while (orders.Count > 0)
                {
                    Console.WriteLine(orders[0].OrderNumber);
                    orders.RemoveAt(0); 
                }
            }

            Console.WriteLine("\nClose?");
            string e = Console.ReadLine();
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Order> Products { get; set; } = new List<Order>();
    }

    public class Order
    {
        public Order(string orderNumber)
        {
            OrderNumber = orderNumber;
        }
        public string OrderNumber { get; set; }
    }
}