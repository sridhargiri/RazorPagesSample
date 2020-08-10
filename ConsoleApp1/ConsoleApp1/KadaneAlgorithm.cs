﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class KadaneAlgorithm
    {
        static int maxSubArraySum(int[] a)
        {
            int size = a.Length;
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here = max_ending_here + a[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }

        // Drive code  
        public static void Main()
        {
            int[] a = { -2, -3, 4, -1, -2, 1, 5, -3 };
            //int[] a =  { 1, 4, 2, 10, 2, 3, 1, 0, 20 };
            Console.Write("Maximum contiguous sum is " +
                                    maxSubArraySum(a));
        }

    }
}
