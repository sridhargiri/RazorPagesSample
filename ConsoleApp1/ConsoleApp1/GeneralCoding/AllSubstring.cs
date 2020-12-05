using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class AllSubstring
    {
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
        }
    }
}
