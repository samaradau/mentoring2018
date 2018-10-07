using FileVisitor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonitor
{
	class Program
	{
		static void Main(string[] args)
		{
			FileSystemVisitor visitor = new FileSystemVisitor();
			string[] files = Array.Empty<string>();
			string[] dirs = Array.Empty<string>();

			visitor.GetAllDirectoryElements(@"C:\Users\Yury_Samaradau\Desktop\mentoring2018\Advanced C#", ref dirs, ref files);

			Console.WriteLine("\nDirectories: \n");

			foreach (var el in dirs)
				Console.WriteLine(el);

			Console.WriteLine("\nFiles: \n");

			foreach (var el in files)
				Console.WriteLine(el);

			Console.ReadKey();
		}
	}
}
