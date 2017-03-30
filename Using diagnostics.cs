using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;
using System.Diagnostics;

namespace Task1
{
    class Program
    {
        delegate long GCDAlgorithm(long x, long y);

        private static long GCDLib(List<long> _numbers)
        {
            return Euclid.GreatestCommonDivisor(_numbers);
        }

        private static long GCD(long[] _numbers, GCDAlgorithm _alg)
        {
            int n = _numbers.Length;
            long gcd = _numbers[0];

            if (n == 0) return 0;
            for (int i = 0; i < n - 1; i++)
                gcd = _alg.Invoke(Math.Abs(gcd), Math.Abs(_numbers[i + 1]));
            return gcd;
        }

        private static long GCDDivision(long a, long b)
        {
            long t;
            while (b != 0)
            {
                t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        private static long GCDSubtracion(long a, long b)
        {
            while (a != b)
                if (a > b)
                    a -= b;
                else
                    b -= a;
            return a;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nEnter the number of values in the set.");
            int n = Convert.ToInt32(Console.ReadLine());
            long[] numbers = new long[n];

            Console.WriteLine("\nEnter values:");
            for (int i = 0; i < n; i++)
            {
                numbers[i] = Convert.ToInt64(Console.ReadLine());
            }

            Stopwatch sw = new Stopwatch();

            Console.WriteLine("\nGCD by MathNet.");
            sw.Start();
            GCDLib(numbers.ToList());
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw.Reset();

            Console.WriteLine("\nThe division-based version of the GCD.");
            sw.Start();
            GCD(numbers, GCDDivision);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw.Reset();

            Console.WriteLine("\nThe subtraction-based version of the GCD.");
            sw.Start();
            GCD(numbers, GCDSubtracion);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw.Reset();

            Console.ReadKey();
        }
    }
}