using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Minimum Swaps for Bracket Balancing
Difficulty Level : Hard
 Last Updated : 21 Dec, 2020
You are given a string of 2N characters consisting of N ‘[‘ brackets and N ‘]’ brackets. A string is considered balanced if it can be represented in the for S2[S1] where S1 and S2 are balanced strings. We can make an unbalanced string balanced by swapping adjacent characters. Calculate the minimum number of swaps necessary to make a string balanced.

Examples: 

Input  : []][][
Output : 2
First swap: Position 3 and 4
[][]][
Second swap: Position 5 and 6
[][][]

Input  : [[][]]
Output : 0
The string is already balanced.
Recommended: Please solve it on “PRACTICE ” first, before moving on to the solution. 
 
We can solve this problem by using greedy strategies. If the first X characters form a balanced string, we can neglect these characters and continue on. If we encounter a ‘]’ before the required ‘[‘, then we must start swapping elements to balance the string.

Naive Approach 
Initialize sum = 0 where sum stores result. Go through the string maintaining a count of the number of ‘[‘ brackets encountered. Reduce this count when we encounter a ‘]’ character. If the count hits negative, then we must start balancing the string. 
Let index ‘i’ represents the position we are at. We now move forward to the next ‘[‘ at index j. Increase sum by j – i. Move the ‘[‘ at position j, to position i, and shift all other characters to the right. Set the count back to 0 and continue traversing the string. In the end, ‘sum’ will have the required value.

Time Complexity = O(N^2) 
Extra Space = O(1)




Optimized approach 
We can initially go through the string and store the positions of ‘[‘ in a vector say ‘pos‘. Initialize ‘p’ to 0. We shall use p to traverse the vector ‘pos’. Similar to the naive approach, we maintain a count of encountered ‘[‘ brackets. When we encounter a ‘[‘ we increase the count and increase ‘p’ by 1. When we encounter a ‘]’ we decrease the count. If the count ever goes negative, this means we must start swapping. The element pos[p] tells us the index of the next ‘[‘. We increase the sum by pos[p] – i, where i is the current index. We can swap the elements in the current index and pos[p] and reset the count to 0 and increment p so that it pos[p] indicates to the next ‘[‘.
Since we have converted a step that was O(N) in the naive approach, to an O(1) step, our new time complexity reduces. 

Time Complexity = O(N) 
Extra Space = O(N)
    */
    class MinSwapBracketBalancing
    {

        // Function to calculate swaps required
        static long swapCount(string s)
        {

            // Keep track of '['
            List<int> pos = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '[')
                {
                    pos.Add(i);
                }
            }

            // To count number of encountered '['
            int count = 0;

            // To track position of next '[' in pos
            int p = 0;

            // To store result
            long sum = 0;

            char[] S = s.ToCharArray();

            for (int i = 0; i < S.Length; i++)
            {

                // Increment count and move p 
                // to next position
                if (S[i] == '[')
                {
                    ++count;
                    ++p;
                }
                else if (S[i] == ']')
                {
                    --count;
                }

                // We have encountered an 
                // unbalanced part of string
                if (count < 0)
                {

                    // Increment sum by number of 
                    // swaps required i.e. position 
                    // of next '[' - current position
                    sum += pos[p] - i;
                    char temp = S[i];
                    S[i] = S[pos[p]];
                    S[pos[p]] = temp;
                    ++p;

                    // Reset count to 1
                    count = 1;
                }
            }
            return sum;
        }
        /*
         Output:  

2
0
Another Method: 
Time Complexity = O(N) 
Extra Space = O(1) 
We can do without having to store the positions of ‘[‘. 
        */
        public static long swapCount1(string s)
        {
            char[] chars = s.ToCharArray();

            // stores the total number of Left and 
            // Right brackets encountered 
            int countLeft = 0, countRight = 0;

            // swap stores the number of swaps 
            // required imbalance maintains the
            // number of imbalance pair 
            int swap = 0, imbalance = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '[')
                {
                    // increment count of Left bracket 
                    countLeft++;
                    if (imbalance > 0)
                    {
                        // swaps count is last swap count + total 
                        // number imbalanced brackets 
                        swap += imbalance;

                        // imbalance decremented by 1 as it solved 
                        // only one imbalance of Left and Right 
                        imbalance--;
                    }
                }
                else if (chars[i] == ']')
                {
                    // increment count of Right bracket 
                    countRight++;

                    // imbalance is reset to current difference 
                    // between Left and Right brackets 
                    imbalance = (countRight - countLeft);
                }
            }
            return swap;
        }
        static void Main()
        {
            string s = "[]][][";
            Console.WriteLine(swapCount(s));

            s = "[[][]]";
            Console.WriteLine(swapCount(s));
        }
    }
}
