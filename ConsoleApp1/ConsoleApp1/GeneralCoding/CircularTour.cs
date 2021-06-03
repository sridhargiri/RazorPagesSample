using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/find-a-tour-that-visits-all-stations/
    Find the first circular tour that visits all petrol pumps
Difficulty Level : Hard
Last Updated : 19 May, 2021
Suppose there is a circle. There are n petrol pumps on that circle. You are given two sets of data.
 

The amount of petrol that every petrol pump has.
Distance from that petrol pump to the next petrol pump.
Calculate the first point from where a truck will be able to complete the circle (The truck will stop at each petrol pump and it has infinite capacity). Expected time complexity is O(n). Assume for 1-litre petrol, the truck can go 1 unit of distance.
For example, let there be 4 petrol pumps with amount of petrol and distance to next petrol pump value pairs as {4, 6}, {6, 5}, {7, 3} and {4, 5}. The first point from where the truck can make a circular tour is 2nd petrol pump. Output should be “start = 1” (index of 2nd petrol pump).
 

Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
A Simple Solution is to consider every petrol pumps as a starting point and see if there is a possible tour. If we find a starting point with a feasible solution, we return that starting point. The worst case time complexity of this solution is O(n^2).
An efficient approach is to use a Queue to store the current tour. We first enqueue first petrol pump to the queue, we keep enqueueing petrol pumps till we either complete the tour, or the current amount of petrol becomes negative. If the amount becomes negative, then we keep dequeuing petrol pumps until the queue becomes empty.
Instead of creating a separate queue, we use the given array itself as a queue. We maintain two index variables start and end that represent the rear and front of the queue. 
Below image is a dry run of the above approach:
    https://media.geeksforgeeks.org/wp-content/cdn-uploads/20190626142203/CircularTour1.png
     */
    // A petrol pump has petrol and
    // distance to next petrol pump
    public class PetrolPump
    {
        public int petrol;
        public int distance;

        // constructor
        public PetrolPump(int petrol,
                          int distance)
        {
            this.petrol = petrol;
            this.distance = distance;
        }
    }
    class CircularTour
    {

        // The function returns starting point
        // if there is a possible solution,
        // otherwise returns -1
        public static int printTour(PetrolPump[] arr,
                                    int n)
        {
            int start = 0;
            int end = 1;
            int curr_petrol = arr[start].petrol -
                              arr[start].distance;

            // If current amount of petrol in 
            // truck becomes less than 0, then
            // remove the starting petrol pump from tour
            while (end != start || curr_petrol < 0)
            {

                // If current amount of petrol in
                // truck becomes less than 0, then
                // remove the starting petrol pump from tour
                while (curr_petrol < 0 && start != end)
                {
                    // Remove starting petrol pump.
                    // Change start
                    curr_petrol -= arr[start].petrol -
                                   arr[start].distance;
                    start = (start + 1) % n;

                    // If 0 is being considered as
                    // start again, then there is no
                    // possible solution
                    if (start == 0)
                    {
                        return -1;
                    }
                }

                // Add a petrol pump to current tour
                curr_petrol += arr[end].petrol -
                               arr[end].distance;

                end = (end + 1) % n;
            }

            // Return starting point
            return start;
        }

        // Driver Code
        public static void Main(string[] args)
        {
            PetrolPump[] arr = new PetrolPump[]
            {
            new PetrolPump(6, 4),
            new PetrolPump(3, 6),
            new PetrolPump(7, 3)
            };

            int start = printTour(arr, arr.Length);

            Console.WriteLine(start == -1 ? "No Solution" :
                                       "Start = " + start);
            /*
             Output: 

start = 2
Time Complexity: We are visiting each petrol pump exactly once, therefore the time complexity is O(n)

Auxiliary Space: O(1)
            */
        }
    }
    /*
     Another efficient solution can be to find out the first petrol pump where the amount of petrol is greater than or equal to the distance to be covered to reach the next petrol pump. Now we mark that petrol pump as start and now we check whether we can finish the journey towards the end point. If in the middle, at any petrol pump, the amount of petrol is less than the distance to be covered to reach the next petrol pump, then we can say we cannot complete the circular tour from start. We again try to find out the next point from where we can start our journey i.e. the next petrol pump where the amount of petrol is greater than or equal to the distance to be covered and we mark it as start. We need not look at any petrol pump in between the initial petrol pump marked as start and and the new start as we know that we cannot complete the journey if we start from any middle petrol pump because eventually we will arrive at a point where amount of petrol is less than the distance. Now we repeat the process until we reach the last petrol pump and update our start as and when required. After we reach our last petrol pump, we try to reach our first petrol pump from the last and let’s say we have a remaining amount of petrol as curr_petrol. Now we again start travelling from the first petrol pump and take the advantage of our curr_petrol and try to reach the start. If we can reach the start, then we may conclude that start can be our starting point.

Below is the implementation of the above approach:
    */
    class CircularTourPetrolPump
    {
        static int printTour(PetrolPump[] arr, int n)
        {
            int start = 0;

            for (int j = 0; j < n; j++)
            {
                // Identify the first petrol pump from where we
                // might get a full circular tour
                if (arr[j].petrol >= arr[j].distance)
                {
                    start = j;
                    break;
                }
            }

            // To store the excess petrol
            int curr_petrol = 0;

            int i;

            for (i = start; i < n;)
            {

                curr_petrol += (arr[i].petrol - arr[i].distance);

                // If at any point remaining petrol is less than 0,
                // it means that we cannot start our journey from
                // current start
                if (curr_petrol < 0)
                {

                    // We move to the next petrol pump
                    i++;

                    // We try to identify the next petrol pump from
                    // where we might get a full circular tour
                    for (; i < n; i++)
                    {
                        if (arr[i].petrol >= arr[i].distance)
                        {

                            start = i;

                            // Reset rem_petrol
                            curr_petrol = 0;

                            break;
                        }
                    }
                }

                else
                {
                    // Move to the next petrolpump if curr_petrol is
                    // >= 0
                    i++;
                }
            }

            // If remaining petrol is less than 0 while we reach the
            // first petrol pump, it means no circular tour is
            // possible
            if (curr_petrol < 0)
            {
                return -1;
            }

            for (int j = 0; j < start; j++)
            {

                curr_petrol += (arr[j].petrol - arr[j].distance);

                // If remaining petrol is less than 0 at any point
                // before we reach initial start, it means no
                // circular tour is possibl
                if (curr_petrol < 0)
                {
                    return -1;
                }
            }

            // If we have successfully reached intial_start, it
            // means can get a circular tour from final_start, hence
            // return it
            return start;
        }
        static void Main(string[] args)
        {

            PetrolPump[] arr = new PetrolPump[]
            {
            new PetrolPump(6, 4),
            new PetrolPump(3, 6),
            new PetrolPump(7, 3)
            };

            int start = printTour(arr, arr.Length);

            Console.WriteLine(start == -1 ? "No Solution" :
                                       "Start = " + start);
            /*
             Output:

start = 2
Time Complexity: O(n)

Auxiliary Space: O(1)
            */
        }
    }
}
