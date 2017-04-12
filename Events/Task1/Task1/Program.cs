using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task1
{
    delegate void LastStepEventHandler();

    class Plant
    {
        public event LastStepEventHandler PlantGrew;

        public void PlantGrowing()
        {
            Console.WriteLine("Plant slowly grows ");
            Thread.Sleep(2300);

            FinishGrow();
        }

        protected virtual void FinishGrow()
        {
            Console.WriteLine("Plant grew");
            if (PlantGrew != null)
                PlantGrew();
        }
    }

    class Herbivore
    {
        public void PlantGrewReady()
        {
            Console.WriteLine("Herbivore is ready");
            Thread.Sleep(2300);

            HerbivoreEatPlant();
        }

        public event LastStepEventHandler HerbivoreAtePlant;

        public void HerbivoreEatPlant()
        {
            Console.WriteLine("Plant was eaten by Herbivore");
            if (HerbivoreAtePlant != null)
                HerbivoreAtePlant();
        }
    }

    class Carnivore
    {
        public void OnHerbivoreAtePlant()
        {
            Console.WriteLine("Carnivore is ready");
            Thread.Sleep(2300);

            OnCarnivoreAteHerbivore();
        }

        public void OnCarnivoreAteHerbivore()
        {
            Console.WriteLine("Herbivore is eaten by Carnivore");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Plant a = new Plant();
            Herbivore b = new Herbivore();
            Carnivore c = new Carnivore();

            a.PlantGrew += b.PlantGrewReady;
            b.HerbivoreAtePlant += c.OnHerbivoreAtePlant;

            a.PlantGrowing();

            Console.ReadKey();
        }
    }
}