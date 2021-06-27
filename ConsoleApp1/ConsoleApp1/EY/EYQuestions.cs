using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class GetAuthorArticles
    {
        //Q3.docx
        //see homeController.cs for Question 3 GetAuthorArticles
    }
    public class DoubleOnMatch
    {
        //Q1.docx

        /*
https://www.geeksforgeeks.org/find-final-value-if-we-double-after-every-successful-search-in-array/
Find final value if we double after every successful search in array
Difficulty Level : Basic
Last Updated : 07 Apr, 2021
Given an array and an integer k, traverse the array and if the element in array is k, double the value of k and continue traversal. In the end return value of k.
Examples: 

Input : arr[] = { 2, 3, 4, 10, 8, 1 }, k = 2
Output: 16
Explanation:
First k = 2 is found, then we search for 4
which is also found, then we search for 8
which is also found, then we search for 16.
 
Input : arr[] = { 2, 4, 5, 6, 7 }, k = 3
Output: 3
        */
        static int findValue(int[] arr, int n, int k)
        {

            // Search for k. After every successful
            // search, double k.
            for (int i = 0; i < n; i++)
                if (arr[i] == k)
                    k *= 2;

            return k;
        }

        // Driver Code
        public static void Main()
        {
            int[] arr = { 2, 3, 4, 10, 8, 1 };
            int k = 2;
            int n = arr.Length;

            Console.WriteLine(findValue(arr, n, k));
            // Output: 16
        }
    }
    public class CountingClosedPaths
    {
        //Q2.docx
        //Global array for hole values

        /*
https://www.geeksforgeeks.org/count-the-number-of-holes-in-an-integer/
Count the number of holes in an integer
Difficulty Level : Basic
Last Updated : 29 Apr, 2021
Given an integer num, the task is to count the number of holes in that number. The holes in each digit are given below: 
 

Digit	Number of Holes
0	1
1	0
2	0
3	0
4	1
5	0
6	1
7	0
8	2
9	1
Examples: 
 

Input: num = 6457819 
Output: 5
Input: num = 2537312 
Output: 0 
 

 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
 
Approach: Initialize holes = 0 and an array hole[] with the values given where hole[i] stores the number of holes in the digit i. Now, for every digit d in num update holes = holes + hole[d]. Print the holes in the end.
Below is the implementation of the above approach:
        */
        static int[] hole = { 1, 0, 0, 0, 1, 0, 1, 0, 2, 1 };

        // Function to return the count
        // of holes in num
        static int countHoles(int num)
        {
            int holes = 0;

            while (num > 0)
            {

                // Last digit in num
                int d = num % 10;

                // Update holes
                holes += hole[d];

                // Remove last digit
                num /= 10;
            }

            // Return the count of holes
            // in the original num
            return holes;
        }

        // Driver code
        public static void Main()
        {
            int num = 6457819;
            Console.WriteLine(countHoles(num));
            // output is 5
        }
    }
    public class LeastEarningLocations
    {
        /*
Q3.docx
        https://stackoverflow.com/questions/60984221/sql-least-earning-location-count
        SQL Least Earning Location Count
        I am using an online editor to solve query

https://www.jdoodle.com/execute-sql-online/

have the following SQL Table

create table CITIES(id int, name String);
create table USERS(id int, city_id String, name String, email);
create table RIDES(id int, user_id int, distance int, fare int);

INSERT INTO CITIES (id, name) VALUES
(1,"Cooktown"),
(2,"South Suzanne");

INSERT INTO USERS (id, city_id, name, email) VALUES
(1,2,"a","email"),
(2,2,"b","email"),
(3,1,"c","email"),
(4,1,"d","email"),
(5,1,"e","email"),
(5,1,"f","email");

INSERT INTO RIDES (id, user_id, distance, fare) VALUES
(1,1,21,200),
(2,3,6,55),
(3,2,30,230),
(4,2,16,125),
(5,2,11,110),
(6,6,30,285),
(7,3,18,170),
(8,1,6,50),
(9,2,4,40),
(10,1,10,90),
(11,5,11,95),
(12,5,16,140),
(13,4,24,220),
(14,6,17,160),
(15,2,23,205),
(16,2,11,90),
(17,6,5,50),
(18,3,19,180),
(19,5,22,205),
(20,4,6,60);
Output should be :

South Suzanne 1050

Cooktown 1710

SELECT c.name, SUM(r.fare)
FROM CITIES c
  LEFT JOIN USERS u ON c.id=u.city_id 
  LEFT JOIN RIDES r ON u.id=r.user_id
GROUP BY c.name
ORDER BY SUM(r.fare) ASC;
        */
    }
}
