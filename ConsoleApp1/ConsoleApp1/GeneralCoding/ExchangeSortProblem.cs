using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/introduction-to-exchange-sort-algorithm/
    Introduction to Exchange Sort Algorithm
    Exchange sort is an algorithm used to sort in ascending as well as descending order. 
    It compares the first element with every element if any element seems out of order it swaps

Example:

Input: arr[] = {5, 1, 4, 2, 8}
Output: {1, 2, 4, 5, 8}
Explanation: Working of exchange sort:

1st Pass: 
Exchange sort starts with the very first elements, comparing with other elements to check which one is greater.
( 5 1 4 2 8 ) –> ( 1 5 4 2 8 ).
Here, the algorithm compares the first two elements and swaps since 5 > 1. 
No swap since none of the elements is smaller than 1 so after 1st iteration (1 5 4 2 8) 
2nd Pass:
(1 5 4 2 8 ) –>  ( 1 4 5 2 8 ), since 4 < 5
( 1 4 5 2 8 ) –> ( 1 2 5 4 8 ), since 2 < 4
( 1 2 5 4 8 ) No change since in this there is no other element smaller than 2
3rd Pass:
(1 2 5 4 8 ) -> (1 2 4 5 8 ), since 4 < 5
after completion of the iteration, we found array is sorted
After completing the iteration it will come out of the loop, Therefore array is sorted.

     */
    public class ExchangeSortProblem
    {
        /*
         procedure ExchangeSort(num: list of sortable items)
  n = length(A)

  // outer loop
  for i = 1 to n – 2 do

  // inner loop

      for j = i + 1 to n-1 do

           if num[i] > num[j] do

               swap(num[i], num[j])
           end if
       end for
   end for
end procedure

Steps Involved in Implementation for ascending order sorting:

First, we will iterate over the array from arr[1] to n – 2 
in the outer loop to compare every single element with every other element in an array, inner loops will take of comparing that single element in the outer loop with all the other elements in an array. 
The inner loop will start from i + 1st index where i is the index of the outer loop
We compare if the ith element is bigger than the jth element we swap in case of ascending order
To sort in descending order we swap array elements if the jth element is bigger than the ith element 
If there is no case where the condition doesn’t meet that means it is already in desired order so we won’t perform any operations 
Here both if and the inner loop end and so does the outer loop after that we didn’t take the last element in the outer loop since the inner loop’s current index is i+1th so eventually, when the current index of the outer loop is n-2 it will automatically take care of last element due to i+1th index of the inner loop. 
        this case can also be considered a corner case for this algorithm
Below is the code to sort the array into ascending order:
         */
        static void exchangeSortAscending(int[] num)
        {
            int size = num.Count();
            int i, j, temp;
            for (i = 0; i < size - 1; i++)
            {
                // Outer Loop
                for (j = i + 1; j < size; j++)
                {
                    // Inner Loop
                    // Sorting into ascending order if
                    // previous element bigger than next
                    // element we swap to make it in ascending order
                    if (num[i] > num[j])
                    {

                        // Swapping
                        temp = num[i];
                        num[i] = num[j];
                        num[j] = temp;
                    }
                }
            }
        }

        /*
         To sort in Descending order:

procedure ExchangeSort(num: list of sortable items)
n = length(A)

  //outer loop
  for i = 1 to n – 2 do

  //inner loop.

      for j = i + 1 to n-1 do

           if num[i] < num[j] do

               swap(num[i], num[j])
           end if
       end for
   end for
end procedure

Below is the code to sort the array into Descending order:
        */
        static void exchangeSortDescending(int[] num)
        {
            int size = num.Count();
            int i, j, temp;
            for (i = 0; i < size - 1; i++)
            {
                for (j = i + 1; j < size; j++)
                {

                    // Sorting into descending
                    // order when previous element
                    // is smaller than next element
                    if (num[i] < num[j])
                    {

                        // Swapping
                        temp = num[i];
                        num[i] = num[j];
                        num[j] = temp;
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            int[] arr1 = { 5, 1, 4, 2, 8 };
            int[] arr2 = { 5, 1, 4, 2, 8 };
            exchangeSortAscending(arr1);
            exchangeSortDescending(arr2);
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + " ");
            }
            /*
Output
1 2 4 5 8 
8 5 4 2 1
Time Complexity: O(N^2)
Auxiliary Space : O(1)
            */
        }
    }
}
