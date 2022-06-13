using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredientValues = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Stack<int> freshnessValues = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Dictionary<string, int> dishes = new Dictionary<string, int>();
            dishes.Add("Dipping sauce", 0);
            dishes.Add("Green salad", 0);
            dishes.Add("Chocolate cake", 0);
            dishes.Add("Lobster", 0);
            while (ingredientValues.Count != 0 && freshnessValues.Count != 0)
            {
                int ingredient = ingredientValues.Peek();
                if (ingredient == 0)
                {
                    ingredientValues.Dequeue();
                    continue;

                }

                int freshness = freshnessValues.Pop();
                int totalFreshness = ingredient * freshness;
                string dish = string.Empty;
                switch (totalFreshness)
                {
                    case 150:
                        dish = "Dipping sauce";
                        break;
                    case 250:
                        dish = "Green salad";
                        break;
                    case 300:
                        dish = "Chocolate cake";
                        break;
                    case 400:
                        dish = "Lobster";
                        break;
                    default:
                        dish = string.Empty;
                        break;
                }
                if (dish != string.Empty)
                {
                    dishes[dish]++;
                    ingredientValues.Dequeue();

                }
                else
                {
                    ingredientValues.Dequeue();
                    ingredientValues.Enqueue(ingredient + 5);

                }



            }
            dishes = dishes.Where(x => x.Value >= 1).ToDictionary(x => x.Key, x => x.Value);
            if (dishes.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");


            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");


            }
            if (ingredientValues.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredientValues.Sum()}");

            }
            foreach (var dish in dishes.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");


            }
        }
    }
}
