using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
https://www.geeksforgeeks.org/rearrangement-number-also-divisible/?ref=lbp
    Rearrangement of a number which is also divisible by it
    Given a number n, we need to rearrange all its digits such that the new arrangement is divisible by n. 
    Also, the new number should not be equal to x. If no such rearrangement is possible, print -1. Examples:

Input : n = 1035
Output : 3105
The result 3105 is divisible by
given n and has the same set of digits.

Input : n = 1782
Output : m = 7128
Simple Approach : Find all the permutation of given n and then check whether it is divisible by n or not also check that new permutation should not be equal to n. 
    Efficient Approach : Let’s suppose that y is our result then y = m * n, 
    also we know that y must be a rearrangement of digits of n so we can say now restrict m (the multiplier) as per given conditions. 
    1) y has the same number of digits as n has. So, m must be less than 10. 
    2) y must not be equal to n. So, m will be greater than 1. So we get the multiplier m in the range [2,9]. 
    So we will find all the possible y and then check that should y has the same digits as n or not. 
    */
    public class RearrangeNumber
    {

        // perform hashing for given n
        static int[] storeDigitCounts(int n)
        {
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
                arr[i] = 0;
            // perform hashing
            while (n > 0)
            {
                arr[n % 10]++;
                n /= 10;
            }
            return arr;
        }

        // check whether any arrangement exists
        static int rearrange(int n)
        {
            // Create a hash for given number n
            // The hash is of size 10 and stores
            // count of each digit in n.
            int[] hash = storeDigitCounts(n);

            // check for all possible multipliers
            for (int mult = 2; mult < 10; mult++)
            {
                int curr = n * mult;

                int[] hash_curr = storeDigitCounts(curr);

                // check hash table for both.
                int ind;
                for (ind = 0; ind < 10; ind++)
                {
                    if (hash_curr[ind] != hash[ind])
                        break;
                }
                if (ind == 10)
                    return curr;
            }
            return -1;
        }

        // driver program
        public static void Main(string[] args)
        {
            int n = 10035;
            Console.WriteLine(rearrange(n));
            //op 30105
        }
    }
}
