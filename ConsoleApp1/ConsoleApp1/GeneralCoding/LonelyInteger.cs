using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ConsoleApp1
{
    public class FlipAllBits
    {

        /*
You will be given a list of 32 bit unsigned integers. Flip all the bits 0_1,1->0 and print the result as an unsigned
Sample Input 0

3
2147483647
1
0
Sample Output 0

2147483648
4294967294
4294967295
         */
        static long flippingBits(long n)
        {
            long number;
            long unsignedNumber;
            number = ~n;
            unsignedNumber = number & 0xffffffffL;
            return unsignedNumber;

        }
        static void Main(string[] args)
        {
            Console.WriteLine(flippingBits(2147483647));
        }
    }
    public class StudentGrading
    {
        /*
         HackerLand University has the following grading policy:

Every student receives a grade in the inclusive range from  to .
Any grade less than  is a failing grade.
Sam is a professor at the university and likes to round each student's grade according to these rules:

If the difference between the grade and the next multiple of  is less than , round  up to the next multiple of .
If the value of grade is less than , no rounding occurs as the result will still be a failing grade.
Examples

 round to  (85 - 84 is less than 3)
 do not round (result is less than 40)
 do not round (60 - 57 is 3 or higher)
Sample Input

4

73

67

38

33
 

Sample Output
4

75

67

40

33
         */
        public static List<int> gradingStudents(List<int> grades)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] >= 38)
                {
                    int nextMultipleOfFive = 5 - (grades[i] % 5) + grades[i];
                    if (nextMultipleOfFive - grades[i] < 3)
                    {
                        grades[i] = nextMultipleOfFive;
                    }
                }
            }

            return grades;
        }
        public static void Main(string[] args)
        {
            List<int> marks = new List<int>() { 4, 73, 67, 38, 33 };
            var outmarks = gradingStudents(marks);
            foreach (int mark in marks)
            {
                Console.Write(mark + " ");
            }
        }
    }
    /*
     
Lonely Integer
There are N integers in an array A. All but one integer occurs in pairs. Your task is to find out the number that occurs only once.

Input Format

The first line of the input contains an integer N indicating number of integers in the array A. The next line contains N integers each separated by a single space. Constraints 1 <= N < 100 N % 2 = 1 ( N is an odd number ) 0 <= A[i] <= 100, ∀ i ∈ [1, N]

Output Format

Output S, the number that occurs only once.
Sample Input
3
1 1 2
Sample Output
2
     */
    class LonelyInteger
    {
        static int lonelyinteger(int[] a)
        {
            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result ^= a[i];
            }
            return result;
        }
        static void Main(string[] args)
        {
            int lonely = lonelyinteger(new int[] { 1, 4, 2, 3, 2, 3, 1 });
            Console.WriteLine(lonely);
        }


    }
    /*
     * Louise and Richard have developed a numbers game. They pick a number and check to see if it is a power of 2. 
     * If it is, they divide it by 2. If not, they reduce it by the next lower number which is a power of 2. Whoever reduces the number to 1 wins the game. 
     * Louise always starts.
    https://www.hackerrank.com/challenges/counter-game/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
Given an initial value, determine who wins the game.

As an example, let the initial value n=132. It's Louise's turn so she first determines that 132 is not a power of 2.
    The next lower power of 2 is 128, so she subtracts that from 132 and passes 4 to Richard. 4 is a power of 2, so Richard divides it by 2 and passes 2 to Louise.
    Likewise, 2 is a power so she divides it by 2 and reaches 1. She wins the game.

    Update If they initially set counter to 1, Richard wins. Louise cannot make a move so she loses.
    */
    // Case 1: If N is not a power of 2, reduce the counter by the largest power of 2 less than N
    //
    // This is equivalent to turning the most significant 1 in N to 0. This operation will keep
    // repeating until we reach Case 2. To count the number of times we have to do Case 1's operation 
    // we can count the number of 1s in our original number (except for the least significant 1). 

    // Case 2: If N is a power of 2, we must "reduce the counter by half of N".
    //
    // This is equivalent of doing a right shift. This operation keeps repeating until the game ends.
    // The number of right shifts we do depends on the number of trailing 0s.

    // Additional optimization:
    //
    // Instead of counting the number of times Case 1 and Case 2 happen separately, we can just
    // calculate the number of 1s in N-1. This is because subtracting 1 from our number will turn
    // all of the trailing 0s (which we wanted to count) into 1s that we can count (for example:
    // 10000 would become 01111)

    // Example:
    //
    // 10110100  Case 1
    //   110100  Case 1
    //    10100  Case 1
    //      100  Case 2
    //       10  Case 2
    //        1  Done
    //
    // We had 5 operations total. Directly applying our algorithm would look like this:
    //
    // Original Number: 10110100
    //     Number - 1 : 10110011   and the number of 1s is 5
    /*
     Sample Input 0

1
6
Sample Output 0

Richard
Explanation 0

 6 is not a power of 2 so Louise reduces it by the largest power of 2 less than 6:6-4=2.
 2 is a power of 2 so Richard divides by 2 to get 1 and wins the game.
    */

    public class CounterGame
    {
        static string counterGame(long n)
        {
            bool richardWins = true;

            while ((n & 1) == 0)
            {
                richardWins = !richardWins;
                n >>= 1;
            }
            while (n != 1)
            {
                if ((n & 1) == 1)
                    richardWins = !richardWins;
                n >>= 1;
            }

            return richardWins ? "Richard" : "Louise";
        }
        static void Main(string[] args)
        {
            Console.WriteLine(counterGame(6));
        }
    }
    /*
     https://www.geeksforgeeks.org/extract-all-integers-from-a-given-string/
    Extract all integers from a given String
    example
    Input: str = “1Hello2   &* how  are y5ou”
Output: 1 2 5
    Input: str = “Hey everyone, I have 500 rupees and I would spend a 100”
Output: 500 100
    Approach: To solve this problem follow the below steps:

Create a string tillNow, which will store all founded integers till now. Initialise it with an empty string.
Now start traversing string str, and in each iteration:
If a character is a number, add it to the string tillNow.
Otherwise, check if the string tillNow is empty or not. If it isn’t empty, then convert it to an integer and empty it after printing it.
Now, after the loop ends, check again that if the string tillNow is empty or not. If it isn’t then, convert it to integer and print it.
Below is the implementation of the above approach
    
     */
    public class ExtractIntegers
    {
        static void extractIntegersFromString(string str)
        {
            int n = str.Length;

            // This variable will store each founded
            // integer temporarily
            string tillNow = "";

            for (int i = 0; i < n; i++)
            {

                // If current character is an integer, then
                // add it to string tillNow
                if (str[i] - '0' >= 0 && str[i] - '0' <= 9)
                {
                    tillNow += str[i];
                }

                // Otherwise, check if tillNow is empty or not
                // If it isn't then convert tillNow to integer
                // and empty it after printing
                else
                {
                    if (tillNow.Length > 0)
                    {
                        Console.WriteLine(int.Parse(tillNow));

                        tillNow = "";
                    }
                }
            }

            // if tillNow isn't empty then convert tillNow
            // to integer and print it
            if (tillNow.Length > 0)
            {
                Console.WriteLine(int.Parse(tillNow));
            }
        }
        static void Main(string[] args)
        {
            string str = "1Hello2 & *how  are y5ou7";
            extractIntegersFromString(str);
            /*
             Output
1 2 5
Time Complexity: O(N)
Auxiliary Space: O(N)
            */
        }
    }
}
