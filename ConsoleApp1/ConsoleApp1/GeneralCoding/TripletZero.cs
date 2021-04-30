using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class TripleZero
    {
        /*
         * https://www.geeksforgeeks.org/print-all-triplets-with-given-sum/
         Find all triplets with zero sum
Difficulty Level : Medium
 Last Updated : 30 Mar, 2020
Given an array of distinct elements. The task is to find triplets in the array whose sum is zero.

Examples :

Input : arr[] = {0, -1, 2, -3, 1}
Output : (0 -1 1), (2 -3 1)

Explanation : The triplets with zero sum are
0 + -1 + 1 = 0 and 2 + -3 + 1 = 0  

Input : arr[] = {1, -2, 1, 0, 5}
Output : 1 -2  1
Explanation : The triplets with zero sum is
1 + -2 + 1 = 0   

Method 1: This is a simple method that takes O(n3) time to arrive at the result.

Approach: The naive approach run three loops and check one by one that sum of three elements is zero or not.
        If the sum of three elements is zero then print elements otherwise print not found.
Algorithm:
Run three nested loops with loop counter i, j, k
The three loops will run from 0 to n-3 and second loop from i+1 to n-2 and the third loop from j+1 to n-1. The loop counter represents the three elements of the triplet.
check if the sum of elements at i’th, j’th, k’th is equal to zero or not. If yes print the sum else continue.
Implementation:
        */
        static void findTriplets(int[] arr, int n)
        {
            bool found = true;
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (arr[i] + arr[j] + arr[k] == 0)
                        {
                            Console.WriteLine(arr[i] + " "
                                 + arr[j] + " "
                                 + arr[k]);
                            found = true;
                        }
                    }
                }
            }

            // If no triplet with 0 sum found in array 
            if (found == false)
                Console.WriteLine(" not exist ");

        }
        /*
         
         Method 2: The second method uses the process of Hashing to arrive at the result and is solved at a lesser time of O(n2).

Approach: This involves traversing through the array. For every element arr[i], find a pair with sum “-arr[i]”. 
        This problem reduces to pairs sum and can be solved in O(n) time using hashing.
Algorithm:
Create a hashap to store a key value pair.
Run a nested loop with two loops, outer loop from 0 to n-2 and the inner loop from i+1 to n-1
Check if the sum of ith and jth element multiplied with -1 is present in the hashmap or not
If the element is present in the hashmap, print the triplet else insert the j’th element in the hashmap.
        */
        static void findTriplets1(int[] arr, int n)
        {
            bool found = false;

            for (int i = 0; i < n - 1; i++)
            {
                // Find all pairs with sum equals to 
                // "-arr[i]" 
                HashSet<int> s = new HashSet<int>();
                for (int j = i + 1; j < n; j++)
                {
                    int x = -(arr[i] + arr[j]);
                    if (s.Contains(x))
                    {
                        Console.Write("{0} {1} {2}\n", x, arr[i], arr[j]);
                        found = true;
                    }
                    else
                    {
                        s.Add(arr[j]);
                    }
                }
            }

            if (found == false)
            {
                Console.Write(" No Triplet Found\n");
            }
        }
        /*
         Method 3: This method uses the method of Sorting and Two-pointer Technique to solve the above problem. This execution will involve O(n2)) time complexity and O(1) space complexity. The idea is based on Method 2 of this post.
Approach : The two pointer technique can be brought into action using the sorting technique. In two pointer technique one can search for the pair having a target sum in linear time. The idea here is to fix one pointer (say a) and and use the remaining pointers to find the pair having required sum Target-value at(a) efficiently. 
Now let’s discuss how we can find the required pair effectively using two pointer technique. The pointers used for two pointer technique are say (l and r). 
 



So if the sum = value(a) + value(l) + value(r) exceeds the required sum, for same (a, l) the required value(r) should be less than the previous. Thus, decrementing the r pointer. 
 
If the sum = value(a) + value(l) + value(r) is less than the required sum, for same (a, r) the required value(l) should be greater than the previous. Thus, incrementing the l pointer.
Algorithm: 
 

Sort the array and for every element arr[i] search for the other two elements arr[l], arr[r] such that arr[i]+arr[l]+arr[r]=Target sum.
Searching for the other two elements can be done efficiently using Two-pointer technique as the array is sorted.
Run an outer loop taking contol variable as i and for every iteration initialize a value l which is the first pointer with i+1 and r with last index.
Now enter into a while loop which will run till the value of l<r.
If arr[i]+arr[l]+arr[r]>Target sum then decrement r by 1 as the required sum is less than the current sum and decreasing the value of will do the needful.
If arr[i]+arr[l]+arr[r]<Target sum then increment l by 1 as the required sum is less than the current sum and increasing the value of will do the needful.
If arr[i]+arr[l]+arr[r]==Target sum print the values.
Increment i Goto Step 3.
Pseudo Code : 
 

1. Sort all element of array
2. Run loop from i=0 to n-2.
     Initialize two index variables l=i+1 and r=n-1
4. while (l < r) 
     Check sum of arr[i], arr[l], arr[r] is
     given sum or not if sum is 'sum', then print 
     the triplet and do l++ and r--.
5. If sum is less than given sum then l++
6. If sum is greater than given sum then r--
7. If not exist in array then print not found.
        */

        static void findTriplets3(int[] arr,
                                 int n, int sum)
        {
            // sort array elements
            Array.Sort(arr);

            for (int i = 0; i < n - 1; i++)
            {
                // initialize left and right
                int l = i + 1;
                int r = n - 1;
                int x = arr[i];
                while (l < r)
                {
                    if (x + arr[l] + arr[r] == sum)
                    {
                        // print elements if it's
                        // sum is given sum.
                        Console.WriteLine(x + " " + arr[l] + " " + arr[r]);
                        l++;
                        r--;
                    }

                    // If sum of three elements
                    // is less than 'sum' then
                    // increment in left
                    else if (x + arr[l] + arr[r] < sum)
                        l++;

                    // if sum is greater than
                    // given sum, then decrement
                    // in right side
                    else
                        r--;
                }
            }
        }
        public static void Main(String[] args)
        {
            int[] arr = { 0, -1, 2, -3, 1 };
            int n = arr.Length;
            findTriplets(arr, n);
            findTriplets1(arr, n);
            /*
             Output: 
-1 2 1
2 1 -3
 

Complexity Analysis: 
 

Time Complexity: O(n2). 
Use of a nested for loop brings the time complexity to n2.
Auxiliary Space: O(n). 
As an unordered_set data structure has been used for storing values.
            */

            findTriplets3(arr, n, -2);
            /*
             Output: 
-3 -1 2
-3 0 1
 

Complexity Analysis: 
 

Time Complexity: O(n2). 
Use of a nested loop (one for iterating, other for two-pointer technique) brings the time complexity to O(n2).
Auxiliary Space: O(1). 

As no use of additional data structure is used.
            */
        }
    }
}
