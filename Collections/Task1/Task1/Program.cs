using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Crew : IList<Worker>
    {
        List<Worker> contents = new List<Worker>();

        public Worker this[int index]
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

        public void Add(Worker item)
        {
            contents.Add(item);
        }

        public void Clear()
        {
            contents.Clear();
        }

        public bool Contains(Worker item)
        {
            return contents.Contains(item);
        }

        public void CopyTo(Worker[] array, int arrayIndex)
        {
            contents.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Worker> GetEnumerator()
        {
            return contents.GetEnumerator();
        }

        public int IndexOf(Worker item)
        {
            return contents.IndexOf(item);
        }

        public void Insert(int index, Worker item)
        {
            contents.Insert(index, item);
        }

        public bool Remove(Worker item)
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

        public void Sort()
        {
            contents.Sort(new EqualityComparer());
        }
    }

    class Worker
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Position WorkPosition { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Name, Surname, WorkPosition);
        }
    }

    class EqualityComparer : IComparer<Worker>
    {
        public int Compare(Worker x, Worker y)
        {
            return x.WorkPosition.CompareTo(y.WorkPosition);
        }
    }

    enum Position
    {
        Director = 1,
        SubDirector = 2,
        HR = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            Crew crew = new Crew();
            crew.Add(new Worker { Name = "Petr", Surname = "Petrov", WorkPosition = Position.Director });
            crew.Add(new Worker { Name = "Valera", Surname = "Ivanov", WorkPosition = Position.HR });
            crew.Add(new Worker { Name = "Sasha", Surname = "Voron", WorkPosition = Position.SubDirector });

            //sort by IComparer
            crew.Sort();
            Console.WriteLine("IComparer:\n");
            foreach (var worker in crew)
                Console.WriteLine("{0} {1} {2}", worker.Name.PadRight(5), worker.Surname.PadRight(5), worker.WorkPosition);

            Console.ReadKey();
        }
    }
}