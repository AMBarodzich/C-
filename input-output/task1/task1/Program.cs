using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace task1
{
    class Program
    {
        static void GetFile(string _dirName)
        {
            Console.WriteLine("Files:");
            string[] files = Directory.GetFiles(_dirName);

            Console.WriteLine("Choose file:");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, files[i]);
            }
            Console.WriteLine("Enter number of file");
            int choose = 0;
            try
            {
                choose = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException) { }
            if (choose < files.Length + 1)
            {
                string file = files[choose - 1];
                ReadFile(file);
            }
            else Console.WriteLine("there isn't file.");
        }

        static void ReadFile(string _file)
        {
            using (FileStream fileStream = File.OpenRead(_file))
            {
                byte[] data = new byte[fileStream.Length];
                for (int index = 0; index < fileStream.Length; index++)
                {
                    data[index] = (byte)fileStream.ReadByte();
                }
                Console.WriteLine(Encoding.UTF8.GetString(data));
            }
        }

        static void Path()
        {
            Console.WriteLine("Enter file path: ");
            string filePath = Convert.ToString(Console.ReadLine());
            if (Regex.IsMatch(filePath, @"^(([a-zA-Z]\:)|\\)(\\|(\\[^/:*?<>""|]*)+)$", RegexOptions.IgnoreCase))
            {
                Console.WriteLine("correct directory path.");
                string dirName = filePath;
                GetFile(dirName);
            }
            else
            {
                Console.WriteLine("incorrect directory path.");
            }
        }

        static void Main(string[] args)
        {
            int choose = 0;
            while (choose != 2)
            {
                Console.WriteLine("Menu: \n1. Input directory path. \n2. Exit.");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException) { }
                switch (choose)
                {
                    case 1:
                        Path();
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("it's wrong, choose number again");
                        break;
                }
            }
        }
    }
}
