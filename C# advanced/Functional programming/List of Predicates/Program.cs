using System;
using System.Collections.Generic;
using System.Linq;

namespace List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> numbers = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);
            }
            Func<int, int[], bool> isDivisible = (x, dividers) =>
              {
                  foreach (int divider in dividers)
                  {
                      if (x % divider != 0)
                          return false;


                  }
                  return true;



              };
            numbers = numbers.Where(x => isDivisible(x, dividers)).ToList();
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
