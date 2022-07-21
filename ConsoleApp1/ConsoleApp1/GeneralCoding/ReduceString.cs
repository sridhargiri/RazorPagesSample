// C# implementation of the above approach
using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    /*
     https://www.geeksforgeeks.org/reduce-the-string-by-removing-k-consecutive-identical-characters/
    Reduce the string by removing K consecutive identical characters
    Given a string str and an integer K, the task is to reduce the string by applying the following operation any number of times until it is no longer possible:

Choose a group of K consecutive identical characters and remove them from the string.

Finally, print the reduced string.

Examples:  

Input: K = 2, str = “geeksforgeeks” 
Output: gksforgks 
Explanation: After removal of both occurrences of the substring “ee”, the string reduces to “gksforgks”.

Input: K = 3, str = “qddxxxd” 
Output: q 
Explanation: 
Removal of “xxx” modifies the string to “qddd”. 
Again, removal of “ddd”modifies the string to “q”. 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
 
Approach: This problem can be solved using the Stack data structure. Follow the steps below to solve the problem:

Initialize a stack of pair<char, int>, to store characters and their respective consecutive frequencies.
Iterate over the characters of the string.
If the current character is different from the character present currently at the top of the stack, then set its frequency to 1.
Otherwise, if the current character is the same as the character at the top of the stack, then increase its frequency by 1.
If the frequency of the character at the top of the stack is K, pop that out of the stack.
Finally, print the characters which are remaining in the stack as the resultant string.
Below is the implementation of the above approach: 
     */

    public class ReduceString
    {

        // Function to find the reduced string
        public static String reduced_String(int k, String s)
        {
            // Base Case
            if (k == 1)
            {

                return "";
            }

            // Creating a stack of type Pair
            Stack<Pair> st = new Stack<Pair>();

            // Length of the string S
            int l = s.Length;

            // iterate through the string
            for (int i = 0; i < l; i++)
            {

                // if stack is empty then simply add the
                // character with count 1 else check if
                // character is same as top of stack
                if (st.Count == 0)
                {
                    st.Push(new Pair(s[i], 1));
                    continue;
                }

                // if character at top of stack is same as
                // current character increase the number of
                // repetitions in the top of stack by 1
                if (st.Peek().c == s[i])
                {
                    Pair p = st.Peek();
                    st.Pop();
                    p.ctr += 1;
                    if (p.ctr == k)
                    {
                        continue;
                    }
                    else
                    {
                        st.Push(p);
                    }
                }
                else
                {

                    // if character at top of stack is not
                    // same as current character push the
                    // character along with count 1 into the
                    // top of stack
                    st.Push(new Pair(s[i], 1));
                }
            }

            // iterate through the stack
            // Use string(int,char) in order to replicate the
            // character multiple times and convert into string
            // then add in front of output string
            String ans = "";
            while (st.Count > 0)
            {
                char c = st.Peek().c;
                int cnt = st.Peek().ctr;
                while (cnt-- > 0)
                    ans = c + ans;
                st.Pop();
            }
            return ans;
        }

        // Driver code
        public static void Main(String[] args)
        {
            int k = 2;
            String st = "geeksforgeeks";
            String ans = reduced_String(k, st);
            Console.Write(ans);
            /*
			 Output
gksforgks
Time Complexity: O(N) 
Auxiliary Space: O(N)
			*/
        }

        public class Pair
        {
            public char c;
            public int ctr;
            public Pair(char c, int ctr)
            {
                this.c = c;
                this.ctr = ctr;
            }
        }
    }
    // This code has been contributed by 29AjayKumar
}