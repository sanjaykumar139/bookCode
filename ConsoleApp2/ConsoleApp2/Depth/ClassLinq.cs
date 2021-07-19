using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ConsoleApp2.Depth
{
    class ClassLinq
    {
        public string Name1 { get; set; }
        public string Name { get; private set; }

        Dictionary<string, List<decimal>> mapping = new Dictionary<string, List<decimal>>();

        //var array = new[,] { { 1, 2, 3 }, { 4, 5, 6 } };


    }
    public class Order
    {
        private readonly List<OrderItem> items = new List<OrderItem>();
        public string OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get { return items; } }
    }
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class OrderItem
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }
    }

    public class MyClass
    {
        Order order = new Order
        {
            OrderId = "xyz",
            Customer = new Customer { Name = "Jon", Address = "UK" },
            Items =
                    {
                    new OrderItem { ItemId = "abcd123", Quantity = 1 },
                    new OrderItem { ItemId = "fghi456", Quantity = 2 }
                    }
        };


        public static void MainE()
        {
            Action<string> action = delegate (string message)
            {
                Console.WriteLine("In delegate: {0}", message);
            };
            action("Message");


            Action<string> action1 = (string message) =>
            {
                Console.WriteLine("In delegate1: {0}", message);
            };
            action1("Message1");

            //CapturedVariablesDemo cd = new CapturedVariablesDemo();
            //var abc= cd.CreateAction("hello world");
            //Console.WriteLine("In " + abc);

            //CapturedVariablesDemo.CreateActions();

            //List<Action> actions = CapturedVariablesDemo.CreateActions();
            //foreach (Action action in actions)
            //{
            //    action();
            //}

            CapturedVariablesDemo ab = new CapturedVariablesDemo();
            //ab.MyFunction();
            ab.Chaining();
            Console.Read();
        }
    }

    public class CapturedVariablesDemo
    {
        private string instanceField = "instance field";
        public Action<string> CreateAction(string methodParameter)
        {
            string methodLocal = "method local";
            string uncaptured = "uncaptured local";
            Action<string> action = lambdaParameter =>
            {
                string lambdaLocal = "lambda local";
                Console.WriteLine("Instance field: {0}", instanceField);
                Console.WriteLine("Method parameter: {0}", methodParameter);
                Console.WriteLine("Method local: {0}", methodLocal);

                Console.WriteLine("Lambda parameter: {0}", lambdaParameter);
                Console.WriteLine("Lambda local: {0}", lambdaLocal);
            };
            methodLocal = "modified method local";
            return action;
        }


        public static List<Action> CreateActions()
        {
            List<Action> actions = new List<Action>();
            for (int i = 0; i < 5; i++)
            {
                string text = string.Format("message {0}", i);
                actions.Add(() => Console.WriteLine(text));
            }
            return actions;
        }

        public void MyFunction()
        {
            Expression<Func<int, int, int>> adder = (x, y) => x + y;
            Console.WriteLine(adder);

            ParameterExpression xParameter = Expression.Parameter(typeof(int), "x");
            ParameterExpression yParameter = Expression.Parameter(typeof(int), "y");
            Expression body = Expression.Add(xParameter, yParameter);
            ParameterExpression[] parameters = new[] { xParameter, yParameter };
            Expression<Func<int, int, int>> adder1 =
            Expression.Lambda<Func<int, int, int>>(body, parameters);
            Console.WriteLine(adder);
        }

        public void Chaining()
        {
            string[] words = { "keys", "coat", "laptop", "bottle" };
            IEnumerable<string> query = words
                                        .Where(word => word.Length > 4)
                                        .OrderBy(word => word)
                                        .Select(word => word.ToUpper());
            foreach (string word in query)
            {
                Console.WriteLine(word);
            }
        }
    }
}

//namespace NodaTime.Extensions
//{
//    public static class DateTimeOffsetExtensions
//    {
//        public static Instant ToInstant(this DateTimeOffset dateTimeOffset)
//        {
//            return Instant.FromDateTimeOffset(dateTimeOffset);
//        }
//    }
//}