using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_continent_and_country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var cities = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < count; i++)
            {
                string[] token = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = token[0];
                string country = token[1];
                string city = token[2];
                if (!cities.ContainsKey(continent))
                    cities[continent] = new Dictionary<string, List<string>>();
                if (!cities[continent].ContainsKey(country))
                    cities[continent][country] = new List<string>();
                cities[continent][country].Add(city);

            }
            foreach (var (continent, countries) in cities)
            {
                Console.WriteLine($"{continent}:");
                foreach (var country in countries)
                {
                    string towns = string.Join(", ",country.Value);
                    Console.WriteLine($"\t{country.Key} -> {towns}");


                }



            }
        }
    }
}
