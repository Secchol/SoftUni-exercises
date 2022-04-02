using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Exercise_two
{


    class Program
    {

        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex regex = new Regex(@"(=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1");
            List<string> destinations = regex.Matches(text).Select(x => x.Groups["destination"].Value).ToList();
            int travelPoints = destinations.Select(x => x.Length).Sum();
            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");




        }
    }
}
