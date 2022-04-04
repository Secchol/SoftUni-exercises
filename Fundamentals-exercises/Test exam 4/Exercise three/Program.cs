using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Exercise_three
{
    class Program
    {

        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Finish")
            {
                string[] commandsArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandsArray[0];

                if (action == "Replace")
                {
                    string currentChar = commandsArray[1];
                    string newChar = commandsArray[2];
                    text = text.Replace(currentChar, newChar);
                    Console.WriteLine(text);



                }
                else if (action == "Cut")
                {
                    int startIndex = int.Parse(commandsArray[1]);
                    int endIndex = int.Parse(commandsArray[2]);
                    if (startIndex >= 0 && endIndex < text.Length && startIndex <= endIndex)
                    {
                        text = text.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(text);


                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");



                    }



                }
                else if (action == "Make")
                {
                    string change = commandsArray[1];
                    if (change == "Upper")
                    {
                        text = text.ToUpper();



                    }
                    else if (change == "Lower")
                    {
                        text = text.ToLower();



                    }

                    Console.WriteLine(text);

                }
                else if (action == "Check")
                {
                    string check = commandsArray[1];
                    if (text.Contains(check))
                    {
                        Console.WriteLine($"Message contains {check}");



                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {check}");



                    }



                }
                else if (action == "Sum")
                {
                    int startIndex = int.Parse(commandsArray[1]);
                    int endIndex = int.Parse(commandsArray[2]);
                    if (startIndex >= 0 && startIndex < text.Length && endIndex >= 0 && endIndex < text.Length)
                    {
                        int sum = 0;
                        string substring = text.Substring(startIndex, endIndex - startIndex + 1);
                        foreach (char character in substring)
                        {
                            sum += character;


                        }
                        Console.WriteLine(sum);


                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");



                    }



                }


                command = Console.ReadLine();
            }



        }
    }
}

