using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     Asked in nagarro, taken test on 21/07/2022
     TechMahindra "Student Report" Coding Question
    https://dev.to/gouravmpk/student-report-coding-question-1e1
    Statement :-
Given a list of N students, every student is marked for M subjects. Each student is denoted by an index value. 
    Their teacher Ms. Margaret must ignore the marks of any 1 subject for every student. 
    For this she decides to ignore the subject which has the lowest class average.
Your task is to help her find that subject, calculate the total marks of each student in all the other subjects and then finally return the array of the total marks scored by each student
    Input Specification:
input1:
An integer value N denoting number of students

input2:
An integer value M denoting number of subjects

input3:
A 2-D integer array of size N'M containing the marks of all students in each subject.
Output Specification:

Return an integer array of size N containing the total marks of each student afte deducting the score for that one subject.
    Example 1:
INPUT
3 5
75 76 65 87 87
78 76 68 56 89
67 87 78 77 65
    OUTPUT
325 299 296
    Example 2:
INPUT
3 3
50 30 70 
30 70 99 
99 20 30
OUTPUT
120 129 129
    Explanation:

Out of these subjects, the students average was lowest in subject 2
i.e 30+70+20= 120/3=40

So the teacher will ignore marks of this subject and will consider the title other two subjects for each of the three students i.e. 120 129 129 respectively

Hence (120 129 129) is returned as the final output.

Solution:-




     */
    class NagarroStudentReport
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            int[] avg = new int[row];
            int[] ans = new int[row];
            int[,] arr= new int[row,col];
            int[] res = new int[row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    arr[i,j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < row; i++)
            { //calculating and storing average of each column
                for (int j = 0; j < row; j++)
                {
                    ans[i] += arr[j,i];

                }
                avg[i] = ans[i] / row;

            }

            int min = avg[0];
            int eleminate_Index = 0;
            for (int i = 1; i < row; i++)
            { 
                // minimum average calculated and ..
                if (avg[i] < min)
                {
                    min = avg[i];
                    eleminate_Index = i; //..index of it stored.
                }
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (eleminate_Index != j)
                    {
                        //calculating sum of remaining subjects
                        res[i] += arr[i,j];
                    }
                }

            }
            for (int j = 0; j < row; j++)
            {
                Console.WriteLine(res[j] + " ");
            }
        }
    }
}
