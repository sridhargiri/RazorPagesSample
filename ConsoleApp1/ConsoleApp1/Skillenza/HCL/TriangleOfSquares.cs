using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Triangle of Squares
Given side length of square s and height of triangle h, output the pattern as shown below.

For side length of square 2, and height 3 the pattern is

            * * *
            *   *
            * * *
      * * *       * * *
      *   *       *   *
      * * *       * * *
* * *       * * *       * * *
*   *       *   *       *   *
* * *       * * *       * * *
For side length of square 3, and height 4 the pattern is

                        * * * *
                        *     *
                        *     *
                        * * * *
                * * * *         * * * *
                *     *         *     *
                *     *         *     *
                * * * *         * * * *
        * * * *         * * * *         * * * *
        *     *         *     *         *     *
        *     *         *     *         *     *
        * * * *         * * * *         * * * *
* * * *         * * * *         * * * *         * * * *
*     *         *     *         *     *         *     *
*     *         *     *         *     *         *     *
* * * *         * * * *         * * * *         * * * *
For side length of square 1, and height 1 the pattern is

* *
* *
For side length of square 4, and height 2 the pattern is

          * * * * *
          *       *
          *       *
          *       *
          * * * * *
* * * * *           * * * * *
*       *           *       *
*       *           *       *
*       *           *       *
* * * * *           * * * * *
For side length of square 1, and height 5 the pattern is

                * *
                * *
            * *     * *
            * *     * *
        * *     * *     * *
        * *     * *     * *
    * *     * *     * *     * *
    * *     * *     * *     * *
* *     * *     * *     * *     * *
* *     * *     * *     * *     * *
Input Format
The first line of input consists of an integer t denoting the number of test cases. Next t test cases follow. Each test case consists of one line. Each line of test case consists of two space separated integers s and h denoting the side length of the square and height of the triangle respectively.

Output Format
For each test case output the triangle of squares pattern.

Constraints
1 <= t (number of test cases) <= 200

1 <= s (side length of square) <= 20

1 <= h (height of triangle) <= 20

Sample Input
3
2 3
3 1
5 2
Sample Output
            * * *
            *   *
            * * *
      * * *       * * *
      *   *       *   *
      * * *       * * *
* * *       * * *       * * *
*   *       *   *       *   *
* * *       * * *       * * *
* * * *
*     *
*     *
* * * *
            * * * * * *
            *         *
            *         *
            *         *
            *         *
            * * * * * *
