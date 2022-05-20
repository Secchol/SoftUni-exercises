using System;
using System.Linq;

namespace Diagonal_difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = rowElements[col];
                }


            }
            int firstDiagonalSum = 0;
            int currentCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++, currentCol++)                    firstDiagonalSum += matrix[row, currentCol];
            
            currentCol = matrix.GetLength(0) - 1;
            int secondDiagonalSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++, currentCol--)
                            secondDiagonalSum += matrix[row, currentCol];
            
            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}
