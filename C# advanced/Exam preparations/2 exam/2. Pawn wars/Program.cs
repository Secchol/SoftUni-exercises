using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Pawn_wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = new string[8, 8];
            int[] whitePosition = new int[2];
            int[] blackPosition = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col].ToString();
                    if (matrix[row, col] == "b")
                    {
                        blackPosition[0] = row;
                        blackPosition[1] = col;
                    }
                    else if (matrix[row, col] == "w")
                    {
                        whitePosition[0] = row;
                        whitePosition[1] = col;
                    }

                }
            }
            while (true)
            {
                int whiteRow = whitePosition[0];
                int whiteCol = whitePosition[1];
                int blackRow = blackPosition[0];
                int blackCol = blackPosition[1];
                bool whiteWon = false;
                bool blackWon = false;
                bool whitePromoted = false;
                bool blackPromoted = false;
                int[] winnerCoordinates = new int[2];
                string winner = string.Empty;
                matrix[whiteRow, whiteCol] = "-";
                if ((ColIndexValidation(matrix, whiteCol - 1) && matrix[whiteRow - 1, whiteCol - 1] == "b") || (ColIndexValidation(matrix, whiteCol + 1) && matrix[whiteRow - 1, whiteCol + 1] == "b"))
                {
                    whiteWon = true;
                    whiteRow = blackRow;
                    whiteCol = blackCol;
                    winner = "White";
                    winnerCoordinates[0] = whiteRow;
                    winnerCoordinates[1] = whiteCol;

                }
                else if (whiteRow - 1 == 0)
                {
                    whitePromoted = true;
                    winnerCoordinates[0] = whiteRow - 1;
                    winnerCoordinates[1] = whiteCol;
                    winner = "White";

                }
                if (!whiteWon)
                {
                    whiteRow--;
                    whitePosition[0] = whiteRow;
                    matrix[whitePosition[0], whitePosition[1]] = "w";

                }
                if (!whiteWon && !whitePromoted)
                {
                    matrix[blackRow, blackCol] = "-";
                    if ((ColIndexValidation(matrix, blackCol - 1) && matrix[blackRow + 1, blackCol - 1] == "w") || (ColIndexValidation(matrix, blackCol + 1) && matrix[blackRow + 1, blackCol + 1] == "w"))
                    {
                        blackWon = true;
                        blackRow = whiteRow;
                        blackCol = whiteCol;
                        winnerCoordinates[0] = blackRow;
                        winnerCoordinates[1] = blackCol;
                        winner = "Black";

                    }
                    else if (blackRow + 1 == matrix.GetLength(0) - 1)
                    {
                        blackPromoted = true;
                        winnerCoordinates[0] = blackRow + 1;
                        winnerCoordinates[1] = blackCol;
                        winner = "Black";

                    }
                    if (!blackWon)
                    {
                        blackRow++;
                        blackPosition[0] = blackRow;
                        matrix[blackPosition[0], blackPosition[1]] = "b";
                    }


                }
                if (whiteWon || blackWon)
                {
                    Console.WriteLine($"Game over! {winner} capture on {CoordinatesFinder(winnerCoordinates[0], winnerCoordinates[1])}.");
                    break;

                }
                else if (whitePromoted || blackPromoted)
                {
                    Console.WriteLine($"Game over! {winner} pawn is promoted to a queen at {CoordinatesFinder(winnerCoordinates[0], winnerCoordinates[1])}.");
                    break;


                }

            }

        }

        public static string CoordinatesFinder(int row, int col)
        {
            int realRow = 8 - row;
            string colLetter = string.Empty;
            switch (col)
            {
                case 0:
                    colLetter = "a";
                    break;
                case 1:
                    colLetter = "b";
                    break;

                case 2:
                    colLetter = "c";
                    break;

                case 3:
                    colLetter = "d";
                    break;

                case 4:
                    colLetter = "e";
                    break;

                case 5:
                    colLetter = "f";
                    break;

                case 6:
                    colLetter = "g";
                    break;

                case 7:
                    colLetter = "h";
                    break;
                default:
                    break;
            }
            return $"{colLetter}{realRow}";


        }
        public static bool ColIndexValidation(string[,] matrix, int col)
        {
            return col >= 0 && col < matrix.GetLength(1);



        }
    }
}
