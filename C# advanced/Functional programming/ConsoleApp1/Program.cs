using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            Func<int, int> add = x => x + 1;
            Func<int, int> subtract = x => x - 1;
            Func<int, int> multiply = x => x * 2;
            Action<int> print = x => Console.Write($"{x} ");
            while (command != "end")
            {
                if (command == "add")
                {
                    numbers = numbers.Select(add).ToList();

                }
                else if (command == "multiply")
                {
                    numbers = numbers.Select(multiply).ToList();


                }
                else if (command == "subtract")
                {
                    numbers = numbers.Select(subtract).ToList();


                }
                else if (command == "print")
                {
                    numbers.ForEach(print);
                    Console.WriteLine();



                }

                command = Console.ReadLine();
            }
        }
    }

}

