using DependencyInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
	public class House
	{
		public IAnimal Animal { get; set; }

		[Injectable]
		public House(IAnimal animal)
		{
			this.Animal = animal;
		}

		public void SoundsLike()
		{
			Animal.Say();
		}
	}
}
