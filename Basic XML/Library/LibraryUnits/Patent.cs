using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library.Units
{
	[Serializable]
	public class Patent : IUnit
	{
		public string Name { get; set; }
		public string Inventor { get; set; }
		public string Country { get; set; }
		public int RegistrationNumber { get; set; }
		public DateTime ApplicationDate { get; set; }
		public DateTime PublishingDate { get; set; }
		public int PageNumber { get; set; }
		public string Notes { get; set; }

		public Patent(string name, string inventor, string country, int registrationNumber, DateTime applicationDate, DateTime publishingDate, int pageNumber, string notes)
		{
			Name = name;
			Inventor = inventor;
			Country = country;
			RegistrationNumber = registrationNumber;
			ApplicationDate = applicationDate;
			PublishingDate = publishingDate;
			PageNumber = pageNumber;
			Notes = notes;
		}

		public Patent()
		{
			
		}
	}
}
