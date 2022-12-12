using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    https://www.geeksforgeeks.org/find-three-element-from-given-three-arrays-such-that-their-sum-is-x-set-2/
     Find three element from given three arrays such that their sum is X | Set 2
    Given three sorted integer arrays A[], B[] and C[], the task is to find three integers, one from each array such that they sum up to a given target value X. Print Yes or No depending on whether such triplet exists or not.
Examples: 
 

Input: A[] = {2}, B[] = {1, 6, 7}, C[] = {4, 5}, X = 12 
Output: Yes 
A[0] + B[1] + C[0] = 2 + 6 + 4 = 12
Input: A[] = {2}, B[] = {1, 6, 7}, C[] = {4, 5}, X = 14 
Output: Yes 
A[0] + B[2] + C[1] = 2 + 7 + 5 = 14 

    Approach: We have already discusses a hash based approach in this article which takes O(N) extra space. 
In this article, we will solve this problem using space efficient method that takes O(1) extra space. The idea is using two pointer technique. 
We will iterate through the smallest of all the arrays and for each index i, we will use two-pointer on the larger two arrays to find a pair with sum equal to X – A[i] (assuming A[] is the smallest in length among the three arryas). 
Now, what is the idea behind using two pointer on larger two arrays? We will try to understand the same from an example. 

Let’s assume 
len(A) = 100000 
len(B) = 10000 
len(C) = 10
Case 1: Applying two pointer on larger two arrays 
Number of iterations will be of order = len(C) * (len(A) + len(B)) = 10 * (110000) = 1100000
Case 2: Applying two pointer on smaller two arrays 
Number of iterations will be of order = len(A) * (len(B) + len(C)) = 100000 * (10010) = 1001000000
Case 3: Applying two pointer on smallest and largest array 
Number of iterations will be of order = len(B) * (len(A) + len(C)) = 10000 * (100000 + 10) = 1000100000
As we can see, Case 1 is the most optimal for this example and it can be easily proved that its most optimal in general as well. 
 

Algorithm: 
 

Sort the arrays in increasing order of there lengths.
Let’s say the smallest array after sorting is A[]. Then, iterate through all the elements of A[] and for each index ‘i’, apply two-pointer on the other two arrays. We will put a pointer on the beginning of array B[] and a pointer to end of array C[]. Let’s call the pointer ‘j’ and ‘k’ respectively. 
If B[j] + C[k] = X – A[i], we found a match.
If B[j] + C[k] less than X – A[i], we increase value of ‘j’ by 1.
If B[j] + C[k] greater than X – A[i], we decrease value of ‘k’ by 1.
Below is the implementation of the above approach: 
     */
    public class TripletSumThreeArray
    {

        // Function that returns true if there
        // exists a triplet with sum x
        static bool existsTriplet(int[] a, int[] b,
                                  int[] c, int x, int l1,
                                  int l2, int l3)
        {
            // Sorting arrays such that a[]
            // represents smallest array
            if (l2 <= l1 && l2 <= l3)
            {
                swap(l2, l1);
                swap(a, b);
            }
            else if (l3 <= l1 && l3 <= l2)
            {
                swap(l3, l1);
                swap(a, c);
            }

            // Iterating the smallest array
            for (int i = 0; i < l1; i++)
            {

                // Two pointers on second and third array
                int j = 0, k = l3 - 1;
                while (j < l2 && k >= 0)
                {

                    // If a valid triplet is found
                    if (a[i] + b[j] + c[k] == x)
                        return true;
                    if (a[i] + b[j] + c[k] < x)
                        j++;
                    else
                        k--;
                }
            }
            return false;
        }

        private static void swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        private static void swap(int[] x, int[] y)
        {
            int[] temp = x;
            x = y;
            y = temp;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int[] a = { 2, 7, 8, 10, 15 };
            int[] b = { 1, 6, 7, 8 };
            int[] c = { 4, 5, 5 };
            int l1 = a.Length;
            int l2 = b.Length;
            int l3 = c.Length;

            int x = 14;

            if (existsTriplet(a, b, c, x, l1, l2, l3))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            /*
             Output: Yes

Time complexity: O(min(len(A), len(B), len(C)) * max(len(A), len(B), len(C)))
Auxiliary Space: O(1),  since no extra space has been taken.
            */
        }
    }
}
