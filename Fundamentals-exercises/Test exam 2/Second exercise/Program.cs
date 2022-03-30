using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Second_exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex emojiPattern = new Regex(@"(::|\*\*)(?<word>[A-Z][a-z]{2,})\1");
            Regex numberPattern = new Regex(@"\d");
            List<long> coolThresholdList = numberPattern.Matches(text).Select(x => x.Value).Select(x => long.Parse(x)).ToList();
            long coolThreshold = 1;
            foreach (long element in coolThresholdList)
            {
                coolThreshold *= element;



            }
            MatchCollection matches = emojiPattern.Matches(text);
            List<string> emojies = new List<string>();
            foreach (Match match in matches)
            {
                string emoji = match.Groups["word"].Value;
                int coolness = 0;
                foreach (char character in emoji)
                {
                    coolness += character;



                }
                if (coolness >= coolThreshold)
                {
                    emojies.Add(match.Value);



                }



            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (string emoji in emojies)
            {
                Console.WriteLine(emoji);



            }

        }
    }
}
