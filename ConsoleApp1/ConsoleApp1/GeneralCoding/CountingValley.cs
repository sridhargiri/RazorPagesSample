using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     An avid hiker keeps meticulous records of their hikes. During the last hike that took exactly  steps, for every step it was noted if it was an uphill, , or a downhill,  step. Hikes always start and end at sea level, and each step up or down represents a  unit change in altitude. We define the following terms:
  •	A mountain is a sequence of consecutive steps above sea level, starting with a step up from sea level and ending with a step down to sea level.
  •	A valley is a sequence of consecutive steps below sea level, starting with a step down from sea level and ending with a step up to sea level.
  Given the sequence of up and down steps during a hike, find and print the number of valleys walked through.
  Example

  The hiker first enters a valley  units deep. Then they climb out and up onto a mountain  units high. Finally, the hiker returns to sea level and ends the hike.
  Function Description
  Complete the countingValleys function in the editor below.
  countingValleys has the following parameter(s):
  •	int steps: the number of steps on the hike
  •	string path: a string describing the path
  Returns
  •	int: the number of valleys traversed
  Input Format
  The first line contains an integer , the number of steps in the hike.
  The second line contains a single string , of  characters that describe the path.
  Constraints
  •	
  •	
  Sample Input
  8
  UDDDUDUU
  Sample Output
  1
  Explanation
  If we represent _ as sea level, a step up as /, and a step down as \, the hike can be drawn as:
  _/\      _
     \    /
      \/\/
  The hiker enters and leaves one valley.
https://www.hackerrank.com/challenges/counting-valleys/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=7-day-campaign
     */
    public class CountingValley
    {
        public static void countValleyHackerrank(String str)
        {
            int currLevel = 0;
            int valley = 0;
            bool isFound = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'U')
                {
                    currLevel++;
                }
                else
                {
                    currLevel--;
                }
                if (currLevel < 0)
                {
                    isFound = true;
                }
                if (currLevel >= 0 && isFound)
                {
                    isFound = false;
                    valley++;
                }
            }
            Console.WriteLine(valley);
        }
        static void Main(string[] args)
        {
            string s = "UDDDUDUU";
            countValleyHackerrank(s);
        }
    }
    /*
    Equalize the Array


Given an array of integers, determine the minimum number of elements to delete to leave only elements of equal value.

Example

Arr = [1,2,2,3]

Delete the 2 elements 1 and 3 leaving arr=[2,2]. If both twos plus either the 1 or 3  are deleted, it takes 3 deletions to leave either [3] or [1]. The minimum number of deletions is 2.

    */
    public class EqualiseArray
    {
        static void Main(string[] args)
        {
            int[] counts = new int[101];
            int[] array = { 1,2,2,3};
            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i]]++;
            }
            Array.Sort(counts);
        }
    }
}
