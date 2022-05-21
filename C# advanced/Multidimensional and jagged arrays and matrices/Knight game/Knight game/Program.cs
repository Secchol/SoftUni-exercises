using System;
using System.Linq;

namespace Knight_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
            int knightsRemoved = 0;

            while (true)
            {
                bool hasKnightsToRemove = false;

                int maxAttacks = 0;
                int maxAttacksRow = 0;
                int maxAttacksCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int currentAttacks = 0;
                            //TOPLEFT TOPRIGHT
                            if (IndexValidation(matrix, row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                                hasKnightsToRemove = true;

                            }
                            if (IndexValidation(matrix, row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                                hasKnightsToRemove = true;

                            }
                            //LEFTUP LEFTDOWN
                            if (IndexValidation(matrix, row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                                hasKnightsToRemove = true;

                            }
                            if (IndexValidation(matrix, row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                            {
                                currentAttacks++;
                                hasKnightsToRemove = true;

                            }


                            //DOWNLEFT DOWNRIGHT
                            if (IndexValidation(matrix, row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                            {
                                currentAttacks++;
                                hasKnightsToRemove = true;

                            }
                            if (IndexValidation(matrix, row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                            {
                                currentAttacks++;
                                hasKnightsToRemove = true;

                            }


                            //RIGHTUP RIGHTDOWN
                            if (IndexValidation(matrix, row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                                hasKnightsToRemove = true;

                            }
                            if (IndexValidation(matrix, row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                            {
                                currentAttacks++;
                                hasKnightsToRemove = true;

                            }
                            if (currentAttacks > maxAttacks)
                            {
                                maxAttacks = currentAttacks;
                                maxAttacksRow = row;
                                maxAttacksCol = col;

                            }

                        }
                    }
                }
                if (!hasKnightsToRemove)
                {
                    break;


                }

                matrix[maxAttacksRow, maxAttacksCol] = '0';

                knightsRemoved++;


            }
            Console.WriteLine(knightsRemoved);

        }
        static bool IndexValidation(char[,] matrix, int row, int col)
        {


            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
