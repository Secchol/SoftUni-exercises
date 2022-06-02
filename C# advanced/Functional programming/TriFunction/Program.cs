using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int charSum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Func<List<string>, int, string> firstValidName = (list, charSum) =>
            {
                for (int i = 0; i < list.Count; i++)
                {
                    char[] currentName = list[i].ToCharArray();
                    int sum = 0;
                    for (int j = 0; j < currentName.Length; j++)
                    {
                        sum += currentName[j];

                    }
                    if (sum >= charSum)
                        return list[i];
                }
                return null;


            };
            Console.WriteLine(firstValidName(names,charSum));
        }
    }
}
