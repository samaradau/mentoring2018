using System;
using System.IO;
using System.Reflection.Emit;
using Library.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Test
{
	[TestClass]
	public class LibraryTests
	{
		[TestMethod]
		public void LibraryLoad_ValidPath_LibraryLoaded()
		{
			var expected = new Library();
			expected.Units.Add(new Book("Обломов", "Гончаров И.В.", "Санкт-Петербург", "Новый свет", 1864, 867, "Неплохая книга для досуга", "2135848212"));
			expected.Units.Add(new Newspaper("Вечерний Минск", "Минск", "Белсоюзпечать", 2018, 15, "Белорусский таблойд", 2546, DateTime.Today, "32515454132"));
			expected.Units.Add(new Patent("Двигатель внутреннего сгорания", "Франсуа Исаак де Риваз", "Франция", 1258321, new DateTime(1807, 11, 10), new DateTime(1807, 11, 10), 321, String.Empty));
			string path = "library.xml";

			expected.Unload(path);
			var actual = expected.Load(path);

			Assert.IsTrue(actual.Units.Count == expected.Units.Count);
			Assert.IsTrue(actual.Units[0].GetType() == expected.Units[0].GetType());
		}

		[TestMethod]
		public void LibraryLoadAndUnload_InvalidPath_ThrowsException()
		{
			var expected = new Library();
			string pathNull= null;
			string pathEmpty = String.Empty;
			string pathNonexistance = "somefile.xml";

			Assert.ThrowsException<ArgumentNullException>(() => expected.Load(pathNull));
			Assert.ThrowsException<ArgumentNullException>(() => expected.Load(pathEmpty));
			Assert.ThrowsException<FileNotFoundException>(() => expected.Load(pathNonexistance));
			Assert.ThrowsException<ArgumentNullException>(() => expected.Unload(pathNull));
			Assert.ThrowsException<ArgumentNullException>(() => expected.Unload(pathEmpty));
		}

		[TestMethod]
		public void LibraryLoad_NotValidFileFormat_ReturnsNull()
		{
			var expected = new Library();
			string path = "someLib.xml";

			var actual = expected.Load(path);

			Assert.IsTrue(actual is null);
		}

		[TestMethod]
		public void LibraryUnload_ValidPath_LibraryUnloaded()
		{
			var lib = new Library();
			lib.Units.Add(new Book("Обломов", "Гончаров И.В.", "Санкт-Петербург", "Новый свет", 1864, 867, "Неплохая книга для досуга", "2135848212"));
			lib.Units.Add(new Newspaper("Вечерний Минск", "Минск", "Белсоюзпечать", 2018, 15, "Белорусский таблойд", 2546, DateTime.Today, "32515454132"));
			lib.Units.Add(new Patent("Двигатель внутреннего сгорания", "Франсуа Исаак де Риваз", "Франция", 1258321, new DateTime(1807, 11, 10), new DateTime(1807, 11, 10), 321, String.Empty));
			string path = "library.xml";

			lib.Unload(path);
			var exists = File.Exists(path);
			var containsText = !String.IsNullOrEmpty(File.ReadAllText(path));

			Assert.IsTrue(exists);
			Assert.IsTrue(containsText);
		}
	}
}
