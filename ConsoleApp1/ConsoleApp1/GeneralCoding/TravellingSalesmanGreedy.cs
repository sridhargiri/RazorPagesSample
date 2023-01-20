using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class TravellingSalesmanGreedy
    {
        /*
         https://www.geeksforgeeks.org/travelling-salesman-problem-greedy-approach/
        Travelling Salesman Problem | Greedy Approach
Difficulty Level : Medium
Last Updated : 29 Dec, 2020
Given a 2D matrix tsp[][], where each row has the array of distances from that indexed city to all the other cities and -1 denotes that there doesn’t exist a path between those two indexed cities. The task is to print minimum cost in TSP cycle.
Examples: 

Input: 
tsp[][] = {{-1, 10, 15, 20}, 
{10, -1, 35, 25}, 
{15, 35, -1, 30}, 
{20, 25, 30, -1}}; 
Below is the given graph: 
 



Output: 80 
Explanation: 
We are trying to find out the path/route with the minimum cost such that our aim of visiting all cities once and return back to the source city is achieved. The path through which we can achieve that, can be represented as 1 -> 2 -> 4 -> 3 -> 1. Here, we started from city 1 and ended on the same visiting all other cities once on our way. The cost of our path/route is calculated as follows: 
1 -> 2 = 10 
2 -> 4 = 25 
4 -> 3 = 30 
3 -> 1 = 15 
(All the costs are taken from the given 2D Array) 
Hence, total cost = 10 + 25 + 30 + 15 = 80
Input: 
tsp[][] = {{-1, 30, 25, 10}, 
{15, -1, 20, 40}, 
{10, 20, -1, 25}, 
{30, 10, 20, -1}}; 
Output: 50 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
We introduced Travelling Salesman Problem and discussed Naive and Dynamic Programming Solutions for the problem in the previous post. Both of the solutions are infeasible. In fact, there is no polynomial-time solution available for this problem as the problem is a known NP-Hard problem. There are approximate algorithms to solve the problem though. 
This problem can be related to the Hamiltonian Cycle problem, in a way that here we know a Hamiltonian cycle exists in the graph, but our job is to find the cycle with minimum cost. Also, in a particular TSP graph, there can be many hamiltonian cycles but we need to output only one that satisfies our required aim of the problem.
Approach: This problem can be solved using Greedy Technique. Below are the steps: 



Create two primary data holders: 
A list that holds the indices of the cities in terms of the input matrix of distances between cities.
Result array which will have all cities that can be displayed out to the console in any manner.
Perform traversal on the given adjacency matrix tsp[][] for all the city and if the cost of the reaching any city from current city is less than current cost the update the cost.
Generate the minimum path cycle using the above step and return there minimum cost.
Below is the implementation of the above approach:
         */
        static void findMinRoute(int[,] tsp)
        {
            int sum = 0;
            int counter = 0;
            int j = 0, i = 0;
            int min = int.MaxValue;

            List<int> visitedRouteList = new List<int>();

            // Starting from the 0th indexed
            // city i.e., the first city
            visitedRouteList.Add(0);
            int[] route = new int[tsp.Length];

            // Traverse the adjacency
            // matrix tsp[,]
            while (i < tsp.GetLength(0) &&
                   j < tsp.GetLength(1))
            {

                // Corner of the Matrix
                if (counter >= tsp.GetLength(0) - 1)
                {
                    break;
                }

                // If this path is unvisited then
                // and if the cost is less then
                // update the cost
                if (j != i &&
                    !(visitedRouteList.Contains(j)))
                {
                    if (tsp[i, j] < min)
                    {
                        min = tsp[i, j];
                        route[counter] = j + 1;
                    }
                }
                j++;

                // Check all paths from the
                // ith indexed city
                if (j == tsp.GetLength(0))
                {
                    sum += min;
                    min = int.MaxValue;
                    visitedRouteList.Add(route[counter] - 1);

                    j = 0;
                    i = route[counter] - 1;
                    counter++;
                }
            }

            // Update the ending city in array
            // from city which was last visited
            i = route[counter - 1] - 1;

            for (j = 0; j < tsp.GetLength(0); j++)
            {
                if ((i != j) && tsp[i, j] < min)
                {
                    min = tsp[i, j];
                    route[counter] = j + 1;
                }
            }
            sum += min;

            // Started from the node where
            // we finished as well.
            Console.Write("Minimum Cost is : ");
            Console.WriteLine(sum);
        }

        // Driver Code
        public static void Main(String[] args)
        {

            // Input Matrix
            int[,] tsp = { { -1, 10, 15, 20 },
                   { 10, -1, 35, 25 },
                   { 15, 35, -1, 30 },
                   { 20, 25, 30, -1 } };

            // Function call
            findMinRoute(tsp);
            /*
             Output
Minimum Cost is : 80
Time Complexity: O(N2*log2N) 
Auxiliary Space: O(N)
            */
        }
        //https://www.geeksforgeeks.org/find-the-person-who-will-finish-last/
        //python
    }
    /*
     https://www.geeksforgeeks.org/travelling-salesman-problem-implementation-using-backtracking/
    Travelling Salesman Problem implementation using BackTracking
    Travelling Salesman Problem (TSP): Given a set of cities and distance between every pair of cities, the problem is to find the shortest possible route that visits every city exactly once and returns back to the starting point.
Note the difference between Hamiltonian Cycle and TSP. The Hamiltonian cycle problem is to find if there exist a tour that visits every city exactly once. Here we know that Hamiltonian Tour exists (because the graph is complete) and in fact many such tours exist, the problem is to find a minimum weight Hamiltonian Cycle. 
For example, consider the graph shown in the figure. A TSP tour in the graph is 1 -> 2 -> 4 -> 3 -> 1. The cost of the tour is 10 + 25 + 30 + 15 which is 80.
The problem is a famous NP hard problem. There is no polynomial time know solution for this problem.
    Output of Given Graph: 
Minimum weight Hamiltonian Cycle : 10 + 25 + 30 + 15 = 80 
    Approach: In this post, implementation of simple solution is discussed. 
 

Consider city 1 (let say 0th node) as the starting and ending point. Since route is cyclic, we can consider any point as starting point.
Start traversing from the source to its adjacent nodes in dfs manner.
Calculate cost of every traversal and keep track of minimum cost and keep on updating the value of minimum cost stored value.
Return the permutation with minimum cost.
Below is the implementation of the above approach: 

     */
    public class TravellingSalesmanBacktracking
    {

        // Function to find the minimum weight Hamiltonian Cycle
        static int tsp(int[,] graph, bool[] v, int currPos,
                int n, int count, int cost, int ans)
        {

            // If last node is reached and it has a link
            // to the starting node i.e the source then
            // keep the minimum value out of the total cost
            // of traversal and "ans"
            // Finally return to check for more possible values
            if (count == n && graph[currPos, 0] > 0)
            {
                ans = Math.Min(ans, cost + graph[currPos, 0]);
                return ans;
            }

            // BACKTRACKING STEP
            // Loop to traverse the adjacency list
            // of currPos node and increasing the count
            // by 1 and cost by graph[currPos,i] value
            for (int i = 0; i < n; i++)
            {
                if (v[i] == false && graph[currPos, i] > 0)
                {

                    // Mark as visited
                    v[i] = true;
                    ans = tsp(graph, v, i, n, count + 1,
                        cost + graph[currPos, i], ans);

                    // Mark ith node as unvisited
                    v[i] = false;
                }
            }
            return ans;
        }

        // Driver code
        static void Main()
        {
            // n is the number of nodes i.e. V
            int n = 4;

            int[,] graph = {
        { 0, 10, 15, 20 },
        { 10, 0, 35, 25 },
        { 15, 35, 0, 30 },
        { 20, 25, 30, 0 }
    };

            // Boolean array to check if a node
            // has been visited or not
            bool[] v = new bool[n];

            // Mark 0th node as visited
            v[0] = true;
            int ans = int.MaxValue;

            // Find the minimum weight Hamiltonian Cycle
            ans = tsp(graph, v, 0, n, 1, 0, ans);

            // ans is the minimum weight Hamiltonian Cycle
            Console.Write(ans);
            /* 
             output 80
             Time Complexity: O(N!), As for the first node there are N possibilities and for the second node there are n – 1 possibilities.
            For N nodes time complexity = N * (N – 1) * . . . 1 = O(N!)
            Auxiliary Space: O(N)
            */
        }
    }
    /*
     https://www.geeksforgeeks.org/travelling-salesman-problem-using-dynamic-programming/
    Travelling Salesman Problem using Dynamic Programming
    Travelling Salesman Problem (TSP): 

Given a set of cities and the distance between every pair of cities, the problem is to find the shortest possible route that visits every city exactly once and returns to the starting point. Note the difference between Hamiltonian Cycle and TSP. 
    The Hamiltonian cycle problem is to find if there exists a tour that visits every city exactly once. Here we know that Hamiltonian Tour exists (because the graph is complete) and in fact, many such tours exist, the problem is to find a minimum weight Hamiltonian Cycle
    For example, consider the graph shown in the figure on the right side. A TSP tour in the graph is 1-2-4-3-1. The cost of the tour is 10+25+30+15 which is 80. The problem is a famous NP-hard problem. There is no polynomial-time know solution for this problem. The following are different solutions for the traveling salesman problem. 


Naive Solution: 

1) Consider city 1 as the starting and ending point.

2) Generate all (n-1)! Permutations of cities. 
3) Calculate the cost of every permutation and keep track of the minimum cost permutation. 

4) Return the permutation with minimum cost. 

Time Complexity: Θ(n!) 

    Dynamic Programming: 

Let the given set of vertices be {1, 2, 3, 4,….n}. Let us consider 1 as starting and ending point of output. For every other vertex I (other than 1), we find the minimum cost path with 1 as the starting point, I as the ending point, and all vertices appearing exactly once. Let the cost of this path cost (i), and the cost of the corresponding Cycle would cost (i) + dist(i, 1) where dist(i, 1) is the distance from I to 1. Finally, we return the minimum of all [cost(i) + dist(i, 1)] values. This looks simple so far. 

Now the question is how to get cost(i)? To calculate the cost(i) using Dynamic Programming, we need to have some recursive relation in terms of sub-problems. 

Let us define a term C(S, i) be the cost of the minimum cost path visiting each vertex in set S exactly once, starting at 1 and ending at i. We start with all subsets of size 2 and calculate C(S, i) for all subsets where S is the subset, then we calculate C(S, i) for all subsets S of size 3 and so on. Note that 1 must be present in every subset.

If size of S is 2, then S must be {1, i},
 C(S, i) = dist(1, i) 
Else if size of S is greater than 2.
 C(S, i) = min { C(S-{i}, j) + dis(j, i)} where j belongs to S, j != i and j != 1.
Below is the dynamic programming solution for the problem using top down recursive+memoized approach:-

For maintaining the subsets we can use the bitmasks to represent the remaining nodes in our subset. Since bits are faster to operate and there are only few nodes in graph, bitmasks is better to use.

For example: –  

10100 represents node 2 and node 4 are left in set to be processed

010010 represents node 1 and 4 are left in subset.

NOTE:- ignore the 0th bit since our graph is 1-based

     */
    /*
     Similar to ON Time Logistics

A traveling salesperson lives in HackerLand, with road_nodes houses and m roads. the ith road runs from house x[i] to house y[i] and has length of t[i], it is not possible to travel from house y[i] to x[i] by this road, i.e. they are directional.

find the minimum length of the journey such that it starts and ends at the salesperson's house at node x. find the answers for x=1,22,..road_nodes. if there is no such path for a particular x, return 0 for that x.

Note- it is guaranteed that there are no multiple roads between 2 houses, but there can be a road that starts and ens at the same house. All the houses may or may not be conencted together

     */
    public class TravellingSalesmanDP
    {

        // there are four nodes in example graph (graph is
        // 1-based)
        static int n = 4;

        // give appropriate maximum to avoid overflow
        static int MAX = 1000000;

        // dist[i][j] represents shortest distance to go from i
        // to j this matrix can be calculated for any given
        // graph using all-pair shortest path algorithms
        static int[,] dist = { { 0, 0, 0, 0, 0 },
                         { 0, 0, 10, 15, 20 },
                         { 0, 10, 0, 25, 25 },
                         { 0, 15, 25, 0, 30 },
                         { 0, 20, 25, 30, 0 } };

        // memoization for top down recursion
        static int[,] memo = new int[(n + 1), (1 << (n + 1))];

        static int fun(int i, int mask)
        {
            // base case
            // if only ith bit and 1st bit is set in our mask,
            // it implies we have visited all other nodes
            // already
            if (mask == ((1 << i) | 3))
                return dist[1, i];

            // memoization
            if (memo[i, mask] != 0)
                return memo[i, mask];

            int res = MAX; // result of this sub-problem

            // we have to travel all nodes j in mask and end the
            // path at ith node so for every node j in mask,
            // recursively calculate cost of travelling all
            // nodes in mask
            // except i and then travel back from node j to node
            // i taking the shortest path take the minimum of
            // all possible j nodes
            for (int j = 1; j <= n; j++)
                if ((mask & (1 << j)) != 0 && j != i && j != 1)
                    res = Math.Min(res,
                                   fun(j, mask & (~(1 << i)))
                                   + dist[j, i]);

            return memo[i, mask] = res;
        }

        // Driver program to test above logic
        public static void Main()
        {
            int ans = MAX;
            for (int i = 1; i <= n; i++)

                // try to go from node 1 visiting all nodes in
                // between to i then return from i taking the
                // shortest route to 1
                ans = Math.Min(ans, fun(i, (1 << (n + 1)) - 1)
                               + dist[i, 1]);

            Console.WriteLine("The cost of most efficient tour = " + ans);
            /*
             Output
The cost of most efficient tour = 80
For a set of size n, we consider n-2 subsets each of size n-1 such that all subsets don’t have nth in them. 
            Using the above recurrence relation, we can write a dynamic programming-based solution. 
            There are at most O(n*2n) subproblems, and each one takes linear time to solve. 
            The total running time is therefore O(n2*2n). The time complexity is much less than O(n!) but still exponential. 
            The space required is also exponential. So this approach is also infeasible even for a slightly higher number of vertices. 
            We will soon be discussing approximate algorithms for the traveling salesman problem.
            */
        }
    }


}
