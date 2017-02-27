using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication1
{
    class Task1
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(1, "Ivan");
            List<Product> products = new List<Product>();
            products.Add(new Product("milk", 7));
            products.Add(new Product("meat", 9));
            products.Add(new Product("bread", 5));
            Order order = new Order(products, customer);
            Shop.serviceOrder(order);
            Console.ReadKey();
        }

    }

    class Shop
    {
        public static void serviceOrder(Order order)
        {
            Console.WriteLine("Servicing the client: " + order.getCustomer().getId());
            Console.WriteLine("writing the check...");
            Console.WriteLine(order.ToString());
        }
    }

    class Order
    {
        IList<Product> products;
        private Customer customer;
        private decimal cost;

        public Order(IList<Product> products, Customer customer)
        {
            this.customer = customer;
            this.products = new List<Product>();
            foreach (Product p in products)
            {
                this.products.Add(p);
            }
            calculateCost();
        }

        public IList<Product> getProductsList()
        {
            return this.products;
        }

        public Customer getCustomer()
        {
            return this.customer;
        }

        public decimal getCost()
        {
            return this.cost;
        }

        public void calculateCost()
        {
            decimal result = 0;
            foreach (Product p in products)
            {
                result += p.getPrice();
            }
            this.cost = result;
        }

        public String ToString()
        {
            StringBuilder stb = new StringBuilder();
            stb.Append("Customer:" + this.customer.getId() + ";" + this.customer.getName() + "\n");
            stb.Append("Products:\n");
            foreach (Product p in this.products)
            {
                stb.Append(p.getName() + ";" + p.getPrice() + ";\n");
            }
            stb.Append("Result cost:" + this.cost);
            return stb.ToString();
        }
    }

    class Customer
    {
        private int id;
        private String name;
        public Customer(int id, String name)
        {
            this.name = name;
            this.id = id;
        }
        public int getId()
        {
            return this.id;
        }
        public String getName()
        {
            return this.name;
        }
    }

    class Product
    {
        private String name;
        private decimal price;
        public Product(String name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
        public String getName()
        {
            return this.name;
        }
        public decimal getPrice()
        {
            return this.price;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public void setPrice(decimal price)
        {
            this.price = price;
        }
    }
}
