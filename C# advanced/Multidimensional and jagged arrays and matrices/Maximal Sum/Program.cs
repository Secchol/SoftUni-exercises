using System;
using System.Linq;

namespace Maximal_Sum
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
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }
            int maxSum = int.MinValue;
            int[] bestMatrixCoordinates = new int[2];
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        bestMatrixCoordinates[0] = row;
                        bestMatrixCoordinates[1] = col;


                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = bestMatrixCoordinates[0]; row < bestMatrixCoordinates[0] + 3; row++)
            {
                for (int col = bestMatrixCoordinates[1]; col < bestMatrixCoordinates[1] + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
