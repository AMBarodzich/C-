using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Shop
    {
        interface ForOrder                
        {
            void Things();
            void Prices();
        }

        interface ForCustomer
        {
            void Color();
            void Size();
        }

        interface ForProduct
        {
            void Big();
            void Small();
        }

        class Order : ForOrder         
        {
            public void Things()
            {
                Console.WriteLine("Some things for shopes.");
            }
            public void Prices()
            {
                Console.WriteLine("Prices for shops");
            }
        }

        class Customer : ForCustomer
        {
            public void Color()
            {
                Console.WriteLine("Some colors for shopes.");
            }
            public void Size()
            {
                Console.WriteLine("Size for shops");
            }
        }

        class Product : ForProduct
        {
            public void Big()
            {
                Console.WriteLine("which product ?");
            }
            public void Small()
            {
                Console.WriteLine("or small product ?");
            }
        }

        static void Main()
        {
            ForOrder things = new Order();
            things.Things();                    
            ForOrder rep = new Order();
            rep.Prices();

            ForCustomer color = new Customer();
            color.Color();
            ForCustomer size = new Customer();
            size.Size();

            ForProduct big = new Product();
            big.Big();
            ForProduct small = new Product();
            small.Small();

            Console.WriteLine("\nClose?");
            string e = Console.ReadLine();
        }
    }
}
