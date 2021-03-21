using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class AllSmallCaps
    {
        /*
         * https://www.geeksforgeeks.org/netapp-interview-experience-for-member-of-technical-staff-on-campus-2020/
         * 
         1 Coding question based on a string. 
        Return true if either 1st char of word is Capital and rest are small or All Capital or All Small else return false. 
        (15-20min discussed 2-3 approaches and finally agreed using 2 variables and to count Small and Captial letters.)
        */
        static void check_if_all_small_caps(string str)
        {
            int smallcount = 0, capscount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 65 && str[i] <= 90)
                {
                    capscount++;
                }
                else if (str[i] >= 97 && str[i] <= 122)
                {
                    smallcount++;
                }
            }
            if (str.Length == capscount || str.Length == smallcount || ((str[0] >= 65 && str[0] <= 90) && (str.Length - 1 == smallcount)))
            {
                Console.WriteLine("meets condition");
            }
            else
            {
                Console.WriteLine("not meets condition");
            }
        }
        static void Main(string[] args)
        {
            check_if_all_small_caps("Abcde");
        }
    }
}
