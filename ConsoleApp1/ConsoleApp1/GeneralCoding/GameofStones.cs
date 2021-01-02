using System;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
namespace ConsoleApp1{
/*
Two players called  and  are playing a game with a starting number of stones. Player  always plays first, and the two players move in alternating turns. The game's rules are as follows:

In a single move, a player can remove either 2,3 or 5 stones from the game board.
If a player is unable to make a move, that player loses the game.


Given the starting number of stones, find and print the name of the winner. 
P1 is named First and P2 is named Second. 
Each player plays optimally, meaning they will not make a move that causes them to lose the game if a winning move exists.
Sample Input

8
1
2
3
4
5
6
7
10
Sample Output

Second
First
First
First
First
First
Second
First

*/ 
public class GameOfStones  {
    // Complete the gameOfStones function below.
static string gameOfStones(int N) {
// We can use dynamic programming to compute a solution
        bool *dp = new bool[N+1]; // dp[N] = true -> P1 wins, else P2 wins
        dp[1] = false;
        dp[2] = true;
        dp[3] = true;
        dp[4] = true;
        dp[5] = true;
        for(int i = 6; i <= N; i++) {
            if(dp[i-2] == false || dp[i-3] == false || dp[i-5] == false) {
                dp[i] = true;
            } else {
                dp[i] = false;
            }
        }
        if(dp[N]) {
            return "First";
        } else {
            return "Second";
        }
}
} 

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            string result = gameOfStones(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}