using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());
            Queue<int> plates = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            bool noPlates = false;
            for (int i = 1; i <= numberOfWaves; i++)
            {

                Stack<int> orcs = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
                if (i % 3 == 0)
                    plates.Enqueue(int.Parse(Console.ReadLine()));

                while (orcs.Count > 0)
                {
                    int currentPlate = plates.Peek();
                    int currentOrc = orcs.Peek();
                    if (currentPlate > currentOrc)
                    {

                        int[] platesArr = plates.ToArray();
                        platesArr[0] -= currentOrc;
                        plates = new Queue<int>(platesArr);
                        orcs.Pop();

                    }
                    else if (currentPlate < currentOrc)
                    {
                        int[] orcArray = orcs.ToArray();
                        orcArray[0] -= currentPlate;
                        Array.Reverse(orcArray);
                        orcs = new Stack<int>(orcArray);

                        plates.Dequeue();


                    }
                    else
                    {
                        plates.Dequeue();
                        orcs.Pop();


                    }
                    if (plates.Count == 0)
                    {
                        noPlates = true;
                        break;
                    }


                }
                if (noPlates)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                    Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
                    Environment.Exit(0);

                }
            }
            Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
        }
    }
}
