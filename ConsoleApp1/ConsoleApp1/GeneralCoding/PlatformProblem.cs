﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	/*
	 Efficient Solution:
https://www.geeksforgeeks.org/minimum-number-platforms-required-railwaybus-station/
https://www.geeksforgeeks.org/minimum-number-platforms-required-railwaybus-station-set-2-map-based-approach/
Approach: The idea is to consider all events in sorted order. Once the events are in sorted order, trace the number of trains at any time keeping track of trains that have arrived, but not departed.
For example consider the above example.

arr[]  = {9:00,  9:40, 9:50,  11:00, 15:00, 18:00}
dep[]  = {9:10, 12:00, 11:20, 11:30, 19:00, 20:00}

All events are sorted by time.
Total platforms at any time can be obtained by
subtracting total departures from total arrivals
by that time.

 Time      Event Type     Total Platforms Needed 
                               at this Time                               
 9:00       Arrival                  1
 9:10       Departure                0
 9:40       Arrival                  1
 9:50       Arrival                  2
 11:00      Arrival                  3 
 11:20      Departure                2
 11:30      Departure                1
 12:00      Departure                0
 15:00      Arrival                  1
 18:00      Arrival                  2 
 19:00      Departure                1
 20:00      Departure                0

Minimum Platforms needed on railway station 
= Maximum platforms needed at any time 
= 3  
Note: This approach assumes that trains are arriving and departing on the same date.

Algorithm:
1. Sort the arrival and departure time of trains.
2. Create two pointers i=0, and j=0 and a variable to store ans and current count plat
3. Run a loop while i<n and j<n and compare the ith element of arrival array and jth element of departure array.
4. if the arrival time is less than or equal to departure then one more platform is needed so increase the count, i.e. plat++ and increment i
   Else if the arrival time greater than departure then one less platform is needed so decrease the count, i.e. plat++ and increment j
   Update the ans, i.e ans = max(ans, plat).

Implementation: This doesn’t create a single sorted list of all events, rather it individually sorts arr[] and dep[] arrays, and then uses merge process of merge sort to process them together as a single sorted array.
	 */

	class PlatformProblem
	{

		// Returns minimum number of platforms 
		// reqquired 
		static int findPlatform(int[] arr,
								int[] dep, int n)
		{

			// Sort arrival and departure arrays 
			Array.Sort(arr);
			Array.Sort(dep);

			// plat_needed indicates number of 
			// platforms needed at a time 
			int plat_needed = 1, result = 1;
			int i = 1, j = 0;

			// Similar to merge in merge sort 
			// to process all events in sorted 
			// order 
			while (i < n && j < n)
			{

				// If next event in sorted order 
				// is arrival, increment count 
				// of platforms needed 
				if (arr[i] <= dep[j])
				{
					plat_needed++;
					i++;
				}

				// Else decrement count of 
				// platforms needed 
				else if (arr[i] > dep[j])
				{
					plat_needed--;
					j++;
				}

				// Update result if needed 
				if (plat_needed > result)
					result = plat_needed;
			}

			return result;
		}

		// Driver program to test methods of 
		// graph class 
		public static void Main()
		{
			int[] arr = { 900, 940, 950, 1100,
					1500, 1800 };
			int[] dep = { 910, 1200, 1120, 1130,
					1900, 2000 };
			int n = arr.Length;
			Console.Write("Minimum Number of "
						+ " Platforms Required = "
						+ findPlatform(arr, dep, n));
		}
	}

	// This code os contributed by nitin mittal. 

}
