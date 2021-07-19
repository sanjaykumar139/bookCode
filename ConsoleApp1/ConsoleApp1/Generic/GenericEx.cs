using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Generic
{
    class GenericEx
    {
        static void Main7(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Make an array of string data.
            string[] strArray =   { "First", "Second", "Third" };
            // Show number of items in array using Length property.
            Console.WriteLine("This array has {0} items.", strArray.Length);
            Console.WriteLine();

            // Display contents using enumerator.
            foreach (string s in strArray)
            {
                Console.WriteLine("Array Entry: {0}", s);
            }
            Console.WriteLine();
            // Reverse the array and print again.
            Array.Reverse(strArray);
            foreach (string s in strArray)
            {
                Console.WriteLine("Array Entry: {0}", s);
            }
            Console.ReadLine();

        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Age: {Age}";
        }


    }

    public class PersonCollection : IEnumerable
    {
        private ArrayList arPeople = new ArrayList();
        // Cast for caller.
        public Person GetPerson(int pos) => (Person)arPeople[pos];
        // Insert only Person objects.
        public void AddPerson(Person p)
        { arPeople.Add(p); }
        public void ClearPeople()
        { arPeople.Clear(); }
        public int Count => arPeople.Count;
        // Foreach enumeration support.
        IEnumerator IEnumerable.GetEnumerator() => arPeople.GetEnumerator();
    }
}

namespace StaticNonStaticDemo
{
    class Example
    {
        static Example()
        {
            Console.WriteLine("static constructor is called");
        }
        public Example()
        {
            Console.WriteLine("non-static constructor is called");
        }
        static void Main8(string[] args)
        {
            Console.WriteLine("Main method is executed");
            Example obj1 = new Example();
            Example obj2 = new Example();
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}

namespace ReadOnlyConstDemo
{
    class Example
    {
        int x; //Non-static variable
        static int y = 200; //Static Variable
        const float PI = 3.14f; //Const Variable
        readonly bool flag; //Readonly Variable
        public Example(int x, bool flag)
        {
            this.x = x;
            this.flag = flag;
        }
        static void Main9(string[] args)
        {
            Console.WriteLine(Example.y);
            Console.WriteLine(Example.PI);
            Example obj1 = new Example(50, true);
            Example obj2 = new Example(100, false);
            Console.WriteLine(obj1.x + " " + obj1.x);
            Console.WriteLine(obj2.flag + " " + obj2.flag);
            Console.WriteLine("Press any key to exist.");
            Console.ReadLine();
        }
    }
}

namespace UnderstandingObjectClassMethods
{
    public class Program
    {
        public static void Main9()
        {
            //Customer C1 = new Customer();
            //C1.FirstName = "Pranaya";
            //C1.LastName = "Rout";

            //Customer C2 = C1;

            //Console.WriteLine(C1 == C2);
            //Console.WriteLine(C1.Equals(C2));


            Customer C1 = new Customer();
            C1.FirstName = "Pranaya";
            C1.LastName = "Rout";
            Customer C2 = new Customer();
            C2.FirstName = "Pranaya";
            C2.LastName = "Rout";
            Console.WriteLine(C1 == C2);
            Console.WriteLine(C1.Equals(C2));
        }
    }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}