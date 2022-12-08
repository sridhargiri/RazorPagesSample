using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     UBS Hackerrank test taken on 29 nov 2022
    Q1
    ***
     https://www.geeksforgeeks.org/find-length-of-longest-substring-with-at-most-k-normal-characters/
    Find length of longest substring with at most K normal characters
    Given a string P consisting of small English letters and a 26-digit bit string Q, 
    where 1 represents the special character and 0 represents a normal character for the 26 English alphabets. 
    The task is to find the length of the longest substring with at most K normal characters.
    Examples: 

Input : P = “normal”, Q = “00000000000000000000000000”, K=1 
Output : 1 
Explanation : In string Q all characters are normal. 
Hence, we can select any substring of length 1.

Input : P = “giraffe”, Q = “01111001111111111011111111”, K=2 
Output : 3 
Explanation : Normal characters in P from Q are {a, f, g, r}. 
Therefore, possible substrings with at most 2 normal characters are {gir, ira, ffe}. 
The maximum length of all substring is 3. 
    Approach: 
To solve the problem mentioned above we will be using the concept of two pointers. Hence, maintain left and right pointers of the substring, and a count of normal characters. Increment the right index till the count of normal characters is at most K. Then update the answer with a maximum length of substring encountered till now. Increment left index and decrement count till it is greater than K.
Below is the implementation of the above approach: 

     */
    public class IntelligentSubstring
    {

        // Function to find maximum
        // length of normal subStrings
        static int maxNormalSubString(string P, string Q,int K)
        {

            if (K == 0)
                return 0;

            // keeps count of normal characters
            int count = 0;

            // indexes of subString
            int left = 0, right = 0;

            // maintain length of longest subString
            // with at most K normal characters
            int ans = 0;

            while (right < P.Length)
            {

                while (right < P.Length && count <= K)
                {

                    // get position of character
                    int pos = P[right] - 'a';

                    // check if current character is normal
                    if (Q[pos] == '0')
                    {

                        // check if normal characters
                        // count exceeds K
                        if (count + 1 > K)

                            break;

                        else
                            count++;
                    }

                    right++;

                    // update answer with subString length
                    if (count <= K)
                        ans = Math.Max(ans, right - left);
                }

                while (left < right)
                {

                    // get position of character
                    int pos = P[left] - 'a';

                    left++;

                    // check if character is
                    // normal then decrement count
                    if (Q[pos] == '0')

                        count--;

                    if (count < K)
                        break;
                }
            }

            return ans;
        }

        // Driver code
        public static void Main(String[] args)
        {
            // initialise the String
            String P = "giraffe", Q = "01111001111111111011111111";

            int K = 2;
            Console.Write(maxNormalSubString(P, Q, K));
            //output 3
            //Time Complexity: The above method takes O(N) time.
        }
    }
    /*
     Q2
    ****
    Question:
    A number of cities each have a number of agencies that estimate revenues. The average revenue of a city is defined as the average of all agencies’ estimates of revenue for a city.

Write a query to print the floor of the avarage revenue of each city. The order of output does not matter. The result should be in the following format: CITY_NAME, AVERAGE_REVENUE

Schema:

There are 2 tables: CITIES and REVENUE

CITIES:

CITY_CODE — INTEGER — The city’s PINCODE. This is a primary key.

CITY_NAME — STRING — The city’s name.

REVENUE:

CITY_CODE — INTEGER — The city’s PINCODE.

REVENUE — INTEGER — The estimated revenue.

    Answer
    select cities.city_name as city_name, floor(avg(revenue.revenue)) as average_revenue from 
    cities join revenue on cities.city_code = revenue.city_code group by cities.city_name
    https://sumitkp.medium.com/hackerrank-sql-solution-city-revenue-97c830db8dd7

Sample Output:

new york 10

london 7

paris 15

Explanation:

new york has only one estimate, so it is the average.
london has two estimates. The average of those is floor((5+9)/2) = 7.
paris has only one estimate, so it is the average.

    Q3
    ***
    .net core custom middleware to check if request header value equals a given value. if pass, allow request else return 403

    Q4
    ***
    Abstract class override sample program to complete, like user class, moderator class, then admin class
     */
}
