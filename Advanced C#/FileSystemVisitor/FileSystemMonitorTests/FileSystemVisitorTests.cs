using System;
using FileVisitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
	[TestClass]
	public class FileSystemVisitorTests
	{
		[TestMethod]
		public void GetAllDirectoryElements_NullPath_ThrowsException()
		{
			FileSystemVisitor fsv = new FileSystemVisitor();
			string[] files = Array.Empty<string>();
			string[] dirs = Array.Empty<string>();

			Assert.ThrowsException<ArgumentNullException>(() => fsv.GetAllDirectoryElements(null, ref dirs, ref files));
		}

		[TestMethod]
		public void GetAllDirectoryElements_NullFiles_ThrowsException()
		{
			FileSystemVisitor fsv = new FileSystemVisitor();
			string[] files = Array.Empty<string>();
			string[] dirs = Array.Empty<string>();

			Assert.ThrowsException<ArgumentNullException>(() => fsv.GetAllDirectoryElements(null, ref dirs, ref files));
		}

		[TestMethod]
		public void GetAllDirectoryElements_NullDirs_ThrowsException()
		{
			FileSystemVisitor fsv = new FileSystemVisitor();
			string[] files = Array.Empty<string>();
			string[] dirs = Array.Empty<string>();

			Assert.ThrowsException<ArgumentNullException>(() => fsv.GetAllDirectoryElements(null, ref dirs, ref files));
		}


	}
}
