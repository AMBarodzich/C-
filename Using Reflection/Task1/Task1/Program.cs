using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Task1
{
    class TypeInfo
    {
        public void AboutMethods()
        {
            IEnumerable<MethodInfo> methods = typeof(Input).GetTypeInfo().DeclaredMethods;
            foreach (MethodInfo method in methods)
                Console.WriteLine(method);
        }

        public void AboutConstructors()
        {
            List<ConstructorInfo> constructors = typeof(Input).GetConstructors().ToList();
            foreach (ConstructorInfo constructor in constructors)
                Console.WriteLine(constructor);
        }

        public void AboutMembers()
        {
            IEnumerable<MemberInfo> members = typeof(Input).GetTypeInfo().DeclaredMembers;
            foreach (MemberInfo member in members)
                Console.WriteLine(member);
        }

        public void AboutFields()
        {
            List<FieldInfo> fields = typeof(Input).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).ToList();
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field);
            }
        }

        public void DisplayValuesOfTheFields()
        {
            object instance = (Input)Activator.CreateInstance(typeof(Input));
            List<FieldInfo> fields = instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).ToList();
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.GetValue(instance));
            }
        }
    }

    class Input
    {
        private string @string;
        private int value;

        public Input()
        {
            @string = "something";
            value = 4;
        }

        public Input(string _str)
        {
            @string = _str;
        }

        public Input(int _val)
        {
            value = _val;
        }

        public string WriteString()
        {
            Console.WriteLine("About string.");
            return @string;
        }

        public void SomeMethod()
        {
            Console.WriteLine("Some methods.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TypeInfo a = new TypeInfo();
            Console.WriteLine("about Input");
            Console.WriteLine("\nMembers");
            a.AboutMembers();
            Console.WriteLine("\nMethods:");
            a.AboutMethods();
            Console.WriteLine("\nConstructors:");
            a.AboutConstructors();
            Console.WriteLine("\nFields:");
            a.AboutFields();
            Console.WriteLine("\nValues of the fields:");
            a.DisplayValuesOfTheFields();

            Console.ReadKey();
        }
    }
}
