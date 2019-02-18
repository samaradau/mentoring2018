using System;
using System.IO;
using FileVisitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class FileSystemVisitorTests
	{
		[TestMethod]
		public void GetEnumerator_PathIsNull_ThrowsArgNullException()
		{
			FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(null);

			Assert.ThrowsException<ArgumentNullException>(() =>
			{
				foreach (var item in fileSystemVisitor)
				{
					item.ToString();
				}
			});
		}

		[TestMethod]
		public void GetEnumerator_OnlyPath_AllFiles()
		{
			var path = Directory.GetCurrentDirectory();
			FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(path);
			int counter = 0;

			foreach (var item in fileSystemVisitor)
			{
				counter++;
			}

			Assert.IsTrue(counter > 0);
		}

		[TestMethod]
		public void GetEnumerator_WhithPathAndFilter_AllFiles()
		{
			var path = Directory.GetCurrentDirectory();
			FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(path, x => x.Contains("."));
			int counter = 0;

			foreach (var item in fileSystemVisitor)
			{
				counter++;
			}

			Assert.IsTrue(counter > 0);
		}
	}
}
