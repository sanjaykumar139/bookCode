
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2design.Builder1
{
    class Class1
    {
        static void MainWQ(string[] args)
        {
            Console.WriteLine("***Builder Pattern Demo***");
            Director director = new Director();
            Imyinterface b1 = new Car();
            Imyinterface b2 = new Bike();

            // Making Car
            //director.Construct(b1);
            //Product p1 = b1.Add();
            //p1.Show();

            ////Making MotorCycle
            //director.Construct(b2);
            //Product p2 = b2.Sub();
            //p2.Show();
            //Console.ReadLine();
        }
    }

    class Director
    {
        Imyinterface builder;
        // A series of steps-in real life, steps are complex.
        public void Construct(Imyinterface builder)
        {
            this.builder = builder;
            builder.Add();
            builder.Sub();
            //builder.InsertWheels();
            //builder.AddHeadlights();
            //builder.EndOperations();
        }
    }
    public class Product
    {
        // We can use any data structure that you prefer e.g.List<string> etc.
        private LinkedList<string> parts;
        public Product()
        {
            parts = new LinkedList<string>();
        }
        public void Add(string part)
        {
            //Adding parts
            parts.AddLast(part);
        }
        public void Show()
        {
            Console.WriteLine("\nProduct completed as below :");
            foreach (string part in parts)
                Console.WriteLine(part);
        }
    }

     interface Imyinterface
    {
        public void Add();
        public void Sub();
    }

    public class Car : Imyinterface
    {
        public void Add()
        {
            Console.WriteLine("Add method from car");
        }

        public void Sub()
        {
            Console.WriteLine("Sub method from car");
        }
    }

    public class Bike : Imyinterface
    {
        public void Add()
        {
            Console.WriteLine("Add method from Bike");
        }

        public void Sub()
        {
            Console.WriteLine("Sub method from Bike");
        }
    }
}
