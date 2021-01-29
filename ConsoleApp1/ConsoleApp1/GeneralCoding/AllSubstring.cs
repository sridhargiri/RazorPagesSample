using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class AllSubstring
    {
        //O(n3) time

        // Function to print all sub strings
        static void subString(char[] str)
        {
            int n = str.Length;
            // Pick starting point
            for (int len = 1; len <= n; len++)
            {
                // Pick ending point
                for (int i = 0; i <= n - len; i++)
                {
                    //  Print characters from current
                    // starting point to current ending
                    // point.  
                    int j = i + len - 1;
                    for (int k = i; k <= j; k++)
                        Console.Write(str[k]);

                    Console.WriteLine();
                }
            }
        }
        public static void Main(string[] args)
        {
            string ss = "abcd";
            //for (int i = 0; i < ss.Length; i++)
            //{
            //    for (int j = 1; j <= ss.Length - i; j++)
            //    {
            //        Console.WriteLine(ss.Substring(i, j));
            //    }
            //}
            for (int i = 1; i <= ss.Length; i++)
            {
                for (int j = 0; j <= ss.Length - i; j++)
                {
                    Console.WriteLine(ss.Substring(j, i));
                }
            }
            subString(ss.ToCharArray());
        }
    }
}
