using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace task1
{

    class common
    {
        public const string NameBook = "book";
        public const string ID = "id";
        public const string TITLE = "title";
        public const string AUTHOR = "authors";
        public const string YEAR = "publication-year";
        public const string DESCR = "description";
        public const string TEXT = "text";
    }

    [Serializable]
    [DataContract]
    public class Book
    {
        [XmlAttribute(common.ID)]
        [DataMember]
        public string Id { get; set; }
        [XmlElement(common.TITLE)]
        [DataMember]
        public string Title { get; set; }
        [XmlElement(common.AUTHOR)]
        [DataMember]
        public string Author { get; set; }
        [XmlElement(common.YEAR)]
        [DataMember]
        public int PublicationYear { get; set; }
        [XmlElement(common.DESCR)]
        [DataMember]
        public string Description { get; set; }
        [XmlElement(common.TEXT)]
        [DataMember]
        public string Text { get; set; }

        public Book()
        {

        }

        public static Book LoadFromXML(string id)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;

            Book book = new Book();

            using (XmlReader xr = XmlReader.Create(string.Format(@".\{0}.xml", id), settings))
            {
                xr.MoveToContent();
                book.Id = xr[common.ID];
                xr.ReadStartElement(common.NameBook);
                book.Title = xr.ReadElementContentAsString();
                book.Author = xr.ReadElementContentAsString();
                book.PublicationYear = xr.ReadElementContentAsInt();
                book.Description = xr.ReadElementContentAsString();
                book.Text = xr.ReadElementContentAsString();
                xr.ReadEndElement();
            }

            return book;
        }

        public void SaveToXML()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter xw = XmlWriter.Create(string.Format(@".\{0}.xml", this.Id), settings))
            {
                xw.WriteStartElement(common.NameBook);
                xw.WriteAttributeString(common.ID, this.Id);
                xw.WriteElementString(common.TITLE, this.Title);
                xw.WriteElementString(common.AUTHOR, this.Author);
                xw.WriteElementString(common.YEAR, this.PublicationYear.ToString());
                xw.WriteElementString(common.DESCR, this.Description);
                xw.WriteElementString(common.TEXT, this.Text);
                xw.WriteEndElement();
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

        public void SaveToJSON()
        {
            using (Stream stream = new FileStream(@"..\..\file.json", FileMode.Create))
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Book));
                json.WriteObject(stream, this);
                Console.WriteLine("saved to JSON format.");
            }
        }

        public override string ToString()
        {
            return string.Format("Book #{0}: '{1}' by {2} (pub. year: {3})\nDescription: {4}\n\n{5}", this.Id, this.Title, this.Author, this.PublicationYear, this.Description, this.Text);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book b = new Book();
            b.SaveToXML();
            b.SaveToJSON();
            b.LoadFromJSON();
            Console.ReadKey();
        }
    }
}