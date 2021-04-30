// C# program to find first non-repeating character 
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class FindFirst
    {
        /*
         Given a string, find its first non-repeating character
Difficulty Level : Easy
Last Updated : 18 Mar, 2021
Given a string, find the first non-repeating character in it. For example, if the input string is “GeeksforGeeks”, then the output should be ‘f’ and if the input string is “GeeksQuiz”, then the output should be ‘G’. 
 

find-first-non-repeated-character-in-a-string

 https://www.geeksforgeeks.org/given-a-string-find-its-first-non-repeating-character/

Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution.
Example: 

Input: "geeksforgeeks"
Explanation:
Step 1: Construct a character count array 
        from the input string.
   ....
  count['e'] = 4
  count['f'] = 1
  count['g'] = 2
  count['k'] = 2
  ……

Step 2: Get the first character who's 
        count is 1 ('f').
Method 1: HashMap and Two-string method traversals.
Approach: A character is said to be non-repeating if its frequency in the string is unit. Now for finding such characters, one needs to find the frequency of all characters in the string and check which character has unit frequency. This task could be done efficiently using a hash_map which will map the character to there respective frequencies and in which we can simultaneously update the frequency of any character we come across in constant time. The maximum distinct characters in the ASCII system are 256. So hash_map has a maximum size of 256. Now read the string again and the first character which we find has a frequency as unity is the answer. 
Algorithm: 



Make a hash_map which will map the character to there respective frequencies.
Traverse the given string using a pointer.
Increase the count of current character in the hash_map.
Now traverse the string again and check whether the current character hasfrequency=1.
If the frequency>1 continue the traversal.
Else break the loop and print the current character as the answer.
Pseudo Code : 

for ( i=0 to str.length())
hash_map[str[i]]++;

for(i=0 to str.length())
  if(hash_map[str[i]]==1)
  return str[i]
  break 
        */

        static int NO_OF_CHARS = 256;
        static char[] count = new char[NO_OF_CHARS];

        /* calculate count of characters  
        in the passed string */
        static void getCharCountArray(string str)
        {
            for (int i = 0; i < str.Length; i++)
                count[str[i]]++;
        }

        /* The method returns index of first non-repeating 
        character in a string. If all characters are  
        repeating then returns -1 */
        static int firstNonRepeating(string str)
        {
            getCharCountArray(str);
            int index = -1, i;

            for (i = 0; i < str.Length; i++)
            {
                if (count[str[i]] == 1)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
        /*
         Output
First non-repeating character is f
Can this be done by traversing the string only once? 
The above approach takes O(n) time, but in practice, it can be improved. The first part of the algorithm runs through the string to construct the count array (in O(n) time). This is reasonable. But the second part about running through the string again just to find the first non-repeater is not a good practice.
In real situations, the string is expected to be much larger than your alphabet. Take DNA sequences, for example, they could be millions of letters long with an alphabet of just 4 letters. What happens if the non-repeater is at the end of the string? Then we would have to scan for a long time (again). 
Method 2: HashMap and single string traversal.
Approach: Make a count array instead of hash_map of maximum number of characters(256). We can augment the count array by storing not just counts but also the index of the first time you encountered the character e.g. (3, 26) for ‘a’ meaning that ‘a’ got counted 3 times and the first time it was seen is at position 26. So when it comes to finding the first non-repeater, we just have to scan the count array, instead of the string. Thanks to Ben for suggesting this approach.
Algorithm : 

Make a count_array which will have two fields namely frequency, first occurence of a character.
The size of count_array is ‘256’.
Traverse the given string using a pointer.
Increase the count of current character and update the occurence.
Now here’s a catch, the array will contain valid first occurence of the character which has frequency has unity otherwise the first occurence keeps updating.
Now traverse the count_array and find the character which has least value of first occurence and frequency value as unity.
Return the character
Pseudo Code : 

for ( i=0 to str.length())
count_arr[str[i]].first++;
count_arr[str[i]].second=i;

int res=INT_MAX;
for(i=0 to count_arr.size())
  if(count_arr[str[i]].first==1)
  res=min(min, count_arr[str[i]].second)

return res
        */


        public class CountIndex
        {
            public int count, index;

            // constructor for first occurrence
            public CountIndex(int index)
            {
                this.count = 1;
                this.index = index;
            }

            // method for updating count
            public virtual void incCount()
            {
                this.count++;
            }
        }


        public static Dictionary<char,
                                 CountIndex>
            hm = new Dictionary<char,
                                CountIndex>(NO_OF_CHARS);

        /* calculate count of characters
        in the passed string */
        public static void getCharCountArray1(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                // If character already occurred,
                if (hm.ContainsKey(str[i]))
                {
                    // updating count
                    hm[str[i]].incCount();
                }

                // If it's first occurrence, then
                // store the index and count = 1
                else
                {
                    hm[str[i]] = new CountIndex(i);
                }
            }
        }

        /* The method returns index of first
        non-repeating character in a string.
        If all characters are repeating then
        returns -1 */
        public static int firstNonRepeating1(string str)
        {
            getCharCountArray1(str);
            int result = int.MaxValue, i;

            for (i = 0; i < str.Length; i++)
            {
                // If this character occurs only
                // once and appears before the
                // current result, then update the result
                if (hm[str[i]].count == 1 && result > hm[str[i]].index)
                {
                    result = hm[str[i]].index;
                }
            }

            return result;
        }

        public static void Main()
        {
            string str = "geeksforgeeks";
            int index = firstNonRepeating(str);

            Console.WriteLine(index == -1 ? "Either " +
            "all characters are repeating or string " +
            "is empty" : "First non-repeating character"
            + " is " + str[index]);

             str = "geeksforgeeks";
             index = firstNonRepeating1(str);

            Console.WriteLine(
                index == int.MaxValue
                    ? "Either all characters are repeating "
                          + " or string is empty"
                    : "First non-repeating character is "
                          + str[index]);
            /*
             Output
First non-repeating character is f
Complexity Analysis: 

Time Complexity: O(n). 
As the string need to be traversed at-least once.
Auxiliary Space: O(n). 

Space is occupied by the use of count_array/hash_map to keep track of frequency.*/
        }
    }
}
