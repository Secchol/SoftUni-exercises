using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < count; i++)
            {
                string[] token = Console.ReadLine()
                    .Split(" -> ");
                string color = token[0];
                if (!wardrobe.ContainsKey(color))
                    wardrobe[color] = new Dictionary<string, int>();
                string[] clothes = token[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                foreach (string pieceOfClothing in clothes)
                {
                    if (!wardrobe[color].ContainsKey(pieceOfClothing))
                        wardrobe[color][pieceOfClothing] = 0;
                    wardrobe[color][pieceOfClothing]++;


                }



            }
            string[] clothesToSearchFor = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var (color, clothing) in wardrobe)
            {
                
                Console.WriteLine($"{color} clothes:");
                foreach (var cloth in clothing)
                {
                    Console.Write($"* {cloth.Key} - {cloth.Value}");
                    if (color == clothesToSearchFor[0] && cloth.Key == clothesToSearchFor[1])
                        Console.Write(" (found!)");
                    Console.WriteLine();



                }


            }
        }
    }
}
