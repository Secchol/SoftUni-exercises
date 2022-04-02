using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Exercise_one
{

    class Program
    {


        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Travel")
            {
                string[] commandsArray = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string action = commandsArray[0];
                if (action == "Add Stop")
                {
                    int index = int.Parse(commandsArray[1]);
                    string @string = commandsArray[2];
                    if (index >= 0 && index < text.Length)
                    {
                        text = text.Insert(index, @string);


                    }
                }
                else if (action == "Remove Stop")
                {
                    int startIndex = int.Parse(commandsArray[1]);
                    int endIndex = int.Parse(commandsArray[2]);
                    if (startIndex >= 0 && endIndex >= 0 && startIndex < text.Length && endIndex < text.Length)
                    {
                        text = text.Remove(startIndex, endIndex + 1 - startIndex);


                    }


                }
                else if (action == "Switch")
                {
                    string oldString = commandsArray[1];
                    string newString = commandsArray[2];
                    if (text.Contains(oldString))
                    {
                        text = text.Replace(oldString, newString);


                    }


                }
                Console.WriteLine(text);


                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {text}");




        }
    }
}
