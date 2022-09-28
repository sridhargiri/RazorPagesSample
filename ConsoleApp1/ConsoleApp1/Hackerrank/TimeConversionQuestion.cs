using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
    Given a time in -hour AM/PM format, convert it to military (24-hour) time.

Note: - 12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
- 12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock.

Example


Return '12:01:00'.


Return '00:01:00'.

Function Description

Complete the timeConversion function in the editor below. It should return a new string representing the input time in 24 hour format.

timeConversion has the following parameter(s):

string s: a time in  hour format
Returns

string: the time in  hour format
Input Format

A single string  that represents a time in hh:mm:ss am/pm.

Constraints

All input times are valid
Sample Input 0

07:05:45PM
Sample Output 0

19:05:45


    Problem: https://www.hackerrank.com/challenges/time-conversion/problem
    C# Language Version: 6.0
    .Net Framework Version: 4.7
    Tool Version : Visual Studio Community 2017
    Thoughts :
    1. Get the input 12 hour format time string. Let the string be s.
    2. Get the hour component of time by extracting first two characters of string s. Let it be h.
    3. Let the remainig time component after removing h (obtained in step # 2) from s above be r.
    4. If input string s is in AM format and h is equal to "12" then set h = "00".
    5. If input string s is in PM format and h is not equal to "12" then - add 12 to numerical value of h and set it back to h as a string. 
    6. Append r to h and print it on console.
    Time Complexity:  O(1)
    Space Complexity: O(1) //number of dynamically allocated variables remain constant for any input.

    solution link
    https://github.com/RyanFehr/HackerRank/blob/master/Algorithms/Warmup/Time%20Conversion/Solution.cs
*/
    public class TimeConversionQuestion
    {
        static void Main(String[] args)
        {
            var time = Console.ReadLine();
            var amOrPm = time.Substring(8);
            var hourComponent = time.Substring(0, 2);
            var remainingTimeComponent = time.Substring(2, 6);
            if (amOrPm == "AM" && hourComponent == "12")
            {
                hourComponent = "00";
            }
            else if (amOrPm == "PM")
            {
                var numericHourComponent = int.Parse(hourComponent);
                if (numericHourComponent != 12)
                {
                    hourComponent = Convert.ToString(12 + numericHourComponent);
                }
            }
            Console.WriteLine(hourComponent + remainingTimeComponent);
        }
    }
}
