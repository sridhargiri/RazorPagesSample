/*
Given an Array Arr, N,S,K which follows that the absolute value of each item does not exceed K
find the minimum number of elements to be added to make the sum of array equal to S

Asked in JLL hackerearth, caught stream input error
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class JLL1
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            int[] a = null; int sum = 0; int diff = 0;
            int[] array = null;
            for (int i = 0; i < T; i++)
            {
                int n = 0, s = 0, k = 0;
                a = Console.ReadLine().Split(' ').Select(n1 => int.Parse(n1)).ToArray();
                n = a[0]; s = a[1]; k = a[2];
                for (int j = 0; j < n; j++)
                {
                    array = Console.ReadLine().Split(' ').Select(n1 => int.Parse(n1)).ToArray();
                    for (int k1 = 0; k1 < array.Length; k1++)
                    {
                        sum += array[k1];
                    }
                    diff = s - sum;
                    int counter = 0; int tempsum = 0;
                    if (diff == 0)
                    {
                        Console.WriteLine(0);
                    }
                    else if (diff == k)
                    {
                        Console.WriteLine(1);
                    }
                    else if (diff > k)
                    {
                        counter = (diff / k)+1;
                        Console.WriteLine(counter);
                    }
                }
            }
        }
    }
}
