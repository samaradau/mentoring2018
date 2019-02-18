using ConsoleApp.Models;
using DependencyInjector;
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
			var IoC = new Container();
			IoC.Register<IAnimal, Cat>();

			// Bind by property
			var flat = (Flat)IoC.Resolve(typeof(Flat));
			// Bind by ctor
			var house = (House)IoC.Resolve(typeof(House));

			flat.SoundsLike();
			house.SoundsLike();

			Console.ReadKey();
		}
	}
}
