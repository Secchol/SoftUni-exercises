using System;
using System.Collections.Generic;
using System.Linq;

namespace Dragon_Game
{
    class Dragon
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public Dragon(string type, string name, int damage, int health, int armor)
        {
            this.Type = type;
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;



        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int dragonCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<Dragon>> dragonDictionary = new Dictionary<string, List<Dragon>>();
            for (int i = 0; i < dragonCount; i++)
            {
                string[] infoArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = infoArray[0];
                string name = infoArray[1];
                if (infoArray[2] == "null")
                {
                    infoArray[2] = "45";

                }
                else if (infoArray[3] == "null")
                {
                    infoArray[3] = "250";
                }
                else if (infoArray[4] == "null")
                {
                    infoArray[4] = "10";


                }
                int damage = int.Parse(infoArray[2]);
                int health = int.Parse(infoArray[3]);
                int armor = int.Parse(infoArray[4]);
                bool isFound = false;

                Dragon dragon = new Dragon(type, name, damage, health, armor);

                if (dragonDictionary.ContainsKey(type))
                {
                    for (int j = 0; j < dragonDictionary[type].Count; j++)
                    {
                        if (dragonDictionary[type][j].Name == dragon.Name)
                        {
                            dragonDictionary[type][j] = dragon;
                            isFound = true;


                        }
                    }
                    if (!isFound)
                    {
                        dragonDictionary[type].Add(dragon);

                    }


                }
                else
                {
                    dragonDictionary.Add(type, new List<Dragon> { dragon });



                }
                dragonDictionary[type] = dragonDictionary[type].OrderBy(x => x.Name).ToList();



            }
            Dictionary<string, List<double>> averageValues = new Dictionary<string, List<double>>();
            foreach (var type in dragonDictionary)
            {
                averageValues[type.Key] = new List<double> { 0, 0, 0 };
                foreach (Dragon dragon in dragonDictionary[type.Key])
                {
                    averageValues[type.Key][0] += dragon.Damage;
                    averageValues[type.Key][1] += dragon.Health;
                    averageValues[type.Key][2] += dragon.Armor;



                }


            }
            foreach (var item in dragonDictionary)
            {
                Console.WriteLine($"{item.Key}::({averageValues[item.Key][0] / dragonDictionary[item.Key].Count:F2}/{averageValues[item.Key][1] / dragonDictionary[item.Key].Count:F2}/{averageValues[item.Key][2] / dragonDictionary[item.Key].Count:F2})");
                foreach (Dragon dragon in item.Value)
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");


                }



            }

        }
    }
}
