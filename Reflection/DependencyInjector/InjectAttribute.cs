using System;

namespace DependencyInjector
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Constructor)]
	public class InjectableAttribute : Attribute
	{
	}
}