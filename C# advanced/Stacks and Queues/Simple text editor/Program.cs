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
            string characters = string.Empty;
            Queue<char> deletedElements = new Queue<char>();
            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] commandArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandArray[0] == "1")
                {
                    foreach (char character in commandArray[1])
                    {
                        manipulatedString.Push(character);

                    }
                    characters = commandArray[1];
                    deletedElements.Clear();

                }
                else if (commandArray[0] == "2")
                {


                    int eraseCount = int.Parse(commandArray[1]);
                    for (int j = 0; j < eraseCount; j++)
                    {
                        deletedElements.Enqueue(manipulatedString.Pop());
                    }
                    characters = string.Empty;



                }
                else if (commandArray[0] == "3")
                {




                }
                else if (commandArray[0] == "4")
                {
                    if (deletedElements.Count > 0)
                    {
                        while (deletedElements.Count > 0)
                        {
                            manipulatedString.Push(deletedElements.Dequeue());


                        }


                    }
                    else if (characters != String.Empty)
                    {
                        foreach (char character in characters)
                        {
                            manipulatedString.Push(character);


                        }

                    }



                }

            }
        }
    }
}
