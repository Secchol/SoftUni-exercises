using System;
using System.Linq;

namespace Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[matrixSize[0], matrixSize[1]];
            string snake = Console.ReadLine();
            char[] matrixFill = snake.ToCharArray();
            int arrayIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++, arrayIndex++)
                {
                    if (arrayIndex >= matrixFill.Length)
                    {
                        arrayIndex = 0;
                        matrixFill = snake.ToCharArray();


                    }
                    matrix[row, col] = matrixFill[arrayIndex];

                }
                if (row % 2 != 0)
                {
                    for (int i = 0; i < matrixSize[1] / 2; i++)
                    {
                        char temp = matrix[row, i];
                        matrix[row, i] = matrix[row, matrixSize[1] - 1 - i];
                        matrix[row, matrixSize[1] - 1 - i] = temp;

                    }


                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
