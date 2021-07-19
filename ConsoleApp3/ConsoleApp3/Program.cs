using System;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        //Find which has 2 or more repeated character.
        static void Main1(string[] args)
        {
            Console.WriteLine("Hello World!");
            string strPrint = "sanjay";
            string strResult = "";

            //First by Array style
            char[] strchar = strPrint.ToCharArray();

            for (int i = 0; i < strchar.Length; i++)
            {
                for (int j = i + 1; j < strchar.Length - 1; j++)
                {
                    if (strchar[i] == strchar[j])
                    {
                        strResult = "the duplicate letter is: " + strchar[i].ToString().ToUpper();

                    }
                }
            }

            if (strResult.Length > 1)
            {
                Console.WriteLine(strResult);
            }
            else
            {
                Console.WriteLine("Nothing Found");
            }


            //second way by LINQ
            var duplicates = strchar.GroupBy(s => s)
                              .Where(g => g.Count() > 1);
            //.Select(g => g.Key); // or .SelectMany(g => g)

            Console.WriteLine("\n BY LINQ: " + duplicates.FirstOrDefault());

            Console.Read();
        }


        //Reverse the order of string
        static void Main2(string[] args)
        {
            string strQuestion = "Do or do not, there is no try.";

            string[] strArray = strQuestion.Split(" ");
            strQuestion = "";

            for( int i= strArray.Length-1; i>= 0;i--)
            {
                strQuestion = strQuestion + strArray[i] + " ";
            }

            Console.WriteLine("ORIGINAL: Do or do not, there is no try.");
            Console.WriteLine(strQuestion);
            Console.Read();

        }

        //reverse a string
        static void Main(string[] args)
        {
            string strQuestion = "sanjay";
            char[] strchar = strQuestion.ToCharArray();
           

            for (int i = strchar.Length-1; i >= 0; i--)
            {
                strchar[j] = strchar[i];
            }

            Console.WriteLine("ORIGINAL: Do or do not, there is no try.");
            Console.WriteLine(strQuestion);
            Console.Read();

        }
    }
}
