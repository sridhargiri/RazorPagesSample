using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class FindPairOfSum
    {
        // Returns number of pairs 
        // in arr[0..n-1] with sum 
        // equal to 'sum' 
        static void printPairs(int[] arr,
                               int n, int sum)
        {
            // int count = 0; 

            // Consider all possible pairs 
            // and check their sums 
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] + arr[j] == sum)
                        Console.Write("(" + arr[i] + ", " + arr[j] + ")" + "\n");
        }
        static void printPairs(int[] arr, int sum)
        {
            HashSet<int> s = new HashSet<int>();
            for (int i = 0; i < arr.Length; ++i)
            {
                int temp = sum - arr[i];
                //check condition
                if (s.Contains(temp))
                {
                    Console.Write("Pair with given sum " + sum + " is (" + arr[i] + ", " + temp + ")");
                }
                s.Add(arr[i]);
            }
        }
        static void printPairs_(int[] arr, int sum)
        {
            for (int i = 0; i < arr.Length; ++i)
            {
                int temp = sum - arr[i];
                //check condition
                if (arr.Contains(temp))
                {
                    Console.Write("Pair with given sum " + sum + " is (" + arr[i] + ", " + temp + ")");
                }
            }
        }

        // Driver Code 
        public static void Main()
        {
            int[] arr = { 8, 7, 2, 5, 3, 1 };// { 1, 5, 7, -1, 5 };
            int n = arr.Length;
            int sum = 10;
            printPairs(arr, n, sum);
            Console.WriteLine("---");
            arr = new int[] { 1, 4, 45,
                              6, 10, 8 };
            sum = 16;
            printPairs(arr, sum);
            Console.WriteLine("---");
            printPairs_(arr, sum);
            Console.WriteLine("---");
        }
    }
}
