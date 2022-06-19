using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffect = new Queue<int>(Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Dictionary<string, int> bombs = new Dictionary<string, int>();
            bombs.Add("Datura Bombs", 0);
            bombs.Add("Cherry Bombs", 0);
            bombs.Add("Smoke Decoy Bombs", 0);
            bool casingFilled = false;
            while (bombEffect.Count != 0 && bombCasing.Count != 0)
            {
                int currentBombEffect = bombEffect.Peek();
                int currentCasing = bombCasing.Peek();
                int sum = currentBombEffect + currentCasing;
                if (sum == 40)
                {
                    bombs["Datura Bombs"]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else if (sum == 60)
                {

                    bombs["Cherry Bombs"]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();


                }
                else if (sum == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();


                }
                else
                {
                    int[] bombCasingArr = bombCasing.ToArray();
                    bombCasingArr[0] -= 5;
                    Array.Reverse(bombCasingArr);
                    bombCasing = new Stack<int>(bombCasingArr);

                }
                if (bombs.Where(x => x.Value >= 3).ToDictionary(x => x.Key, x => x.Value).Count == 3)
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    casingFilled = true;
                    break;

                }

            }
            if (!casingFilled)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");

            }
            if (bombEffect.Count == 0)
                Console.WriteLine("Bomb Effects: empty");
            else
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");

            if (bombCasing.Count == 0)
                Console.WriteLine("Bomb Casings: empty");
            else
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");

            foreach (var bomb in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");

            }
        }
    }
}
