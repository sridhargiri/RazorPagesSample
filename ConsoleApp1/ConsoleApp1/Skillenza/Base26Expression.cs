using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /*
agora     Base 26 Expression
Given an expression consisting of operands in base 26 and operators +, -, evaluate it and output the result.
0 to a, 1 to b..... 25 to z
Table
Please find below the base 26 table below



table.png


Input Format
First line of test case consists of an integer t denoting the number of test cases. Next t lines follow. Each line consist of an expression e.

Output Format
For each expression, output evaluated result in base 26.

Constraints
1 <= t <= 10000

2 <= o <= 100

1 <= n <= 10000000

where

t is the number of test cases

o is the number of operands in the expression

n is the value of each operand in decimal

expression doesn’t contain any space or brackets

operators + and -

expression also doesn’t contain any operators next to each other

for eg. there won’t be a case a++b

Sample Input
3
no+end
got+bad-how
a+b+c+d+e-f+g-h-i-j+k-l-m-n-o+p-q-r+s-t+u-v+w-x+y+z
Sample Output
far
a
-z
Explanation
For the expression no+end

no = 13 * 26 + 14 = 352

end = 4 * 26 * 26 + 13 * 26 + 3 = 3045

no + end = 352 + 3045 = 3397

3397 = 5 * 26 * 26 + 17 =  far
    https://cdn.skillenza.com/files/92554ca3-8ec8-48d5-b698-48bab40bd8eb/in.txt
    https://cdn.skillenza.com/files/9aca2c33-91ea-4fc0-adeb-43a1f42b9c77/out.txt
    */
    public class Base26Expression
    {
        static int numShrink(string word)
        {
            int sum = 0;
            for (int j = 0; j <= word.Length - 1; j++)
            {
                sum += (int)((word[j] - 'a') * Math.Pow(26, word.Length - 1 - j));
            }
            return sum;
        }
        static string numExpand(int num)
        {
            bool neg = num < 0; num = Math.Abs(num);
            if (num == 0) return "a";
            int temp = 0;
            string _t1 = "";
            string _t = "";
            while (num > 0)
            {
                temp = num % 26;
                num = num / 26;
                _t += (char)('a' + temp);
            }
            for (int i = _t.Length - 1; i >= 0; i--)
            {
                _t1 += _t[i];
            }
            _t1 = neg ? '-' + _t1 : _t1;
            return _t1;
        }
        public static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                string equation = Console.ReadLine(); string _temp = "";
                int prevsign = 1; int sign = 1; string outer = ""; int total = 0;
                for (int j = 0; j < equation.Length; j++)
                {
                    if (equation[j] >= 97 && equation[j] <= 122)
                    {
                        _temp += equation[j];
                        if (j == equation.Length - 1)
                            total += numShrink(_temp) == 0 ? 0 : sign * numShrink(_temp);
                    }
                    else if ((equation[j] == '+' || equation[j] == '-') || j == equation.Length - 1)
                    {
                        prevsign = sign; sign = equation[j] == '+' ? 1 : -1;
                        if (j > 0)
                            total += numShrink(_temp) == 0 ? 0 : prevsign * numShrink(_temp);
                        _temp = "";
                    }
                }
                outer = numExpand(total);
                Console.WriteLine(outer);
            }
        }
    }
}
