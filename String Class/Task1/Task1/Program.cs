using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task1
{
    class TextTransformer
    {
        public string OurString { get; set; }

        public void Transform()
        {
            foreach (string word in StringMas())
            {
                Console.WriteLine(word);
            }
        }

        public IEnumerable<string> StringMas()
        {
            if (!string.IsNullOrEmpty(OurString) && OurString.Trim().Length > 0)
            {
                string[] words = OurString.Split(new char[] { ' ', ',', '.', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    yield return words[i].ToUpper();
                }
            }
            else
                yield return "OurString without any.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TextTransformer str = new TextTransformer();

            int ChoseNumber = 0;
            while (ChoseNumber != 4)
            {
                Console.WriteLine("Menu: \n1.string input. \n2.string transform. \n3.Show string. \n4.Exit.");
                Console.Write("Menu item: ");
                ChoseNumber = Convert.ToInt32(Console.ReadLine());
                switch (ChoseNumber)
                {
                    case 1:
                        str.OurString = Convert.ToString(Console.ReadLine());
                        break;
                    case 2:
                        str.Transform();
                        break;
                    case 3:
                        Console.WriteLine("\nEntered text: " + str.OurString + "\n");
                        break;
                    default:
                        Console.WriteLine("Choose number again, sometring was wrong");
                        break;
                }
            }
        }
    }
}