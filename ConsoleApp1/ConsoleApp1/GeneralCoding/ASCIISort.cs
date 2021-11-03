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
    /*
https://www.geeksforgeeks.org/sums-of-ascii-values-of-each-word-in-a-sentence/
    Sums of ASCII values of each word in a sentence
Last Updated : 05 May, 2021
We are given a sentence of English language(can also contain digits), we need to compute and print the sum of ASCII values of characters of each word in that sentence.
Examples: 
 

Input :  GeeksforGeeks, a computer science portal for geeks
Output : Sentence representation as sum of ASCII each character in a word:
         1361 97 879 730 658 327 527 
         Total sum -> 4579
Here, [GeeksforGeeks, ] -> 1361, [a] -> 97, [computer] -> 879, [science] -> 730
      [portal] -> 658, [for] -> 327, [geeks] -> 527 

Input : I am a geek
Output : Sum of ASCII values:
         73 206 97 412 
Approach: 
 



Iterate over the length of the string and keep converting the characters to their ASCII
Keep adding up the values till the end of sentence.
When we come across a space character, we store the sum calculated for that word and set the sum equal to zero again.
Later, we print elements
 
     */
    public class ASCIISum
    {

        // Function to compute the sum of ASCII
        // values of each word separated by a
        // space and return the total sum of
        // the ASCII values, excluding the space.
        static long ASCIIWordSum(String str, long[] sumArr)
        {
            int l = str.Length;
            int pos = 0;
            long sum = 0;
            long bigSum = 0;
            for (int i = 0; i < l; i++)
            {

                // Separate each word by
                // a space and store values
                // corresponding to each word
                if (str[i] == ' ')
                {
                    bigSum += sum;
                    sumArr[pos++] = sum;
                    sum = 0;
                }
                else

                    // Implicit type casting
                    sum += str[i];
            }

            // Storing the sum of last word
            sumArr[pos] = sum;
            bigSum += sum;
            return bigSum;
        }

        // Driver function
        public static void Main()
        {
            String str = "GeeksforGeeks, a computer " +
                         "science portal for geeks";

            // Counting the number of words
            // in the input sentence
            int ctr = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ')
                    ctr++;

            long[] sumArr = new long[ctr + 1];

            // Calling function
            long sum = ASCIIWordSum(str, sumArr);

            // Printing equivalent sum of
            // the words in the sentence
            Console.WriteLine("Sum of ASCII values:");
            for (int i = 0; i <= ctr; i++)
                Console.Write(sumArr[i] + " ");

            Console.WriteLine();
            Console.Write("Total sum -> " + sum);
            /*
             Output:  

Sum of ASCII values:
1317 97 879 730 658 327 495 
Total sum -> 4503
The complexity of the approach is O(len)  
 

https://youtu.be/B3dghSG2R
            */
        }
    }
}
