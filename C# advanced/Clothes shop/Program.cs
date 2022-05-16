using System;
using System.Collections.Generic;
using System.Linq;
namespace Clothes_shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int racksCount = 1;
            int currentWeightOnRack = 0;



            while (clothes.Count > 0)
            {
                currentWeightOnRack += clothes.Peek();
                if (currentWeightOnRack == rackCapacity)
                {
                    clothes.Pop();
                    currentWeightOnRack = 0;
                    if (clothes.Count > 0)
                    {

                        racksCount++;

                    }
                    



                }
                else if (currentWeightOnRack > rackCapacity)
                {
                    currentWeightOnRack = 0;
                    racksCount++;



                }
                else
                {
                    clothes.Pop();


                }



            }
            Console.WriteLine(racksCount);
        }
    }
}
