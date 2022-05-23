using System;
using System.Linq;

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
            foreach (char command in commands)
            {
                if (playerDied)
                    continue;
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
                }
                // Continue for playersWon-what to do then?
                if (!playerWon && matrix[playerRow, playerCol] == 'B')
                {

                    playerDied = true;

                }
                else
                {
                    if (!playerWon)
                    {
                        matrix[playerRow, playerCol] = 'P';

                    }


                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (IsValidIndex(matrix, row - 1, col))
                            {
                                if (playerRow == row - 1 && playerCol == col && !playerWon)
                                {
                                    playerDied = true;

                                }
                                matrix[row - 1, col] = 'B';
                            }
                            if (IsValidIndex(matrix, row + 1, col))
                            {
                                if (playerRow == row + 1 && playerCol == col && !playerWon)
                                {
                                    playerDied = true;

                                }
                                matrix[row + 1, col] = 'B';
                            }

                            if (IsValidIndex(matrix, row, col - 1))
                            {
                                if (playerRow == row && playerCol == col - 1 && !playerWon)
                                {
                                    playerDied = true;

                                }

                                matrix[row, col - 1] = 'B';
                            }
                            if (IsValidIndex(matrix, row, col + 1))
                            {
                                if (playerRow == row && playerCol == col + 1 && !playerWon)
                                {
                                    playerDied = true;

                                }
                                matrix[row, col + 1] = 'B';
                            }


                        }
                    }
                }
                if (playerDied)
                {
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    Environment.Exit(0);
                    break;

                }
                else if (playerWon)
                {
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    Environment.Exit(0);
                    break;

                }
                else
                {
                    playerPosition[0] = playerRow;
                    playerPosition[1] = playerCol;


                }

            }
        }
        static bool IsValidIndex(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);


        }
    }
}
