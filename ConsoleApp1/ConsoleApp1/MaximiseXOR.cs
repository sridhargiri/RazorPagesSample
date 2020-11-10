using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Complete the maximizingXor function in the editor below. It must return an integer representing the maximum value calculated.maximizingXor has the following parameter(s):

l: an integer, the lower bound, inclusive
r: an integer, the upper bound, inclusive
     */
    class MaximiseXOR
    {
        static int maximizingXor(int l, int r)
        {
            int max = 0; int temp = 0;
            for (int i = l; i <= r; i++)
            {
                for (int j = i; j <= r; j++)
                {
                    temp = i ^ j;
                    if (max < temp)
                        max = temp;
                }
            }
            return max;
        }
        static void Main(string[] args)
        {
            int maxx = maximizingXor(10, 15);
            Console.WriteLine(maxx);
        }
    }
}
