using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp2.LinqPocketRef
{
    class LinqPacket
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Function4();

            Console.Read();
        }
        static void Function1()
        {

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jsy" };

            IEnumerable<string> filteredNames = Enumerable.Where(names, n => n.Length >= 4);
            IEnumerable<string> abcEnum = names.Where(x => x.Length > 4).ToList();
            IEnumerable<string> filter1 = from n in names
                                          where n.Length > 4
                                          select n;

            IEnumerable<string> filter2 = names.Where(x => x.Contains('r')).OrderBy(v => v.Length).Select(y => y.ToUpper());


            //names
            //                        .Where(n => n.Contains("a"))
            //                        .OrderBy(n => n.Length)
            //                        .Select(n => n.ToUpper());

            foreach (var ab in filter2)
            {
                Console.WriteLine(ab);
            }

        }

        static void Function2()
        {
            int[] numbers = { 10, 9, 8, 7, 6 };
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jsy" };

            int firstNumber = numbers.First(); // 10
            int lastNumber = numbers.Last(); // 6
            int secondNumber = numbers.ElementAt(1); // 9
            int count1 = numbers.Count(); // 5;
            int min = numbers.Min(); // 6;


            bool hasTheNumberNine = numbers.Contains(9); // true
            bool hasMoreThanZeroElements = numbers.Any(); // true
            IEnumerable<int> hasAnOddElement = numbers.Where(n => n % 2 == 1).Select(n => n); // true

            foreach (var ab in hasAnOddElement)
            {
                Console.WriteLine(ab);
            }


            int count = (from n in names
                         where n.Contains("a")
                         select n
                        ).Count();

            var numbers1 = new List<int>();
            numbers1.Add(1);
            // Build query
            IEnumerable<int> query = numbers1.Select(n => n * 10);
            numbers1.Add(2); // Sneak in an extra element
            foreach (int n in query)
                Console.Write(n + "|");
        }

        static void Function3()
        {
            IEnumerable<char> query = "Not what you might expect";
            foreach (char vowel in "aeiou")
            {
                char temp = vowel;
                query = query.Where(c => c != temp);
            }

            foreach (var ab in query)
            {
                //Console.Write(ab);
            }


            string[] musos = { "David Gilmour", "Roger Waters", "Rick Wright" };
            IEnumerable<string> query1 = musos.OrderBy(m => m.Split().Last());

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> outerQuery = names
                                            .Where(n => n.Length == names.OrderBy(n2 => n2.Length).Select(n2 => n2.Length).First()
            );


            foreach (var ab in outerQuery)
            {
                //Console.Write(ab);
            }


            IEnumerable<string> query2 = names
                                .Select(n => Regex.Replace(n, "[aeiou]", ""))
                                .Where(n => n.Length > 2)
                                .OrderBy(n => n);

            IEnumerable<string> query3 =
                                            from n in names
                                            where n.Length > 2
                                            orderby n
                                            select Regex.Replace(n, "[aeiou]", "");


            IEnumerable<string> query4 = from n in names
                                         select Regex.Replace(n, "[eiou]", "")
                                        into noVowerl
                                         where noVowerl.Length > 2
                                         orderby noVowerl
                                         select noVowerl;


            foreach (var ab in query4)
            {
                Console.Write(ab);
            }
        }

        static void Function4()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            IEnumerable<TempProjectionItem> temp =
                                                from n in names
                                                select new TempProjectionItem
                                                {
                                                    Original = n,
                                                    Vowelless = Regex.Replace(n, "[aeiou]", "")
                                                };

            IEnumerable<TempProjectionItem> abc = from m in names
                                                  select new TempProjectionItem
                                                  {
                                                      Vowelless = m,
                                                      Original = m.ToUpper()
                                                  };

            IEnumerable<string> query =
                                    from n in names
                                    let vowelless = Regex.Replace(n, "[aeiou]", "")
                                    where vowelless.Length > 2
                                    orderby vowelless
                                    select n; // Thanks to let, n is still in scope

            foreach (var ab in query)
            {
                Console.WriteLine(ab);
                //Console.WriteLine(ab.Original + " | " + ab.Vowelless);
            }

        }
    }
   public class TempProjectionItem
    {
        public string Original; // Original name
        public string Vowelless; // Vowel-stripped name
    }
}
