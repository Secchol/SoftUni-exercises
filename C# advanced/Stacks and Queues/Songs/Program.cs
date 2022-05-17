using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
            while (queue.Count > 0)
            {
                string command = Console.ReadLine();
                if (command == "Play")
                {
                    queue.Dequeue();



                }
                else if (command.Substring(0, 3) == "Add")
                {
                    string song = command.Substring(3, command.Length - 3).Trim();
                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");


                    }
                    else
                    {
                        queue.Enqueue(song);


                    }


                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", queue));



                }



            }
            Console.WriteLine("No more songs!");
        }
    }
}
