using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{

    class Crew : IList<Customer>
    {
        List<Customer> contents = new List<Customer>();

        public Customer this[int index]
        {
            get
            {
                return contents[index];
            }

            set
            {
                contents[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return contents.Count();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(Customer item)
        {
            contents.Add(item);
        }

        public void Clear()
        {
            contents.Clear();
        }

        public bool Contains(Customer item)
        {
            return contents.Contains(item);
        }

        public void CopyTo(Customer[] array, int arrayIndex)
        {
            contents.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Customer> GetEnumerator()
        {
            return contents.GetEnumerator();
        }

        public int IndexOf(Customer item)
        {
            return contents.IndexOf(item);
        }

        public void Insert(int index, Customer item)
        {
            contents.Insert(index, item);
        }

        public bool Remove(Customer item)
        {
            return contents.Remove(item);
        }

        public void RemoveAt(int index)
        {
            contents.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Name, Surname, Order,Product);
        }
    }


    enum Order
    {
        Ordering_1 = 1,
        Ordering_2 = 2,
        Ordering_3 = 3
    }

    enum Product
    {
        Book = 1,
        Beer = 2,
        Cat = 3
    }

    class Shop
    {
        static void Main(string[] args)
        {
            Crew crew = new Crew();
            crew.Add(new Customer { Name = "Petr", Surname = "Ivanov", Order = Order.Ordering_1, Product = Product.Book });
            crew.Add(new Customer { Name = "Vika", Surname = "Klichko", Order = Order.Ordering_2, Product = Product.Beer });
            crew.Add(new Customer { Name = "Kolya", Surname = "Vikulov", Order = Order.Ordering_3, Product = Product.Cat });

            foreach (var worker in crew)
                Console.WriteLine("{0} {1} {2} {3}", worker.Name.PadRight(15), worker.Surname.PadRight(15), worker.Order, worker.Product);

            Console.WriteLine("\nClose?");
            string e = Console.ReadLine();
        }
    }

}
