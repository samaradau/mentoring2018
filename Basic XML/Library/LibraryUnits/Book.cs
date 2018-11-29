using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Library.Units
{
	/// <summary>
	/// Represents a Book.
	/// </summary>
	[XmlInclude(typeof(Book))]
	[Serializable]
    public class Book : Item
	{
		public string Name { get; set; }
		public string Author { get; set; }
		public string PublishingCity { get; set; }
		public string PublisherName { get; set; }
		public int PublishingYear { get; set; }
		protected int PageCount { get; set; }
		public string Notes { get; set; }
		public string ISBN { get; set; }

		public Book(string name, string author, string publishingCity, string publisherName, int publishingYear, int pageCount, string notes, string isbn)
		{
			Name = name;
			Author = author;
			PublishingCity = publishingCity;
			PublisherName = publisherName;
			PublishingYear = publishingYear;
			PageCount = pageCount;
			Notes = notes;
			ISBN = isbn;
		}

		public Book()
		{
			
		}
	}
}
