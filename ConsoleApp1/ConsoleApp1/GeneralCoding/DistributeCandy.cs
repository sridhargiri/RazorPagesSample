using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
   https://www.geeksforgeeks.org/distribute-n-candies-among-k-people/
    Distribute N candies among K people - asked in o9 solutions - see image file in files folder
    Given N candies and K people. In the first turn, the first person gets 1 candy, the second gets 2 candies, and so on till K people. In the next turn, the first person gets K+1 candies, the second person gets k+2 candies, and so on. If the number of candies is less than the required number of candies at every turn, then the person receives the remaining number of candies. 
The task is to find the total number of candies every person has at the end.
    Examples: 
 

Input: N = 7, K = 4 
Output: 1 2 3 1 
At the first turn, the fourth people has to be given 4 candies, but there is 
only 1 left, hence he takes one only. 
Input: N = 10, K = 3 
Output: 5 2 3 
At the second turn first one receives 4 and then we have no more candies left.
    A naive approach is to iterate for every turn and distribute candies accordingly till candies are finished. 
Time complexity: O(Number of distributions)
A better approach is to perform every turn in O(1) by calculating sum of natural numbers till the last term of series which will be (turns*k) and subtracting the sum of natural numbers till the last term of previous series which is (turns-1)*k. Keep doing this till the sum is less than N, once it exceeds then distribute candies in the given way till possible. We call a turn completed if every person gets the desired number of candies he is to get in a turn. 
Below is the implementation of the above approach: 
 

    */
    public class DistributeCandy
    {
        // Function to find out the number of
        // candies every person received
        static void distribute_candies(int n, int k)
        {

            // Count number of complete turns
            int count = 0;

            // Get the last term
            int ind = 1;

            // Stores the number of candies
            int[] arr = new int[k];

            for (int i = 0; i < k; i++)
                arr[i] = 0;

            while (n > 0)
            {

                // Last term of last and
                // current series
                int f1 = (ind - 1) * k;
                int f2 = ind * k;

                // Sum of current and last series
                int sum1 = (f1 * (f1 + 1)) / 2;
                int sum2 = (f2 * (f2 + 1)) / 2;

                // Sum of current series only
                int res = sum2 - sum1;

                // If sum of current is less than N
                if (res <= n)
                {
                    count++;
                    n -= res;
                    ind++;
                }
                else // Individually distribute
                {
                    int i = 0;

                    // First term
                    int term = ((ind - 1) * k) + 1;

                    // Distribute candies till there
                    while (n > 0)
                    {

                        // Candies available
                        if (term <= n)
                        {
                            arr[i++] = term;
                            n -= term;
                            term++;
                        }
                        else // Not available
                        {
                            arr[i++] = n;
                            n = 0;
                        }
                    }
                }
            }

            // Count the total candies
            for (int i = 0; i < k; i++)
                arr[i] += (count * (i + 1))
                        + (k * (count * (count - 1)) / 2);

            // Print the total candies
            for (int i = 0; i < k; i++)
                Console.Write(arr[i] + " ");
        }

        // Driver Code
        public static void Main()
        {
            int n = 10, k = 3;
            distribute_candies(n, k);
            /*
             Output: 5 2 3
Time complexity: O(Number of turns + K)
Auxiliary Space: O(k)
            */

        }
    }
    /*
An efficient approach is to find the largest number(say MAXI) whose sum upto natural numbers is less than N using Binary search. Since the last number will always be a multiple of K, we get the last number of complete turns. Subtract the summation till then from N. Distribute the remaining candies by traversing in the array. 
Below is the implementation of the above approach: 
    */
    public class DistributeCandyEfficient
    {
        // Function to find out the number of
        // candies every person received
        static void candies(int n, int k)
        {

            // Count number of complete turns
            int count = 0;

            // Get the last term
            int ind = 1;

            // Stores the number of candies
            int[] arr = new int[k];

            for (int i = 0; i < k; i++)
                arr[i] = 0;


            int low = 0, high = n;

            // Do a binary search to find the number whose
            // sum is less than N.
            while (low <= high)
            {

                // Get mide
                int mid = (low + high) >> 1;
                int sum = (mid * (mid + 1)) >> 1;

                // If sum is below N
                if (sum <= n)
                {

                    // Find number of complete turns
                    count = mid / k;

                    // Right halve
                    low = mid + 1;
                }
                else
                {

                    // Left halve
                    high = mid - 1;
                }
            }

            // Last term of last complete series
            int last = (count * k);

            // Subtract the sum till
            n -= (last * (last + 1)) / 2;

            int j = 0;

            // First term of incomplete series
            int term = (count * k) + 1;

            while (n > 0)
            {
                if (term <= n)
                {
                    arr[j++] = term;
                    n -= term;
                    term++;
                }
                else
                {
                    arr[j] += n;
                    n = 0;
                }
            }

            // Count the total candies
            for (int i = 0; i < k; i++)
                arr[i] += (count * (i + 1))
                    + (k * (count * (count - 1)) / 2);

            // Print the total candies
            for (int i = 0; i < k; i++)
                Console.Write(arr[i] + " ");
        }

        // Driver Code
        public static void Main()
        {
            int n = 7, k = 4;
            candies(n, k);
            /*
             Output: 1 2 3 1
Time Complexity: O(log N + K)
Auxiliary Space: O(K) for given K
            */

        }

    }
}
