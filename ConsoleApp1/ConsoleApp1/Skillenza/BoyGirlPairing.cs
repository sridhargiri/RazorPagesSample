
/*
 Dancing Pair
Delhi Public School is hosting a chess competition in celebration of its 30th anniversary. N boys and M girls registered for it. The school management has to make pairs(since chess is a 2 people game).

A pair must have one boy and one girl. For each boy, we know his chess skills. Similarly, for each girl, we know her chess skills. The opponents’ chess skills in each pair must differ by at most one.

You being in the management committee has to determine the largest possible number of distinct pairs that can be formed from N boys and M girls.

Note: Two pairs are distinct if the intersection of them is null i.e. Not one student is common in either of the pair. More formally, If a student either a boy or a girl is selected in any pair then the same student won’t be considered for another pair.

Input:
The first line contains T- denoting the number of test cases.
For each Testcase in T,

The first line contains a single integer N, denoting the number of boys.
The second line contains N space-separated integers denoting skills of N boys.
The third line contains a single integer M, denoting the number of girls.
The fourth line contains M space-separated integers denoting skills of M girls.
Output:
Output in new line the maximum number of distinct pairs that can be formed, wherein each pair the skill of the boy and the girl differ by at most 1.

Constraints:

1<=T<=10
1<=N<=1e5
1<=M<=1e5
0<=skills<=1e12
Sample Input:

2
3
1 2 3
3
2 2 4
4
2 3 4 5
3
6 7 8
Sample output:

3
1
Explanation:

In the first test case, the 1st boy can be paired with 1st girl(difference in skills=1),2nd boy with 2nd girl(difference in skills=1), and 3rd boy with 3rd girl(difference in skills=1). We can see every pair has at most 1 difference and no two pair has common students in the skills of their partners.
In the second test case, only 4th boy and 1st girl can be paired(difference in skills=1), for every other pair the difference will be greater than 1.

 */
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Skillenza
{
    class BoyGirlPairing
    {
    }
}
