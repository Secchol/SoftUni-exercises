using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Exercise_three
{
    class Plant
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public double Rating { get; set; }
        public Plant(string name, int rarity, double rating)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.Rating = rating;




        }



    }

    class Program
    {

        static void Main(string[] args)
        {
            int plantsCount = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();
            for (int i = 0; i < plantsCount; i++)
            {
                string[] plantToken = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = plantToken[0];
                int plantRarity = int.Parse(plantToken[1]);
                Plant plant = new Plant(plantName, plantRarity, 0);
                if (!plants.ContainsKey(plantName))
                {
                    plants[plantName] = plant;


                }
                else
                {
                    plants[plantName].Rarity = plantRarity;


                }

            }
            string command = Console.ReadLine();
            Dictionary<string, int> countOfRatings = new Dictionary<string, int>();
            foreach (var plant in plants)
            {
                countOfRatings[plant.Key] = 0;


            }
            while (command != "Exhibition")
            {
                string[] commandsArray = command.Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries);
                string action = commandsArray[0];
                string plantName = commandsArray[1];
                if (!plants.ContainsKey(plantName))
                {
                    Console.WriteLine("error");
                    command = Console.ReadLine();
                    continue;


                }
                if (action == "Rate")
                {
                    double rating = double.Parse(commandsArray[2]);
                    plants[plantName].Rating += rating;
                    countOfRatings[plantName]++;


                }
                else if (action == "Update")
                {
                    int rarity = int.Parse(commandsArray[2]);
                    plants[plantName].Rarity = rarity;



                }
                else if (action == "Reset")
                {
                    plants[plantName].Rating = 0;
                    countOfRatings[plantName] = 0;

                }


                command = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                double averageRating;
                if (countOfRatings[plant.Key] != 0)
                {
                    averageRating = plant.Value.Rating / countOfRatings[plant.Key];


                }
                else
                {
                    averageRating = 0;


                }

                Console.WriteLine($" - {plant.Key}; Rarity: { plant.Value.Rarity}; Rating: { averageRating:F2}");



            }




        }
    }
}

