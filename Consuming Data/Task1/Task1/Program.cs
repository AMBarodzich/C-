using System;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Task1
{
    [DataContract]
    class Book
    {
        [DataMember]
        public string NameBook { get; set; } = "boigraphy";
        [DataMember]
        public string Author { get; set; } = "Borodich Aleksandr";
        [DataMember]
        public int Year { get; set; } = 2011;
        [DataMember]
        public int Pages { get; set; } = 231;
        [DataMember]
        public string CityPublished { get; set; } = "Minsk";
        [DataMember]
        public string CountryPublished { get; set; } = "Belarus";

        // work with  JSON
        public void SaveToJSON()
        {
            using (Stream stream = new FileStream(@"..\..\file.json", FileMode.Create))
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Book));
                json.WriteObject(stream, this);
                Console.WriteLine("saved to JSON format.");
            }
        }

        public void LoadFromJSON()
        {
            using (Stream stream = new FileStream(@"..\..\file.json", FileMode.Open))
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Book));
                Book result = (Book)json.ReadObject(stream);
                Console.WriteLine("\nIt's information from JSON file:" + result);
            }
        }

        //work with XML
        public void SaveToXML()
        {
            using (Stream stream = new FileStream(@"..\..\file.xml", FileMode.Create))
            {
                DataContractSerializer xml = new DataContractSerializer(typeof(Book));
                xml.WriteObject(stream, this);
                Console.WriteLine("saved to XML format.");
            }
        }

        public void LoadFromXML()
        {
            using (Stream stream = new FileStream(@"..\..\file.xml", FileMode.Open))
            {
                DataContractSerializer xml = new DataContractSerializer(typeof(Book));
                Book result = (Book)xml.ReadObject(stream);
                Console.WriteLine("\nIt's information from XML file:" + result);
            }
        }


        public override string ToString()
        {
            return "\nName: " + NameBook + "\nAuthor: " + " " + Author + "\nYear: " + Year + "\nPages " + Pages + "\nCityPublished: " + CityPublished + "\nCountryPublished: " + CountryPublished;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book b = new Book();
            b.SaveToXML();
            b.SaveToJSON();
            b.LoadFromXML();
            b.LoadFromJSON();
            Console.ReadKey();
        }
    }
}