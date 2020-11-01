using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class AlternatingChar
    {
        /*
        AABAAB=ABAB=2
        AAAA=A=3
        AABAA=AB=3
        ABAB=ABAB=0
         */
        public static int AlternatingCount(string s)
        {
            int count = 0;
            for (int i = 1; i <= s.Length - 1; i++)
            {
                if (s[i - 1] == s[i])
                    count++;
            }
            return count;
        }
        public static void Main(string[] args)
        {
            int counter = AlternatingCount("AAAAAA");
            Console.WriteLine(counter);
        }
    }
}
