using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class BalancedParan
    {
        public class stack
        {
            public int top = -1;
            public char[] items = new char[100];

            public void push(char x)
            {
                if (top == 99)
                {
                    Console.WriteLine("Stack full");
                }
                else
                {
                    items[++top] = x;
                }
            }

            char pop()
            {
                if (top == -1)
                {
                    Console.WriteLine("Underflow error");
                    return '\0';
                }
                else
                {
                    char element = items[top];
                    top--;
                    return element;
                }
            }

            Boolean isEmpty()
            {
                return (top == -1) ? true : false;
            }
        }

        // Returns true if character1 and character2 
        // are matching left and right Parenthesis */ 
        static Boolean isMatchingPair(char character1,
                                      char character2)
        {
            if (character1 == '(' && character2 == ')')
                return true;
            else if (character1 == '{' && character2 == '}')
                return true;
            else if (character1 == '[' && character2 == ']')
                return true;
            else
                return false;
        }

        // Return true if expression has balanced 
        // Parenthesis  
        static Boolean areParenthesisBalanced(char[] exp)
        {
            // Declare an empty character stack */ 
            Stack<char> st = new Stack<char>();

            // Traverse the given expression to 
            //   check matching parenthesis 
            for (int i = 0; i < exp.Length; i++)
            {
                // If the exp[i] is a starting 
                // parenthesis then push it 
                if (exp[i] == '{' || exp[i] == '('
                    || exp[i] == '[')
                    st.Push(exp[i]);

                //  If exp[i] is an ending parenthesis 
                //  then pop from stack and check if the 
                //   popped parenthesis is a matching pair 
                if (exp[i] == '}' || exp[i] == ')'
                    || exp[i] == ']')
                {

                    // If we see an ending parenthesis without 
                    //   a pair then return false 
                    if (st.Count == 0)
                    {
                        return false;
                    }

                    // Pop the top element from stack, if 
                    // it is not a pair parenthesis of 
                    // character then there is a mismatch. This 
                    // happens for expressions like {(}) 
                    else if (!isMatchingPair(st.Pop(),
                                             exp[i]))
                    {
                        return false;
                    }
                }
            }

            // If there is something left in expression 
            // then there is a starting parenthesis without 
            // a closing parenthesis  

            if (st.Count == 0)
                return true; // balanced 
            else
            { // not balanced 
                return false;
            }
        }


        // Driver code 
        public static void Main(String[] args)
        {
            char[] exp = { '{', '(', ')', '}', '[', ']' };

            // Function call 
            if (areParenthesisBalanced(exp))
                Console.WriteLine("Balanced ");
            else
                Console.WriteLine("Not Balanced ");
        }
    }

    /*
     https://www.geeksforgeeks.org/maximum-balanced-string-partitions/
    Maximum Balanced String Partitions
Last Updated : 20 Jul, 2021
Given a balanced string str of size N with an equal number of L and R, the task is to find a maximum number X, such that a given string can be partitioned into X balanced substring. A string called to be balanced if the number of ‘L’s in the string equals the number of ‘R’s. 
Examples: 
 

Input : str = “LRLLRRLRRL” 
Output : 4 
Explanation: { “LR”, “LLRR”, “LR”, “RL”} are the possible partitions.
Input : “LRRRRLLRLLRL” 
Output : 3 
Explanation: {“LR”, “RRRLLRLL”, “RL”} are the possible partitions. 
 

 

Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach: The approach to solving this problem is to loop through the string and keep incrementing the count of L and R whenever encountered. Any instant when the respective counts of L and R become equal, a balanced parenthesis is formed. Thus the count of such instances gives the desired maximum possible partitions.
Below is the implementation of the above approach:
     */
    public class BalancedPartition
    {

        // Function to find a maximum number X, such
        // that a given String can be partitioned
        // into X subStrings that are each balanced
        static int MaxBalancedPartition(string str, int n)
        {

            // If the size of the String is 0,
            // then answer is zero
            if (n == 0)
                return 0;

            // Variable that represents the
            // number of 'R's and 'L's
            int r = 0, l = 0;

            // To store maximum number of
            // possible partitions
            int ans = 0;
            for (int i = 0; i < n; i++)
            {

                // Increment the variable r if the
                // character in the String is 'R'
                if (str[i] == 'R')
                {
                    r++;
                }

                // Increment the variable l if the
                // character in the String is 'L'
                else if (str[i] == 'L')
                {
                    l++;
                }

                // If r and l are equal,
                // then increment ans
                if (r == l)
                {
                    ans++;
                }
            }

            // Return the required answer
            return ans;
        }

        // Driver code
        public static void Main()
        {
            string str = "LLRRRLLRRL";
            int n = str.Length;

            // Function call
            Console.Write(MaxBalancedPartition(str, n) + "\n");
            /*
             Output 4
Time Complexity: O(N) 
Space Complexity: O(1)*/
        }
    }
    /*
    https://www.geeksforgeeks.org/length-of-the-longest-valid-substring/ 
    Length of the longest valid substring
Difficulty Level : Medium
Last Updated : 20 Oct, 2021
Given a string consisting of opening and closing parenthesis, find the length of the longest valid parenthesis substring.

Examples: 

Attention reader! Don’t stop learning now. Get hold of all the important DSA concepts with the DSA Self Paced Course at a student-friendly price and become industry ready.  To complete your preparation from learning a language to DS Algo and many more,  please refer Complete Interview Preparation Course.

In case you wish to attend live classes with experts, please refer DSA Live Classes for Working Professionals and Competitive Programming Live for Students.

Input : ((()
Output : 2
Explanation : ()

Input: )()())
Output : 4
Explanation: ()() 

Input:  ()(()))))
Output: 6
Explanation:  ()(())
Recommended: Please solve it on “PRACTICE” first, before moving on to the solution.
A Simple Approach is to find all the substrings of given string. For every string, check if it is a valid string or not. If valid and length is more than maximum length so far, then update maximum length. We can check whether a substring is valid or not in linear time using a stack (See this for details). Time complexity of this solution is O(n2.



An Efficient Solution can solve this problem in O(n) time. The idea is to store indexes of previous starting brackets in a stack. The first element of the stack is a special element that provides index before the beginning of valid substring (base for next valid string). 

1) Create an empty stack and push -1 to it. 
   The first element of the stack is used 
   to provide a base for the next valid string. 

2) Initialize result as 0.

3) If the character is '(' i.e. str[i] == '('), 
   push index'i' to the stack. 
   
2) Else (if the character is ')')
   a) Pop an item from the stack (Most of the 
      time an opening bracket)
   b) If the stack is not empty, then find the
      length of current valid substring by taking 
      the difference between the current index and
      top of the stack. If current length is more 
      than the result, then update the result.
   c) If the stack is empty, push the current index
      as a base for the next valid substring.

3) Return result.
Below is the implementation of the above algorithm. 
    */
    public class LongestBalancedString
    {
        // method to get length of
        // the longest valid
        public static int findMaxLen(string str)
        {
            int n = str.Length;

            // Create a stack and push -1 as
            // initial index to it.
            Stack<int> stk = new Stack<int>();
            stk.Push(-1);

            // Initialize result
            int result = 0;

            // Traverse all characters of
            // given string
            for (int i = 0; i < n; i++)
            {
                // If opening bracket, push
                // index of it
                if (str[i] == '(')
                {
                    stk.Push(i);
                }

                else // If closing bracket,
                     // i.e.,str[i] = ')'
                {
                    // Pop the previous opening
                    // bracket's index
                    if (stk.Count > 0)
                        stk.Pop();

                    // Check if this length formed
                    // with base of current valid
                    // substring is more than max
                    // so far
                    if (stk.Count > 0)
                    {
                        result
                            = Math.Max(result,
                                       i - stk.Peek());
                    }

                    // If stack is empty. push current
                    // index as base for next valid
                    // substring (if any)
                    else
                    {
                        stk.Push(i);
                    }
                }
            }

            return result;
        }

        // Driver Code
        public static void Main(string[] args)
        {
            string str = "((()()";

            // Function call
            Console.WriteLine(findMaxLen(str));

            str = "()(()))))";

            // Function call
            Console.WriteLine(findMaxLen(str));
            /*
             Output
4
6
            */
        }
    }
    /*
     
Explanation with example: 

 

Input: str = "(()()"

Initialize result as 0 and stack with one item -1.

For i = 0, str[0] = '(', we push 0 in stack

For i = 1, str[1] = '(', we push 1 in stack

For i = 2, str[2] = ')', currently stack has 
[-1, 0, 1], we pop from the stack and the stack
now is [-1, 0] and length of current valid substring 
becomes 2 (we get this 2 by subtracting stack top from 
current index).

Since the current length is more than the current result, 
we update the result.

For i = 3, str[3] = '(', we push again, stack is [-1, 0, 3].
For i = 4, str[4] = ')', we pop from the stack, stack 
becomes [-1, 0] and length of current valid substring 
becomes 4 (we get this 4 by subtracting stack top from 
current index). 
Since current length is more than current result,
we update result. 
 



Another Efficient Approach can solve the problem in O(n) time. The idea is to maintain an array that stores the length of the longest valid substring ending at that index. We iterate through the array and return the maximum value.

 

1) Create an array longest of length n (size of the input
   string) initialized to zero.
   The array will store the length of the longest valid 
   substring ending at that index.

2) Initialize result as 0.

3) Iterate through the string from second character
   a) If the character is '(' set longest[i]=0 as no 
      valid sub-string will end with '('.
   b) Else
      i) if s[i-1] = '('
            set longest[i] = longest[i-2] + 2
      ii) else
            set longest[i] = longest[i-1] + 2 + 
            longest[i-longest[i-1]-2]

4) In each iteration update result as the maximum of 
   result and longest[i]

5) Return result.
 

Below is the implementations of the above algorithm.  
    */
    public class LongestBalancedStringEff
    {

        static int findMaxLen(String s)
        {
            if (s.Length <= 1)
                return 0;

            // Initialize curMax to zero
            int curMax = 0;
            int[] longest = new int[s.Length];

            // Iterate over the String starting from second index
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ')' && i - longest[i - 1] - 1 >= 0 && s[i - longest[i - 1] - 1] == '(')
                {
                    longest[i] = longest[i - 1] + 2 + ((i - longest[i - 1] - 2 >= 0) ? longest[i - longest[i - 1] - 2] : 0);
                    curMax = Math.Max(longest[i], curMax);
                }
            }
            return curMax;
        }

        // Driver code
        public static void Main(String[] args)
        {
            String str = "((()()";

            // Function call
            Console.Write(findMaxLen(str) + "\n");

            str = "()(()))))";

            // Function call
            Console.Write(findMaxLen(str) + "\n");//op 4 6
        }
    }

    /*
     Thanks to Gaurav Ahirwar and Ekta Goel for suggesting above approach.

Another approach in O(1) auxiliary space and O(N) Time complexity: 

The idea to solve this problem is to traverse the string on and keep track of the count of open parentheses and close parentheses with the help of two counters left and right respectively.
First, the string is traversed from the left towards the right and for every “(” encountered, the left counter is incremented by 1 and for every “)” the right counter is incremented by 1.
Whenever the left becomes equal to right, the length of the current valid string is calculated and if it greater than the current longest substring, then value of required longest substring is updated with current string length.
If the right counter becomes greater than the left counter, then the set of parentheses has become invalid and hence the left and right counters are set to 0.
After the above process, the string is similarly traversed from right to left and similar procedure is applied.
Below is the implementation of the above approach: 
    */
    public class LongestBalancedStringOpt
    {

        // Function to return the length
        // of the longest valid substring
        public static int solve(String s, int n)
        {

            // Variables for left and right
            // counter maxlength to store
            // the maximum length found so far
            int left = 0, right = 0;
            int maxlength = 0;

            // Iterating the string from left to right
            for (int i = 0; i < n; i++)
            {

                // If "(" is encountered, then
                // left counter is incremented
                // else right counter is incremented
                if (s[i] == '(')
                    left++;
                else
                    right++;

                // Whenever left is equal to right,
                // it signifies that the subsequence
                // is valid and
                if (left == right)
                    maxlength = Math.Max(maxlength,
                                         2 * right);

                // Reseting the counters when the
                // subsequence becomes invalid
                else if (right > left)
                    left = right = 0;
            }

            left = right = 0;

            // Iterating the string from right to left
            for (int i = n - 1; i >= 0; i--)
            {

                // If "(" is encountered, then
                // left counter is incremented
                // else right counter is incremented
                if (s[i] == '(')
                    left++;
                else
                    right++;

                // Whenever left is equal to right,
                // it signifies that the subsequence
                // is valid and
                if (left == right)
                    maxlength = Math.Max(maxlength,
                                         2 * left);

                // Reseting the counters when the
                // subsequence becomes invalid
                else if (left > right)
                    left = right = 0;
            }
            return maxlength;
        }

        // Driver code
        public static void Main(String[] args)
        {
            // Function call
            Console.Write(solve("((()()()()(((())", 16));//op 8
        }
    }
    /*
     https://exploringbits.com/hackerrank-in-a-string-hackerrank-solution/
    We say that a string contains the word hackerrank if a subsequence of its characters spell the word hackerrank. Remember that a subsequence maintains the order of characters selected from a sequence.

More formally, let p[0],p[1],…p[9] be the respective indices of h, a, c, k, e, r, r, a, n, k in string . If p[0]<p[1]<p[2]<…p[9] is true, then s contains hackerrank.

For each query, print YES on a new line if the string contains hackerrank, otherwise, print NO.
    Example

s=haacckkerrannkk ans = YES
    s=hccaakkerrannkk

There is no ‘c’ after the first occurrence of an ‘a’, so answer NO.
     */
    public class HackerrankString
    {
        static void Main(String[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                char[] hr = new char[10] { 'h', 'a', 'c', 'k', 'e', 'r', 'r', 'a', 'n', 'k' };
                char[] sArray = Console.ReadLine().ToCharArray();
                bool status = true;
                for (int i = 0; i < hr.Length; i++)
                {
                    char symbol = hr[i];
                    int index = Array.FindIndex(sArray, s => s == symbol);
                    if (index < 0)
                    {
                        status = false;
                        break;
                    }
                    var newArr = new char[sArray.Length - index - 1];
                    Array.Copy(sArray, index + 1, newArr, 0, sArray.Length - index - 1);
                    sArray = newArr;
                }
                Console.WriteLine(status ? "YES" : "NO");
            }
        }
    }
    /*
Alice and Bob each created one problem for HackerRank. A reviewer rates the two challenges, awarding points on a scale from 1 to 100 for three categories: problem clarity, originality, and difficulty.

The rating for Alice’s challenge is the triplet a = (a[0], a[1], a[2]), and the rating for Bob’s challenge is the triplet b = (b[0], b[1], b[2]).

The task is to find their comparison points by comparing a[0] with b[0], a[1] with b[1], and a[2] with b[2].

If a[i] > b[i], then Alice is awarded 1 point.
If a[i] < b[i], then Bob is awarded 1 point.
If a[i] = b[i], then neither person receives a point.
Comparison points is the total points a person earned.

Given a and b, determine their respective comparison points.
Example

a = [1, 2, 3]

b = [3, 2, 1]

For elements *0*, Bob is awarded a point because a[0] .
For the equal elements a[1] and b[1], no points are earned.
Finally, for elements 2, a[2] > b[2] so Alice receives a point.
The return array is [1, 1] with Alice’s score first and Bob’s second.

Function Description

Complete the function compareTriplets in the editor below.

compareTriplets has the following parameter(s):

int a[3]: Alice’s challenge rating
int b[3]: Bob’s challenge rating
Return

int[2]: Alice’s score is in the first position, and Bob’s score is in the second.

Input Format

The first line contains 3 space-separated integers, a[0], a[1], and a[2], the respective values in triplet a.

The second line contains 3 space-separated integers, b[0], b[1], and b[2], the respective values in triplet b.
Constraints

1 ≤ a[i] ≤ 100
1 ≤ b[i] ≤ 100
Sample Input 0

5 6 7

3 6 10
Sample Output 0

1 1
Explanation 0

In this example:

a=(a[0],a[1],a[2]) = (5,6,7)
b=(b[0],b[1],b[2]) = (3,6,10)
Now, let’s compare each individual score:

a[0]>b[0], so Alice receives 1 point.

a[1]=b[1], so nobody receives a point.

a[2]<b[2], so Bob receives 1 point.
Alice’s comparison score is 1, and Bob’s comparison score is 1. Thus, we return the array [1,1].

Sample Input 1

17 28 30

99 16 8
Sample Output 1

2 1
Explanation 1

Comparing the 0th elements, 17<99 so Bob receives a point.

Comparing the 1st and 2nd elements,28>16  and 30>8 so Alice receives two points.

The return array is [2,1].  
Attempt Compare the Triplet HackerRank Challenge

Link: https://www.hackerrank.com/challenges/compare-the-triplets

Next Challenge – A Very Big Sum HackerRank Solution

Link: https://exploringbits.com/a-very-big-sum-hackerrank-solution/
    */
    public class HackerrankCompareTriplets
    {
        static void Main(String[] args)
        {
            string[] tokens_a0 = Console.ReadLine().Split(' ');
            int a0 = Convert.ToInt32(tokens_a0[0]);
            int a1 = Convert.ToInt32(tokens_a0[1]);
            int a2 = Convert.ToInt32(tokens_a0[2]);
            string[] tokens_b0 = Console.ReadLine().Split(' ');
            int b0 = Convert.ToInt32(tokens_b0[0]);
            int b1 = Convert.ToInt32(tokens_b0[1]);
            int b2 = Convert.ToInt32(tokens_b0[2]);

            int alice = 0;
            int bob = 0;
            if (a0 > b0)
            {
                alice++;
            }

            if (a0 < b0)
            {
                bob++;
            }
            if (a1 > b1)
            {
                alice++;
            }

            if (a1 < b1)
            {
                bob++;
            }
            if (a2 > b2)
            {
                alice++;
            }

            if (a2 < b2)
            {
                bob++;
            }

            Console.WriteLine(alice + " " + bob);
        }
    }
    /*
     https://exploringbits.com/jumping-on-the-clouds-revisited-hackerrank-solution/
    https://www.hackerrank.com/challenges/jumping-on-the-clouds-revisited/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
    Jumping on the Clouds: Revisited HackerRank Solution
    A child is playing a cloud hopping game. In this game, there are sequentially numbered clouds that can be thunderheads or cumulus clouds. The character must jump from cloud to cloud until it reaches the start again.

There is an array of clouds,c  and an energy level e=100. The character starts from c[0] and uses  1 unit of energy to make a jump of size k to cloud c[(i+k)%n]. If it lands on a thundercloud,c[i]=1 , its energy (e) decreases by 2 additional units. The game ends when the character lands back on cloud 0.

Given the values of n,k , and the configuration of the clouds as an array c, determine the final value of e after the game ends.

Example. c=[0,0,1,0]

k=2
    The indices of the path are 0->2->0. The energy level reduces by 1 for each jump to 98. The character landed on one thunderhead at an additional cost of 2 energy units. The final energy level is 96.

Note: Recall that  refers to the modulo operation. In this case, it serves to make the route circular. If the character is at  and jumps , it will arrive at .

Function Description
    Complete the jumpingOnClouds function in the editor below.

jumpingOnClouds has the following parameter(s):

int c[n]: the cloud types along the path
int k: the length of one jump
Returns

int: the energy level remaining.
Input Format

The first line contains two space-separated integers,n  and k, the number of clouds and the jump distance.

The second line contains n space-separated integers c[i] where 0<=i<=n. Each cloud is described as follows:

If c[i] = 0, then cloud i is a cumulus cloud.
If c[i] = 1, then cloud i is a thunderhead.
Sample Input

STDIN             Function

-----             --------

8 2               n = 8, k = 2
    0 0 1 0 0 1 1 0   c = [0, 0, 1, 0, 0, 1, 1, 0]
Sample Output

92

     */
    public class HackerrankCloudRevisited
    {
        static void Main(String[] args)
        {
            var tmp = Console.ReadLine().Split(' ');
            int n = int.Parse(tmp[0]);
            int k = int.Parse(tmp[1]);
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), x => Convert.ToInt32(x));
            int E = 100;
            int pos = 0;
            while (true)
            {
                pos += k;
                pos %= n;
                if (arr[pos] == 1) E -= 2;
                E -= 1;
                if (pos == 0) break;
            }
            Console.WriteLine(E);
        }
    }
}
