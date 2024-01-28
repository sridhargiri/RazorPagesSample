using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/longest-substring-containing-1/
    Given a binary string, the task is to print the length of the longest substring containing only ‘1’.

Examples:

Input: 110
Output: 2
Explanation: Length of the longest substring containing only ‘1’ is “11”.

Input: 11101110
Output: 3

testgorilla online test AxiCorp
     */
    public class LongestSubstringOne
    {
        static int Maxlength(String s)
        {
            int n = s.Length, i, j;
            int ans = 0;
            for (i = 0; i <= n - 1; i++)
            {

                // Count the number of contiguous 1's
                if (s[i] == '1')
                {

                    int count = 1;
                    for (j = i + 1; j <= n - 1 && s[j] == '1'; j++)
                        count++;
                    ans = Math.Max(ans, count);
                }
            }
            return ans;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Maxlength("11101110"));
            /*
             Output: 3
Time Complexity: O(N2)
Auxiliary Space: O(1)
            */
        }
    }

    // testgorilla online test AxiCorp
    public class ATMPinValidate
    {
        public static bool ValidatePin(string pin)
        {
            Regex rgx = new Regex(@"^\d{4}(?:\d{2})?$");
            return rgx.IsMatch(pin);
        }

        public static void Main()
        {
            Console.WriteLine("Insert pin:");
            string pin = Console.ReadLine();

            Console.WriteLine("The restult is {0}", ValidatePin(pin));
        }
    }
}
