using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{

    /*
     Authority partners codility 1 apr 2021

     */
    class AuthorityPartners
    {
        /*
         

An array is called "switching" if the odd and even elements are equal.

Example:
[3,-7,3,-7,3] and [4,4,4] are switching
[2,4,2,4] is a switching array because the members in even positions (indexes 0 and 2) and odd positions (indexes 1 and 3) are equal.
negative case
        [-3,2,3] will return zero (if no switching array found return 2
If A = [3,7,3,7, 2, 1, 2], the switching sub-arrays are:

== > [3,7,3,7] and [2,1,2]

Therefore, the longest switching sub-array is [3,7,3,7] with length = 4.

As another example if A = [1,5,6,0,1,0], the the only switching sub-array is [0,1,0].

Another example: A= [7,-5,-5,-5,7,-1,7], the switching sub-arrays are [7,-1,7] and [-5,-5,-5].

Question:

Write a function that receives an array and find its longest switching sub-array.

I would like to know how you solve this problem and which strategies you use to solve this with a good time complexity?
        below solution taken from 
        https://stackoverflow.com/questions/58357037/the-longest-sub-array-with-switching-elements
        */
        static int Switching(int[] arr)
        {
            if (arr.Length == 1) return 1;
            int even = arr[0], odd = arr[1];
            int start = 0, max_len = 0;
            for (int i = 2; i < arr.Length; ++i)
            {
                if (i % 2 == 0 && arr[i] != even || i % 2 == 1 && arr[i] != odd)
                {
                    max_len = Math.Max(max_len, i - start);
                    start = i - 1;
                    if (i % 2 == 0)
                    {
                        even = arr[i];
                        odd = arr[i - 1];
                    }
                    else
                    {
                        even = arr[i - 1];
                        odd = arr[i];
                    }
                }
            }


            return Math.Max(max_len, arr.Length - start);
        }
        /*
         If given an array A consisting of N integers, how can I return the size of the largest possible subset of A such that its AND product is greater than 0???
        I am inputting an array of N size = {13,7,2,8,3}, output should be 3
        AND between 12 and 21, we get 4
01100 (12)
10101 (21)
------------
00100 (4)
--------

further ANDing with 00100 we get same 00100
samples [1,2,4,8] returns 1, [16,16] returns 2
         */
        static int findLargestSubset(int[] values)
        {
            if (values.Length > 30)
                throw new ArgumentException("Too many values");

            // Iterate all subsets (permutations), except the empty subset
            int maxSubsetSize = 0;
            int subsetCount = 1 << values.Length;
            for (int subsetMask = 1; subsetMask < subsetCount; subsetMask++)
            {

                // 'AND' all values in the subset
                int result = -1; // all bits set
                for (int i = 0; i < values.Length; i++)
                    if ((subsetMask & (1 << i)) != 0) // value is in subset
                        result &= values[i];

                // Check subset size if result is non-zero
                if (result != 0)
                {
                    int subsetSize = countSetBits(subsetMask);
                    if (subsetSize > maxSubsetSize)
                        maxSubsetSize = subsetSize;
                }
            }
            return maxSubsetSize;
        }
        /*
         * C# Program for Count set bits in an integer
Last Updated : 02 Jan, 2019
Write an efficient program to count number of 1s in binary representation of an integer.

Examples :

Input : n = 6
Output : 2
Binary representation of 6 is 110 and has 2 set bits

Input : n = 13
Output : 3
Binary representation of 11 is 1101 and has 3 set bits
         1. Simple Method Loop through all bits in an integer, check if a bit is set and if it is then increment the set bit count. See below program.
        */
        static int countSetBits(int n)
        {
            int count = 0;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }
        static void Main(string[] args)
        {
            int[] array = { 1, 5, 6, 0, 1, 0 };
            Console.WriteLine(Switching(array));
            int[] arr = { 13, 7, 2, 8, 3 };
            Console.WriteLine(findLargestSubset(arr));
        }

        /*
Task 3 in SQL

2 tables given buses and passengers

create table buses(
id int primary key,
origin varchar(10) not null,
destination varchar(10) not null,
[time] varchar(10) not null)
CREATE UNIQUE NONCLUSTERED INDEX IX_Subscriber_Email
   ON buses (origin, destination,[time]);

   create table passengers(
   id int primary key,
origin varchar(10) not null,
destination varchar(10) not null,
[time] varchar(10) not null)

insert into buses values
(10,'Warsaw','Berlin','10:55'),
(20,'Berlin','Paris','06:20'),
(21,'Berlin','Paris','14:00'),
(22,'Berlin','Paris','21:40'),
(30,'Paris','Madrid','13:30')

insert into passengers values
(1,'Paris','Madrid','13:30'),
(2,'Paris','Madrid','13:31'),
(10,'Warsaw','Paris','10:00'),
(11,'Warsaw','Berlin','22:31'),
(40,'Berlin','Paris','06:15'),
(41,'Berlin','Paris','06:50'),
(42,'Berlin','Paris','07:12'),
(43,'Berlin','Paris','12:03'),
(44,'Berlin','Paris','20:50')

each row of the table bus has data about origin, destination  and departure time. Passenger data row represent a passenger travelling from / to and the time they arrive at departure station
passengers will board  earliestp ossible bus tha travels directly to the destination. passenger can still board a bus if it departs in the same minute that they arrive at departure station
all passengers who are still at the station at 23:59 and dont board any of the buses will leave the platform without taking any bus

You can assume no two buses with same origin and  destination depart at the same time
write a query such that for each bus  return its id and no of passengers on board ordered by bus id asc
Time is a  string hh:mm

for the above data the output shall be
id	passengers
--	----------
10	0
20	1
21	3
22	1
30	1


second example

insert into buses values
(100,'Munich','Rome','10:55'),
(200,'Munich','Rome','06:20'),
(300,'Munich','Rome','14:00')

insert into passengers values
(1,'Munich','Rome','10:01'),
(2,'Munich','Rome','11:30'),
(3,'Munich','Rome','11:30'),
(4,'Munich','Rome','12:03'),
(5,'Munich','Rome','13:00')

output

id	passengers
--	----------
100	5
200	0
300	0

        ; WITH will_catch AS (
    SELECT p.id  pid, MIN(CAST(t.time AS TIME)) AS t_deptime
    FROM passengers p
    LEFT JOIN buses t ON t.origin = p.origin AND t.destination = p.destination
        AND CAST(t.time AS TIME) >= CAST(p.time AS TIME)
    GROUP BY p.id
)
SELECT t.id, COUNT(t_deptime)
FROM buses t
LEFT JOIN will_catch wc
on wc.t_deptime = CAST(t.time AS TIME)
GROUP BY t.id order by t.id

*/
    }
}
