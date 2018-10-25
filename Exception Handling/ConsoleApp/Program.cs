using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var quit = false;

			while (!quit)
			{
				var str = Console.ReadLine();
				if (str != "quit")
				{
					if (!String.IsNullOrWhiteSpace(str))
					{
						Console.WriteLine(str[0]);
					}
				}
				else
				{
					quit = true;
				}
			}
		}
	}
}
