using System;
using System.Linq;

namespace Square_with_max_sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[matrixSize[0], matrixSize[1]];
            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            {
                int[] currentRow = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = currentRow[cols];
                }
            }
            int bestMatrixSize = int.MinValue;
            int[] bestMatrixRowsAndCols = new int[2];
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                int currentMatrixSize = 0;
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    currentMatrixSize = matrix[rows, cols] +
                        matrix[rows, cols + 1]
                        + matrix[rows + 1, cols] +
                        matrix[rows + 1, cols + 1];
                    if (currentMatrixSize > bestMatrixSize)
                    {
                        bestMatrixSize = currentMatrixSize;
                        bestMatrixRowsAndCols[0] = rows;
                        bestMatrixRowsAndCols[1] = cols;



                    }
                }
            }
            Console.WriteLine($"{matrix[bestMatrixRowsAndCols[0], bestMatrixRowsAndCols[1]]} {matrix[bestMatrixRowsAndCols[0], bestMatrixRowsAndCols[1] + 1]}");
            Console.WriteLine($"{matrix[bestMatrixRowsAndCols[0] + 1, bestMatrixRowsAndCols[1]]} {matrix[bestMatrixRowsAndCols[0] + 1, bestMatrixRowsAndCols[1] + 1]}");
            Console.WriteLine(bestMatrixSize);

        }
    }
}