* * * * * *             * * * * * *
*         *             *         *
*         *             *         *
*         *             *         *
*         *             *         *
* * * * * *             * * * * * *
https://cdn.skillenza.com/files/d314b851-c3be-4897-8ebf-a7857f8908a0/in.txt
https://cdn.skillenza.com/files/9e732c77-94a7-4a5a-911d-6e92dd0f99da/out.txt    
     */
    public class TriangleOfSquares
    {
        public static void PrintDesiredPattern() { }
        /*
         Prefix Hierarchy
Given a list of names, determine the number of names in that list for which a given query string is a prefix.
 
For example, given the list names = [jackson, jacques, jack], the complete query string jack is a prefix of jackson but not of jacques or jack. The prefix cannot contain the entire name string.
 
Function Description 
Complete the function findCompletePrefixes in the editor below. The function must return an array of integers that each denotes the number of names strings for which a query string is a prefix.
 
findCompletePrefixes has the following parameter(s):
    names[names[0],...names[n-1]]:  an array of name strings
    query[query[0],...query[n-1]]:  an array of query strings
 
Constraints
•	1 ≤ n ≤ 20000
•	2 ≤ |names[i]| ≤ 30,
•	1 ≤ sum of all |names[i]| ≤ 5 x 105
•	1 ≤ q ≤ 200
•	2 ≤ |query[i]| ≤ 30
 
Input Format For Custom Testing
Input from stdin will be processed as follows and passed to the function.
 
The first line contains an integer n, the size of the array names.
Each of the next n lines contains an element names[i] where 0 ≤ i < n.
The next line contains an integer q, the size of the array query.
Each of the next q lines contains an element query[i] where 0 ≤ i < q.
Sample Case 0
Sample Input 0
10
steve
stevens
danny
steves
dan
john
johnny
joe
alex
alexander
5
steve
alex
joe
john
dan
Sample Output 0
2
1
0
1
1
Explanation 0
Query 1: steve appears as a prefix in two strings: stevens and steves.
Query 2: alex appears as a prefix in one string: alexander.
Query 3: joe does not appear as a prefix in any string.
Query 4: john appears as a prefix in one string: johnny.
Query 5: dan appears as a prefix in one string: danny.
Language
C#
 
Autocomplete Ready
More
1
16
17
18
19
20
21
22
23
24
25
26
27
28
29
30
31
32
33
34
35
36
using System.CodeDom.Compiler;
 
class Result
{
 
    
      Complete the 'findCompletePrefixes' function below.
    
      The function is expected to return an INTEGER_ARRAY.
      The function accepts following parameters:
       1. STRING_ARRAY names
       2. STRING_ARRAY query
     

        public static List<int> findCompletePrefixes(List<string> names, List<string>
    query)
        {

        }

    }

    class Solution


Line: 16 Col: 1
Test Results
Custom Input
Run Code
Run Tests
Submit
SuppressMessageAttribute

*/
        public static List<int> findCompletePrefixes(List<string> names, List<string> query)
        {
            List<int> inter = new List<int>();
            foreach (var q in query)
            {
                int sum = -1;
                foreach (var name in names)
                {
                    if (name.IndexOf(q) != -1)
                    {
                        if (name.StartsWith(q))
                        {
                            sum++;
                        }
                    }
                }
                inter.Add(sum); sum = 0;
            }
            return inter;
        }
        public static void Main(string[] args)
        {
            
        }


        /*
Virtusa
9. Hosts and the Total Number of Requests
 
In this challenge, write a program to analyze a log file and summarize the results.  Given a text file of an http requests log, list the number of requests from each host.  Output should be directed to a file as described in the Program Description below.
 
The format of the log file, a text file with a .txt extension, follows.  Each line contains a single log record with the following columns (in order):
1.	The hostname of the host making the request.
2.	This column's values are missing and were replaced by a hyphen.
3.	This column's values are missing and were replaced by a hyphen.
4.	A timestamp enclosed in square brackets following the format [DD/mmm/YYYY:HH:MM:SS -0400], where DD is the day of the month, mmm is the name of the month, YYYY is the year, HH:MM:SS is the time in 24-hour format, and -0400 is the time zone.
5.	The request, enclosed in quotes (e.g., "GET /images/NASA-logosmall.gif HTTP/1.0").
6.	The HTTP response code.
7.	The total number of bytes sent in the response.
 
Example log file entry
Given the following log record:
	unicomp6.unicomp.net - - [01/Jul/1995:00:00:06 -0400] "GET /shuttle/countdown/ HTTP/1.0" 200 3985
We can label each column in the record like so:
Hostname	-	-	Timestamp	Request	HTTP Response Code	Bytes
unicomp6.unicomp.net	-	-	[01/Jul/1995:00:00:06 -0400]	"GET /shuttle/countdown/ HTTP/1.0"	200	3985
Function Description 
Your function must create a unique list of hostnames with their number of requests and output to a file named records_filename where filename is replaced with the input filename. Each hostname should be followed by a space, the number of requests, and a newline. Order doesn't matter.
 
Constraints
•	The log file has a maximum of 2 × 105 lines of records.
 
Input Format
 
There is one line of input which contains the string filename read from STDIN.
Sample Case 0
Sample Input 0
hosts_access_log_00.txt
Sample Output 0
Given filename = "hosts_access_log_00.txt", process the records in hosts_access_log_00.txt and create an output file named records_hosts_access_log_00.txt which contains the following rows:
burger.letters.com 3
d104.aa.net 3
unicomp6.unicomp.net 4
Explanation 0
The log file hosts_access_log_00.txt contains the following log records:
unicomp6.unicomp.net - - [01/Jul/1995:00:00:06 -0400] "GET /shuttle/countdown/ HTTP/1.0" 200 3985
burger.letters.com - - [01/Jul/1995:00:00:11 -0400] "GET /shuttle/countdown/liftoff.html HTTP/1.0" 304 0
burger.letters.com - - [01/Jul/1995:00:00:12 -0400] "GET /images/NASA-logosmall.gif HTTP/1.0" 304 0
burger.letters.com - - [01/Jul/1995:00:00:12 -0400] "GET /shuttle/countdown/video/livevideo.gif HTTP/1.0" 200 0
d104.aa.net - - [01/Jul/1995:00:00:13 -0400] "GET /shuttle/countdown/ HTTP/1.0" 200 3985
unicomp6.unicomp.net - - [01/Jul/1995:00:00:14 -0400] "GET /shuttle/countdown/count.gif HTTP/1.0" 200 40310
unicomp6.unicomp.net - - [01/Jul/1995:00:00:14 -0400] "GET /images/NASA-logosmall.gif HTTP/1.0" 200 786
unicomp6.unicomp.net - - [01/Jul/1995:00:00:14 -0400] "GET /images/KSC-logosmall.gif HTTP/1.0" 200 1204
d104.aa.net - - [01/Jul/1995:00:00:15 -0400] "GET /shuttle/countdown/count.gif HTTP/1.0" 200 40310
d104.aa.net - - [01/Jul/1995:00:00:15 -0400] "GET /images/NASA-logosmall.gif HTTP/1.0" 200 786
When the data is consolidated, it confirms the following:
1.	The host unicomp6.unicomp.net made 4 requests.
2.	The host burger.letters.com made 3 requests.
3.	The host d104.aa.net made 3 requests.
Language
C#
 
Autocomplete Ready
More
1
6
7
8
9
10
11
12
13
14
15
16
17
18
using System;
 
namespace Solution
{
    class Solution
    {
        static void Main(string[] args)
        {
            // read the string filename
            string filename = Console.ReadLine();
            
        }
    }
}
 
Line: 6 Col: 1
Test Results
Custom Input
Run Code
Run Tests
Submit
SuppressMessageAttribute


         */


        /*
         River records
A meteorologist maintains a record of water level readings taken on a nearby river.  Initially, there was an average level that is considered to be level 0.  Subsequent readings show the height in millimeters above or below that zero level, at regular intervals.  One of the figures to determine is the maximum height above a previously recorded value that has been achieved to date.  Given the complete array of records collected, determine the maximum difference between any reading versus any prior reading, the trailing record.  If there is never a lower prior reading, return -1.
 
Example
levels = [5, 3, 6, 7, 4]
 
There are no earlier readings than levels[0].
There is no earlier reading with a value lower than levels[1].
There are two lower earlier readings with a value lower than levels[2] = 6:
•	levels[2] - levels[1] = 6 - 3 = 3
•	levels[2] - levels[0] = 6 - 5 = 1
There are three lower earlier readings with a lower value than levels[3] = 7:
•	levels[3] - levels[2] = 7 - 6 = 1
•	levels[3] - levels[1] = 7 - 3 = 4
•	levels[3] - levels[0] = 7 - 5 = 2
There is one lower earlier reading with a lower value than arr[4] = 4:
•	levels[4] - levels[1] = 4 - 3 = 1
 
The maximum trailing record is levels[3] - levels[1] = 4.
 
Example
levels = [4, 3, 2, 1]
 
No item in levels has a lower earlier reading, therefore return -1
 
Function Description 
Complete the function maximumTrailing in the editor below.
 
maximumTrailing has the following parameter(s):
    int levels[n]:  an array of integers
Returns:
    int: an integer that represents the maximum trailing record, or -1 if no element in levels has a lower earlier reading
 
Constraints
•	1 ≤ n ≤ 2 × 105
•	−106 ≤ levels[i] ≤ 106  and  0 ≤ i < n
 
Input Format For Custom Testing
Input from stdin will be processed as follows and passed to the function:
 
The first line contains a single integer, n, the number of elements in the array levels.
Each of the n subsequent lines contains a single integer, each an element levels[i] where 0 ≤ i < n.
Sample Case 0
Sample Input 0
STDIN         Function
-----         --------
7       →     levels[] size n = 7
2       →     levels = [2, 3, 10, 2, 4, 8, 1]
3       
10     
2      
4      
8       
1         
 
Sample Output
8
Explanation
 
Differences are calculated as:
•	3 - [2] = [1]
•	10 - [3, 2] = [7, 8]
•	4 - [2, 3, 2] = [2, 1, 2]
•	8 - [4, 2, 3, 2] = [4, 6, 5, 6]
The maximum trailing record is 10 - 2 = 8.
Sample Case 1
Sample Input 1
STDIN         Function 
-----         -------- 
6       →     levels[] size n = 6
7       →     levels = [7, 9, 5, 6, 3, 2]
9       
5       
6       
3       
2       
Sample Output
2
Explanation
 
Differences are calculated as:
•	9 - [7] = 2
•	6 - [5] = 1
The maximum trailing record is 2.
Language
C++
 
Autocomplete Ready
More
1
9
10
11
12
13
14
15
16
17
18
19
20
21
#include <bits/stdc++.h>
 

Complete the 'maxTrailing' function below.

The function is expected to return an INTEGER.
The function accepts INTEGER_ARRAY levels as parameter.


        int maxTrailing(vector<int> levels)
        {

        }

        int main()


Line: 9 Col: 1
Test Results
Custom Input
Run Code
Run Tests
Submit


         */
    }
}
