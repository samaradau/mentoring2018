using System;
using FileVisitor;

namespace ConsoleMonitor
{
	class Program
	{
		private static FileSystemVisitor visitor;

		static void Main(string[] args)
		{
			var path = @"C:\Users\Yury_Samaradau\Desktop\mentoring2018\Introduction to .NET\StandartClassLibrary";
			visitor = new FileSystemVisitor(path);

			visitor.OnSearchStart += Visitor_OnSearchStart;
			visitor.OnSearchStop += Visitor_OnSearchStop;
			int counter = 0;
			foreach (var item in visitor)
			{
				counter++;
			}
			Console.WriteLine(counter);
			Console.ReadKey();
		}

		private static void Visitor_OnSearchStop(object sender, EventArgs e)
		{
			Console.WriteLine($"Search stop at { DateTime.UtcNow }");
		}

		private static void Visitor_OnSearchStart(object sender, EventArgs e)
		{
			Console.WriteLine($"Search start at { DateTime.UtcNow }");
		}
	}
}