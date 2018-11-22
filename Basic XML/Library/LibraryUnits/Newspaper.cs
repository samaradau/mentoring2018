using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library.Units
{
	[Serializable]
	public class Newspaper : IUnit
	{
		public string Name { get; set; }
		public string PublishingCity { get; set; }
		public string PublisherName { get; set; }
		public int PublishingDate { get; set; }
		public int PageCount { get; set; }
		public string Notes { get; set; }
		public int Number { get; set; }
		public DateTime Date { get; set; }
		public string ISSN { get; set; }

		public Newspaper(string name, string publishingCity, string publisherName, int publishingDate, int pageCount, string notes, int number, DateTime date, string issn)
		{
			Name = name;
			PublishingCity = publishingCity;
			PublisherName = publisherName;
			PublishingDate = publishingDate;
			PageCount = pageCount;
			Notes = notes;
			Number = number;
			Date = date;
			ISSN = issn;
		}

		public Newspaper()
		{
			
		}
	}
}
