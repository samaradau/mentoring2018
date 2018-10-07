using System;

namespace StandartClassLibrary
{
    public class DemoClass
    {
		public string GetString(string name)
		{
			return $"{DateTime.UtcNow.ToString()} Hello, {name}!";
		}
    }
}
