using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    delegate string del(string str);
    class DelSample
    {
        public static string DelegateSample(string a)
        {
            return a.Replace(',', '*');
        }
    }
    public class InterviewProgram
    {
        public static void Main(string[] args)
        {
            del str1 = new del(DelSample.DelegateSample);
            str1 += a => { return a.Replace(',', '-'); };
            string str = str1("Welcome,,friends,,to,,TechBeamers");
            Console.WriteLine(str);
        }
    }
    public class WhatIstheOutput
    {
        public static void Main(string[] args)
        {
            int n = 5;
            int x = 4;
            int z, c, k;
            z = 3 * x * x + 2 * x + 4 / x + 8;
            for (c = 1; c <= n; c++)
            {
                for (k = 1; k <= c; k++)
                {
                    Console.Write(Convert.ToString(Convert.ToChar(z)));
                    z++;
                }
                Console.WriteLine();
            }
        }
    }
}
