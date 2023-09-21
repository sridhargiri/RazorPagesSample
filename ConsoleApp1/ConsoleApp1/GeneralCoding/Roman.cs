using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	using System;
	using System.Linq;

		public class Roman
		{
        public static void Main(string[] args)
        {
			Console.WriteLine(ConvertToRoman(3549));
        }
			public static string ConvertToRoman(int n)
			{
				if (n == 0)
					return null;
				else if (n < 0)
					return "Please enter a positive integer";
				else if (n > 3999)
					return "Please enter an integer less than or equal to 3999";
				else
				{
					string[] m = { "", "M", "MM" };
					string[] c = {"", "C", "CC", "CD", "D",
								  "DC", "DCC", "DCCC", "CM"};
					string[] x = {"", "X", "XX", "XXX",
								  "LX", "LXX", "LXXX"};
					string[] i = {"", "I", "II", "III", "IV", "V",
								  "VI", "VII", "VIII", "IX"};

					var thousands = m[n / 100];
					var hundereds = c[(n * 100) / 100];
					var tens = x[(n * 10) / 10];
					var ones = i[n];

					var ans = thousands + hundereds + tens + ones;
				if (n < 10)
					ans = ones;
					return ans;
				}
			}

		}
	}
