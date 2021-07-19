//using ConsoleApp1.Files.SimpleSerialize;
using SimpleSerialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace ConsoleApp1.Files
{
    class Searilization
    {
        public static void Main()
        {
            Console.WriteLine("***** Fun with Object Serialization *****\n");

            //JamesBondCar savedCar = ReadAsXmlFormat<JamesBondCar>("CarData.xml");
            //Console.WriteLine("Original Car: {0}", savedCar.ToString());
            //Console.WriteLine("Read Car: {0}", savedCar.ToString());
            //List<JamesBondCar> savedCars = ReadAsXmlFormat<List<JamesBondCar>>("CarCollection.xml");



            // Make a JamesBondCar and set state.
            JamesBondCar jbc = new JamesBondCar()
            {
                CanFly = true,
                CanSubmerge = false,
                TheRadio = new Radio()
                {
                    StationPresets = new List<double>() { 89.3, 105.1, 97.1 },
                    HasTweeters = true
                }
            };

            Person p = new Person()
            {
                FirstName = "James",
                IsAlive = true
            };

            //Console.WriteLine(jbc);

            SaveAsXmlFormat(jbc, "CarData.xml");
            Console.WriteLine("=> Saved car in XML format!");
            SaveAsXmlFormat(p, "PersonData.xml");
            Console.WriteLine("=> Saved person in XML format!");


            SaveAsJsonFormat(jbc, "CarData.json");
            Console.WriteLine("=> Saved car in JSON format!");
            SaveAsJsonFormat(p, "PersonData.json");
            Console.WriteLine("=> Saved person in JSON format!");

            Console.Read();
        }


        static void SaveAsXmlFormat<T>(T objGraph, string fileName)
        {
            //Must declare type in the constructor of the XmlSerializer
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));

            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
        }


        static void SaveListOfCarsAsXml()
        {
            //Now persist a List<T> of JamesBondCars.
            List<JamesBondCar> myCars = new List<JamesBondCar>()
            {
                new JamesBondCar { CanFly = true, CanSubmerge = true },
                new JamesBondCar { CanFly = true, CanSubmerge = false },
                new JamesBondCar { CanFly = false, CanSubmerge = true },
                new JamesBondCar { CanFly = false, CanSubmerge = false },
            };
            using (Stream fStream = new FileStream("CarCollection.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
                xmlFormat.Serialize(fStream, myCars);
            }
            Console.WriteLine("=> Saved list of cars!");
        }

        static T ReadAsXmlFormat<T>(string fileName)
        {
            // Create a typed instance of the XmlSerializer
            XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            using (Stream fStream = new FileStream(fileName, FileMode.Open))
            {
                T obj = default;
                obj = (T)xmlFormat.Deserialize(fStream);
                return obj;
            }
        }

        static void SaveAsJsonFormat<T>(T objGraph, string fileName)
        {
            File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(objGraph));
        }

        static void SaveAsJsonFormat2<T>(T objGraph, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                //IncludeFields = true,
                WriteIndented = true
            };
            File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(objGraph, options));
        }
    }
}

namespace SimpleSerialize
{
    public class Radio
    {
        public bool HasTweeters;
        public bool HasSubWoofers;
        public List<double> StationPresets;
        public string RadioId = "XF-552RR6";
        public override string ToString()
        {
            var presets = string.Join(",", StationPresets.Select(i => i.ToString()).ToList());
            return $"HasTweeters:{HasTweeters} HasSubWoofers:{HasSubWoofers} Station Presets: {presets} ";
        }
    }
}


namespace SimpleSerialize
{
    public class Car
    {
        public Radio TheRadio = new Radio();
        public bool IsHatchBack;
        public override string ToString()
        => $"IsHatchback:{IsHatchBack} Radio:{TheRadio.ToString()}";
    }
}

namespace SimpleSerialize
{
    public class JamesBondCar : Car
    {
        public bool CanFly;
        public bool CanSubmerge;
        public override string ToString()
        => $"CanFly:{CanFly}, CanSubmerge:{CanSubmerge} {base.ToString()}";
    }
}


namespace SimpleSerialize
{
    public class Person
    {
        // A public field.
        public bool IsAlive = true;
        // A private field.
        private int PersonAge = 21;
        // Public property/private data.
        private string _fName = string.Empty;
        public string FirstName
        {
            get { return _fName; }
            set { _fName = value; }
        }
        public override string ToString() =>
        $"IsAlive:{IsAlive} FirstName:{FirstName} Age:{PersonAge} ";
    }
}