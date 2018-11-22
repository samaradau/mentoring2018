using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Units;

namespace Library
{
	public class Library : IEnumerable<IUnit>
	{
		public List<IUnit> Units { get; set; }

		public Library()
		{
			Units = new List<IUnit>();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Units.GetEnumerator();
		}

		public IEnumerator<IUnit> GetEnumerator()
		{
			return Units.GetEnumerator();
		}
	}

}
