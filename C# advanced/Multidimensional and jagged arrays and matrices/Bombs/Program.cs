using System;
using System.Linq;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
            string[] indices = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in indices)
            {
                char[] index = element.Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => char.Parse(x))
                    .ToArray();
                int bombRow = int.Parse(index[0].ToString());
                int bombCol = int.Parse(index[1].ToString());
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {

                        if (row == bombRow && col == bombCol)
                        {
                            if (matrix[row, col] <= 0)
                            {
                                continue;


                            }
                            int currentValue = matrix[row, col];
                            //top
                            if (IndexValidation(matrix, row - 1, col) && matrix[row - 1, col] > 0)
                            {
                                matrix[row - 1, col] -= currentValue;


                            }
                            //topRight
                            if (IndexValidation(matrix, row - 1, col + 1) && matrix[row - 1, col + 1] > 0)
                            {
                                matrix[row - 1, col + 1] -= currentValue;


                            }
                            //Right
                            if (IndexValidation(matrix, row, col + 1) && matrix[row, col + 1] > 0)
                            {
                                matrix[row, col + 1] -= currentValue;


                            }
                            //bottomRight
                            if (IndexValidation(matrix, row + 1, col + 1) && matrix[row + 1, col + 1] > 0)
                            {
                                matrix[row + 1, col + 1] -= currentValue;


                            }
                            //bottom
                            if (IndexValidation(matrix, row + 1, col) && matrix[row + 1, col] > 0)
                            {
                                matrix[row + 1, col] -= currentValue;


                            }
                            //bottomLeft
                            if (IndexValidation(matrix, row + 1, col - 1) && matrix[row + 1, col - 1] > 0)
                            {
                                matrix[row + 1, col - 1] -= currentValue;


                            }
                            //left
                            if (IndexValidation(matrix, row, col - 1) && matrix[row, col - 1] > 0)
                            {
                                matrix[row, col - 1] -= currentValue;


                            }
                            //topLeft
                            if (IndexValidation(matrix, row - 1, col - 1) && matrix[row - 1, col - 1] > 0)
                            {
                                matrix[row - 1, col - 1] -= currentValue;


                            }
                            matrix[row, col] = 0;


                        }
                    }
                }


            }
            int aliveCellsCount = 0;
            int aliveCellsSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsCount++;
                        aliveCellsSum += matrix[row, col];

                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsSum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        static bool IndexValidation(int[,] matrix, int row, int col)
        {

            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        }
    }
}
