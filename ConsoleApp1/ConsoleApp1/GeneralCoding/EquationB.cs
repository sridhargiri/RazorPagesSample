using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
     Find the missing digit x from the given expression
Last Updated : 17 Sep, 2020
Given an alphanumeric string, consisting of a single alphabet X, which represents an expression of the form:

A operator B = C
where A, B and C denotes integers and the operator can be either of +, -, * or /

The task is to evaluate the missing digit X present in any of the integers A, B and C such that the given expression holds to be valid.

Examples:

Input: S = “3x + 12 = 46”
Output: 4
Explanation:
If we subtract 12 from 46, we will get 34.
So, on comparing 3x and 34. the value of x = 4


*********Supports two digit operands only

Approach: Follow the steps below to solve the problem:

Split the string to extract the two operands, operator and the resultant.
Check if X is present in the resultant or not. If so, then compute the value of the resultant by applying operations on the first operand and second operand with the operator.
Otherwise, if X is not present in the resultant. Then check if X is present in the first operand. If so, then apply the operation on the second operand and resultant with the operator.
Otherwise, if X is not present in the first operand also. Then check if X is present in the second operand. If so, then apply the operation on the first operand and resultant with the operator.
Below is the implementation of the above approach:*/
    class EquationB
    {
        static int findMissing(string str)
        {
            int res = 0;
            var exp = str.Split(' ');
            string first_operand = exp[0];
            string _operator = exp[1];
            string second_operand = exp[2];
            string resultant = exp[4];
            //If x is present in resultant
            if (resultant.Contains("x"))
            {
                int first = Convert.ToInt32(first_operand[0]);
                int second = Convert.ToInt32(first_operand[1]);
                if (_operator == "+")
                    res = first + second;
                else
                if (_operator == "-")
                    res = first - second;
                else
                if (_operator == "*")
                    res = first * second;
                else
                    res = first / second;
            }
            else
            {
                //If x is present in 1st operand
                if (first_operand.Contains("x"))
                {
                    string _first = first_operand[0].ToString();
                    string _second = first_operand[1].ToString();
                    if (_operator == "+") res = Convert.ToInt32(resultant) - Convert.ToInt32(second_operand);
                    else if (_operator == "-") res = Convert.ToInt32(resultant) + Convert.ToInt32(second_operand);
                    else if (_operator == "*") res = Convert.ToInt32(resultant) / Convert.ToInt32(second_operand);
                    else res = Convert.ToInt32(resultant) * Convert.ToInt32(second_operand);
                    if (_first == "x")
                    {
                        res /= Convert.ToInt32(_second);
                    }
                    else
                    {
                        res /= Convert.ToInt32(_first);
                    }
                }
                //If x is present in 2nd operand
                else
                {
                    char _first = second_operand[0];
                    char _second = second_operand[1];
                    if (_operator == "+") res = Convert.ToInt32(resultant) - Convert.ToInt32(first_operand);
                    else if (_operator == "-") res = Convert.ToInt32(resultant) + Convert.ToInt32(first_operand);
                    else if (_operator == "*") res = Convert.ToInt32(resultant) / Convert.ToInt32(first_operand);
                    else res = Convert.ToInt32(resultant) * Convert.ToInt32(first_operand);
                    if (_first == 'x')
                    {
                        res /= Convert.ToInt32(_second);
                    }
                    else
                    {
                        res /= Convert.ToInt32(_first);
                    }
                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            string exp = "3x + 12 = 18";
            //string exp = "3 + 12 = x";
            int output = findMissing(exp);
            Console.WriteLine(output);
        }
    }
}
