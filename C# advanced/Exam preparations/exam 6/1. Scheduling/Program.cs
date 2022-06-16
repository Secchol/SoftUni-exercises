using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int taskToBeKilled = int.Parse(Console.ReadLine());
            while (true)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();
                if (currentTask == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {taskToBeKilled}");
                    Console.WriteLine(String.Join(" ", threads));
                    Environment.Exit(0);

                }
                if (currentThread >= currentTask)
                    tasks.Pop();
                threads.Dequeue();



            }
        }
    }
}
