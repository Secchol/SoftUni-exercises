using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int[] snakePosition = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] matrixRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixRow[col];
                    if (matrix[row, col] == 'S')
                    {
                        snakePosition[0] = row;
                        snakePosition[1] = col;


                    }
                }
            }
            int foodCount = 0;
            bool gameOver = false;
            bool foodEaten = false;
            while (!gameOver && !foodEaten)
            {
                string command = Console.ReadLine();
                int row = snakePosition[0];
                int col = snakePosition[1];
                matrix[row, col] = '.';
                if (command == "up" && IsValidIndex(matrix, row - 1, col))
                {
                    row--;

                }
                else if (command == "down" && IsValidIndex(matrix, row + 1, col))
                {
                    row++;

                }
                else if (command == "left" && IsValidIndex(matrix, row, col - 1))
                {
                    col--;

                }
                else if (command == "right" && IsValidIndex(matrix, row, col + 1))
                {
                    col++;

                }
                else
                {
                    gameOver = true;
                }
                if (!gameOver)
                {
                    if (matrix[row, col] == '*')
                    {
                        foodCount++;
                        matrix[row, col] = 'S';
                    }
                    else if (matrix[row, col] == 'B')
                    {
                        matrix[row, col] = '.';
                        int nextRow = 0;
                        int nextCol = 0;
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (matrix[i, j] == 'B')
                                {
                                    nextRow = i;
                                    nextCol = j;

                                }
                            }
                        }
                        matrix[nextRow, nextCol] = 'S';
                        row = nextRow;
                        col = nextCol;

                    }
                    snakePosition[0] = row;
                    snakePosition[1] = col;
                    if (foodCount == 10)
                        foodEaten = true;

                }
            }
            if (gameOver)
                Console.WriteLine("Game over!");
            else
                Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {foodCount}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
        public static bool IsValidIndex(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);

        }
    }
}
