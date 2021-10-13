using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/frequent-element-array/
    Most frequent element in an array
Difficulty Level : Easy
Last Updated : 21 Sep, 2021
Given an array, find the most frequent element in it. If there are multiple elements that appear a maximum number of times, print any one of them.

Examples: 
Input : arr[] = {1, 3, 2, 1, 4, 1}
Output : 1
1 appears three times in array which
is maximum frequency.

Input : arr[] = {10, 20, 10, 20, 30, 20, 20}
Output : 20
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
     */
    class MostFrequent
    {
        /*
A simple solution is to run two loops. The outer loop picks all elements one by one. The inner loop finds the frequency of the picked element and compares it with the maximum so far. The time complexity of this solution is O(n2)
         
         */
        static int mostFrequent1(int[] arr, int n)
        {

            // Sort the array
            Array.Sort(arr);

            // find the max frequency using
            // linear traversal
            int max_count = 1, res = arr[0];
            int curr_count = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[i - 1])
                    curr_count++;
                else
                {
                    if (curr_count > max_count)
                    {
                        max_count = curr_count;
                        res = arr[i - 1];
                    }
                    curr_count = 1;
                }
            }

            // If last element is most frequent
            if (curr_count > max_count)
            {
                max_count = curr_count;
                res = arr[n - 1];
            }

            return res;
            /*
             Output
1
Time Complexity: O(n Log n) 
Auxiliary Space: O(1)
            */
        }
        /*
         An efficient solution is to use hashing. We create a hash table and store elements and their frequency counts as key-value pairs. Finally, we traverse the hash table and print the key with the maximum value.  
        */

        static int mostFrequent2(int[] arr,
                                int n)
        {
            // Insert all elements in hash
            Dictionary<int, int> hp =
                        new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int key = arr[i];
                if (hp.ContainsKey(key))
                {
                    int freq = hp[key];
                    freq++;
                    hp[key] = freq;
                }
                else
                    hp.Add(key, 1);
            }

            // find max frequency.
            int min_count = 0, res = -1;

            foreach (KeyValuePair<int,
                        int> pair in hp)
            {
                if (min_count < pair.Value)
                {
                    res = pair.Key;
                    min_count = pair.Value;
                }
            }
            return res;
            /*
             Output
1
Time Complexity : O(n) 
Auxiliary Space : O(n)
            */
        }
        /*
         An efficient solution of this problem can be to solve this problem by Moore’s voting Algorithm.

NOTE: THE ABOVE VOTING ALGORITHM ONLY WORKS WHEN THE MAXIMUM OCCURRING ELEMENT IS MORE THAN (SIZEOFARRAY/2) TIMES;

In this method, we will find the maximum occurred integer by counting the votes a number has.
        */

        static int maxFreq(int[] arr, int n)
        {

            // using moore's voting algorithm
            int res = 0;
            int count = 1;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[res])
                {
                    count++;
                }
                else
                {
                    count--;
                }

                if (count == 0)
                {
                    res = i;
                    count = 1;
                }

            }

            return arr[res];

            /*
             Output
Element 30 occurs 3 times
Time Complexity : O(n)
Space Complexity : O(1)
            */
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] arr = { 40, 50, 30, 40, 50, 30, 30 };
            int n = arr.Length;
            int freq = maxFreq(arr, n);
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] == freq)
                {
                    count++;
                }
            }
            Console.Write("Element " + maxFreq(arr, n) + " occurs " + count + " times");
        }
    }
}
