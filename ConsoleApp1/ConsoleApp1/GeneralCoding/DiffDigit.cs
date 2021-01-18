using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	/*
	 Numbers having difference with digit sum more than s
Difficulty Level : Medium
 Last Updated : 10 May, 2018
You are given two positive integer value n and s. 
	You have to find the total number of such integer from 1 to n such that the difference of integer and its digit sum is greater than given s.
	for n=20, s=5 there are 11 numbers satisfying the condition i - digitsum(i) > s
10-1=9
11-1=10
12-3=9
13-4=8
14-5=9
15-6=9
16-7=9
17-8=9
18-9=9
19-10=10
20-2=18

	Examples :

Input : n = 20, s = 5
Output :11
Explanation : Integer from 1 to 9 have 
diff(integer - digitSum) = 0 but for 10 to 
20 they have diff(value - digitSum) > 5

Input : n = 20, s = 20
Output : 0
Explanation : Integer from 1 to 20 have diff
(integer - digitSum) >  5

	The very first and basic approach to solve this question is to check for all integer starting from 1 to n and for each check whether integer minus digit sum is greater than s or not. This will become very time costly because we have to traverse 1 to n and for each integer we also have to calculate the digit sum.

Before moving to better approach lets have some key analysis about this questions and its features:

	
For the largest possible integer (say long long int i.e. 10^18), the maximum possible digit sum is 9*18 (when all of digits are nine) = 162. This means in any case all the integer greater than s + 162 satisfy the condition of integer – digitSum > s.
All integer less than s can not satisfy the given condition for sure.
All the integers within a tens range (0-9, 10-19…100-109) does have same value of integer minus digitSum.
Using above three key features we can shorten our approach and time complexity in a manner where we have to iterate only over s to s+163 integers. Beside checking for all integer within range we only check for each 10th integer (e.g 150, 160, 170..).


	Algorithm:

// if n < s then return 0
if n<s 
    return 0
else

    // iterate for s to min(n, s+163)
    for i=s to i min(n, s+163)

        // return n-i+1
        if (i-digitSum)>s
            return (n-i+1)

// if no such integer found return 0
return 0


	 */


	class DiffDigit
	{
		// function for digit sum 
		static long digitSum(long n)
		{
			long digSum = 0;

			while (n > 0)
			{
				digSum += n % 10;
				n /= 10;
			}
			return digSum;
		}

		// function to calculate count of integer s.t. 
		// integer - digSum > s 
		public static long countInteger(long n, long s)
		{
			// if n < s no integer possible 
			if (n < s)
				return 0;

			// iterate for s range and then calculate 
			// total count of such integer if starting 
			// integer is found 
			for (long i = s; i <= Math.Min(n, s + 163); i++)
				if ((i - digitSum(i)) > s)
					return (n - i + 1);

			// if no integer found return 0 
			return 0;
		}

		// Driver program 
		public static void Main()
		{
			long n = 20, s = 5;
			Console.WriteLine(countInteger(n, s));
		}
	}

	// This code is contributed by vt_m. 

}
