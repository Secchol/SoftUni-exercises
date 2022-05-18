using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_text_editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<char> manipulatedString = new Stack<char>();
            Stack<string[]> cache = new Stack<string[]>();
            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] commandsArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandsArray[0] == "1")
                {
                    foreach (char character in commandsArray[1])
                    {
                        manipulatedString.Push(character);

                    }
                    cache.Push(commandsArray);


                }
                else if (commandsArray[0] == "2")
                {


                    int eraseCount = int.Parse(commandsArray[1]);
                    string[] deletedElements = new string[eraseCount];
                    for (int j = 0; j < eraseCount; j++)
                    {
                        deletedElements[j] = manipulatedString.Pop().ToString();
                    }
                    cache.Push(deletedElements.Reverse().ToArray());



                }
                else if (commandsArray[0] == "3")
                {
                    char[] charactersArr = manipulatedString.Reverse().ToArray();
                    int returnIndex = int.Parse(commandsArray[1]);
                    Console.WriteLine(charactersArr[returnIndex - 1]);



                }
                else if (commandsArray[0] == "4")
                {
                    string[] lastCommand = cache.Pop();
                    if (lastCommand[0] == "1")
                    {
                        for (int j = 0; j < lastCommand[1].Length; j++)
                        {
                            manipulatedString.Pop();
                        }


                    }
                    else
                    {

                        foreach (string character in lastCommand)
                        {

                            manipulatedString.Push(char.Parse(character));




                        }



                    }

                }
            }
        }
    }
}
