using System;
using FileVisitor;

namespace ConsoleMonitor
{
	class Program
	{
		private static FileSystemVisitor visitor;

		static void Main(string[] args)
		{
			Console.Write("Input the path: ");
			var path = Console.ReadLine();
			visitor = new FileSystemVisitor(path);

			visitor.OnSearchStart += Visitor_OnSearchStart;
			visitor.OnSearchStop += Visitor_OnSearchStop;
			foreach (var item in visitor)
			{
				Console.WriteLine(item);
			}
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