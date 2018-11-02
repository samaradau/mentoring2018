using System;

namespace ClassLibrary
{
	/// <summary>
	/// Represents an Int32 Parser.
	/// </summary>
	public class Int32Parser
	{
		/// <summary>
		/// Convert string to Int32
		/// </summary>
		/// <param name="str">String number.</param>
		/// <returns>Int32 result</returns>
		/// <exception cref="ArgumentNullException">Whether the argument is null or empty.</exception>
		/// <exception cref="OverflowException">Whether the requested convertion overflows min or max size of the Int32.</exception>
		/// <exception cref="NotFiniteNumberException">Whether the string number is not consistent.</exception>
		public int Parse(string str)
		{
			if (String.IsNullOrWhiteSpace(str))
			{
				throw new ArgumentNullException();
			}

			bool isNegative = false;

			if (str[0] == '-')
			{
				isNegative = true;
				str = str.Remove(0, 1);
			}

			if (str[0] == '+')
			{
				str = str.Remove(0, 1);
			}

			var rang = str.Length;

			if (rang > 10)
			{
				throw new OverflowException();
			}

			long result = 0;
			int currentRang = 0;
			for (int i = str.Length-1; i >= 0; i--)
			{
				var digit = GetDigit(str[i]);
				if (digit != -1)
				{
					result += digit * (int)Math.Pow((double)10, currentRang);
					if (result > Int32.MaxValue || result * -1 < Int32.MinValue)
					{
						throw new OverflowException();
					}
					currentRang++;
				}
				else
				{
					throw new FormatException();
				}
			}

			if (isNegative)
			{
				result *= -1;
			}

			return (int)result;
		}

		private int GetDigit(char s)
		{
			switch (s)
			{
				case '0':
					{
						return 0;
					}
				case '1':
					{
						return 1;
					}
				case '2':
					{
						return 2;
					}
				case '3':
					{
						return 3;
					}
				case '4':
					{
						return 4;
					}
				case '5':
					{
						return 5;
					}
				case '6':
					{
						return 6;
					}
				case '7':
					{
						return 7;
					}
				case '8':
					{
						return 8;
					}
				case '9':
					{
						return 9;
					}
				default:
					{
						return -1;
					}
			}
		}
	}
}
