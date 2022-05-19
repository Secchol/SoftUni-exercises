using System;
using System.Linq;

namespace Jagged_array_modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrayRows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[arrayRows][];
            for (int rows = 0; rows < arrayRows; rows++)
            {
                jaggedArray[rows] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();


            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandArr[0] == "Add" || commandArr[0] == "Subtract")
                {
                    int row = int.Parse(commandArr[1]);
                    int element = int.Parse(commandArr[2]);
                    int value = int.Parse(commandArr[3]);
                    if (row < 0 || element < 0 || row >= jaggedArray.Length || element >= jaggedArray[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        command = Console.ReadLine();
                        continue;


                    }

                    if (commandArr[0] == "Subtract")
                    {
                        value = -value;



                    }

                    jaggedArray[row][element] += value;

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
