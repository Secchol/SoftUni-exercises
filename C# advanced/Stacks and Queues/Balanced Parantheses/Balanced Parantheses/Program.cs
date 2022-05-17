using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parantheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            Stack<char> normal = new Stack<char>();
            Stack<char> curly = new Stack<char>();
            Stack<char> square = new Stack<char>();
            for (int i = 0; i < sequence.Length; i++)
            {
                char character = sequence[i];
                if (character == '(')
                {
                    normal.Push(character);


                }
                else if (character == '{')
                {
                    curly.Push(character);


                }
                else if (character == '[')
                {
                    square.Push(character);


                }
                else if (character == ')')
                {
                    normal.Pop();


                }
                else if (character == ']')
                {
                    square.Pop();


                }
                else if (character == '}')
                {
                    curly.Pop();


                }
            }
            if (square.Count == 0 && curly.Count == 0 && normal.Count == 0)
            {
                Console.WriteLine("YES");


            }
            else
            {
                Console.WriteLine("NO");


            }
        }
    }
}
