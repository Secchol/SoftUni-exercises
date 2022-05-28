using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var sides = new Dictionary<string, HashSet<string>>();
            string info = Console.ReadLine();

            while (info != "Lumpawaroo")
            {
                if (info.Contains(" | "))
                {
                    string[] infoArray = info.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = infoArray[0];
                    string forceUser = infoArray[1];
                    if (!sides.ContainsKey(forceSide))
                        sides.Add(forceSide, new HashSet<string>());
                    sides[forceSide].Add(forceUser);


                }
                else if (info.Contains(" -> "))
                {
                    string[] infoArray = info.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = infoArray[0];
                    string forceSide = infoArray[1];
                    if (!sides.ContainsKey(forceSide))
                        sides.Add(forceSide, new HashSet<string>());
                    foreach (var side in sides)
                    {
                        if (side.Value.Contains(forceUser))
                        {
                            side.Value.Remove(forceUser);


                        }


                    }
                    sides[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");


                }

                info = Console.ReadLine();
            }
            foreach (var side in sides.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (side.Value.Count == 0)
                    continue;
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (string forceUser in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {forceUser}");


                }


            }
        }
    }
}
