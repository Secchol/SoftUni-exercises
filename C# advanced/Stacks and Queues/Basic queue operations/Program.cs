using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_queue_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            int numbersToEnqueue = info[0];
            int numbersToDequeue = info[1];
            int numberToLookFor = info[2];
            Queue<int> queue = new Queue<int>();
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();
            for (int i = 0; i < numbersToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < numbersToDequeue; i++)
            {
                queue.Dequeue();
            }
            string output = string.Empty;
            if (queue.Contains(numberToLookFor))
            {
                output = "true";


            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);


            }
            else
            {
                int minNumber = int.MaxValue;
                while (queue.Count > 0)
                {
                    int number = queue.Dequeue();
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
