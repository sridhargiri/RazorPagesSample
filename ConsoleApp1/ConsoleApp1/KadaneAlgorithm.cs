using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class KadaneAlgorithm
    {
        /// <summary>
        /// Explanation: Simple idea of the Kadane’s algorithm is to look for all positive contiguous segments of the array(max_ending_here is used for this). 
        /// And keep track of maximum sum contiguous segment among all positive segments(max_so_far is used for this). 
        /// Each time we get a positive sum compare it with max_so_far and update max_so_far if it is greater than max_so_far
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
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


        // Utility functions to get minimum of two integers 
        static int min(int x, int y) { return x < y ? x : y; }

        // Utility functions to get maximum of two integers 
        static int max(int x, int y) { return x > y ? x : y; }

        /* Returns the product of max product subarray. 
        Assumes that the given array always has a subarray 
        with product more than 1 */
        /*
         * 
         The following solution assumes that the given input array always has a positive output. The solution works for all cases mentioned above. It doesn’t work for arrays like {0, 0, -20, 0}, {0, 0, 0}.. etc. The solution can be easily modified to handle this case.
It is similar to Largest Sum Contiguous Subarray problem. The only thing to note here is, maximum product can also be obtained by minimum (negative) product ending with the previous element multiplied by this element.
        For example, in array {12, 2, -3, -5, -6, -2}, when we are at element -2, the maximum product is multiplication of, minimum product ending with -6 and -2
         */
        static int maxSubarrayProduct(int[] arr)
        {
            int n = arr.Length;
            // max positive product ending at the current 
            // position 
            int max_ending_here = 1;

            // min negative product ending at the current 
            // position 
            int min_ending_here = 1;

            // Initialize overall max product 
            int max_so_far = 1;
            int flag = 0;

            /* Traverse through the array. Following 
            values are maintained after the ith iteration: 
            max_ending_here is always 1 or some positive 
            product ending with arr[i] min_ending_here is 
            always 1 or some negative product ending  
            with arr[i] */
            for (int i = 0; i < n; i++)
            {
                /* If this element is positive, update  
                max_ending_here. Update min_ending_here  
                only if min_ending_here is negative */
                if (arr[i] > 0)
                {
                    max_ending_here = max_ending_here * arr[i];
                    min_ending_here = min(min_ending_here
                                              * arr[i],
                                          1);
                    flag = 1;
                }

                /* If this element is 0, then the maximum  
                product cannot end here, make both  
                max_ending_here and min_ending_here 0 
                Assumption: Output is alway greater than or 
                equal to 1. */
                else if (arr[i] == 0)
                {
                    max_ending_here = 1;
                    min_ending_here = 1;
                }

                /* If element is negative. This is tricky 
                max_ending_here can either be 1 or positive. 
                min_ending_here can either be 1 or negative. 
                next min_ending_here will always be prev. 
                max_ending_here * arr[i] 
                next max_ending_here will be 1 if prev 
                min_ending_here is 1, otherwise 
                next max_ending_here will be  
                prev min_ending_here * arr[i] */
                else
                {
                    int temp = max_ending_here;
                    max_ending_here = max(min_ending_here
                                              * arr[i],
                                          1);
                    min_ending_here = temp * arr[i];
                }

                // update max_so_far, if needed 
                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;
            }

            if (flag == 0 && max_so_far == 1)
                return 0;

            return max_so_far;
        }
        // Drive code  
        public static void Main()
        {
            int[] a = { -2, -3, 4, -1, -2, 1, 5, -3 };
            //int[] a =  { 1, 4, 2, 10, 2, 3, 1, 0, 20 };
            Console.Write("Maximum contiguous sum is " +
                                    maxSubArraySum(a));
            int[] arr = { 1, -2, -3, 0, 7, -8, -2 };

            Console.WriteLine("Maximum Sub array product is "
                              + maxSubarrayProduct(arr));
        }

    }
}
