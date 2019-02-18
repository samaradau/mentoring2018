using StandartClassLibrary;
using System;

namespace CoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			DemoClass demoClass = new DemoClass();
            var name = Console.ReadLine();
            Console.WriteLine(demoClass.GetString(name));
			Console.ReadKey();
        }
    }
}
