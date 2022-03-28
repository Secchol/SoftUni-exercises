using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace First_exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] commandsArray = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandsArray[0];
                if (action == "TakeOdd")
                {
                    text = string.Join("", text.Where((x, index) => index % 2 != 0));



                }
                else if (action == "Cut")
                {
                    int index = int.Parse(commandsArray[1]);
                    int length = int.Parse(commandsArray[2]);
                    text = text.Remove(index, length);


                }
                else if (action == "Substitute")
                {
                    string substring = commandsArray[1];
                    string substitute = commandsArray[2];
                    if (text.Contains(substring))
                    {
                        text = text.Replace(substring, substitute);



                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                        command = Console.ReadLine();
                        continue;


                    }



                }

                Console.WriteLine(text);
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {text}");
        }
    }
}
