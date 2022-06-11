using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Beaver_at_work
{
    public class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            string[,] matrix = new string[matrixSize, matrixSize];
            int[] beaverPosition = new int[2];
            int woodBranchCount = 0;
            int woodBranchesCollected = 0;
            List<string> woodBranchesList = new List<string>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] rowArray = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowArray[j];
                    if (matrix[i, j] == "B")
                    {
                        beaverPosition[0] = i;
                        beaverPosition[1] = j;


                    }
                    else if (Char.IsLower(char.Parse(matrix[i, j])))
                    {
                        woodBranchCount++;


                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                int row = beaverPosition[0];
                int col = beaverPosition[1];
                if (command == "down" && IsValidIndex(matrix, row + 1, col))
                {
                    row++;
                    if (matrix[row, col] == "F")
                    {
                        matrix[row, col] = "-";
                        if (row < matrix.GetLength(0) - 1)
                            row = matrix.GetLength(0) - 1;
                        else
                            row = 0;

                    }


                }
                else if (command == "up" && IsValidIndex(matrix, row - 1, col))
                {
                    row--;
                    if (matrix[row, col] == "F")
                    {
                        matrix[row, col] = "-";
                        if (row > 0)
                            row = 0;
                        else
                            row = matrix.GetLength(0) - 1;

                    }


                }
                else if (command == "right" && IsValidIndex(matrix, row, col + 1))
                {
                    col++;
                    if (matrix[row, col] == "F")
                    {
                        matrix[row, col] = "-";
                        if (col < matrix.GetLength(1) - 1)
                            col = matrix.GetLength(1) - 1;
                        else
                            col = 0;

                    }


                }
                else if (command == "left" && IsValidIndex(matrix, row, col - 1))
                {
                    col--;

                    if (matrix[row, col] == "F")
                    {
                        matrix[row, col] = "-";
                        if (col > 0)
                            col = 0;
                        else
                            col = matrix.GetLength(1) - 1;

                    }


                }
                else
                {
                    if (woodBranchesCollected != 0)
                    {

                        woodBranchesList.RemoveAt(woodBranchesList.Count - 1);
                    }
                    command = Console.ReadLine();
                    continue;

                }
                if (Char.IsLower(char.Parse(matrix[row, col])))
                {
                    woodBranchesCollected++;
                    woodBranchesList.Add(matrix[row, col]);
                    woodBranchCount--;
                }

                matrix[beaverPosition[0], beaverPosition[1]] = "-";
                matrix[row, col] = "B";
                beaverPosition[0] = row;
                beaverPosition[1] = col;
                if (woodBranchCount == 0)
                    break;
                command = Console.ReadLine();
            }
            if (woodBranchCount == 0)
                Console.WriteLine($"The Beaver successfully collect {woodBranchesList.Count} wood branches: {string.Join(", ", woodBranchesList)}.");
            else
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {woodBranchCount} branches left.");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
        public static bool IsValidIndex(string[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);


        }
    }
}
