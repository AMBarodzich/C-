using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list1 = new List<double>();
            List<double> list2 = new List<double>();

            IEnumerable<double> set;
            int choose = 0;

            while (choose != 7)
            {
                Console.WriteLine("Menu: \n1. Input sets. \n2. Show sets. \n3. Arithmetic mean. \n4. Covariance. \n5. Median. \n6. Quantile. \n7. Exit.");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException) {
                    Console.WriteLine("You have entered invalid character");
                    throw;
                }
                switch (choose)
                {
                    case 1:
                        list1.Clear();
                        list2.Clear();
                        try
                        {
                            Console.WriteLine("\nEnter the number of values in the set #1.");
                            int n1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\nEnter values:");
                            for (int i = 0; i < n1; i++)
                            {
                                double number = Convert.ToDouble(Console.ReadLine());
                                list1.Add(number);
                            }
                            Console.WriteLine("\nEnter the number of values in the set #2.");
                            int n2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\nEnter values:");
                            for (int i = 0; i < n2; i++)
                            {
                                double number = Convert.ToDouble(Console.ReadLine());
                                list2.Add(number);
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nIncorrect value.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nList of numbers #1:");
                        foreach (double n in list1)
                            Console.Write(n + " ");
                        Console.WriteLine("\nList of numbers #2:");
                        foreach (double n in list2)
                            Console.Write(n + " ");
                        Console.WriteLine("\n");
                        break;

                    case 3:
                        Console.WriteLine("\nAverage of the list #1:");
                        Console.WriteLine(Statistics.Mean(list1));
                        Console.WriteLine("\nAverage of the list #2:");
                        Console.WriteLine(Statistics.Mean(list2));
                        break;
          
                    case 4:
                        Console.WriteLine("\nMeasures with an N normalizer for lists of size N.");
                        Console.WriteLine("\nCovariance of the lists:");
                        Console.WriteLine(Statistics.PopulationCovariance(list1, list2));

                        Console.WriteLine("\nMeasures with an N-1 normalizer for lists of size N.");
                        Console.WriteLine("\nCovariance of the lists:");
                        Console.WriteLine(Statistics.Covariance(list1, list2));
                        break;
                    case 5:
                        Console.WriteLine("\nMedian of the list #1.");
                        Console.WriteLine(Statistics.Median(list1));
                        Console.WriteLine("\nMedian of the list #2.");
                        Console.WriteLine(Statistics.Median(list2));
                        break;
                    case 6:
                        Console.WriteLine("\nQuantile of the list #1:");
                        Console.WriteLine(Statistics.Quantile(list1, 0.6));
                        Console.WriteLine("\nQuantile of the list #2:");
                        Console.WriteLine(Statistics.Quantile(list1, 0.5));
                        break;

                    case 7:
                        break;
                    default:
                        Console.WriteLine("The menu doesn't have this item");
                        break;
                }
            }
        }
    }
}
