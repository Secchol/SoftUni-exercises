using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_and_exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int divisibleBy = int.Parse(Console.ReadLine());
            Func<List<int>, List<int>> reverse = (list) =>
            {
                for (int i = 0; i < list.Count / 2; i++)
                {
                    int temp = list[i];
                    list[i] = list[list.Count - 1 - i];
                    list[list.Count - 1 - i] = temp;
                }

                return list;

            };
            numbers = reverse(numbers);

            Predicate<int> removeDivisibleElements = x => x % divisibleBy == 0;
            numbers.RemoveAll(removeDivisibleElements);
            Console.WriteLine(String.Join(" ",numbers));
        }
    }
}
