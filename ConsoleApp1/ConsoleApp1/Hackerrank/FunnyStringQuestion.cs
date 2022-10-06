﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     In this challenge, you will determine whether a string is funny or not. 
    To determine whether a string is funny, create a copy of the string in reverse e.g. abc->cba . 
    Iterating through each string, compare the absolute difference in the ascii values of the characters at positions 0 and 1, 1 and 2 and so on to the end. If the list of absolute differences is the same for both strings, they are funny.

Determine whether a give string is funny. If it is, return Funny, otherwise return Not Funny.
    */
    public class FunnyStringQuestion
    {
        static void Main(string[] args)
        {
            var o = Funny("lmnop");
            Console.WriteLine(o);
        }
        static bool Funny(string s)
        {
            string rev = ReverseStr(s);
            for (int i = 1; i < s.Length; i++)
                if (Math.Abs(s[i] - s[i - 1]) != Math.Abs(rev[i] - rev[i - 1]))
                    return false;
            return true;
        }
        private static String ReverseStr(String input)
        {
            char[] a = input.ToCharArray();
            int l, r = 0;
            r = a.Length - 1;

            for (l = 0; l < r; l++, r--)
            {
                // Swap values of l and r  
                char temp = a[l];
                a[l] = a[r];
                a[r] = temp;
            }
            return String.Join("", a);
        }
    }
}
