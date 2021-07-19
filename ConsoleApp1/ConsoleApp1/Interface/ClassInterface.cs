
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Interface
{
    class ClassInterface
    {
    }
    class Program
    {
        static void MainQss(string[] args)
        {
            Console.WriteLine("***** A First Look at Interfaces *****\n");
            // All of these classes support the ICloneable interface.
            string myStr = "Hello";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            System.Data.SqlClient.SqlConnection sqlCnn = new System.Data.SqlClient.SqlConnection();

            // Therefore, they can all be passed into a method taking ICloneable.
            CloneMe(myStr);
            CloneMe(unixOS);
            CloneMe(sqlCnn);
            Console.ReadLine();
        }
        private static void CloneMe(ICloneable c)
        {
            // Clone whatever we get and print out the name.
            object theClone = c.Clone();
            Console.WriteLine("Your clone is a: {0}",  theClone.GetType().Name);
        }
    }
}

namespace CustomEnumerator
{
    // Garage contains a set of Car objects.
    public class Garage
    {
        private Car[] carArray = new Car[4];
        // Fill with some Car objects upon startup.
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        // Return the array object's IEnumerator.
        public IEnumerator GetEnumerator() => carArray.GetEnumerator();



        public static void MainQssan(string[] arg)
        {
            // This seems reasonable ...
            Console.WriteLine("***** Fun with IEnumerable / IEnumerator *****\n");
            Garage carLot = new Garage();
            // Hand over each car in the collection?
            foreach (Car c in carLot)
            {
                Console.WriteLine("{0} is going {1} MPH",
                c.PetName, c.Speed);
            }
            Console.ReadLine();
        }
    }

    class Car
    {
        public string PetName { get; set; } = "";
        public string Color { get; set; } = "";
        public int Speed { get; set; }
        public string Make { get; set; } = "";
        public Car(string PetName, int Speed)
        {
            this.PetName = PetName;
            this.Speed = Speed;
        }
    }
}

namespace CloneablePoint
{
    public interface ICloneable
    {
        object Clone();
    }

    // A class named Point.
    public class Point1
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point1(int xPos, int yPos) { X = xPos; Y = yPos; }
        public Point1() { }
        // Override Object.ToString().
        public override string ToString() => $"X = {X}; Y = {Y}";
    }

    // The Point now supports "clone-ability."
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int xPos, int yPos) { X = xPos; Y = yPos; }
        public Point() { }
        // Override Object.ToString().
        public override string ToString() => $"X = {X}; Y = {Y}";
        // Return a copy of the current object.
        public object Clone() => new Point(this.X, this.Y);


        public static void MainQas(string[] arg)
        {
            Console.WriteLine("***** Fun with Object Cloning *****\n");

            // Notice Clone() returns a plain object type.
            // You must perform an explicit cast to obtain the derived type.
            Point p3 = new Point(100, 100);
            Point p4 = (Point)p3.Clone();
            // Change p4.X (which will not change p3.X).
            p4.X = 0;
            // Print each object.
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.ReadLine();
        }
    }
}

namespace CloneablePoint1
{
    // This class describes a point.
    public class PointDescription
    {
        public string PetName { get; set; }
        public Guid PointID { get; set; }
        public PointDescription()
        {
            PetName = "No-name";
            PointID = Guid.NewGuid();
        }
    }

    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointDescription desc = new PointDescription();
        public Point(int xPos, int yPos, string petName)
        {
            X = xPos; Y = yPos;
            desc.PetName = petName;
        }
        public Point(int xPos, int yPos)
        {
            X = xPos; Y = yPos;
        }
        public Point() { }
        // Override Object.ToString().
        public override string ToString()
        => $"X = {X}; Y = {Y}; Name = {desc.PetName};\nID = {desc.PointID}\n";
        // Return a copy of the current object.
        public object Clone() => this.MemberwiseClone();


        public static void MainQw(string[] arg)
        {
            Console.WriteLine("***** Fun with Object Cloning *****\n");

            Console.WriteLine("Cloned p3 and stored new Point in p4");
            Point p3 = new Point(100, 100, "Jane");
            Point p4 = (Point)p3.Clone();
            Console.WriteLine("Before modification:");
            Console.WriteLine("p3: {0}", p3);
            Console.WriteLine("p4: {0}", p4);
            p4.desc.PetName = "My new Point";
            p4.X = 9;
            Console.WriteLine("\nChanged p4.desc.petName and p4.X");
            Console.WriteLine("After modification:");
            Console.WriteLine("p3: {0}", p3);
            Console.WriteLine("p4: {0}", p4);
            Console.ReadLine();
        }
    }
}

