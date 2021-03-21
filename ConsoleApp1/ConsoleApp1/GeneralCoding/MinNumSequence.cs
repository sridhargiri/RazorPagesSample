using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Form minimum number from given sequence
Difficulty Level : Hard
 Last Updated : 19 Jan, 2021
Given a pattern containing only I’s and D’s. I for increasing and D for decreasing. Devise an algorithm to print the minimum number following that pattern. Digits from 1-9 and digits can’t repeat.

Examples: 

   Input: D        Output: 21
   Input: I        Output: 12
   Input: DD       Output: 321
   Input: II       Output: 123
   Input: DIDI     Output: 21435
   Input: IIDDD    Output: 126543
   Input: DDIDDIID Output: 321654798
Source: Amazon Interview Question
    
     
Below are some important observations

Since digits can’t repeat, there can be at most 9 digits in output. 
    Also number of digits in output is one more than number of characters in input. Note that the first character of input corresponds to two digits in output.
    Alternate Solution: 
Let’s observe a few facts in case of minimum number: 

The digits can’t repeat hence there can be 9 digits at most in output.
To form a minimum number , at every index of the output, we are interested in the minimum number which can be placed at that index.
The idea is to iterate over the entire input array , keeping track of the minimum number (1-9) which can be placed at that position of the output.

The tricky part of course occurs when ‘D’ is encountered at index other than 0. In such a case we have to track the nearest ‘I’ to the left of ‘D’ and increment each number in the output vector by 1 in between ‘I’ and ‘D’. 
We cover the base case as follows: 

If the first character of input is ‘I’ then we append 1 and 2 in the output vector and the minimum available number is set to 3 .The index of most recent ‘I’ is set to 1.
If the first character of input is ‘D’ then we append 2 and 1 in the output vector and the minimum available number is set to 3, and the index of most recent ‘I’ is set to 0.
Now we iterate the input string from index 1 till its end and: 



If the character scanned is ‘I’ ,minimum value which has not been used yet is appended to the output vector .We increment the value of minimum no. available and index of most recent ‘I’ is also updated.
If the character scanned is ‘D’ at index i of input array, we append the ith element from output vector in the output and track the nearest ‘I’ to the left of ‘D’ and increment each number in the output vector by 1 in between ‘I’ and ‘D’.
Following is the program for the same

     
     */
    class MinNumSequence
    {

        static void printLeast(String arr)
        {
            // min_avail represents the minimum number which is 
            // still available for inserting in the output vector. 
            // pos_of_I keeps track of the most recent index 
            // where 'I' was encountered w.r.t the output vector 
            int min_avail = 1, pos_of_I = 0;

            //vector to store the output
            List<int> al = new List<int>();

            // cover the base cases
            if (arr[0] == 'I')
            {
                al.Add(1);
                al.Add(2);
                min_avail = 3;
                pos_of_I = 1;
            }

            else
            {
                al.Add(2);
                al.Add(1);
                min_avail = 3;
                pos_of_I = 0;
            }

            // Traverse rest of the input
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == 'I')
                {
                    al.Add(min_avail);
                    min_avail++;
                    pos_of_I = i + 1;
                }
                else
                {
                    al.Add(al[i]);
                    for (int j = pos_of_I; j <= i; j++)
                        al[j] = al[j] + 1;

                    min_avail++;
                }
            }

            // print the number
            for (int i = 0; i < al.Count; i++)
                Console.Write(al[i] + " ");
            Console.WriteLine();
        }


        // Driver code
        public static void Main(String[] args)
        {
            printLeast("IDID");
            printLeast("I");
            printLeast("DD");
            printLeast("II");
            printLeast("DIDI");
            printLeast("IIDDD");
            printLeast("DDIDDIID");
            /*Output
1 3 2 5 4 
1 2 
3 2 1 
1 2 3 
2 1 4 3 5 
1 2 6 5 4 3 
3 2 1 6 5 4 7 9 8 

--nim game  https://www.geeksforgeeks.org/combinatorial-game-theory-set-2-game-nim/
            */
        }
    }
}
