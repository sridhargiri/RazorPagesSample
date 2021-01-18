using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    // C# program to find sum of 
    // digits of a number until 
    // sum becomes single digit.

    class DigitSumUntilOne
    {
        /*
		 Finding sum of digits of a number until sum becomes single digit
		Difficulty Level : Medium
		Given a number n, we need to find the sum of its digits such that:

		If n < 10    
			digSum(n) = n
		Else         
			digSum(n) = Sum(digSum(n))
		Examples :

Input : 1234
Output : 1
Explanation : The sum of 1+2+3+4 = 10, 
              digSum(x) == 10
              Hence ans will be 1+0 = 1

Input : 5674
Output : 4 
		*/
        static int digSum(int n)
        {
            int sum = 0;

            // Loop to do sum while 
            // sum is not less than 
            // or equal to 9 
            while (n > 0 || sum > 9)
            {
                if (n == 0)
                {
                    n = sum;
                    sum = 0;
                }
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
        /*
         There exists a simple and elegant O(1) solution for this too. The ans is given by simply :-

If n == 0
   return 0;

If n % 9 == 0      
    digSum(n) = 9
Else               
    digSum(n) = n % 9 
How does the above logic works?
If a number n is divisible by 9, then the sum of its digit until sum becomes single digit is always 9. For example,
Let, n = 2880
Sum of digits = 2 + 8 + 8 = 18: 18 = 1 + 8 = 9

A number can be of the form 9x or 9x + k. For the first case, answer is always 9. For the second case, answer is always k.

Below is the implementation of the above idea :
        */

        int digSum1(int n)
        {
            if (n == 0)
                return 0;
            return (n % 9 == 0) ? 9 : (n % 9);
        }

        // Driver code 
        public static void Main()
        {
            int n = 1234;
            Console.Write(digSum(n));
        }
    }

    // This code is contributed by nitin mittal 
    //    Related Post :
    //https://www.geeksforgeeks.org/digital-rootrepeated-digital-sum-given-integer/

}
