using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Exercise_one
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] toSplit = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, List<string>> wordsAndDefinitions = new Dictionary<string, List<string>>();
            foreach (string word in toSplit)
            {
                string[] splitWordAndDefinition = word.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                if (!wordsAndDefinitions.ContainsKey(splitWordAndDefinition[0]))
                {
                    wordsAndDefinitions[splitWordAndDefinition[0]] = new List<string>();



                }
                wordsAndDefinitions[splitWordAndDefinition[0]].Add(splitWordAndDefinition[1]);
            }
            string[] wordsToBeTestedOn = Console.ReadLine().Split(" | ", StringSplitOptions.RemoveEmptyEntries);
            string command = Console.ReadLine();
            if (command == "Hand Over")
            {
                string[] wordsInNotebook = wordsAndDefinitions.Select(x => x.Key).ToArray();
                Console.WriteLine(string.Join(" ", wordsInNotebook));



            }
            else if (command == "Test")
            {
                foreach (string word in wordsToBeTestedOn)
                {
                    if (wordsAndDefinitions.ContainsKey(word))
                    {
                        Console.WriteLine($"{word}:");
                        foreach (string item in wordsAndDefinitions[word])
                        {
                            Console.WriteLine($" -{item}");



                        }



                    }



                }



            }




        }
    }
}

