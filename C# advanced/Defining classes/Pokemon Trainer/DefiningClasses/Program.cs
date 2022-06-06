using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            HashSet<Trainer> trainers = new HashSet<Trainer>();

            while (command != "Tournament")
            {
                string[] info = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);
                Trainer trainerTest = trainers.FirstOrDefault(x => x.Name == trainerName);
                if (trainerTest == null)
                {
                    Trainer newTrainer = new Trainer();
                    newTrainer.Name = trainerName;
                    trainers.Add(newTrainer);


                }
                Trainer trainer = trainers.First(x => x.Name == trainerName);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainer.Pokemon.Add(pokemon);


                command = Console.ReadLine();
            }
            command = Console.ReadLine();

            while (command != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemon.Where(x => x.Element == command).ToList().Count > 0)
                    {
                        trainer.NumberOfBadgets++;


                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemon)
                        {
                            pokemon.Health -= 10;

                        }
                        trainer.Pokemon.RemoveWhere(x => x.Health <= 0);


                    }


                }

                command = Console.ReadLine();
            }
            foreach (Trainer trainer in trainers.OrderByDescending(x => x.NumberOfBadgets))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadgets} {trainer.Pokemon.Count}");


            }
        }
    }
}
