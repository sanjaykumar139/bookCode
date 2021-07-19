using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2design.Prototype1
{
    public abstract class BasicCar
    {
        public string CarName { get; set; }
        public int price { get; set; }

        public abstract BasicCar CopyCLone();
    }

    public class Ford : BasicCar
    {
        public Ford()
        {
            Console.WriteLine("This is from Ford Car");
        }
        public override BasicCar CopyCLone()
        {
            return (Ford)this.MemberwiseClone();
            //throw new NotImplementedException();
        }
    }

    public class Honda : BasicCar
    {
        public Honda()
        {
            Console.WriteLine("This is from Honda Car");
        }
        public override BasicCar CopyCLone()
        {
            return (Honda)this.MemberwiseClone();
            //throw new NotImplementedException();
        }
    }

    public class Myclass
    {
        public static void MainQas()
        {
            Console.WriteLine("This is Main class");

            BasicCar bc1;

            bc1 = new Ford();


            bc1.CarName = "abc";
            bc1.price = 1000;
            Console.WriteLine("Ford class " + bc1.price + " " + bc1.CarName);


            bc1 = new Honda();
            bc1.CarName = "cde";
            bc1.price = 2000;

            Console.WriteLine("Honda class " + bc1.price + " " + bc1.CarName);

            Console.ReadLine();
        }
    }
}
