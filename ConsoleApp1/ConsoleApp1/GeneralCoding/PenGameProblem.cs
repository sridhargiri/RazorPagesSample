using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Pen Distribution Problem
Difficulty Level : Medium
 Last Updated : 29 Jan, 2021
Given an integer N denoting the number of boxes in a pen, and two players P1 and P2 playing a game of distributing N pens among themselves as per the following rules:

P1 makes the first move by taking 2X pens. (Initially, X = 0)
P2 takes 3X pens.
Value of X increases by 1 after each move.
P1 and P2 makes move alternatively.
If the current player has to take more pens than the number of pens remaining in the box, then they quit.
Game will be over when both the players quit or when the box becomes empty.
The task to print the following details once the game is over:

The number of pens remaining in the box.
The number of pens collected by P1.
The number of pens collected by P2.
Examples:

Input: N = 22
Output:
Number of pens remaining in the box: 14
Number of pens collected by P1 : 5
Number of pens collected by P2 : 3
Explanation:

Move 1: X = 0, P1 takes 1 pen from the box. Therefore, N = 22 – 1 = 21.
Move 2: X = 1, P2 takes 3 pens from the box. Therefore, N = 21 – 3 = 18.
Move 3: X = 2, P1 takes 4 pens from the box. Therefore, N = 18 – 4 = 14.
Move 4: X = 3, P2 quits as 27 > 14.
Move 5: X = 4, P1 quits as 16 > 14.
Game Over! Both players have quit.
Input: N = 1
Output:
Number of pens remaining in the box : 0
Number of pens collected by P1 : 1
Number of pens collected by P2 : 0

Approach: The idea is to use Recursion. Follow the steps to solve the problem:

Define a recursive function:
Game_Move(N, P1, P2, X, Move, QuitP1, QuitP2)
where,
N : Total number of Pens
P1 : Score of P1
P2 : Score of P2
X : Initialized to zero
Move = 0 : P1’s turn
Move = 1 : P2’s turn
QuitP1 : Has P1 quit
QuitP2 : Has P2 quit
    Finally, print the final values after the game has ended
Below is the implementation of above mentioned approach:
     */
    class PenGameProblem
    {



        // N = Total number of Pens 
        // P1 : Score of P1 
        // P2 : Score of P2 
        // X : Initialized to zero 
        // Move = 0 : P1's turn 
        // Move = 1 : P2's turn 
        // QuitP1 : Has P1 quit 
        // QuitP2 : Has P2 quit 

        // Recursive function to play Game 
        void solve(int N, int P1, int P2, int X, bool Move,
                bool QuitP1, bool QuitP2)
        {
            if (N == 0 || (QuitP1 && QuitP2))
            {

                // Box is empty, Game Over! or 
                // Both have quit, Game Over! 
                Console.WriteLine("Number of pens remaining in the box: " + N);
                Console.WriteLine("Number of pens collected by P1: " + P1);
                Console.WriteLine("Number of pens collected by P2: " + P2);
                return;
            }

            if (!Move && QuitP1 == false)
            {

                // P1 moves 
                int req_P1 = (int)Math.Pow(2, X);

                if (req_P1 <= N)
                {
                    P1 += req_P1;
                    N -= req_P1;
                }
                else
                {
                    QuitP1 = true;
                }
            }

            else if (Move && QuitP2 == false)
            {

                // P2 moves 
                int req_P2 = (int)Math.Pow(3, X);

                if (req_P2 <= N)
                {
                    P2 += req_P2;
                    N -= req_P2;
                }
                else
                {
                    QuitP2 = true;
                }
            }

            // Increment X 
            X++;

            // Switch moves between P1 and P2 
            Move = (Move ? false : true);

            solve(N, P1, P2, X, Move, QuitP1, QuitP2);
        }

        // Function to find the number of 
        // pens remaining in the box and 
        // calculate score for each player 
        void PenGame(int N)
        {
            // Score of P1 
            int P1 = 0;

            // Score of P2 
            int P2 = 0;

            // Initialized to zero 
            int X = 0;

            // Move = 0, P1's turn 
            // Move = 1, P2's turn 
            bool Move = false;

            // Has P1 quit 
            bool QuitP1 = false;

            // Has P2 quit 
            bool QuitP2 = false;

            // Recursively continue the game 
            solve(N, P1, P2, X, Move,
                QuitP1, QuitP2);
        }

        // Driver Code 
        int main()
        {
            int N = 22;
            PenGame(N);

            return 0;
        }

    }
}
