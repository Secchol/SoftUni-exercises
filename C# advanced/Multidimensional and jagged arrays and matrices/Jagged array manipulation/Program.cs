using System;
using System.Linq;

namespace Jagged_array_manipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arraySize = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[arraySize][];
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int element = 0; element < jaggedArray[row].Length; element++)
                    {
                        jaggedArray[row][element] *= 2;
                        jaggedArray[row + 1][element] *= 2;
                    }


                }
                else
                {
                    for (int element = 0; element < jaggedArray[row].Length; element++)
                    {
                        jaggedArray[row][element] /= 2;

                    }
                    for (int element = 0; element < jaggedArray[row + 1].Length; element++)
                    {
                        jaggedArray[row + 1][element] /= 2;

                    }


                }
            }
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandsArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandsArray[0] == "Add" || commandsArray[0] == "Subtract")
                {
                    int row = int.Parse(commandsArray[1]);
                    int element = int.Parse(commandsArray[2]);
                    int value = int.Parse(commandsArray[3]);
                    if (row >= 0 && element >= 0 && row < jaggedArray.Length && element < jaggedArray[row].Length)
                    {
                        if (commandsArray[0] == "Subtract")
                        {

                            value = -value;

                        }
                        jaggedArray[row][element] += value;

                    }


                }


                command = Console.ReadLine();
            }
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[row]));
            }
        }
    }
}
