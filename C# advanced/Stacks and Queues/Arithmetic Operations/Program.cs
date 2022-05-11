using System;
using System.Collections.Generic;

namespace Arithmetic_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.Push(i);


                }
                else if (expression[i] == ')')
                {
                    int firstIndex = stack.Pop();
                    int lastIndex = i;
                    Console.WriteLine(expression.Substring(firstIndex, lastIndex - firstIndex + 1));


                }
            }
        }
    }
}
