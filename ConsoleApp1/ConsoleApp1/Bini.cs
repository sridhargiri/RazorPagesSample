using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Bini
    {///Need one extra array for result, need to traverse full array.  
        public static string stringReverseString1(string str)
        {
            char[] chars = str.ToCharArray();
            char[] result = new char[chars.Length];
            for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
            {
                result[i] = chars[j];
            }
            return new string(result);
        }
        public static string DecToBin(ulong n)
        {
            int i = 0; if (n == 0)
            {
                return "0";
            }
            string bin = string.Empty;
            for (i = 0; n > 0; i++)
            {
                bin += (n % 2).ToString();
                n = n / 2;
            }
            return stringReverseString1(bin);
        }
        static void Main()
        {
            int T = int.Parse(Console.ReadLine());
            for (int k = 0; k < T; k++)
            {
                ulong number = Convert.ToUInt64(Console.ReadLine());
                string str = DecToBin(number);
                List<string> oddzero = new List<string>();
                List<string> oddone = new List<string>();
                int Zero = 0, One = 0;
                //str.ToCharArray().Count(t=>t==49); 48->0 and 49->1    oddzero.Where(st=>st.Count(t=>t=='1')%2!=0)
                for (int i = 1; i < str.Length; i++)
                {
                    for (int start = 0; start <= str.Length - i; start++)
                    {
                        string substr = str.Substring(start, i);
                        oddzero.Add(substr);
                        //if (substr.Count(t => t == 48) % 2 != 0) Zero++;
                        //if (substr.Count(t => t == 49) % 2 != 0)
                        //{
                        //    One++;
                        //}
                    }
                }
                oddzero.Add(str);
                Zero = oddzero.Where(st => st.Count(t => t == '0') % 2 != 0).Count();
                One = oddzero.Where(st => st.Count(t => t == '1') % 2 != 0).Count();
                Console.WriteLine(Zero + " " + One);
            }
            //Console.ReadLine();
        }
    }
}
