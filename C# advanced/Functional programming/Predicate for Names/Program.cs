using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Predicate<string> validLength = x => x.Length <= nameLength;
            names = names.FindAll(validLength);
            Console.WriteLine(String.Join("\n", names));
        }
    }
}
