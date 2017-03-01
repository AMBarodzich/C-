using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    abstract class Human
    {
        private string name;
        private int age;
        private string surname;       

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public virtual double Behavior
        {
            get
            {
                return 0;
            }
        }

        public virtual void Print()
        {
            Console.WriteLine("Personal information:");
        }
    }

    class Boy : Human
    {
        private int health;
        private bool gay = false;

        public int Health
        {
            get
            {
                return health;
            }

            set
            {
                if (value < 29)
                    health = 29;
                else if (value > 320)
                    health = 320;
                else
                    health = value;
            }
        }

        public void Disco()
        {
            Random rand = new Random();
            Health += rand.Next(1, 132);
        }

        public override double Behavior
        {
            get
            {
                if (gay == false)
                    return (double)health / 40;
                else
                    return (double)health * 2 / 40;
            }
        }

        public void Icecream(bool cream)
        {
            gay = cream;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Name: " + Name + "  Surname: " + Surname + "  Age: " + Age + " Health: " + Health + "  Behavior: " + Behavior + "\n");
        }
    }

    class Girl : Human
    {
        private int bigBody;
        private bool bigFace = false;

        public int Bigbody
        {
            get
            {
                return bigBody;
            }

            set
            {
                if (value < 80)
                    bigBody = 80;
                else if (value > 1000)
                    bigBody = 100;
                else
                    bigBody = value;
            }
        }

        public void Loseweigth()
        {
            Random rand = new Random();
            Bigbody -= rand.Next(1, 131);
        }

        public override double Behavior
        {
            get
            {
                if (bigFace == false)
                    return 139 / (double)bigBody;
                else
                    return 139 / ((double)bigBody / 2);
            }
        }

        public void BigFace(bool face)
        {
            bigFace = face;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Name: " + Name + "  Surname: " + Surname + "  Age: " + Age + "  Bigbody: " + Bigbody + "  Behavior: " + Behavior + "\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Boy boy = new Boy { Name = "Kostya", Surname = "Ivanov", Age = 17, Health = 29 };

            Girl girl = new Girl { Name = "Masha", Surname = "Ivanova", Age = 18, Bigbody = 80 };

            boy.Icecream(true);
            boy.Disco();

            girl.BigFace(true);
            girl.Loseweigth();

            boy.Print();
            girl.Print();

            Console.ReadKey();
        }
    }
}
