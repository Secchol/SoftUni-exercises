using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parantheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool isBalanced = true;
            Stack<char> stack = new Stack<char>();


            foreach (char item in input)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    stack.Push(item);
                    continue;


                }
                if (stack.Count == 0)
                {
                    isBalanced = false;
                    break;

                }
                if (item == ')' && stack.Peek() == '(')
                {

                    stack.Pop();


                }
                else if (item == '}' && stack.Peek() == '{')
                {

                    stack.Pop();


                }
                else if (item == ']' && stack.Peek() == '[')
                {

                    stack.Pop();


                }
                else
                {
                    isBalanced = false;
                    break;


                }
            }
            if (!isBalanced || stack.Count > 0)
            {

                Console.WriteLine("NO");


            }
            else
            {
                Console.WriteLine("YES");


            }
        }
    }
}
