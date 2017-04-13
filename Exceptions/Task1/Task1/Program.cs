using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

namespace Task1
{
    [Serializable]
    class PersonalInfoException : Exception, ISerializable
    {
        public PersonalInfoException()
        {

        }
        public PersonalInfoException(string message) : base(message)
        {

        }
        public PersonalInfoException(string message, Exception innerException) : base(message, innerException)
        {

        }
        protected PersonalInfoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }

    class Worker
    {
        private string surname;
        private string name;
        private string workPosition;

        public string Name
        {
            get { return name; }
            set
            {
                string pattern = @"^[А-яЁёA-z]*$";
                if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                    name = value;
                else
                    throw new PersonalInfoException("Incorrect name.");
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                string pattern = @"^[А-яЁёA-z]*$";
                if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                    surname = value;
                else
                    throw new PersonalInfoException("Incorrect surname.");
            }
        }

        public string WorkPosition
        {
            get { return workPosition; }
            set
            {
                string pattern = @"^[А-яЁёA-z]*$";
                if (Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase))
                    workPosition = value;
                else
                    throw new PersonalInfoException("Incorrect working position.");
            }
        }

        public Worker()
        {
            Console.WriteLine("Write a name:");
            Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Write a surname:");
            Surname = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Write a working position:");
            WorkPosition = Convert.ToString(Console.ReadLine());
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name.PadRight(10), Surname.PadRight(10), WorkPosition.PadRight(10));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Worker> workers = new List<Worker>();
            int choose = 0;

            while (choose != 3)
            {
                Console.WriteLine("Menu: \n1. Add info about worker. \n2. Show  info. \n3. Exit.");
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
                        try
                        {
                            workers.Add(new Worker());
                        }
                        catch (PersonalInfoException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Info added.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Name".PadRight(10) + "Surname".PadRight(10) + "Working position".PadRight(10));
                        foreach (Worker worker in workers)
                            Console.WriteLine(worker.ToString());
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("incorrect number");
                        break;
                }
            }
        }
    }
}