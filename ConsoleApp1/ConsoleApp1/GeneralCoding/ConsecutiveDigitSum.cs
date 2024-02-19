using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    https://www.geeksforgeeks.org/sum-of-numbers-formed-by-consecutive-digits-present-in-a-given-string/
    hcl appscan speedexam online test attended 16/02/2024
    Sum of numbers formed by consecutive digits present in a given string
    Given a string S consisting of digits [0 – 9] and lowercase alphabets, the task is to calculate the sum of all numbers represented by continuous sequences of digits present in the string S.

Examples:

Input: S = “11aa32bbb5”
Output: 48
Explanation: 
The consecutive sequence of numbers present in the string S are {11, 32, 5}.
Therefore, sum = 11 + 32 + 5 = 48

Input: s = “5an63ff2”
Output: 70

Approach: Follow the steps below to solve the problem:

Initialize a variable, say curr, to store the current sequence of consecutive digits
Iterate over the characters of the string.
If the current character is not a digit, add the current value of curr to the final answer. Reset curr to 0.
Otherwise, append the current digit to curr.
Finally, return the final answer.
Below is the implementation of the above approach:
     */
    public class ConsecutiveDigitSum
    {

        // Function to calculate the sum of 
        // numbers formed by consecutive 
        // sequences of digits present in the string 
        static int sumOfDigits(string s)
        {

            // Stores consecutive digits 
            // present in the string 
            int curr = 0;

            // Stores the sum 
            int ret = 0;

            // Iterate over characters 
            // of the input string 
            foreach (char ch in s)
            {

                // If current character is a digit 
                if (ch >= 48 && ch <= 57)
                {

                    // Append current digit to curr 
                    curr = curr * 10 + ch - '0';
                }
                else
                {

                    // Add curr to sum 
                    ret += curr;

                    // Reset curr 
                    curr = 0;
                }
            }
            ret += curr;
            return ret;
        }

        // Driver code
        static void Main()
        {
            string S = "11aa32bbb5";
            Console.WriteLine(sumOfDigits(S));//op 48
        }
    }
}
