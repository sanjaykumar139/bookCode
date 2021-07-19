using IteratorPattern.Aggregate;
using IteratorPattern.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2design.Iterator
{
    class IteratorPattern
    {
    }
}


// ISubjects.cs
namespace IteratorPattern.Aggregate
{
    public interface ISubjects
    {
        IIterator CreateIterator();
    }
}

// Science.cs
namespace IteratorPattern.Aggregate
{
    public class Science : ISubjects
    {
        private LinkedList<string> Subjects;
        public Science()
        {
            Subjects = new LinkedList<string>();
            Subjects.AddFirst("Maths");
            Subjects.AddFirst("Comp. Sc.");
            Subjects.AddFirst("Physics");
        }
        public IIterator CreateIterator()
        {
            return new ScienceIterator(Subjects);
        }
    }
}


//Arts.cs
namespace IteratorPattern.Aggregate
{
    public class Arts : ISubjects
    {
        private string[] Subjects;
        public Arts()
        {
            Subjects = new[] { "Bengali", "English" };
        }
        public IIterator CreateIterator()
        {
            return new ArtsIterator(Subjects);
        }
    }
}

namespace IteratorPattern.Iterator
{
    public interface IIterator
    {
        void First();//Reset to first element
        string Next();//Get next element
        bool IsDone();//End of collection check
        string CurrentItem();//Retrieve Current Item
    }
}


// ScienceIterator.cs
namespace IteratorPattern.Iterator
{
    public class ScienceIterator : IIterator
    {
        private LinkedList<string> Subjects;
        private int position;
        public ScienceIterator(LinkedList<string> subjects)
        {
            this.Subjects = subjects;
            position = 0;
        }
        public void First()
        {
            position = 0;
        }
        public string Next()
        {
            return Subjects.ElementAt(position++);
        }
        public bool IsDone()
        {
            if (position < Subjects.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string CurrentItem()
        {
            return Subjects.ElementAt(position);
        }
    }
}


// ArtsIterator.cs
namespace IteratorPattern.Iterator
{
    public class ArtsIterator : IIterator
    {
        private string[] Subjects;
        private int position;
        public ArtsIterator(string[] subjects)
        {
            this.Subjects = subjects;
            position = 0;
        }
        public void First()
        {
            position = 0;
        }
        public string Next()
        {
            return Subjects[position++];
        }
        public bool IsDone()
        {
            if (position < Subjects.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string CurrentItem()
        {
            return Subjects[position];
        }
    }
}


// Program.cs
namespace IteratorPattern
{
    class Program
    {
        static void MainR(string[] args)
        {
            Console.WriteLine("***Iterator Pattern Demo***");

            ISubjects ScienceSubjects = new Science();
            ISubjects ArtsSubjects = new Arts();

            IIterator IteratorForScience = ScienceSubjects.CreateIterator();
            IIterator IteratorForArts = ArtsSubjects.CreateIterator();

            Console.WriteLine("\nScience subjects :");
            Print(IteratorForScience);

            Console.WriteLine("\nArts subjects :");
            Print(IteratorForArts);

            Console.ReadLine();
        }
        public static void Print(IIterator iterator)
        {
            while (!iterator.IsDone())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}