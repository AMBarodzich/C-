using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    interface ground {
        void FoodSearch(bool _search);
    }

    interface sky
    {
        void FoodSearch(bool _search);
    }

    interface water
    {
        void FoodSearch(bool _search);
    }

    class Animal
    {
        private string species;
        private int energy;

        public string Species
        {
            get
            {
                return species;
            }

            set
            {
                species = value;
            }
        }

        public int Energy
        {
            get
            {
                return energy;
            }

            set
            {
                energy = value;
            }
        }

        public void Eat()
        {
            Random rand = new Random();
            int upEnergy = rand.Next(1, 51);
            Energy += upEnergy;
            Console.WriteLine("Received energy: " + upEnergy);
        }

        public void FoundFood()
        {
            bool[] findFood = new bool[2];
            findFood[0] = true;
            findFood[1] = false;
            Random rand = new Random();
            bool foodFounded = findFood[rand.Next(0, 2)];
            if (foodFounded)
            {
                Eat();
                Console.WriteLine("Current energy: " + Energy);
            }
            else
                Console.WriteLine("Food not found.");
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Species, Energy);
        }
    }

    class Cat : Animal, ground
    {
        public void FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the land.");
                FoundFood();
            }
        }
    }

    class Mongoose : Animal, ground, water
    {
        public void FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the land.");
                FoundFood();
            }
        }

        void water.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search in the water.");
                FoundFood();
            }
        }
    }

    class Elephant : Animal, ground, sky
    {
        void ground.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the land.");
                FoundFood();
            }
        }

        void sky.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the air.");
                FoundFood();
            }
        }
    }

    class Snack : Animal, water
    {
        public void FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search in the water.");
                FoundFood();
            }
        }
    }

    class Goose : Animal, ground, water, sky
    {
        void ground.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the land.");
                FoundFood();
            }
        }

        void sky.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search on the air.");
                FoundFood();
            }
        }

        void water.FoodSearch(bool _search)
        {
            if (_search)
            {
                Console.WriteLine("Search in the water.");
                FoundFood();
            }
        }
    }

    class Group<TValue>
    {
        int position;
        TValue[] data = new TValue[10];

        public void Push(TValue obj)
        {
            data[position++] = obj;
        }

        public void Print()
        {
            Console.WriteLine("\nThe animal data:\n");
            foreach (TValue value in data)
            {
                if (value != null)
                    Console.WriteLine(value.ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cat d1 = new Cat { Species = "Ordinary cat" };
            d1.FoodSearch(true);

            Mongoose c1 = new Mongoose { Species = "Africanian mongoose" };
            c1.FoodSearch(true);
            ((water)c1).FoodSearch(true);

            Elephant b1 = new Elephant { Species = "Desert Elephant" };
            ((ground)b1).FoodSearch(true);
            ((sky)b1).FoodSearch(true);

            Snack k1 = new Snack { Species = "Belarusian snack" };
            k1.FoodSearch(true);

            Goose g1 = new Goose { Species = "Grey goose" };
            ((water)g1).FoodSearch(true);
            ((sky)g1).FoodSearch(true);
            ((ground)g1).FoodSearch(true);

            Group<Animal> group = new Group<Animal>();

            group.Push(d1);
            group.Push(c1);
            group.Push(b1);
            group.Push(k1);
            group.Push(g1);
            group.Print();

            Console.ReadKey();
        }
    }
}