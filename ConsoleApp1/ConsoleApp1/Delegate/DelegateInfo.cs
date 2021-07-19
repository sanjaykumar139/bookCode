using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1.Delegate
{
    class DelegateInfo
    {
       // public delegate void someMehtod(string search);
        //public static someMehtod somePointer = null;    //instance of delegate

        static void Maintr(string[] args)
        {
            MyFileSearch x = new MyFileSearch();
            x.publisher += Receiver;
            x.publisher += Receiver2;
            x.publisher += Receiver3;
            // x.publisher = null;

            Console.WriteLine("File searched has started....");
            Task.Run(()=>x.Search("D:\\ebooks"));
        
            
            //somePointer = x.Search;
            //somePointer("D:\\plural");
            //x.Search("D:\\plural");

            Console.WriteLine("End Program..");
            Console.ReadLine();
        }

        static void Receiver(string filename)
        {
            Console.WriteLine(filename);
        }
        static void Receiver2(string filename)
        {
            Console.WriteLine(filename);
        }
        static void Receiver3(string filename)
        {
            Console.WriteLine(filename);
        }
    }

    public class MyFileSearch
    {
        public delegate void searchMethod(string search);
        public event searchMethod publisher = null;

        public void Search(string dir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(dir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        publisher(f);
                    }
                }
            }
            catch(Exception ex) { }
        }
    }

}
        
