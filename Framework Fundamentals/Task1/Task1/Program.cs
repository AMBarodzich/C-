using System;
using System.Collections.Generic;

namespace Task1
{
    class Employee : IComparable<Employee>
    {
        public string Surname { get; set; }
        public int Salary { get; set; }

        public int CompareTo(Employee other)
        {
            return other.Salary.CompareTo(this.Salary);
        }

        public override string ToString()
        {
            return this.Salary.ToString() + "," + this.Surname;
        }
    }

    class Program
    {
        static void Main()
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee() { Surname = "Borodich", Salary = 10000 });
            list.Add(new Employee() { Surname = "Sashas", Salary = 8500 });
            list.Add(new Employee() { Surname = "IBA", Salary = 9000 });
            list.Add(new Employee() { Surname = "student", Salary = 4000 });
            list.Add(new Employee() { Surname = "PM", Salary = 1320 });

            list.Sort();

            foreach (var everything in list)
            {
                Console.WriteLine(everything);
            }
            Console.ReadKey();
        }
    }
}