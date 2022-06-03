using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();
            var removedPeople = new Dictionary<string, Queue<string>>();
            while (command != "Print")
            {
                string[] commandArray = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string addOrRemove = commandArray[0];
                string filter = commandArray[1];
                string filterElement = commandArray[2];
                Predicate<string> format = FormatFinder(filter, filterElement);
                string[] filterElements = new string[2];
                filterElements[0] = filter;
                filterElements[1] = filterElement;
                string key = string.Join(" ", filterElements);
                if (addOrRemove == "Add filter")
                {

                    removedPeople.Add(key, new Queue<string>());
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (format(people[i]))
                        {
                            removedPeople[key].Enqueue(people[i]);
                            people.RemoveAt(i);
                            i--;

                        }
                    }


                }
                else if (addOrRemove == "Remove filter")
                {
                    Queue<string> peopleToAdd = removedPeople[key];
                    while (peopleToAdd.Count > 0)
                        people.Insert(0, peopleToAdd.Dequeue());


                }


                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", people));



        }
        static Predicate<string> FormatFinder(string filter, string filterElement)
        {
            switch (filter)
            {
                case "Starts with":
                    return x => x.StartsWith(filterElement);
                case "Ends with":
                    return x => x.EndsWith(filterElement);
                case "Length":
                    return x => x.Length == int.Parse(filterElement);
                case "Contains":
                    return x => x.Contains(filterElement);
                default:
                    return null;


            }
        }

    }
}
