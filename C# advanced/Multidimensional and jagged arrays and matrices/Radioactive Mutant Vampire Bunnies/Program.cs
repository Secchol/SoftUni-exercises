using System;
using System.Linq;
using System.Collections.Generic;

namespace Radioactive_Mutant_Vampire_Bunnies
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
            int[] playerPosition = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowElements = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;

                    }

                }
            }
            char[] commands = Console.ReadLine().ToCharArray();
            bool playerDied = false;
            bool playerWon = false;
            int[] playersLastIndex = new int[2];

            foreach (char command in commands)
            {


                int playerRow = playerPosition[0];
                int playerCol = playerPosition[1];
                matrix[playerRow, playerCol] = '.';
                if (command == 'U' && IsValidIndex(matrix, playerRow - 1, playerCol))
                {

                    playerRow -= 1;
                }
                else if (command == 'D' && IsValidIndex(matrix, playerRow + 1, playerCol))
                {

                    playerRow += 1;
                }
                else if (command == 'L' && IsValidIndex(matrix, playerRow, playerCol - 1))
                {

                    playerCol -= 1;
                }
                else if (command == 'R' && IsValidIndex(matrix, playerRow, playerCol + 1))
                {

                    playerCol += 1;
                }
                else
                {

                    playerWon = true;
                    playersLastIndex[0] = playerRow;
                    playersLastIndex[1] = playerCol;
                }
                
                if (!playerWon && matrix[playerRow, playerCol] == 'B')
                {

                    playerDied = true;
                    playersLastIndex[0] = playerRow;
                    playersLastIndex[1] = playerCol;

                }
                else
                {
                    if (!playerWon)
                    {
                        matrix[playerRow, playerCol] = 'P';

                    }


                }
                Dictionary<int, List<int>> bunnyIndices = new Dictionary<int, List<int>>();
                //USE SOME OTHER DATA STRUCTURE
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (!bunnyIndices.ContainsKey(row))
                                bunnyIndices.Add(row, new List<int>());
                            bunnyIndices[row].Add(col);

                        }
                    }
                }

                foreach (var (row, cols) in bunnyIndices)
                {
                    foreach (int col in cols)
                    {


                        if (IsValidIndex(matrix, row - 1, col))
                        {
                            if (playerRow == row - 1 && playerCol == col && !playerWon)
                            {
                                playerDied = true;
                                playersLastIndex[0] = playerRow;
                                playersLastIndex[1] = playerCol;

                            }
                            matrix[row - 1, col] = 'B';
                        }
                        if (IsValidIndex(matrix, row + 1, col))
                        {
                            if (playerRow == row + 1 && playerCol == col && !playerWon)
                            {
                                playerDied = true;
                                playersLastIndex[0] = playerRow;
                                playersLastIndex[1] = playerCol;
                            }
                            matrix[row + 1, col] = 'B';
                        }

                        if (IsValidIndex(matrix, row, col - 1))
                        {
                            if (playerRow == row && playerCol == col - 1 && !playerWon)
                            {
                                playerDied = true;
                                playersLastIndex[0] = playerRow;
                                playersLastIndex[1] = playerCol;
                            }

                            matrix[row, col - 1] = 'B';
                        }
                        if (IsValidIndex(matrix, row, col + 1))
                        {
                            if (playerRow == row && playerCol == col + 1 && !playerWon)
                            {
                                playerDied = true;
                                playersLastIndex[0] = playerRow;
                                playersLastIndex[1] = playerCol;
                            }
                            matrix[row, col + 1] = 'B';
                        }


                    }


                }
                if (playerDied || playerWon)
                {
                    break;


                }

                else
                {
                    playerPosition[0] = playerRow;
                    playerPosition[1] = playerCol;


                }


            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
            if (playerDied)
            {
                Console.WriteLine($"dead: {playersLastIndex[0]} {playersLastIndex[1]}");

            }
            else if (playerWon)
            {
                Console.WriteLine($"won: {playersLastIndex[0]} {playersLastIndex[1]}");


            }

        }
        static bool IsValidIndex(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);


        }
    }
}
