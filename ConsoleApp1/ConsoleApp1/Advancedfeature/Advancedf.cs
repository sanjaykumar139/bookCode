using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleApp1.Advancedfeature
{
    class Advancedf
    {
        static void MainQ1a(string[] args)
        {
            // Loop over incoming command-line arguments
            // using index operator.
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine("Args: {0}", args[i]);

            // Declare an array of local integers.
            int[] myInts = { 10, 9, 100, 432, 9874 };

            // Use the index operator to access each element.
            for (int j = 0; j < myInts.Length; j++)
                Console.WriteLine("Index {0} = {1} ", j, myInts[j]);
            Console.ReadLine();
        }
    }
}

namespace ConsoleApp1.Advancedfeature1
{
    // Indexers allow you to access items in an array-like fashion.
    class Program
    {
        static void UseGenericListOfPeople()
        {
            List<Person> myPeople = new List<Person>();
            myPeople.Add(new Person("Lisa", "Simpson", 9));
            myPeople.Add(new Person("Bart", "Simpson", 7));

            // Change first person with indexer.
            myPeople[0] = new Person("Maggie", "Simpson", 2);

            // Now obtain and display each item using indexer.
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person number: {0}", i);
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }
        }
        static void MainQawsx(string[] args)
        {
            Console.WriteLine("***** Fun with Indexers *****\n");
            UseGenericListOfPeople();
            Console.ReadLine();
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string FirstName, string LastName, int Age)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
        }
    }
}

namespace ConsoleApp1.MyExtensions
{
    static class MyExtensions
    {
        // This method allows any object to display the assembly
        // it is defined in.
        public static void DisplayDefiningAssembly(this object obj)
        {
            Console.WriteLine("{0} lives here: => {1}\n", obj.GetType().Name,
            Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }
        // This method allows any integer to reverse its digits.
        // For example, 56 would return 65.
        public static int ReverseDigits(this int i)
        {
            // Translate int into a string, and then
            // get all the characters.
            char[] digits = i.ToString().ToCharArray();
            // Now reverse items in the array.
            Array.Reverse(digits);
            // Put back into string.
            string newDigits = new string(digits);

            // Finally, return the modified string back as an int.
            return int.Parse(newDigits);
        }

        static void MainQwac(string[] args)
        {
            Console.WriteLine("***** Fun with Extension Methods *****\n");
            // The int has assumed a new identity!
           
            int myInt = 12345678;
            myInt.DisplayDefiningAssembly();

            // So has the DataSet!
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();

            // And the SoundPlayer!
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly();

            // Use new integer functionality.
            Console.WriteLine("Value of myInt: {0}", myInt);
            Console.WriteLine("Reversed digits of myInt: {0}", myInt.ReverseDigits());
            Console.ReadLine();
        }
    }
}

namespace ConsoleApp1.MyExtensions1
{
    static class AnnoyingExtensions
    {
        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
                Console.Beep();
            }
        }

        static void MainQaww(string[] args)
        {
            Console.WriteLine("***** Extending Interface Compatible Types *****\n");

            // System.Array implements IEnumerable!
            string[] data = { "Wow", "this", "is", "sort", "of", "annoying","but", "in", "a", "weird", "way", "fun!"};
            data.PrintDataAndBeep();
            Console.WriteLine();

            // List<T> implements IEnumerable!
            List<int> myInts = new List<int>() { 10, 15, 20 };
            myInts.PrintDataAndBeep();
            Console.ReadLine();
        }
    }
}
