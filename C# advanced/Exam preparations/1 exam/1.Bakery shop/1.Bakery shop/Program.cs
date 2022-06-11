using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Bakery_shop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waterValues = new Queue<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray());
            Stack<double> flourValues = new Stack<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray());
            var products = new Dictionary<string, int>();
            while (waterValues.Count != 0 && flourValues.Count != 0)
            {
                double currentWater = waterValues.Peek();
                double currentFlour = flourValues.Peek();
                double waterPercentage = currentWater * 100 / (currentFlour + currentWater);
                string product = string.Empty;
                double flourLeft = 0;
                if (waterPercentage == 50)
                {
                    product = "Croissant";


                }
                else if (waterPercentage == 40)
                {
                    product = "Muffin";


                }
                else if (waterPercentage == 30)
                {
                    product = "Baguette";


                }
                else if (waterPercentage == 20)
                {
                    product = "Bagel";


                }
                else
                {
                    product = "Croissant";
                    if (waterPercentage < 50)
                        flourLeft = flourValues.Peek() - waterValues.Peek();
                    else
                        flourLeft = 0;


                }
                if (!products.ContainsKey(product))
                    products.Add(product, 0);
                products[product]++;
                waterValues.Dequeue();
                flourValues.Pop();
                if (flourLeft != 0)
                    flourValues.Push(flourLeft);



            }
            foreach (var product in products.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
            if (waterValues.Count == 0)
                Console.WriteLine("Water left: None");
            else
                Console.WriteLine($"Water left {string.Join(", ", waterValues)}");

            if (flourValues.Count == 0)
                Console.WriteLine("Flour left: None");
            else
                Console.WriteLine($"Flour left: {string.Join(", ", flourValues)}");



        }
    }
}
