using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class NonRepeatingSubstring
    {

        // Function to count all unique 
        // distinct character subStrings 
        static int distinctSubString(String P, int N)
        {
            // Hashmap to store all subStrings 
            HashSet<String> S = new HashSet<String>();

            // Iterate over all the subStrings 
            for (int i = 0; i < N; ++i)
            {

                // Boolean array to maintain all 
                // characters encountered so far 
                bool[] freq = new bool[26];

                // Variable to maintain the 
                // subString till current position 
                String s = "";

                for (int j = i; j < N; ++j)
                {

                    // Get the position of the 
                    // character in the String 
                    int pos = P[j] - 'a';

                    // Check if the character is 
                    // encountred 
                    if (freq[pos] == true)
                        break;

                    freq[pos] = true;

                    // Add the current character 
                    // to the subString 
                    s += P[j];

                    // Insert subString in Hashmap 
                    S.Add(s);
                }
            }
            return S.Count;
        }

        // Driver code 
        public static void Main(String[] args)
        {
            String S = "abba";
            int N = S.Length;

            Console.Write(distinctSubString(S, N));
        }
    }
}
