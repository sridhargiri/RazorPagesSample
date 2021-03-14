using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Find four elements a, b, c and d in an array such that a+b = c+d
Difficulty Level : Medium
 Last Updated : 27 Nov, 2018
Given an array of distinct integers, find if there are two pairs (a, b) and (c, d) such that a+b = c+d, and a, b, c and d are distinct elements. If there are multiple answers, then print any of them.

Example:

Input:   {3, 4, 7, 1, 2, 9, 8}
Output:  (3, 8) and (4, 7)
Explanation: 3+8 = 4+7

Input:   {3, 4, 7, 1, 12, 9};
Output:  (4, 12) and (7, 9)
Explanation: 4+12 = 7+9

Input:  {65, 30, 7, 90, 1, 9, 8};
Output:  No pairs found
Expected Time Complexity: O(n2)

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution.
A Simple Solution is to run four loops to generate all possible quadruples of array element. For every quadruple (a, b, c, d), check if (a+b) = (c+d). Time complexity of this solution is O(n4).

An Efficient Solution can solve this problem in O(n2) time. The idea is to use hashing. We use sum as key and pair as value in hash table.




Loop i = 0 to n-1 :
    Loop j = i + 1 to n-1 :
        calculate sum
        If in hash table any index already exist
            Then print (i, j) and previous pair 
            from hash table  
        Else update hash table
    EndLoop;
EndLoop;
Below are implementations of above idea. In below implementation, map is used instead of hash. Time complexity of map insert and search is actually O(Log n) instead of O(1). So below implementation is O(n2 Log n).
    */
    class FourElements
    {
        // Class to represent a pair  
        public class pair
        {
            private readonly FourElements outerInstance;

            public int first, second;
            public pair(FourElements outerInstance, int f, int s)
            {
                this.outerInstance = outerInstance;
                first = f;
                second = s;
            }
            public pair(int f, int s)
            {
                first = f;
                second = s;
            }
        }

        public virtual bool findPairs_sum(int[] arr)
        {
            // Create an empty Hash to store mapping from sum to  
            // pair indexes  
            Dictionary<int, pair> map = new Dictionary<int, pair>();
            int n = arr.Length;

            // Traverse through all possible pairs of arr[]  
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    // If sum of current pair is not in hash,  
                    // then store it and continue to next pair  
                    int sum = arr[i] + arr[j];
                    if (!map.ContainsKey(sum))
                    {
                        map[sum] = new pair(this, i, j);
                    }

                    else // Else (Sum already present in hash) 
                    {
                        // Find previous pair  
                        pair p = map[sum];

                        // Since array elements are distinct, we don't  
                        // need to check if any element is common among pairs  
                        Console.WriteLine("(" + arr[p.first] + ", " + arr[p.second] + ") and (" + arr[i] + ", " + arr[j] + ")");
                        return true;
                    }
                }
            }
            return false;
        }
        /*
         Find all pairs (a,b) and (c,d) in array which satisfy ab = cd
Difficulty Level : Easy
 Last Updated : 21 May, 2019
Given an array of distinct integers, the task is to find two pairs (a, b) and (c, d) such that ab = cd, where a, b, c and d are distinct elements.

Examples:

Input  : arr[] = {3, 4, 7, 1, 2, 9, 8}
Output : 4 2 and 1 8
Product of 4 and 2 is 8 and 
also product of 1 and 8 is 8 .

Input  : arr[] = {1, 6, 3, 9, 2, 10};
Output : 6 3 and 9 2
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
A Simple Solution is to run four loops to generate all possible quadruples of array element. For every quadruple (a, b, c, d), check if a*b = c*d. Time complexity of this solution is O(n4).

An Efficient Solution of this problem is to use hashing. We use product as key and pair as value in hash table.




1. For i=0 to n-1
2.   For j=i+1 to n-1
       a) Find  prod = arr[i]*arr[j]       
       b) If prod is not available in hash then make 
            H[prod] = make_pair(i, j) // H is hash table
       c) If product is also available in hash 
          then print previous and current elements
          of array 
        */
        public static void findPairs_product(int[] arr, int n)
        {

            bool found = false;
            Dictionary<int, pair> hp =
                        new Dictionary<int, pair>();

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {

                    // If product of pair is not in  
                    // hash table, then store it 
                    int prod = arr[i] * arr[j];

                    if (!hp.ContainsKey(prod))
                        hp.Add(prod, new pair(i, j));

                    // If product of pair is also  
                    // available in then print  
                    // current and previous pair  
                    else
                    {
                        pair p = hp[prod];
                        Console.WriteLine(arr[p.first]
                                + " " + arr[p.second]
                                + " " + "and" + " " +
                                arr[i] + " " + arr[j]);
                        found = true;
                    }
                }
            }

            // If no pair find then print not found 
            if (found == false)
                Console.WriteLine("No pairs Found");
        }
        // Testing program  
        public static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 4, 7, 1, 2, 9, 8 };
            FourElements a = new FourElements();
            a.findPairs_sum(arr);
            /*
             Output:
            (3, 8) and (4, 7)
            Thanks to Gaurav Ahirwar for suggesting above solutions.

            Exercise:
            1) Extend the above solution with duplicates allowed in array.
            2) Further extend the solution to print all quadruples in output instead of just one. And all quadruples should be printed printed in lexicographical order (smaller values before greater ones). Assume we have two solutions S1 and S2.

            S1 : a1 b1 c1 d1 ( these are values of indices int the array )  
            S2 : a2 b2 c2 d2

            S1 is lexicographically smaller than S2 iff
              a1 < a2 OR
              a1 = a2 AND b1 < b2 OR
              a1 = a2 AND b1 = b2 AND c1 < c2 OR 
              a1 = a2 AND b1 = b2 AND c1 = c2 AND d1 < d2 
            See this for solution of exercise.
            http://qa.geeksforgeeks.org/3921/find-index-values-that-satisfy-where-integers-values-array
            */
            arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8};
            findPairs_product(arr, arr.Length);
            /*
             Output:
1 6 and 2 3
1 8 and 2 4
2 6 and 3 4
3 8 and 4 6
Time Complexity : O(n2) assuming hash search and insert operations take O(1) time.
            */
        }
    }
}
