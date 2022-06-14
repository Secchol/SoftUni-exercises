using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            List<int> claimedItems = new List<int>();
            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstItem = firstBox.Peek();
                int secondItem = secondBox.Pop();
                int sum = firstItem + secondItem;
                if (sum % 2 == 0)
                {
                    firstBox.Dequeue();
                    claimedItems.Add(sum);


                }
                else
                {
                    firstBox.Enqueue(secondItem);

                }
            }
            if (firstBox.Count == 0)
                Console.WriteLine("First lootbox is empty");
            if (secondBox.Count == 0)
                Console.WriteLine("Second lootbox is empty");
            int sumOfClaimedItems = claimedItems.Sum();
            if (sumOfClaimedItems >= 100)
                Console.WriteLine($"Your loot was epic! Value: {sumOfClaimedItems}");
            else
                Console.WriteLine($"Your loot was poor... Value: {sumOfClaimedItems}");
        }
    }
}
