/*
 * Find the day of the week after K days from the given day
 * 
Days of the week are represented as three-letter strings ("Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"). 
Write a javaScript function solution that, given a string S representing the day of the week and an integer K (between 0 and 500), 
returns the day of the week that is K days later. 
For example, given S = "Wed" and K = 2, the function should return "Fri". 
Given S = "Sat" and K = 23, the function should return "Mon".

Microsoft vendor Zen3 infosolutions asked 
*/
using System;
using System.Collections.Generic;
class KDaysAfterWeekday
{

    public static String dayFind(String newDay, int k)
    {

        // Create an array with 
        // days of the week 
        List<String> days = new List<String>();

        days.Add("Monday");
        days.Add("Tuesday");
        days.Add("Wednesday");
        days.Add("Thursday");
        days.Add("Friday");
        days.Add("Saturday");
        days.Add("Sunday");

        // Find index of current 
        // day in days array 
        int index = days.IndexOf(newDay);

        // return readonly day 
        return days[(index + k) % 7];
    }

    // Driver Code 
    public static void Main(String[] args)
    {
        String str = "Monday";

        Console.WriteLine(dayFind(str, 3));
    }
}

// This code is contributed by Rajput-Ji 
