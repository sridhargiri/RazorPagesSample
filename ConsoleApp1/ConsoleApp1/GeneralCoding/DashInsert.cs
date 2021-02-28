using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class DashInsert
    {
        /**
coderbyte => Have the function DashInsert(str) insert dashes ('-') between each two odd numbers in str.

For example: if str is 454793 the output should be 4547-9-3. Don't count zero as an odd number.

Examples

Input: 99946
Output: 9-9-946

Input: 56730
Output: 567-30
        *
        */
        static string dashInsertBetweenOddNumbers(string str)
        {
            StringBuilder outstr = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] % 2 != 0 && str[i + 1] != 0)
                {
                    outstr.Append(str[i] + "-");
                }
                else
                {
                    outstr.Append(str[i]);
                }
            }
            return outstr.ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine(dashInsertBetweenOddNumbers("99946"));
        }
    }
}
