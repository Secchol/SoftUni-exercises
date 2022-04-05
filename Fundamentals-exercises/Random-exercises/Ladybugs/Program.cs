using System;
using System.Linq;

namespace Ladybugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] initialIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] field = new int[fieldSize];
            for (int i = 0; i < fieldSize; i++)
            {
                if (initialIndexes.Contains(i))
                {

                    field[i] = 1;

                }
            }
            string commands;
            while ((commands = Console.ReadLine()) != "end")
            {
                string[] commandsArray = commands.Split();
                int initialIndex = int.Parse(commandsArray[0]);
                string direction = commandsArray[1];
                int flyLength = int.Parse(commandsArray[2]);
                if (initialIndex < 0 || initialIndex >= fieldSize)
                {
                    continue;


                }
                if (field[initialIndex] == 0)
                {
                    continue;


                }
                field[initialIndex] = 0;
                int nextIndex = initialIndex;
                while (true)
                {


                    if (direction == "right")
                    {
                        nextIndex += flyLength;


                    }
                    else if (direction == "left")
                    {
                        nextIndex -= flyLength;


                    }
                    if (nextIndex < 0 || nextIndex >= field.Length)
                    {
                        break;


                    }
                    if (field[nextIndex] == 0)
                    {
                        break;

                    }


                }
                if (nextIndex >= 0 && nextIndex < field.Length)
                {
                    field[nextIndex] = 1;


                }


            }
            Console.WriteLine(String.Join(" ", field));
        }
    }
}

