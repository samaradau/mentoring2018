using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Library.Units;

namespace Library

{
	/// <summary>
	/// Represents a library class.
	/// </summary>
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

		public void Remove(Item item)
		{
			Units.Remove(item);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Units.GetEnumerator();
		}

		public IEnumerator<Item> GetEnumerator()
		{
			return Units.GetEnumerator();
		}

		/// <summary>
		/// Load library from Stream.
		/// </summary>
		/// <param name="path">Source path.</param>
		/// <returns>Loaded library.</returns>
		public Library Load(string path)
		{
			if (String.IsNullOrEmpty(path))
			{
				throw new ArgumentNullException(nameof(path));	
			}

			Library res;

			try
			{
				using (StreamReader sr = new StreamReader(path))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(Library), new Type[]
					{
						typeof(Book),
						typeof(Newspaper),
						typeof(Patent)
					});
					res = serializer.Deserialize(sr) as Library;
				}
			}
			catch (FileNotFoundException e)
			{
				throw new FileNotFoundException(nameof(path));
			}
			catch (Exception e)
			{
				return null;
			}
				
			return res;
		}

		/// <summary>
		/// Unload library to Stream.
		/// </summary>
		/// <param name="path">Destination path.</param>
		public void Unload(string path)
		{
			if (String.IsNullOrEmpty(path))
			{
				throw new ArgumentNullException(nameof(path));
			}

			UnloadDate = DateTime.Now;

			using (StreamWriter sw = new StreamWriter(path))
			{
				XmlSerializer x = new XmlSerializer(typeof(Library), new Type[]
				{
					typeof(Book),
					typeof(Newspaper),
					typeof(Patent)
				});
				x.Serialize(sw, this);
			}
		}
	}

}
