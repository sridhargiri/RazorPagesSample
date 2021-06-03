using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     * Group multiple occurrence of array elements ordered by first occurrence
Difficulty Level : Easy
 Last Updated : 18 Feb, 2020
Given an unsorted array with repetitions, the task is to group multiple occurrence of individual elements. The grouping should happen in a way that the order of first occurrences of all elements is maintained.
Examples:

Input: arr[] = {5, 3, 5, 1, 3, 3}
Output:        {5, 5, 3, 3, 3, 1}

Input: arr[] = {4, 6, 9, 2, 3, 4, 9, 6, 10, 4}
Output:        {4, 4, 4, 6, 6, 9, 9, 2, 3, 10}
    Simple Solution is to use nested loops. The outer loop traverses array elements one by one. 
    The inner loop checks if this is first occurrence, if yes, then the inner loop prints it and all other occurrences.
    */
    class GroupArrayElements
    {
        static void groupElements(int[] arr, int n)
        {

            // Initialize all elements as not visited  
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                visited[i] = false;
            }

            // Traverse all elements  
            for (int i = 0; i < n; i++)
            {

                // Check if this is first occurrence  
                if (!visited[i])
                {

                    // If yes, print it and all  
                    // subsequent occurrences  
                    Console.Write(arr[i] + " ");
                    for (int j = i + 1; j < n; j++)
                    {
                        if (arr[i] == arr[j])
                        {
                            Console.Write(arr[i] + " ");
                            visited[j] = true;
                        }
                    }
                }
            }
        }
        //        Output:
        //4 4 4 6 6 9 9 2 3 10
        //Time complexity of the above method is O(n2).
        /*
         Binary Search Tree based Method: The time complexity can be improved to O(nLogn) using self-balancing binary search tree like Red-Black Tree or AVL tree. Following is complete algorithm.
1) Create an empty Binary Search Tree (BST). Every BST node is going to contain an array element and its count.
2) Traverse the input array and do following for every element.
……..a) If element is not present in BST, then insert it with count as 0.
……..b) If element is present, then increment count in corresponding BST node.
3) Traverse the array again and do following for every element.
…….. If element is present in BST, then do following
……….a) Get its count and print the element ‘count’ times.
……….b) Delete the element from BST.

Time Complexity of the above solution is O(nLogn).



Hashing based Method: We can also use hashing. The idea is to replace Binary Search Tree with a Hash Map in above algorithm.

Below is Implementation of hashing based solution.
        */
        static void orderedGroup(int[] arr)
        {
            // Creates an empty hashmap 
            Dictionary<int,
                       int> hM = new Dictionary<int,
                                                int>();

            // Traverse the array elements,  
            // and store count for every element in HashMap 
            for (int i = 0; i < arr.Length; i++)
            {
                // Check if element is already in HashMap 
                int prevCount = 0;
                if (hM.ContainsKey(arr[i]))
                    prevCount = hM[arr[i]];

                // Increment count of element element in HashMap  
                if (hM.ContainsKey(arr[i]))
                    hM[arr[i]] = prevCount + 1;
                else
                    hM.Add(arr[i], prevCount + 1);
            }

            // Traverse array again  
            for (int i = 0; i < arr.Length; i++)
            {
                // Check if this is first occurrence 
                int count = 0;
                if (hM.ContainsKey(arr[i]))
                    count = hM[arr[i]];
                if (count != 0)
                {
                    // If yes, then print the 
                    // element 'count' times 
                    for (int j = 0; j < count; j++)
                        Console.Write(arr[i] + " ");

                    // And remove the element from HashMap. 
                    hM.Remove(arr[i]);
                }
            }
        }
        /*
 https://www.geeksforgeeks.org/group-occurrences-characters-according-first-appearance/
        Group all occurrences of characters according to first appearance
Difficulty Level : Easy
 Last Updated : 26 Aug, 2019
Given a string of lowercase characters, the task is to print the string in a manner such that a character comes first in string displays first with all its occurrences in string.

Examples:

Input : str = "geeksforgeeks"
Output:  ggeeeekkssfor
Explanation: In the given string 'g' comes first 
and occurs 2 times so it is printed first
Then 'e' comes in this string and 4 times so 
it gets printed. Similarly remaining string is
printed.

Input :  str = "occurrence"
output : occcurreen 

Input  : str = "cdab"
Output : cdab
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
This problem is a string version of following problem for array of integers.

Group multiple occurrence of array elements ordered by first occurrences

Since given strings have only 26 possible characters, it is easier to implement for strings.




Implementation:
1- Count the occurrence of all the characters in given string using an array of size 26.
2- Then start traversing the string. Print every character its count times.
        */

        // Since only lower case  
        // characters are there 
        static int MAX_CHAR = 26;

        // Method to print  
        // the string 
        static void printGrouped(String str)
        {
            int n = str.Length;

            // Initialize counts of 
            // all characters as 0 
            int[] count = new int[MAX_CHAR];

            // Count occurrences of  
            // all characters in string 
            for (int i = 0; i < n; i++)
                count[str[i] - 'a']++;

            // Starts traversing 
            // the string 
            for (int i = 0; i < n; i++)
            {
                // Print the character  
                // till its count in 
                // hash array 
                while (count[str[i] - 'a'] != 0)
                {
                    Console.Write(str[i]);
                    count[str[i] - 'a']--;
                }

                // Make this character's  
                // count value as 0. 
                count[str[i] - 'a'] = 0;
            }
        }
        /* Driver code */
        public static void Main(String[] args)
        {
            int[] arr = { 4, 6, 9, 2, 3, 4, 9, 6, 10, 4 };
            int n = arr.Length;
            groupElements(arr, n);
            //output 4 4 4 6 6 9 9 2 3 10
            Console.WriteLine();

            int[] arr1 = { 10, 5, 3, 10, 10, 4, 1, 3 };
            orderedGroup(arr1);
            Console.WriteLine();
            //outpput 10 10 10 5 3 3 4 1
            string str = "geeksforgeeks";
            printGrouped(str);
            //Output:
            //ggeeeekkssfor
        }
    }
}
