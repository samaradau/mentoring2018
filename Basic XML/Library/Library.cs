using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Library.Units;

namespace Library
{
	[Serializable]
	[XmlRoot(ElementName = "Library")]
	public class Library : IEnumerable<Item>
	{
		[XmlElement("UnloadDate")]
		public DateTime UnloadDate { get; set; }

		[XmlElement("Items")]
		public List<Item> Units { get; set; }

		public Library()
		{
			Units = new List<Item>();
		}

		public void Add(Item item)
		{
			Units.Add(item);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Units.GetEnumerator();
		}

		public IEnumerator<Item> GetEnumerator()
		{
			return Units.GetEnumerator();
		}
	}

}
