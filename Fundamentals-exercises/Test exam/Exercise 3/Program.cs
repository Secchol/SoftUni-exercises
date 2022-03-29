using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Exercise_3
{
    class Hero
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public Hero(string name, int hitPoints, int mana)
        {
            this.Name = name;
            this.HP = hitPoints;
            this.MP = mana;
        }



    }

    class Program
    {

        static void Main(string[] args)
        {
            int heroCount = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            for (int i = 0; i < heroCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int HP = int.Parse(tokens[1]);
                int MP = int.Parse(tokens[2]);
                Hero hero = new Hero(name, HP, MP);
                heroes[name] = hero;
            }
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandsArray = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandsArray[0];
                string heroName = commandsArray[1];
                if (action == "CastSpell")
                {
                    int MPNeeded = int.Parse(commandsArray[2]);
                    string spellName = commandsArray[3];
                    if (heroes[heroName].MP - MPNeeded >= 0)
                    {
                        heroes[heroName].MP -= MPNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");


                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");



                    }



                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(commandsArray[2]);
                    string attacker = commandsArray[3];
                    if (heroes[heroName].HP - damage > 0)
                    {
                        heroes[heroName].HP -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");



                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(heroName);


                    }



                }
                else if (action == "Recharge")
                {
                    int rechargeAmount = int.Parse(commandsArray[2]);

                    if (heroes[heroName].MP + rechargeAmount > 200)
                    {
                        Console.WriteLine($"{heroName} recharged for {200 - heroes[heroName].MP} MP!");
                        heroes[heroName].MP = 200;
                    }
                    else
                    {
                        heroes[heroName].MP += rechargeAmount;
                        Console.WriteLine($"{heroName} recharged for {rechargeAmount} MP!");


                    }



                }
                else if (action == "Heal")
                {
                    int healedAmount = int.Parse(commandsArray[2]);

                    if (heroes[heroName].HP + healedAmount > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {100 - heroes[heroName].HP} HP!");
                        heroes[heroName].HP = 100;
                    }
                    else
                    {
                        heroes[heroName].HP += healedAmount;
                        Console.WriteLine($"{heroName} healed for {healedAmount} HP!");


                    }



                }


                command = Console.ReadLine();
            }
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");



            }






        }




    }
}
