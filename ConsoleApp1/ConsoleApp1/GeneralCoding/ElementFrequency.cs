using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     Counting frequencies of array elements
    Given an array which may contain duplicates, print all elements and their frequencies.

Examples: 

Input :  arr[] = {10, 20, 20, 10, 10, 20, 5, 20}
Output : 10 3
         20 4
         5  1

Input : arr[] = {10, 20, 20}
Output : 10 1
         20 2 
A simple solution is to run two loops. For every item count number of times, it occurs. To avoid duplicate printing, keep track of processed items. 
     */
    public class ElementFrequency
    {
        public static void countFreq(int[] arr, int n)
        {
            bool[] visited = new bool[n];

            // Traverse through array elements and
            // count frequencies
            for (int i = 0; i < n; i++)
            {

                // Skip this element if already processed
                if (visited[i] == true)
                    continue;

                // Count frequency
                int count = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        visited[j] = true;
                        count++;
                    }
                }
                Console.WriteLine(arr[i] + " " + count);
            }
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] arr = new int[] { 10, 20, 20, 10, 10, 20, 5, 20 };
            int n = arr.Length;
            countFreq(arr, n);
            /*
             Output
10 3
20 4
5 1
Time Complexity : O(n2) 
Auxiliary Space : O(n)
            */
        }
    }

    //An efficient solution is to use hashing
    public class ElementFrequencyHashing
    {

        static void countFreq(int[] arr, int n)
        {
            Dictionary<int, int> mp = new Dictionary<int, int>();

            // Traverse through array elements and
            // count frequencies
            for (int i = 0; i < n; i++)
            {
                if (mp.ContainsKey(arr[i]))
                {
                    var val = mp[arr[i]];
                    mp.Remove(arr[i]);
                    mp.Add(arr[i], val + 1);
                }
                else
                {
                    mp.Add(arr[i], 1);
                }
            }

            // Traverse through map and print frequencies
            foreach (KeyValuePair<int, int> entry in mp)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] arr = { 10, 20, 20, 10, 10, 20, 5, 20 };
            int n = arr.Length;
            countFreq(arr, n);
            /*
             Output
5 1
10 3
20 4
            Time Complexity : O(n) 
Auxiliary Space : O(n)
            */
        }
    }

    //Print same prder
    class ElementFrequencySameOrder
    {

        static void countFreq(int[] arr, int n)
        {
            Dictionary<int, int> mp = new Dictionary<int, int>();

            // Traverse through array elements and 
            // count frequencies 

            for (int i = 0; i < n; i++)
            {
                if (mp.ContainsKey(arr[i]))
                {
                    var val = mp[arr[i]];
                    mp.Remove(arr[i]);
                    mp.Add(arr[i], val + 1);
                }
                else
                {
                    mp.Add(arr[i], 1);
                }
            }

            // To print elements according to first 
            // occurrence, traverse array one more time 
            // print frequencies of elements and mark 
            // frequencies as -1 so that same element 
            // is not printed multiple times. 
            for (int i = 0; i < n; i++)
            {
                if (mp.ContainsKey(arr[i]) && mp[arr[i]] != -1)
                {
                    Console.WriteLine(arr[i] + " " + mp[arr[i]]);
                    mp.Remove(arr[i]);
                    mp.Add(arr[i], -1);
                }
            }
        }

        // Driver code 
        public static void Main(String[] args)
        {
            int[] arr = { 10, 20, 20, 10, 10, 20, 5, 20 };
            int n = arr.Length;
            countFreq(arr, n);
            /*
             Output
10 3
20 4
5 1
Time Complexity : O(n) 
Auxiliary Space : O(n)
            */
        }
    }

    public class ElementFrequencyHashmap
    {
        static void frequencyNumber(int[] arr, int size)
        {

            // Creating a Dictionary containing integer
            // as a key and occurrences as a value
            Dictionary<int, int> freqMap = new Dictionary<int, int>();

            for (int i = 0; i < size; i++)
            {
                if (freqMap.ContainsKey(arr[i]))
                {
                    var val = freqMap[arr[i]];
                    freqMap.Remove(arr[i]);
                    freqMap.Add(arr[i], val + 1);
                }
                else
                {
                    freqMap.Add(arr[i], 1);
                }
            }

            // Printing the freqMap
            foreach (KeyValuePair<int, int> entry in freqMap)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }
        }

        public static void Main(String[] args)
        {
            int[] arr = { 10, 20, 20, 10, 10, 20, 5, 20 };
            int size = arr.Length;
            frequencyNumber(arr, size);
            /*
             Output
5 1
10 3
20 4
Time Complexity: O(n) since using a single loop to track frequency
Auxiliary Space: O(n) for hashmap
            */
        }
    }
}
