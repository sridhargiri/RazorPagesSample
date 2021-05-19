using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
Societe generale Mr. X in Meeting
Mr X is a great competitive programmer. Today, he has to go out to his friend’s house at 12: 00 p.m for a meeting. 
    It takes him k minutes to reach his friend’s house. But, he is participating in a contest which will start from 6: 00 a.m. 
    The contest has n problems. He can solve the ith problem of the contest in 3* I minutes. 
    Mr X doesn’t want to miss out the meeting, and hence he wants to reach the meeting at the time, but at the same time, he also wants to take part in the contest.

Your task is to find out the number of problems Mr X will solve in the contest and at the same time, he reaches the meeting on time, provided he takes k minutes to reach the meeting.


Input FOrmat:
The first line of the input consists of a single integer T, denoting the number of test cases.
The first line of each test case consists of two integers n, denoting the number of problems in the contest, and k, denoting minutes taken by Mr X to reach his friend’s house.

Constraints:

1<=T<=100
1<=n<=15
1<=k<=360
Output Format:

For each test case, Print in a new line the number of problems Mr X can solve in the problem, at the same time, also reaches the meeting on time.


Sample Input 0:

1
3 319


Sample Output 0:

3


Explanation:
Mr X can solve 1st problem in 3 minutes, 2nd in 3*2 = 6 minutes, and 3rd in 3*3 = 9 minutes. So total time he takes in solving problems is 3 + 6 + 9 = 18 minutes. Then, he will take 319 minutes to reach the meeting. This is acceptable, since total time is (18 + 319) minutes = 337 minutes. He would reach the meeting at 11: 37 a.m, which is before 12: 00 p.m.

Sample Input 1:

1
3 360

Sample Output 1:

0

Explanation:
To reach the meeting at 12:00 pm, Mr X needs to leave at 6:00 am, the time when the contest starts, thus he would not be able to solve even a single problem.
    https://cdn.skillenza.com/files/9743ff89-ff35-48c3-ab46-3f3ff43aa87a/in.txt
    https://cdn.skillenza.com/files/2a769527-791d-4838-a818-acf2be160c86/out.txt

    https://cdn.skillenza.com/files/5cd4ac6c-1406-4831-a914-4453a012ba67/in.txt
    https://cdn.skillenza.com/files/9d374f40-df6e-4737-9e33-a0a2290789d1/out.txt
     */
    public class XMeeting
    {
        public static void Main(string[] args)
        {
            int[] a = null; int problems = 0; int minutes = 0; int dmin = 0;
            int solvemiutes = 0;
            int T = int.Parse(Console.ReadLine());
            DateTime date1 = new DateTime(1900, 1, 1, 12, 0, 0);
            DateTime date = DateTime.Now;
            for (int i = 0; i < T; i++)
            {
                solvemiutes = 0; a = Console.ReadLine().Split(' ').Select(n1 => int.Parse(n1)).ToArray();
                problems = a[0]; minutes = a[1];
                for (int k = 1; k <= problems; k++)
                {
                    dmin += 3 * k;
                }
                solvemiutes = minutes + dmin;
                int hr = 6 + (solvemiutes / 60);
                int mn = solvemiutes - (hr * 60);
                date = new DateTime(1900, 1, 1, 6 + (solvemiutes / 60), solvemiutes % 60, 0);
                int left =  60-solvemiutes % 60 ;
                if (date <= date1)
                {
                    if (left >= dmin)
                        Console.WriteLine(problems);
                    else if (left > 0 && left <= dmin)
                    {
                        int _dmin = 0;
                        int mm = problems-1; int _k = 1;
                        for ( _k = 1; _k <= mm; _k++)
                        {
                            _dmin += 3 * _k;
                            if (_dmin > left) break;
                        }
                        //int _t = dmin - left;
                        Console.WriteLine(_k-1);
                    }
                    else if (left <= 0)
                        Console.WriteLine(0);
                }
                else Console.WriteLine(0);
            }
        }
    }
}
