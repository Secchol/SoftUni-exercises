using System;
using System.Collections.Generic;

namespace Third_exercise
{
    class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
        public City(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;



        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string towns = Console.ReadLine();
            Dictionary<string, City> cities = new Dictionary<string, City>();
            while (towns != "Sail")
            {
                string[] cityArray = towns.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string name = cityArray[0];
                int population = int.Parse(cityArray[1]);
                int gold = int.Parse(cityArray[2]);
                City city = new City(name, population, gold);
                if (cities.ContainsKey(name))
                {
                    cities[name].Gold += gold;
                    cities[name].Population += population;


                }
                else
                {
                    cities[name] = city;

                }
                towns = Console.ReadLine();
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandsArray = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string action = commandsArray[0];
                string city = commandsArray[1];
                if (action == "Plunder")
                {
                    int population = int.Parse(commandsArray[2]);
                    int gold = int.Parse(commandsArray[3]);
                    cities[city].Gold -= gold;
                    cities[city].Population -= population;
                    Console.WriteLine($"{city} plundered! {gold} gold stolen, {population} citizens killed.");
                    if (cities[city].Gold <= 0 || cities[city].Population <= 0)
                    {
                        cities.Remove(city);
                        Console.WriteLine($"{city} has been wiped off the map!");



                    }



                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(commandsArray[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                        command = Console.ReadLine();
                        continue;

                    }
                    cities[city].Gold += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {city} now has {cities[city].Gold} gold.");




                }


                command = Console.ReadLine();
            }
            if (cities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                return;

            }
            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Key} -> Population: {city.Value.Population} citizens, Gold: {city.Value.Gold} kg");



            }
        }
    }
}
