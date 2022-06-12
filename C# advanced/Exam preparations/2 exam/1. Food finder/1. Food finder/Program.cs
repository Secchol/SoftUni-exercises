using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Food_finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());
            Dictionary<string, int> words = new Dictionary<string, int>();
            words.Add("pear", 0);
            words.Add("flour", 0);
            words.Add("pork", 0);
            words.Add("olive", 0);
            Dictionary<string, int> wordsChanger = words.ToDictionary(x => x.Key, x => x.Value);
            List<char> usedLetters = new List<char>();
            List<string> wordsFound = new List<string>();
            foreach (char consonant in consonants)
            {
                char currentVowel = vowels.Dequeue();
                foreach (var word in words)
                {
                    if (word.Key.Contains(consonant) && !usedLetters.Contains(consonant))
                    {
                        wordsChanger[word.Key]++;

                    }
                    if (word.Key.Contains(currentVowel) && !usedLetters.Contains(currentVowel))
                    {
                        wordsChanger[word.Key]++;

                    }


                }
                usedLetters.Add(consonant);
                usedLetters.Add(currentVowel);
                foreach (var word in wordsChanger)
                {
                    if (word.Key.Length == word.Value)
                        wordsFound.Add(word.Key);

                }
                wordsChanger = wordsChanger.Where(x => x.Key.Length != x.Value).ToDictionary(x => x.Key, x => x.Value);

                vowels.Enqueue(currentVowel);
            }
            Console.WriteLine($"Words found: {wordsFound.Count}");
            foreach (var word in words)
            {
                if (wordsFound.Contains(word.Key))
                    Console.WriteLine(word.Key);


            }
        }
    }
}
