using System;
using System.Linq;

namespace Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                char[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => char.Parse(x))
                    .ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
            int[] currentPosition = new int[2];
            int coalCount = 0;
            for (int row = 0; row < matrixSize; row++)
            {

                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        currentPosition[0] = row;
                        currentPosition[1] = col;


                    }
                    else if (matrix[row, col] == 'c')
                        coalCount++;
                }
            }

            foreach (string command in commands)
            {
                int row = currentPosition[0];
                int col = currentPosition[1];
                if (command == "up" && IsValidIndex(matrix, row - 1, col))
                    row = row - 1;
                else if (command == "down" && IsValidIndex(matrix, row + 1, col))
                    row = row + 1;
                else if (command == "left" && IsValidIndex(matrix, row, col - 1))
                    col = col - 1;
                else if (command == "right" && IsValidIndex(matrix, row, col + 1))
                    col = col + 1;
                else
                    continue;


                if (matrix[row, col] == 'c')
                {
                    coalCount--;
                    matrix[row, col] = '*';
                    if (coalCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({row}, {col})");
                        Environment.Exit(0);
                    }


                }
                else if (matrix[row, col] == 'e')
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    Environment.Exit(0);

                }



                currentPosition[0] = row;
                currentPosition[1] = col;
            }
            Console.WriteLine($"{coalCount} coals left. ({currentPosition[0]}, {currentPosition[1]})");
        }
        static bool IsValidIndex(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);


        }
    }
}
