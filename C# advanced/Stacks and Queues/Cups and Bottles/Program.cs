using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsCapacity = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> bottlesCapacity = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int wastedWater = 0;
            while (cupsCapacity.Count > 0 && bottlesCapacity.Count > 0)
            {
                int currentCupCapacity = cupsCapacity.Peek();
                int currentBottleCapacity = bottlesCapacity.Peek();
                if (currentBottleCapacity >= currentCupCapacity)
                {
                    currentBottleCapacity -= currentCupCapacity;
                    wastedWater += currentBottleCapacity;
                    bottlesCapacity.Pop();
                    cupsCapacity.Dequeue();


                }
                else if (currentCupCapacity > currentBottleCapacity)
                {
                    currentCupCapacity -= currentBottleCapacity;
                    bottlesCapacity.Pop();
                    while (true)
                    {
                        if (bottlesCapacity.Peek() - currentCupCapacity < 0)
                        {
                            currentCupCapacity -= bottlesCapacity.Pop();



                        }
                        else
                        {
                            wastedWater += bottlesCapacity.Pop() - currentCupCapacity;
                            cupsCapacity.Dequeue();
                            break;


                        }






                    }



                }
            }
            if (bottlesCapacity.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");


            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottlesCapacity)}");


            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
