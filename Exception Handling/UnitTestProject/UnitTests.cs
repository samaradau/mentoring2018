using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
	[TestClass]
	public class UnitTests
	{
		[TestMethod]
		public void Parse_PositiveString_Integer()
		{
			var str1 = "2147483647";
			var str2 = "+2147483647";
			var expected = 2147483647;
			Int32Parser parser = new Int32Parser();

			var actual1 = parser.Parse(str1);
			var actual2 = parser.Parse(str2);

			Assert.IsTrue(expected == actual1);
			Assert.IsTrue(expected == actual2);
		}

		[TestMethod]
		public void Parse_NegativeString_NegativeInteger()
		{
			var str = "-2147483648";
			var expected = -2147483648;
			Int32Parser parser = new Int32Parser();

			var actual = parser.Parse(str);

			Assert.IsTrue(expected == actual);
		}

		[TestMethod]
		public void Parse_NullString_ThrowsArgumentNullException()
		{
			string str = null;
			Int32Parser parser = new Int32Parser();

			Assert.ThrowsException<ArgumentNullException>(() =>
			{
				var actual = parser.Parse(str);
			});
		}

		[TestMethod]
		public void Parse_EmptyString_ThrowsArgumentNullException()
		{
			string str = String.Empty;
			Int32Parser parser = new Int32Parser();

			Assert.ThrowsException<ArgumentNullException>(() =>
			{
				var actual = parser.Parse(str);
			});
		}

		[TestMethod]
		public void Parse_OverflownRangPositiveString_ThrowsOverflowException()
		{
			string str = "3213215644654321";
			Int32Parser parser = new Int32Parser();

			Assert.ThrowsException<OverflowException>(() =>
			{
				var actual = parser.Parse(str);
			});
		}

		[TestMethod]
		public void Parse_OverflownPositiveString_ThrowsOverflowException()
		{
			string str = "2147483648";
			Int32Parser parser = new Int32Parser();

			Assert.ThrowsException<OverflowException>(() =>
			{
				var actual = parser.Parse(str);
			});
		}


		[TestMethod]
		public void Parse_OverflownNegativeString_ThrowsOverflowException()
		{
			string str = "-2147483649";
			Int32Parser parser = new Int32Parser();

			Assert.ThrowsException<OverflowException>(() =>
			{
				var actual = parser.Parse(str);
			});
		}

		[TestMethod]
		public void Parse_InconsistentialData_ThrowsOverflowException()
		{
			string str = "123k1234";
			Int32Parser parser = new Int32Parser();

			Assert.ThrowsException<NotFiniteNumberException>(() =>
			{
				var actual = parser.Parse(str);
			});
		}
	}
}
