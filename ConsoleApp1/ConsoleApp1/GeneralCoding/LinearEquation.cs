using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
   https://www.geeksforgeeks.org/solve-the-linear-equation-of-single-variable/
     Solve the Linear Equation of Single Variable
Difficulty Level : Hard
Last Updated : 30 Jul, 2018
Given a linear equation, task is to find the value of variable used. The equation contains only ‘+’, ‘-‘ operation, the variable and its coefficient.

If there is no solution for the equation, return “No solution”.
If there are infinite solutions for the equation, return “Infinite solutions”.
If there is exactly one solution for the equation, ensure that the value of x is an integer.
Examples :

Input : "x + 5 - 3 + x = 6 + x - 2"
Output : "x = 2"

Input : "x = x"
Output : "Infinite solutions"

Input: "2x = x"
Output: "x = 0"

Input: "x = x + 2"
Output: "No solution"
Recommended: Please try your approach on {IDE} first, before moving on to the solution.
Approach : The idea is to use two pointers to update two parameters: the coefficient of variable used and the total sum. On the left and right side of ‘=’, use opposite signs for each numbers which is taken care of by a sign variable, which will flip once ‘=’ is seen.

Now, in case of a unique solution, the ratio of the effective total and coefficient gives the required result. In case of infinite solutions, both the effective total and coefficient turns out to be zero e.g. x + 1 = x + 1. In case of no solution, the coefficient of x turns out to be zero, but the effective total is non-zero.
    */
    class LinearEquation
    {
        // Function to solve 
        // the given equation
        static string solveEquation(string equation)
        {
            int n = equation.Length,
                sign = 1, coeff = 0;
            int total = 0, i = 0;

            // Traverse the equation
            for (int j = 0; j < n; j++)
            {
                if (equation[j] == '+' ||
                    equation[j] == '-')
                {
                    if (j > i)
                        total += sign *
                                 Int32.Parse(
                                 equation.Substring(i, j - i));
                    i = j;
                }

                // For cases such 
                // as: x, -x, +x
                else if (equation[j] == 'x')
                {
                    if ((i == j) ||
                         equation[j - 1] == '+')
                        coeff += sign;

                    else if (equation[j - 1] == '-')
                        coeff -= sign;

                    else
                        coeff += sign *
                                 Int32.Parse(
                                 equation.Substring(i, j - i));
                    i = j + 1;
                }

                // Flip sign once 
                // '=' is seen
                else if (equation[j] == '=')
                {
                    if (j > i)
                        total += sign *
                                 Int32.Parse(
                                 equation.Substring(i, j - i));
                    sign = -1;
                    i = j + 1;
                }
            }

            // There may be a 
            // number left in the end
            if (i < n)
                total += sign *
                         Int32.Parse(
                         equation.Substring(i));

            // For infinite
            // solutions
            if (coeff == 0 && total == 0)
                return "Infinite solutions";

            // For no solution
            if (coeff == 0 && total != 0)
                return "No solution";

            // x = total sum / coeff 
            // of x '-' sign indicates 
            // moving numeric value to 
            // right hand side
            int ans = -total / coeff;
            return "x = " + ans.ToString();
        }

        // Driver code
        static void Main()
        {
            string equation = "x+5-3+x=6+x-2";
            Console.Write(solveEquation(equation));
            /*
             Output:
x = 2
Time complexity : O(n), where n is the length of equation string.
Auxiliary Space : O(1)
            */
        }
    }
}
