using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    https://www.geeksforgeeks.org/remove-leading-zeros-from-an-array/
    Given an array of N numbers, the task is to remove all leading zeros from the array. 

Examples: 

Input : arr[] = {0, 0, 0, 1, 2, 3} 
Output : 1 2 3 

Input : arr[] = {0, 0, 0, 1, 0, 2, 3} 
Output : 1 0 2 3 
Approach: Mark the first non-zero number’s index in the given array. 
Store the numbers from that index to the end in a different array. 
Print the array once all numbers have been stored in a different container. 

Below is the implementation of the above approach: 
     */
    public class ArrayRemoveLeadingZero
    {

        // Function to print the array by
        // removing leading zeros
        static void RemoveLeadingZeros(int[] a, int n)
        {

            // index to store the first
            // non-zero number
            int ind = -1;

            // traverse in the array and find the first
            // non-zero number
            for (int i = 0; i < n; i++)
            {
                if (a[i] != 0)
                {
                    ind = i;
                    break;
                }
            }

            // if no non-zero number is there
            if (ind == -1)
            {
                Console.Write("Array has leading zeros only");
                return;
            }

            // Create an array to store
            // numbers apart from leading zeros
            int[] b = new int[n - ind];

            // store the numbers removing leading zeros
            for (int i = 0; i < n - ind; i++)
                b[i] = a[ind + i];

            // print the array
            for (int i = 0; i < n - ind; i++)
                Console.Write(b[i] + " ");
        }

        // Driver Code
        public static void Main(String[] args)
        {
            int[] a = { 0, 0, 0, 1, 2, 0, 3 };
            int n = a.Length;
            RemoveLeadingZeros(a, n);
            /*
Output 1 2 0 3 
Time complexity: O(n) where n is the size of the given array
Auxiliary space: O(n) because extra space for array b is used.
            */
        }
    }
}
