using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_stack_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            int numbersToPush = info[0];
            int numbersToPop = info[1];
            int numberToLookFor = info[2];
            Stack<int> stack = new Stack<int>();
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            for (int i = 0; i < numbersToPush; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < numbersToPop; i++)
            {
                stack.Pop();
            }
            string output = string.Empty;
            if (stack.Contains(numberToLookFor))
            {
                output = "true";


            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);


            }
            else
            {
                int minNumber = int.MaxValue;
                while (stack.Count > 0)
                {
                    int number = stack.Pop();
                    if (number < minNumber)
                    {
                        minNumber = number;


                    }


                }
                output = minNumber.ToString();


            }
            Console.WriteLine(output);
        }
    }
}
