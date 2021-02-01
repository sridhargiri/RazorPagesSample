using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
	 Given a number n, find the smallest number that has same set of digits as n and is greater than n. If n is the greatest possible number with its set of digits, then print “not possible”.
Examples:
For simplicity of implementation, we have considered input number as a string.

Input:  n = "218765"
Output: "251678"

Input:  n = "1234"
Output: "1243"

Input: n = "4321"
Output: "Not Possible"

Input: n = "534976"
Output: "536479"
Following are few observations about the next greater number.
1) If all digits sorted in descending order, then output is always “Not Possible”. For example, 4321.
2) If all digits are sorted in ascending order, then we need to swap last two digits. For example, 1234.
3) For other cases, we need to process the number from rightmost side (why? because we need to find the smallest of all greater numbers)

You can now try developing an algorithm yourself.

Following is the algorithm for finding the next greater number.
I) Traverse the given number from rightmost digit, keep traversing till you find a digit which is smaller than the previously traversed digit. For example, if the input number is “534976”, we stop at 4 because 4 is smaller than next digit 9. If we do not find such a digit, then output is “Not Possible”.
	
II) Now search the right side of above found digit ‘d’ for the smallest digit greater than ‘d’. For “534976″, the right side of 4 contains “976”. The smallest digit greater than 4 is 6.

III) Swap the above found two digits, we get 536974 in above example.

IV) Now sort all digits from position next to ‘d’ to the end of number. The number that we get after sorting is the output. For above example, we sort digits in bold 536974. We get “536479” which is the next greater number for input 534976.

Following are the implementation of above approach.


	 
	 */
    public class nextGreater
    {
        // Utility function to swap two digit 
        static void swap(char[] ar, int i, int j)
        {
            char temp = ar[i];
            ar[i] = ar[j];
            ar[j] = temp;
        }

        // Given a number as a char array number[], 
        // this function finds the next greater number. 
        // It modifies the same array to store the result 
        static void findNext(char[] ar, int n)
        {
            int i;

            // I) Start from the right most digit 
            // and find the first digit that is smaller 
            // than the digit next to it. 
            for (i = n - 1; i > 0; i--)
            {
                if (ar[i] > ar[i - 1])
                {
                    break;
                }
            }

            // If no such digit is found, then all 
            // digits are in descending order means 
            // there cannot be a greater number with 
            // same set of digits 
            if (i == 0)
            {
                Console.WriteLine("Not possible");
            }
            else
            {
                int x = ar[i - 1], min = i;

                // II) Find the smallest digit on right 
                // side of (i-1)'th digit that is greater 
                // than number[i-1] 
                for (int j = i + 1; j < n; j++)
                {
                    if (ar[j] > x && ar[j] < ar[min])
                    {
                        min = j;
                    }
                }

                // III) Swap the above found smallest 
                // digit with number[i-1] 
                swap(ar, i - 1, min);

                // IV) Sort the digits after (i-1) 
                // in ascending order 
                Array.Sort(ar, i, n - i);
                Console.Write("Next number with same" +
                                        " set of digits is ");
                for (i = 0; i < n; i++)
                    Console.Write(ar[i]);
            }
        }

        /*
		 Write a program to add one to a given number. The use of operators like ‘+’, ‘-‘, ‘*’, ‘/’, ‘++’, ‘–‘ …etc are not allowed.
Examples:

Input:  12
Output: 13

Input:  6
Output: 7
This question can be approached by using some bit magic. Following are different methods to achieve the same using bitwise operators.

Method 1
To add 1 to a number x (say 0011000111), flip all the bits after the rightmost 0 bit (we get 0011000000). Finally, flip the rightmost 0 bit also (we get 0011001000) to get the answer.
		*/

        static int addOne(int x)
        {
            int m = 1;

            // Flip all the set bits  
            // until we find a 0  
            while ((int)(x & m) == 1)
            {
                x = x ^ m;
                m <<= 1;
            }

            // flip the rightmost 0 bit  
            x = x ^ m;
            return x;
        }
        /*
		 Method 2
We know that the negative number is represented in 2’s complement form on most of the architectures. We have the following lemma hold for 2’s complement representation of signed numbers.

		Say, x is numerical value of a number, then

~x = -(x+1) [ ~ is for bitwise complement ]

(x + 1) is due to addition of 1 in 2’s complement conversion

To get (x + 1) apply negation once again. So, the final expression becomes (-(~x)).

		 */

        // Driver code 
        public static void Main(String[] args)
        {
            Console.WriteLine(addOne(13)); Console.WriteLine(addOne(-(~13)));
            char[] digits = { '5', '3', '4', '9', '7', '6' };
            int n = digits.Length;
            findNext(digits, n);
        }
    }

    // This code is contributed by 29AjayKumar 

}
