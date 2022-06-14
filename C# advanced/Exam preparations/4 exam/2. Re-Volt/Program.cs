using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int commandCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int[] playerPosition = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowItems = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowItems[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;

                    }

                }
            }
            bool playerWon = false;
            for (int i = 0; i < commandCount; i++)
            {
                string command = Console.ReadLine();
                int row = playerPosition[0];
                int col = playerPosition[1];
                matrix[row, col] = '-';
                if (command == "up")
                {
                    if (IsValidIndex(matrix, row - 1, col))
                        row--;
                    else
                        row = matrix.GetLength(0) - 1;
                    if (matrix[row, col] == 'B')
                    {
                        if (IsValidIndex(matrix, row - 1, col))
                            row--;
                        else
                            row = matrix.GetLength(0) - 1;

                    }
                    else if (matrix[row, col] == 'T')
                    {
                        if (IsValidIndex(matrix, row + 1, col))
                            row++;
                        else
                            row = 0;


                    }



                }
                else if (command == "down")
                {
                    if (IsValidIndex(matrix, row + 1, col))
                        row++;
                    else
                        row = 0;
                    if (matrix[row, col] == 'B')
                    {
                        if (IsValidIndex(matrix, row + 1, col))
                            row++;
                        else
                            row = 0;

                    }
                    else if (matrix[row, col] == 'T')
                    {
                        if (IsValidIndex(matrix, row - 1, col))
                            row--;
                        else
                            row = matrix.GetLength(0) - 1;


                    }

                }
                else if (command == "left")
                {
                    if (IsValidIndex(matrix, row, col - 1))
                        col--;
                    else
                        col = matrix.GetLength(1) - 1;
                    if (matrix[row, col] == 'B')
                    {
                        if (IsValidIndex(matrix, row, col - 1))
                            col--;
                        else
                            col = matrix.GetLength(0) - 1;

                    }
                    else if (matrix[row, col] == 'T')
                    {
                        if (IsValidIndex(matrix, row, col + 1))
                            col++;
                        else
                            col = 0;


                    }

                }
                else if (command == "right")
                {
                    if (IsValidIndex(matrix, row, col + 1))
                        col++;
                    else
                        col = 0;
                    if (matrix[row, col] == 'B')
                    {
                        if (IsValidIndex(matrix, row, col + 1))
                            col++;
                        else
                            col = 0;

                    }
                    else if (matrix[row, col] == 'T')
                    {
                        if (IsValidIndex(matrix, row, col - 1))
                            col--;
                        else
                            col = matrix.GetLength(1) - 1;


                    }


                }
                if (matrix[row, col] == 'F')
                {

                    playerWon = true;
                    matrix[row, col] = 'f';
                    break;
                }
                matrix[row, col] = 'f';
                playerPosition[0] = row;
                playerPosition[1] = col;
            }
            if (playerWon)
                Console.WriteLine("Player won!");
            else
                Console.WriteLine("Player lost!");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
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

