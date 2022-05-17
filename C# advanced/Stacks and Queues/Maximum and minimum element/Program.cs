using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_minimum_element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < commandsCount; i++)
            {
                int[] commandsArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                if (commandsArray[0] == 1)
                {
                    stack.Push(commandsArray[1]);



                }
                else if (commandsArray[0] == 2)
                {
                    stack.Pop();



                }
                else if (commandsArray[0] == 3)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Max());


                    }



                }
                else if (commandsArray[0] == 4)
                {
                    if (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Min());


                    }



                }
            }
            List<int> stackElements = new List<int>();
            while (stack.Count > 0)
            {
                stackElements.Add(stack.Pop());


            }
            Console.WriteLine(String.Join(", ", stackElements));
        }
    }
}
