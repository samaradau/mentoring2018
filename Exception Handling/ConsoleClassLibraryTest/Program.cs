using ClassLibrary;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClassLibraryTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Input the string: ");
			var str = Console.ReadLine();
			int b = 0;
			var parser = new Int32Parser();

			try
			{
				b = parser.Parse(str);
			}
			catch (OverflowException e)
			{
				Console.WriteLine(e.Message);
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine(e.Message);
			}
			catch (FormatException e)
			{
				Console.WriteLine(e.Message);
			}

			Console.WriteLine($"Your number is {b}");

			Console.ReadKey();
		}
	}
}
