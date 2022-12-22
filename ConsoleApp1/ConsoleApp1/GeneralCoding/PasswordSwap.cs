using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-distinct-characters-in-distinct-substrings-of-a-string/?ref=gcse
    Given a string str, the task is to find the count of distinct characters in all the distinct sub-strings of the given string.
Examples: 
 

Input: str = “ABCA” 
Output: 18 
    
Distinct sub-strings	Distinct characters
A	                    1
AB	                    2
ABC	                    3
ABCA	                3
B	                    1
BC	                    2
BCA	                    3
C	                    1
CA	                    2

Hence, 1 + 2 + 3 + 3 + 1 + 2 + 3 + 1 + 2 = 18
Input: str = “AAAB” 
Output: 10 

Approach: Take all possible sub-strings of the given string and use a set to check whether the current sub-string has been processed before. 
Now, for every distinct sub-string, count the distinct characters in it (again set can be used to do so). 
The sum of this count for all the distinct sub-strings is the final answer.
Below is the implementation of the above approach: 
     */
    public class DistinctCount
    {

        // Function to return the count of distinct
        // characters in all the distinct
        // sub-strings of the given string
        public static int countTotalDistinct(String str)
        {
            int cnt = 0;

            // To store all the sub-strings
            HashSet<String> items = new HashSet<String>();

            for (int i = 0; i < str.Length; ++i)
            {

                // To store the current sub-string
                String temp = "";

                // To store the characters of the
                // current sub-string
                HashSet<char> ans = new HashSet<char>();
                for (int j = i; j < str.Length; ++j)
                {
                    temp = temp + str[j];
                    ans.Add(str[j]);

                    // If current sub-string hasn't
                    // been stored before
                    if (!items.Contains(temp))
                    {

                        // Insert it into the set
                        items.Add(temp);

                        // Update the count of
                        // distinct characters
                        cnt += ans.Count;
                    }
                }
            }

            return cnt;
        }

        // Driver code
        public static void Main(String[] args)
        {
            String str = "ABCA";
            Console.WriteLine(countTotalDistinct(str));
            /*
            output 18
            Time complexity: O(n^2) 

            As the nested loop is used the complexity is order if n^2
            Space complexity: O(n)
            two sets of size n are used so the complexity would be O(2n) nothing but O(n).

             */

        }
    }

}
