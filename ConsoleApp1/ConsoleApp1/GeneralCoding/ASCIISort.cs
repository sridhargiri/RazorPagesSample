using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
	 https://www.geeksforgeeks.org/sort-the-string-as-per-ascii-values-of-the-characters/
	Sort the string as per ASCII values of the characters
Last Updated : 01 Oct, 2021
Given a string S of size N, the task is to sort the string based on their ASCII values.

Examples:

Input: S = “Geeks7”
Output: 7Geeks
Explanation: According to the ASCII values, integers comes first, then capital alphabets and the small alphabets.

Input: S = “GeeksForGeeks”
Output: FGGeeeekkorss

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The idea to solve this problem is to maintain an array to store the frequency of each character and then adding them accordingly in the resultant string. Since there are at max 256 characters which makes the space complexity constant. Follow the steps below to solve this problem:

Initialize a vector freq[] of size 256 with values 0 to store the frequency of each character of the string.
Iterate over the range [0, N) using the variable i and increase the count of s[i] in the array freq[] by 1.
Make the string S as an empty string.
Iterate over the range [0, N) using the variable i and iterate over the range [0, freq[i]) using the variable j and add the character corresponding to the i-th ASCII value in the string s[].
After performing the above steps, print the string S as the result.
Below is the implementation of the above approach:
	 */
    public class ASCIISort
    {
        static void sortascii(string s)
        {
            int N = s.Length;

            // Stores the frequency of each
            // character of the string
            int[] freq = new int[256];

            // Count and store the frequency
            for (int i = 0; i < N; i++)
            {
                freq[s[i]]++;
            }

            s = "";

            // Store the result
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < freq[i]; j++)
                    s = s + (char)i;
            }
            Console.WriteLine(s);
        }
        public static void Main()
        {
            string S = "GeeksForGeeks";
            sortascii(S);
            /*
			 Output:
FGGeeeekkorss
Time Complexity: O(256*N)
Auxiliary Space: O(256)
			*/
        }
    }
}
