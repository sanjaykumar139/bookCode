using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2design.Prototype
{
    class PrototypePat
    {
        static void MainQwe(string[] args)
        {
            Console.WriteLine("***Prototype Pattern Demo***\n");

            //Base or Original Copy
            BasicCar nano_base = new Nano("Green Nano") { Price = 100000 };
            BasicCar ford_base = new Ford("Ford Yellow") { Price = 500000 };
            BasicCar bc1;

            //Nano
            bc1 = nano_base.Clone1();
            bc1.Price = nano_base.Price + BasicCar.SetPrice();
            Console.WriteLine("Car is: {0}, and it's price is Rs. {1} ", bc1.ModelName, bc1.Price);

            //bc1 = nano_base.Clone();
            //bc1.Price = nano_base.Price + BasicCar.SetPrice();
            //Console.WriteLine("Car1 is: {0}, and it's price is Rs. {1} ", bc1.ModelName, bc1.Price);

            //Ford
            bc1 = ford_base.Clone1();
            bc1.Price = ford_base.Price + BasicCar.SetPrice();
            Console.WriteLine("Car is: {0}, and it's price is Rs. {1}", bc1.ModelName, bc1.Price);
            Console.ReadLine();
        }
    }
    public abstract class BasicCar
    {
        public string ModelName { get; set; }
        public int Price { get; set; }
        public static int SetPrice()
        {
            int price = 0;
            Random r = new Random();
            int p = r.Next(200000, 500000);
            price = p;
            return price;
        }
        public abstract BasicCar Clone1();
    }
    public class Ford : BasicCar
    {
        public Ford(string m)
        {
            ModelName = m;
        }
        public override BasicCar Clone1()
        {
            return (Ford)this.MemberwiseClone();
        }
    }
    public class Nano : BasicCar
    {
        public Nano(string m)
        {
            ModelName = m;
        }
        public override BasicCar Clone1()
        {
            return (Nano)this.MemberwiseClone();//shallow Clone
        }
    }
}
