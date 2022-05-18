using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] pump = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                pumps.Enqueue(pump);
            }
            int startIndex = 0;
            while (true)
            {
                int totalLiters = 0;
                bool isComplete = true;
                foreach (int[] item in pumps)
                {
                    int liters = item[0];
                    int distance = item[1];
                    totalLiters += liters;
                    if (totalLiters - distance < 0)
                    {
                        startIndex++;
                        int[] currentPump = pumps.Dequeue();
                        pumps.Enqueue(currentPump);
                        isComplete = false;
                        break;


                    }
                    totalLiters -= distance;

                }
                if (isComplete)
                {
                    Console.WriteLine(startIndex);
                    break;


                }



            }
        }
    }
}
