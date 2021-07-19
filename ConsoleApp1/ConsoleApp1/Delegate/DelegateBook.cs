using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Delegate
{
    class DelegateBook
    {
    }
}

namespace SimpleDelegate
{
    // This delegate can point to any method,
    // taking two integers and returning an integer.
    public delegate int BinaryOp(int x, int y);
    // This class contains methods BinaryOp will
    // point to.
    public class SimpleMath
    {
        public static int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;

        public static int Divide(int x, int y)
        {
            return x / y;
        }
    }
    class Program
    {
        public static int Add1(int x, int y) => x + y;
        static void Maindf(string[] args)
        {





            Console.WriteLine("***** Simple Delegate Example *****\n");
            // Create a BinaryOp delegate object that
            // "points to" SimpleMath.Add().
            SimpleMath ab = new SimpleMath();
            var abh = SimpleMath.Add(10,30);

            BinaryOp b = new BinaryOp(SimpleMath.Add);
            //var abccc= Add1(10, 30);
            ///Console.WriteLine("10 + 10 is {0}", abccc);
            // Invoke Add() method indirectly using delegate object.
            
            Console.WriteLine("10 + 10 is {0}", b(10, 10));

            BinaryOp c = new BinaryOp(SimpleMath.Subtract);
            // Invoke Add() method indirectly using delegate object.
            Console.WriteLine("10 - 10 is {0}", c(10, 10));

            BinaryOp d = new BinaryOp(SimpleMath.Divide);
            Console.WriteLine("10 / 10 is {0}", d(10, 10));
            //DisplayDelegateInfo(b);


            Console.ReadLine();
        }
    }


}

namespace SimpleDelegate2
{
    public class Car
    {
        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        // Is the car alive or dead?
        private bool carIsDead;
        // Class constructors.
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
    }

    class Program
    {
        static void Mains(string[] args)
        {
            Console.WriteLine("***** Delegates as event enablers *****\n");
            // First, make a Car object.
            Car c1 = new Car("SlugBug", 100, 10);
            // Now, tell the car which method to call
            // when it wants to send us messages.
            //c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            // Speed up (this will trigger the events).
            Console.WriteLine("***** Speeding up *****");
            //for (int i = 0; i < 6; i++)
                //c1.Accelerate(20);
            Console.ReadLine();


        }
        // This is the target for incoming events.
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************\n");
        }
    }
}

namespace GenericDelegate
{
    // This generic delegate can represnet any method
    // returning void and taking a single parameter of type T.
    public delegate void MyGenericDelegate<T>(T arg, T arg2);
    class Program
    {
        static void Maindw(string[] args)
        {
            Console.WriteLine("***** Generic Delegates *****\n");
            // Register targets.
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Some string data", "sdada");
            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);
            intTarget(9,7);
            Console.ReadLine();
        }
        static void StringTarget(string arg, string arg2)
        {
            Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper() + arg2.ToUpper());
        }
        static void IntTarget(int arg, int arg2)
        {
            Console.WriteLine("++arg is: {0}", ++arg +""+ arg2--);
        }
    }
}

namespace GenericDelegate2
{
    class Program
    {
        // This is a target for the Action<> delegate.
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }
            // Restore color.
            Console.ForegroundColor = previous;
        }

        static void Mainrt(string[] args)
        {
            Console.WriteLine("***** Fun with Action and Func *****");
            // Use the Action<> delegate to point to DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor,int>(DisplayMessage);
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);
            Console.ReadLine();
        }
    }

}

namespace Lamdaexpr
{
    class Program
    {
        static void Mainh(string[] args)
        {
            Console.WriteLine("***** Fun with Lambdas *****\n");
            TraditionalDelegateSyntax();
            Console.ReadLine();
        }
        static void TraditionalDelegateSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44,4,78,4 });
            // Call FindAll() using traditional delegate syntax

            

            var abc = list.FindAll(x => x == 4).ToArray();
            foreach(var a in abc)
            {
                Console.WriteLine(a.ToString());
            }    
          
        }
    }
}