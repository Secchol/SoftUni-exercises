using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int heroesLeft = int.Parse(Console.ReadLine());
            List<BaseHero> heroes = new List<BaseHero>();

            while (heroesLeft != 0)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                BaseHero hero = CreateHero(name, type);
                if (hero == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }
                heroes.Add(hero);
                heroesLeft--;
            }


            int bossPoints = int.Parse(Console.ReadLine());
            int powerSum = 0;
            foreach (BaseHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                powerSum += hero.Power;

            }
            if (powerSum >= bossPoints)
                Console.WriteLine("Victory!");
            else
                Console.WriteLine("Defeat...");
        }
        public static BaseHero CreateHero(string name, string type)
        {
            if (type == "Druid")
                return new Druid(name);
            else if (type == "Paladin")
                return new Paladin(name);
            else if (type == "Rogue")
                return new Rogue(name);
            else if (type == "Warrior")
                return new Warrior(name);
            return null;





        }
    }
}
