using System;
using System.Collections.Generic;
using System.Linq;
namespace Clothes_shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesWeight = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int racksCount = 1;
            int currentWeightOnRack = 0;
            if (rackCapacity == 0)
            {
                Console.WriteLine(clothesWeight.Count);
                return;


            }


            while (clothesWeight.Count > 0)
            {
                currentWeightOnRack += clothesWeight.Peek();
                if (currentWeightOnRack == rackCapacity)
                {
                    currentWeightOnRack = 0;
                    racksCount++;
                    clothesWeight.Pop();


                }
                else if (currentWeightOnRack > rackCapacity)
                {
                    currentWeightOnRack = 0;
                    racksCount++;



                }
                else
                {
                    clothesWeight.Pop();


                }



            }
            Console.WriteLine(racksCount);
        }
    }
}
