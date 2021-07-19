using ConsoleApp2design.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2design.TemplateMethod
{
    class TemplateMethodPattern
    {
    }
    public abstract class BasicEngineering
    {
        public void Papers()
        {
            //Common Papers:
            Math();
            SoftSkills();
            //Specialized Paper:
            SpecialPaper();
        }
        private void Math()
        {
            Console.WriteLine("Mathematics");
        }
        private void SoftSkills()
        {
            Console.WriteLine("SoftSkills");
        }
        public abstract void SpecialPaper();
    }
}


//ComputerScience.cs
namespace TemplateMethodPattern
{
    public class ComputerScience : BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("Object-Oriented Programming");
        }
    }
}

//Electronics.cs
namespace TemplateMethodPattern
{
    public class Electronics : BasicEngineering
    {
        public override void SpecialPaper()
        {
            Console.WriteLine("Digital Logic and Circuit Theory");
        }
    }
}

// Program.cs
namespace TemplateMethodPattern
{
    class Program
    {
        static void MainW(string[] args)
        {
            Console.WriteLine("***Template Method Pattern Demo***\n");

            BasicEngineering bs = new ComputerScience();
            Console.WriteLine("Computer Sc Papers:");
            bs.Papers();
            Console.WriteLine();

            bs = new Electronics();
            Console.WriteLine("Electronics Papers:");
            bs.Papers();

            Console.ReadLine();
        }
    }
}
