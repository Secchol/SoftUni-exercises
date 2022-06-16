using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            List<string> flowerIndices = new List<string>();
            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                int[] coordinates = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (!IsValidIndex(matrix, coordinates[0], coordinates[1]))
                {
                    Console.WriteLine("Invalid coordinates.");
                    command = Console.ReadLine();
                    continue;

                }
                flowerIndices.Add(command);
                command = Console.ReadLine();
            }
            foreach (string index in flowerIndices)
            {
                int[] flowerIndex = index.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = flowerIndex[0];
                int col = flowerIndex[1];
                matrix[row, col]++;
                while (IsValidIndex(matrix, row + 1, col))
                {
                    row++;
                    matrix[row, col]++;
                }
                row = flowerIndex[0];
                col = flowerIndex[1];
                while (IsValidIndex(matrix, row - 1, col))
                {
                    row--;
                    matrix[row, col]++;
                }
                row = flowerIndex[0];
                col = flowerIndex[1];
                while (IsValidIndex(matrix, row, col + 1))
                {
                    col++;
                    matrix[row, col]++;
                }
                row = flowerIndex[0];
                col = flowerIndex[1];
                while (IsValidIndex(matrix, row, col - 1))
                {
                    col--;
                    matrix[row, col]++;
                }
                row = flowerIndex[0];
                col = flowerIndex[1];

            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        public static bool IsValidIndex(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);


        }
    }
}
