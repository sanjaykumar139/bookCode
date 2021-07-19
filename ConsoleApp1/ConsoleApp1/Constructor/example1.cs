using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Constructor
{
    class example1
    {
    }
}

namespace ConstructorDemo
{
    class Program
    {
        Program()
        {
            Console.WriteLine("This is Constructor");
        }
        public static void Mainy(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Main method");
            Console.ReadKey();
        }
    }
}

namespace ConstructorDemo
{
    class Employee
    {
        int eid, eage;
        String eaddress, ename;
        public void Display()
        {
            Console.WriteLine("\nemployee id is:  " + eid);
            Console.WriteLine("employee name is:  " + this.ename);
            Console.WriteLine("employee age is:  " + this.eage);
            Console.WriteLine("employee address is:  " + eaddress);
        }
    }
    class Test
    {
        static void Mainq(string[] args)
        {
            Employee e1 = new Employee();
            Employee e2 = new Employee();
            e1.Display();
            e2.Display();
            Console.ReadKey();
        }
    }
}

namespace ConstructorDemo1
{
    class Employee
    {

        int eid, eage;
        string eaddress, ename;
        public Employee()
        {
            this.eid = 100;
            eage = 30;
            this.ename = "Pranaya";
            eaddress = "MUMBAI";
        }
        public void Display()
        {
            Console.WriteLine("employee id is:  " + eid);
            Console.WriteLine("employee name is:  " + this.ename);
            Console.WriteLine("employee age is:  " + this.eage);
            Console.WriteLine("employee address is:  " + eaddress);
        }
    }
    class Test
    {
        public static void Mainqq(string[] args)
        {
            Employee e1 = new Employee();
            Employee e2 = new Employee();
            e1.Display();
            e2.Display();
            Console.ReadKey();
        }
    }
}

namespace ConstructorDemo2
{
    class Employee
    {
        int eid, eage;
        String eaddress, ename;
        public Employee(int id, int age, string name, string address)
        {
            this.eid = id;
            this.eage = age;
            this.ename = name;
            this.eaddress = address;
        }
        public void Display()
        {
            Console.WriteLine("employee id is:  " + eid);
            Console.WriteLine("employee name is:  " + this.ename);
            Console.WriteLine("employee age is:  " + this.eage);
            Console.WriteLine("employee address is:  " + eaddress);
        }
    }
    class Test
    {
        static void Mainqw(string[] args)
        {
            Employee e1 = new Employee(101, 30, "Pranaya", "Mumbai");
            Employee e2 = new Employee(101, 28, "Rout", "BBSR");
            e1.Display();
            e2.Display();
            Console.ReadKey();
        }
    }
}

namespace ConstructorDemo3
{
    class Employee
    {
        int eid, age;
        string address, name;
        public Employee()
        {
            Console.WriteLine("ENTER EMPLOYEE DETAILS");
            Console.WriteLine("Enter the employee id");
            this.eid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the employee age");
            this.age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the employee name");
            this.name = Console.ReadLine();
            Console.WriteLine("Enter the employee address:");
            this.address = Console.ReadLine();
        }
        public Employee(Employee tempobj)
        {
            this.eid = tempobj.eid;
            this.age = tempobj.age;
            this.name = tempobj.name;
            this.address = tempobj.address;
        }
        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("Employee id is:  " + this.eid);
            Console.WriteLine("Employee name is:  " + this.name);
            Console.WriteLine("Employee age is:  " + this.age);
            Console.WriteLine("Employee address is:  " + this.address);
        }
    }
    class Test
    {
        static void Mainqwq(string[] args)
        {
            Employee e1 = new Employee();
            Employee e2 = new Employee(e1);
            e1.Display();
            e2.Display();
            Console.ReadKey();
        }
    }
}

namespace ConstructorDemo4
{
    class Example
    {
        int i;
        static int j;
        public Example()
        {
            i = 100;
            Console.WriteLine("Constructor value of i : " + i);
        }
        static Example()
        {
            j = 200;
            Console.WriteLine("Constructor value of j : " + j);
        }
        public void Display()
        {
            Console.WriteLine("value of i : " + i);
            i++;
            Console.WriteLine("value of j : " + j);
            j++;
        }
    }
    class Test
    {
        static void MainAqwa(string[] args)
        {
            Example e1 = new Example();
            e1.Display();
            e1.Display();
            Example e2 = new Example();
            e2.Display();
            e2.Display();
            Console.ReadKey();
        }
    }
}

namespace DestructorExample
{
    class DestructorDemo
    {
        public DestructorDemo()
        {
            Console.WriteLine("constructor object created");
        }
        ~DestructorDemo()
        {
            Console.WriteLine("object is destroyed");
        }
    }
    class Test
    {
        static void Mainqqw(string[] args)
        {
            DestructorDemo obj1 = new DestructorDemo();
            DestructorDemo obj2 = new DestructorDemo();
            obj1 = null;
            obj2 = null;
           // GC.Collect();
            Console.ReadKey();
        }
    }
}

namespace DestructorExample.constructorchaining
{
    class ClassConstructor
    {
        static void Mainewsq(string[] args)
        {
            Console.WriteLine("***** Fun with Class Types *****\n");

            // Make a Motorcycle.
            //Motorcycle c = new Motorcycle();
            Motorcycle c1 = new Motorcycle(5);
            //Motorcycle c = new Motorcycle("abc");
            //Motorcycle c = new Motorcycle(34, "cdef");

            //Console cc;
            
            Console.ReadLine();
        }
    }

    class Motorcycle
    {
        public int driverIntensity;
        public string driverName;
        // Constructor chaining.
        public Motorcycle()
        {
            Console.WriteLine("In default ctor");
        }
        public Motorcycle(int intensity) : this(intensity, "")
        {
            Console.WriteLine("In ctor taking an int");
        }
        public Motorcycle(string name) : this(0, name)
        {
            Console.WriteLine("In ctor taking a string");
        }
        // This is the 'master' constructor that does all the real work.
        public Motorcycle(int intensity, string name)
        {
            Console.WriteLine("In master ctor ");
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
            Console.WriteLine(driverIntensity +" "+ driverName);
        }
    }
}
