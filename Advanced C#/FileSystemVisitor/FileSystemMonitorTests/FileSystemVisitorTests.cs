using System;
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
			var path = @"C:\Users\Yury_Samaradau\Desktop\mentoring2018\Introduction to .NET\StandartClassLibrary";
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
			var path = @"C:\Users\Yury_Samaradau\Desktop\mentoring2018\Introduction to .NET\StandartClassLibrary";
			FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(path, x => x.Contains(".cs"));
			int counter = 0;

			foreach (var item in fileSystemVisitor)
			{
				counter++;
			}

			Assert.IsTrue(counter > 0);
		}
	}
}
