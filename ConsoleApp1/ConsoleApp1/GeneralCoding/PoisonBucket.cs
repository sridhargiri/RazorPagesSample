using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     * Amazon technical scripter
     Minimum number of pigs required to find the poisonous bucket
Difficulty Level : Hard
 Last Updated : 12 Feb, 2021
Given an integer N denoting the number of buckets, and an integer M, denoting the minimum time in minutes required by a pig to die after drinking poison, the task is to find the minimum number of pigs required to figure out which bucket is poisonous within P minutes, if there is exactly one bucket with poison, while the rest is filled with water.
    
     Examples:

Input: N = 1000, M = 15, P = 60
Output: 5
Explanation: Minimum number of pigs required to find the poisonous bucket is 5.

Input: N = 4, M = 15, P = 15
Output: 2
Explanation: Minimum number of pigs required to find the poisonous bucket is 2.
    Approach: The given problem can be solved using the given observations:



A pig can be allowed to drink simultaneously on as many buckets as one would like, and the feeding takes no time.
After a pig has instantly finished drinking buckets, there has to be a cool downtime of M minutes. During this time, only observation is allowed and no feedings at all.
Any given bucket can be sampled an infinite number of times (by an unlimited number of pigs).
Now, P minutes to test and M minutes to die simply tells how many rounds the pigs can be used, i.e., how many times a pig can eat. Therefore, declare a variable called r = P(Minutes To Test) / M(Minutes To Die).

    https://www.geeksforgeeks.org/minimum-number-of-pigs-required-to-find-the-poisonous-bucket/

Consider the cases to understand the approach:

Case 1: If r = 1, i.e., the number of rounds is 1.
Example: 4 buckets, 15 minutes to die, and 15 minutes to test. The answer is 2. Suppose A and B represent 2 pigs, then the cases are:

Buckets     0   1   2   3
--------------------------
drink by    -   A   B   AB

Obviously, using the binary form to represent the solution as:
Buckets     0   1   2   3
--------------------------
drink by    -   A_   _B   AB
---------------------------
Binary      00  10  01  11
    Conclusion: If there are x pigs, they can represent (encode) 2x buckets.

Case 2: If r > 1, i.e. the number of rounds is more than 1. Let below be the following notations:

0 means the pig does not drink and die.
1 means the pig drinks in the first (and only) round.
Generalizing the above results(t means the pig drinks in the t round and die): If there are t attempts, a (t + 1)-based number is used to represent (encode) the buckets. (That’s also why the first conclusion uses the 2-based number)

Example: 8 buckets, 15 buckets to die, and 40 buckets to test. Now, there are 2 (= (40/15).floor) attempts, as a result, 3-based number is used to encode the buckets. The minimum number of pigs required are 2 (= Math.log(8, 3).ceil).

Buckets     0   1   2   3   4   5   6   7
------------------------------------------
3-based     00  01  02  10  11  12  20  21
------------------------------------------
1st round   -   _B  -   A_  AB  A_  -   _B
------------------------------------------
2nd round   -   -   _B  -   -   _B  A_  A_
Below is the approach

     
     */
    class PoisonBucket
    {
        static void poorPigs(int buckets,
                 int minutesToDie,
                 int minutesToTest)
        {
            // Print the result 
            Console.WriteLine(Math.Ceiling(Math.Log(buckets)
                         / Math.Log((minutesToTest / minutesToDie) + 1)));
        }

        // Driver Code 
        public static void main()
        {
            int N = 1000, M = 15, P = 60;
            poorPigs(N, M, P);
        }
        //Output:
        //5
        //Time Complexity: O(1)
        //Auxiliary Space: O(1)
    }
}
