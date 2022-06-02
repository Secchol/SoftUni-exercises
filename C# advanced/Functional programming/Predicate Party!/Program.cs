using System;
using System.Collections.Generic;
using System.Linq;
namespace Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            while (command != "Party!")
            {
                string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Predicate<string> format = FormatFinder(commandArray[1], commandArray[2]);

                if (commandArray[0] == "Remove")
                {
                    people.RemoveAll(format);


                }
                else if (commandArray[0] == "Double")
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (format(people[i]))
                        {
                            people.Insert(i + 1, people[i]);
                            i += 1;



                        }
                    }


                }
                command = Console.ReadLine();

            }
            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                Environment.Exit(0);

            }
            Console.WriteLine($"{string.Join(", ", people)} are going to the party!");





        }
        static Predicate<string> FormatFinder(string condition, string element)
        {
            switch (condition)
            {
                case "StartsWith":
                    return x => x.StartsWith(element);
                case "EndsWith":
                    return x => x.EndsWith(element);
                case "Length":
                    return x => x.Length == int.Parse(element);
                default:
                    return null;


            }






        }
    }
}

