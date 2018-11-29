using DependencyInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
	public class Flat
	{
		[Injectable]
		public IAnimal Animal { get; set; }

		public void SoundsLike()
		{
			Animal.Say();
		}
	}
}
