using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Linq
{
    class LinqClass
    {
        static void DeclareImplicitVars()
        {
            // Implicitly typed local variables.
            var myInt = 0;
            var myBool = true;
            var myString = "Time, marches on...";
            // Print out the underlying type.
            Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
            Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
            Console.WriteLine("myString is a: {0}", myString.GetType().Name);
        }
        static void MainQzzas(string[] args)
        {
            Console.WriteLine("***** Extending Interface Compatible Types *****\n");
            DeclareImplicitVars();
            Console.ReadLine();
        }

    }
}

namespace ConsoleApp1.Linq1
{
    class LinqClass
    {
        static void QueryOverStrings()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;
            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }
        static void MainQwsx(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");
            //QueryOverStrings();
            //QueryOverStringsWithExtensionMethods();

            //string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            //IEnumerable<string> subset = from g in currentVideoGames
            //                             where g.Contains(" ")
            //                             orderby g
            //                             select g;
            //ReflectOverQueryResults(subset);

            QueryOverInts();
            Console.ReadLine();
        }

        static void QueryOverStringsWithExtensionMethods()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            // Build a query expression to find the items in the array
            // that have an embedded space.

            IEnumerable<string> subset =
            currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);

            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);
        }

        static void ReflectOverQueryResults(object resultSet, string queryType = "QueryExpressions")
        {
            Console.WriteLine($"***** Info about your query using {queryType} *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }

        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Print only items less than 10.
            IEnumerable<int> subset = from i in numbers where i < 10 select i;
            foreach (int i in subset)
                Console.WriteLine("Item: {0}", i);
            ReflectOverQueryResults(subset);
        }
    }
    
}

namespace ConsoleApp1.Linq2
{
    class Car
    {
        public string PetName { get; set; } = "";
        public string Color { get; set; } = "";
        public int Speed { get; set; }
        public string Make { get; set; } = "";

        static void MainQffd(string[] args)
        {
            Console.WriteLine("***** LINQ over Generic Collections *****\n");
            // Make a List<> of Car objects.
            List<Car> myCars = new List<Car>() {
                                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
                                };

            GetFastCars(myCars);
            LINQOverArrayList();
            Console.ReadLine();
        }

        static void GetFastCars(List<Car> myCars)
        {
            // Find all Car objects in the List<>, where the Speed is
            // greater than 55.
            //var fastCars = from c in myCars where c.Speed > 55 select c;
            var fastCars = from c in myCars where c.Speed > 90 && c.Make == "BMW" select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }

        static void LINQOverArrayList()
        {
            Console.WriteLine("***** LINQ over ArrayList *****");
            // Here is a nongeneric collection of cars.
            ArrayList myCars = new ArrayList() {
                                new Car{ PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW"},
                                new Car{ PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW"},
                                new Car{ PetName = "Mary", Color = "Black", Speed = 55, Make = "VW"},
                                new Car{ PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo"},
                                new Car{ PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford"}
                                };
            // Transform ArrayList into an IEnumerable<T>-compatible type.
            var myCarsEnum = myCars.OfType<Car>();
            // Create a query expression targeting the compatible type.
            var fastCars = from c in myCarsEnum where c.Speed > 55 select c;
            foreach (var car in fastCars)
            {
                Console.WriteLine("{0} is going too fast!", car.PetName);
            }
        }
    }
}