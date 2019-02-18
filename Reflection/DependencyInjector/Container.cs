using DependencyInjector.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjector
{
    public class Container : IContainer
    {
		private Dictionary<Type, Type> _bindings;

		public Container()
		{
			_bindings = new Dictionary<Type, Type>();
		}

		public object Resolve(Type from)
		{
			if (!_bindings.ContainsKey(from))
			{
				return GetInjectedInstance(from);
			}

			var to = _bindings[from];
			return GetInjectedInstance(to);
		}

		private object GetInjectedInstance(Type from)
		{
			object res = null;

			foreach (var constructor in from.GetConstructors())
			{
				var attr = GetConstructorInjectAttribute(constructor);

				if (attr != null)
				{
					var parmValues = GetResolvedParameterValues(constructor);

					if (parmValues.Count > 0)
					{
						res = Activator.CreateInstance(from, parmValues.ToArray());
					}

					break;
				}
			}

			if (res == null)
			{
				res = Activator.CreateInstance(from);
			}

			foreach (var prop in from.GetProperties())
			{
				var attr = GetPropertyInjectAttribute(prop);

				if (attr != null)
				{
					prop.SetValue(res, Resolve(prop.PropertyType), new object[] { });
				}
			}

			return res;
		}

		protected virtual InjectableAttribute GetConstructorInjectAttribute(ConstructorInfo constructor)
		{
			var attrs = constructor.GetCustomAttributes(typeof(InjectableAttribute), true);
			return attrs.OfType<InjectableAttribute>().FirstOrDefault();
		}

		
		protected virtual InjectableAttribute GetPropertyInjectAttribute(PropertyInfo prop)
		{
			var attrs = prop.GetCustomAttributes(typeof(InjectableAttribute), true);
			return attrs.OfType<InjectableAttribute>().FirstOrDefault();
		}

		
		protected virtual List<object> GetResolvedParameterValues(ConstructorInfo constructor)
		{
			var parms = constructor.GetParameters();
			List<object> parmValues = new List<object>();

			foreach (var parm in parms)
			{
				if (parm.ParameterType.IsInterface || parm.ParameterType.IsAbstract)
				{
					Type parmType = parm.ParameterType;
					object parmValue = Resolve(parmType);
					parmValues.Add(parmValue);
				}
				else
				{
					throw new InvalidOperationException();
				}
			}

			return parmValues;
		}

		public void Register<TFrom, TTo>() where TTo : TFrom
		{
			_bindings.Add(typeof(TFrom), typeof(TTo));
		}
	}
}
