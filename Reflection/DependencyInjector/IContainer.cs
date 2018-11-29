using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjector.Interfaces
{
	public interface IContainer
	{
		void Register<TFrom, TTo>() where TTo : TFrom;
		object Resolve(Type fromType);
	}
}
