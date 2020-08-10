using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MaxConsecutiveZero
    {
        static int maxZeros(int N)
        {
            // variable to store the length  
            // of longest consecutive 0's  
            int maxm = -1;

            // to temporary store the  
            // consecutive 0's  
            int cnt = 0;

            while (N != 0)
            {
                if ((N & 1) == 0)
                {
                    cnt++;
                    maxm = Math.Max(maxm, cnt);
                }
                else
                {
                    maxm = Math.Max(maxm, cnt);
                    cnt = 0;
                }
                N >>= 1;
            }
            return maxm;
        }

        // Driver code 
        public static void Main()
        {
            int N = 189;
            Console.WriteLine(maxZeros(N));
        }
    }
}
