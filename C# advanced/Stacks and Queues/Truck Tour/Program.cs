using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();

            for (int i = 0; i < numberOfPumps ; i++)
            {
                string pump = Console.ReadLine();
                pumps.Enqueue(pump);
            }
            int index = 0;
            while (pumps.Count > 0)
            {
                int[] pumpInfo = pumps.Dequeue().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();
                if (pumpInfo[0] - pumpInfo[1] >= 0)
                {
                    Console.WriteLine(index);
                    break;


                }
                index++;


            }
        }
    }
}
