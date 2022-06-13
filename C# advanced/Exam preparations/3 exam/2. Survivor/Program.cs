using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] jaggedArray = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                char[] rowElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
                jaggedArray[i] = rowElements;


            }
            int myTokens = 0;
            int opponentTokens = 0;
            string command = Console.ReadLine();
            while (command != "Gong")
            {
                string[] commandsArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandsArray[0];
                int row = int.Parse(commandsArray[1]);
                int col = int.Parse(commandsArray[2]);
                if (action == "Find")
                {
                    if (IsIndexValid(jaggedArray, row, col))
                    {
                        if (jaggedArray[row][col] == 'T')
                        {
                            myTokens++;
                            jaggedArray[row][col] = '-';


                        }


                    }


                }
                else if (action == "Opponent")
                {
                    string direction = commandsArray[3];
                    if (IsIndexValid(jaggedArray, row, col))
                    {
                        if (jaggedArray[row][col] == 'T')
                        {
                            opponentTokens++;
                            jaggedArray[row][col] = '-';


                        }
                        for (int i = 0; i < 3; i++)
                        {
                            if (direction == "up")
                            {
                                if (IsIndexValid(jaggedArray, row - 1, col))
                                    row--;


                            }
                            else if (direction == "down")
                            {
                                if (IsIndexValid(jaggedArray, row + 1, col))
                                    row++;


                            }
                            else if (direction == "left")
                            {
                                if (IsIndexValid(jaggedArray, row, col - 1))
                                    col--;


                            }
                            else if (direction == "right")
                            {

                                if (IsIndexValid(jaggedArray, row, col + 1))
                                    col++;

                            }
                            if (jaggedArray[row][col] == 'T')
                            {
                                opponentTokens++;
                                jaggedArray[row][col] = '-';


                            }



                        }


                    }


                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[i]));
            }
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
        public static bool IsIndexValid(char[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;



        }
    }
}
