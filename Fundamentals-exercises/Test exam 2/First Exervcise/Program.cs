using System;

namespace First_Exervcise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Generate")
            {
                string[] commandsArray = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string action = commandsArray[0];
                if (action == "Contains")
                {
                    string substring = commandsArray[1];
                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"{text} contains {substring}");


                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");


                    }




                }
                else if (action == "Flip")
                {
                    string upperOrLower = commandsArray[1];
                    int startIndex = int.Parse(commandsArray[2]);
                    int endIndex = int.Parse(commandsArray[3]);
                    string substring = text.Substring(startIndex, endIndex - startIndex);
                    if (upperOrLower == "Upper")
                    {
                        substring = substring.ToUpper();


                    }
                    else if (upperOrLower == "Lower")
                    {
                        substring = substring.ToLower();


                    }
                    text = text.Remove(startIndex, endIndex - startIndex);
                    text = text.Insert(startIndex, substring);
                    Console.WriteLine(text);


                }
                else if (action == "Slice")
                {
                    int startIndex = int.Parse(commandsArray[1]);
                    int endIndex = int.Parse(commandsArray[2]);
                    text = text.Remove(startIndex,endIndex-startIndex);

                    Console.WriteLine(text);


                }
                command = Console.ReadLine();



            }
            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}
