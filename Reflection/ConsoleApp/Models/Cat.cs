using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
	public class Cat : IAnimal
	{
		public void Say()
		{
			Console.WriteLine("Mew! Mew! Mew!\n");
		}
	}
}
