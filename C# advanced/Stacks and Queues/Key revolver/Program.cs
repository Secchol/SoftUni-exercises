using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int intelligenceValue = int.Parse(Console.ReadLine());
            int bulletCounter = 0;
            int bulletsInBarell = barrelSize;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");

                    locks.Dequeue();



                }
                else
                {
                    Console.WriteLine("Ping!");


                }
                bullets.Pop();
                bulletCounter++;
                bulletsInBarell--;
                if (bulletsInBarell == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    bulletsInBarell = barrelSize;


                }




            }
            if (locks.Count == 0)
            {
                int moneyEarned = intelligenceValue - bulletPrice * bulletCounter;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");


            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");


            }
        }
    }
}
