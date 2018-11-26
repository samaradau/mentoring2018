using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Library;
using Library.Units;

namespace Library
{
	class Program
	{
		static void Main(string[] args)
		{
			var lib = new Library();
			lib.Units.Add(new Book("Обломов", "Гончаров И.В.", "Санкт-Петербург", "Новый свет", 1864, 867, "Неплохая книга для досуга", "2135848212"));
			lib.Units.Add(new Newspaper("Вечерний Минск", "Минск", "Белсоюзпечать", 2018, 15, "Белорусский таблойд", 2546, DateTime.Today, "32515454132"));
			lib.Units.Add(new Patent("Двигатель внутреннего сгорания", "Франсуа Исаак де Риваз", "Франция", 1258321, new DateTime(1807, 11, 10), new DateTime(1807, 11, 10), 321, String.Empty));
			lib.UnloadDate = DateTime.Now;

			using (StreamWriter sw = new StreamWriter("lib.xml"))
			{
				XmlSerializer x = new XmlSerializer(typeof(Library), new Type[] {typeof(Book), typeof(Newspaper), typeof(Patent)});
				
				x.Serialize(sw, lib);
			}
		}
	}
}
