using System;
using System.Linq;

namespace Matrix_shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[matrixSize[0], matrixSize[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArray[0] == "swap" && commandArray.Length == 5)
                {
                    int firstRowIndex = int.Parse(commandArray[1]);
                    int firstColIndex = int.Parse(commandArray[2]);
                    int secondRowIndex = int.Parse(commandArray[3]);
                    int secondColIndex = int.Parse(commandArray[4]);
                    if (firstRowIndex >= 0 && firstColIndex >= 0 && secondColIndex >= 0 && secondRowIndex >= 0 && firstRowIndex < matrix.GetLength(0) && secondRowIndex < matrix.GetLength(0) && firstColIndex < matrix.GetLength(1) && secondColIndex < matrix.GetLength(1))
                    {
                        string temp = matrix[firstRowIndex, firstColIndex];
                        matrix[firstRowIndex, firstColIndex] = matrix[secondRowIndex, secondColIndex];
                        matrix[secondRowIndex, secondColIndex] = temp;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }



                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");


                    }


                }
                else
                {
                    Console.WriteLine("Invalid input!");


                }

                command = Console.ReadLine();
            }
        }
    }
}
