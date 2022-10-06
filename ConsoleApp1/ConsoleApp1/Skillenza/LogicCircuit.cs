using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    /*
PlanetCast    Combinational Logic Circuit
You’re given a combinational logic circuit. There are multiple binary inputs with a single binary output. The circuit is in the form of a full binary tree. All inputs are provided at the leaf nodes and every other node is a logic gate.

Input Format
The first line of input consists of an integer t denoting the number of test cases. The first line of each test case consists of an integer h denoting the height of the tree. First line of line of each test case consists of space separated binary inputs (0 or 1) denoting the inputs to the circuit. Next n-1 lines consists of logic gates space separated.

Output Format
For each circuit print the output (0 or 1) found after feeding inputs into the circuit.

Sample Input
3
2
1 0
or
4
1 1 0 1 1 0 0 0
xor nand or and
or nor
xnor
3
1 1 1 1
and and
and
Sample Output
1
0
1
Truth table
A	B	AND	NAND	OR	NOR	XOR	XNOR
0	0	0	1	0	1	0	1
0	1	0	1	1	0	1	0
1	0	0	1	1	0	1	0
1	1	1	0	1	0	0	1
Constraints
1 <= t <= 128
2 <= h <= 16

Explanation
For input

4
1 1 0 1 1 0 0 0
xor nand or and
or nor
xnor

    output 0
    https://cdn.skillenza.com/files/dff361df-62ef-493a-bef6-35c5069108ad/in.txt
    https://cdn.skillenza.com/files/1748f780-3384-4f7b-a57f-9ab924203522/out.txt
     */
    public class LogicCircuit
    {
        public static void Main(string[] args)
        {
            int[] a = null; 
            int solvemiutes = 0;
            int T = int.Parse(Console.ReadLine());
            DateTime date1 = new DateTime(1900, 1, 1, 12, 0, 0);
            DateTime date = DateTime.Now;
            for (int i = 0; i < T; i++)
            {
                solvemiutes = 0; a = Console.ReadLine().Split(' ').Select(n1 => int.Parse(n1)).ToArray();
                
            }
        }
    }
}
