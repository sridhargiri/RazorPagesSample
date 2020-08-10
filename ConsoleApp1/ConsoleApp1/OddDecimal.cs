using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class OddDecimal
    {

        // Function to count number of substrings  
        // with odd decimal representation 
        static int countSubstr(string s)
        {
            int n = s.Length;

            // auxiliary array to store count  
            // of 1's before ith index 
            int[] auxArr = new int[n];

            if (s[0] == '1')
                auxArr[0] = 1;

            // store count of 1's before  
            // i-th index 
            for (int i = 1; i < n; i++)
            {
                if (s[i] == '1')
                    auxArr[i] = auxArr[i - 1] + 1;
                else
                    auxArr[i] = auxArr[i - 1];
            }

            // variable to store answer 
            int count = 0;

            // Traverse the string reversely to  
            // calculate number of odd substrings  
            // before i-th index 
            for (int i = n - 1; i >= 0; i--)
                if (s[i] == '1')
                    count += auxArr[i];

            return count;
        }

        // Driver Code 
        public static void Main()
        {
            string s = "1101";
            Console.WriteLine(countSubstr(s));
        }
    }

}
