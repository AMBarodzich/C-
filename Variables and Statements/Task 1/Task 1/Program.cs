using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Student
    {
        public string name;
        public string surname;
        public int age;
        public Mark[] marks;

        public void ResetAllMarks()
        {
            for (int i = 0; i < marks.Length; i++)
            {
                marks[i].subjectMark = 0;
            }
        }
        public double GetAvgMark()
        {
            int average = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                average = average + marks[i].subjectMark;
            }
            return average / (double)marks.Length;
        }

        public void MaxAndMin(out int max, out int min)
        {
            max = marks[0].subjectMark;
            min = marks[0].subjectMark;
            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i].subjectMark > max)
                    max = marks[i].subjectMark;
                if (marks[i].subjectMark < min)
                    min = marks[i].subjectMark;
            }
        }

    }

    public class Mark
    {
        public string subjectName;
        public int subjectMark;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Student firstStudent = new Student();

            //Enter info

            Console.WriteLine("Enter the name of the student: ");
            firstStudent.name = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter the surname of the student: ");
            firstStudent.surname = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter the age of the student: ");
            firstStudent.age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number of subjects: ");
            number = Convert.ToInt32(Console.ReadLine());

            firstStudent.marks = new Mark[number];
            for (int i = 0; i < number; i++)
            {
                if (number == 0)
                    Console.WriteLine("I can't believe ");
                else
                {
                    firstStudent.marks[i] = new Mark();

                    Console.WriteLine("Enter the name of the subject: ");
                    firstStudent.marks[i].subjectName = Convert.ToString(Console.ReadLine());

                    Console.WriteLine("Enter the mark of the subject: ");
                    firstStudent.marks[i].subjectMark = Convert.ToInt32(Console.ReadLine());

                }
            }

            //finish our programm
            Console.WriteLine("\nThe average of all marks:" + firstStudent.GetAvgMark());

            Console.WriteLine("Close?");
            string e = Console.ReadLine();
        }
    }
}
