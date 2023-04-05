using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Helper class added by C++ to C# Converter:

    //----------------------------------------------------------------------------------------
    //	Copyright © 2006 - 2023 Tangible Software Solutions, Inc.
    //	This class can be used by anyone provided that the copyright notice remains intact.
    //
    //	This class is used to convert some of the C++ std::vector methods to C#.
    //----------------------------------------------------------------------------------------

    internal static class VectorHelper
    {
        public static void Resize<T>(this List<T> list, int newSize, T value = default(T))
        {
            if (list.Count > newSize)
                list.RemoveRange(newSize, list.Count - newSize);
            else if (list.Count < newSize)
            {
                for (int i = list.Count; i < newSize; i++)
                {
                    list.Add(value);
                }
            }
        }

        public static void Swap<T>(this List<T> list1, List<T> list2)
        {
            List<T> temp = new List<T>(list1);
            list1.Clear();
            list1.AddRange(list2);
            list2.Clear();
            list2.AddRange(temp);
        }

        public static List<T> InitializedList<T>(int size, T value)
        {
            List<T> temp = new List<T>();
            for (int count = 1; count <= size; count++)
            {
                temp.Add(value);
            }

            return temp;
        }

        public static List<List<T>> NestedList<T>(int outerSize, int innerSize)
        {
            List<List<T>> temp = new List<List<T>>();
            for (int count = 1; count <= outerSize; count++)
            {
                temp.Add(new List<T>(innerSize));
            }

            return temp;
        }

        public static List<List<T>> NestedList<T>(int outerSize, int innerSize, T value)
        {
            List<List<T>> temp = new List<List<T>>();
            for (int count = 1; count <= outerSize; count++)
            {
                temp.Add(InitializedList(innerSize, value));
            }

            return temp;
        }
    }
    /*
     https://www.geeksforgeeks.org/replace-in-string-with-zero-or-one/
    Replace ‘?’ in string with zero or one
    Given a binary string consisting of 0s and 1s and ‘?’ characters and an integer K, 
        it is allowed to replace ‘?’ with 0 or 1, the task is to check if there is a unique way of replacing ‘?’ with 0s and 1s such that there is only 1 substring of K length containing all 1s. 
    If there is only one way to do so print “Yes” otherwise “No” in all other cases.
    Note: There should be only 1 possible position of K length substring of all 1s for the answer to be Yes.

Examples:

Input: S = ?1?0, K = 2
Output: No
Explanation: There are two possible ways which satisfies all the conditons, S = 1100, 0110. Hence due to multiple ways the output would be No.

    Input: S = 00?1???10?, K = 5
Output: Yes
Explanation: There is only one possible string S = 0001111100 that have exactly K length substring of all 1s and is the only possible way.

Naive Approach: The basic way to solve the problem is as follows: 

For every K-length substring, we can make that all 1s only if all characters in the substring are ‘1’s or ‘?’s and all other characters outside that substring are all ‘0’s or ‘?’s.
We can check this with brute force for every K-length substring and count the respective number of characters. 

Time complexity: O(|s|K)
Auxiliary Space: O(1)
    Efficient-Approach: To solve the problem follow the below idea:

Moving from Si to Si+K we can keep track of the changes. Now keep count of the number of valid ways. If there is only 1 way, then print “Yes” or else “No”.

Steps that were to follow the above approach: 

Make two prefix arrays sum and tot where sum[i] stores the number of 0s up to index i and tot[i] stores the number of 1s up to index i respectively in string S. 
Now iterate in the range [k, n] where n is the length of string s.
To check if we can make a valid substring, we have to check three conditions: (tot[i – k] == 0 and tot[n] – tot[i] == 0 and sum[i] – sum[i – k] == 0)
Initialize a variable cnt = 0, to store the number of valid substrings.
Whenever we find these three conditions true for a substring increment cnt = cnt + 1. 
Check if cnt == 1 at the end. If cnt == 1, then print “Yes” or else “No”.
Below is the implementation of the above approach:
     */
    public class QuestionMarkReplaceUnique
    {

        private static string QuestionMarkReplaceUniqueWay(string s, int k)
        {

            // Getting size of the string
            int n = s.Length;

            // Initializing prefix arrays
            List<int> sum = VectorHelper.InitializedList(n + 1, 0);
            List<int> tot = VectorHelper.InitializedList(n + 1, 0);

            // Precomputing prefix arrays
            for (int i = 0; i < n; i++)
            {
                sum[i + 1] += sum[i];
                if (s[i] == '0')
                {
                    sum[i + 1]++;
                }
                if (s[i] == '1')
                {
                    tot[i + 1]++;
                }
                tot[i + 1] += tot[i];
            }

            // Initializing cnt to count total
            // number of valid substrings.
            int cnt = 0;
            for (int i = k; i <= n; i++)
            {

                // Condition for a valid substring
                if (tot[i - k] == 0 && tot[n] - tot[i] == 0 && sum[i] - sum[i - k] == 0)
                {

                    // Incrementing cnt to keep
                    // track of valid substrings.
                    cnt++;
                }
            }

            // Returning the answer
            if (cnt == 1)
            {
                return "Yes";
            }
            return "No\n";
        }

        static void Main(string[] args)
        {

            string s = "00?1???10?";
            int k = 5;
            string s1 = QuestionMarkReplaceUniqueWay(s, k);
            Console.WriteLine(s1);
            /*
             Output Yes
Time Complexity: O(|s|)
Auxiliary Space: O(|s|)
            */
        }
    }
}
