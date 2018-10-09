using System;
using FileVisitor;

namespace ConsoleMonitor
{
	class Program
	{
		static FileSystemVisitor visitor;

		static void Main(string[] args)
		{
			visitor = new FileSystemVisitor();
			string[] files = Array.Empty<string>();
			string[] dirs = Array.Empty<string>();
			visitor.OnSearchStart += Visitor_OnSearchStart;
			visitor.OnSearchStop += Visitor_OnSearchStop;

			visitor.GetAllDirectoryElements(@"C:\Users\Yury_Samaradau\Desktop\mentoring2018\Introduction to .NET\StandartClassLibrary", ref dirs, ref files);

			Console.WriteLine("\nDirectories: \n");

			foreach (var el in dirs)
				Console.WriteLine(el);

			Console.WriteLine("\nFiles: \n");

			foreach (var el in files)
				Console.WriteLine(el);

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