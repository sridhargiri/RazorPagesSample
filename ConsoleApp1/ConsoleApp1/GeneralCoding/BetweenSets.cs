using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Problem
You will be given two arrays of integers and asked to determine all integers that satisfy the following two conditions:

The elements of the first array are all factors of the integer being considered
The integer being considered is a factor of all elements of the second array
These numbers are referred to as being between the two arrays. You must determine how many such numbers exist.

For example, given the arrays a =[2, 6] and b = [24, 36], there are two numbers between them: 6 and 12. 6 % 2 = 0, 6 % 6 = 0, 24 % 6 = 0 and 36 % 6 = 0 for the first value. Similarly, 12 % 2 = 0, 12 % 6 = 0 and 24 % 12 = 0, 36 % 12 = 0.
     */
    class BetweenTwoSets
    {
        static void Main(string[] args)
        {
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();
            l1.Add(2);l1.Add(6); 
            l2.Add(24);l2.Add(36);
            int lcm = getTotalX(l1, l2);
            Console.WriteLine(lcm);
        }
        public static int getTotalX(List<int> a, List<int> b)
        {
            bool var, var2; int i; int j; int m = 0;
            for (i = a[a.Count - 1]; i <= b[0]; i++)
            {
                var = false;
                for (j = 0; j < a.Count; j++)
                {
                    if (i % a[j] == 0)
                    {
                        var = true;
                    }
                    else
                    {
                        var = false;
                        break;
                    }
                }
                if (var == true)
                {
                    var2 = false;
                    for (int k = 0; k < b.Count; k++)
                    {
                        if (b[k] % i == 0)
                        {
                            var2 = true;
                        }
                        else
                        {
                            var2 = false;
                            break;
                        }

                    }
                    if (var2 == true)
                    {
                        m++;
                    }
                }
            }
            return m;
        }
    }
}
