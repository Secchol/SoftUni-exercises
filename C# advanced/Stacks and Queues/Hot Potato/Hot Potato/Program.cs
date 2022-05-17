using System;
using System.Collections.Generic;
using System.Linq;

namespace Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> circle = new Queue<string>(Console.ReadLine().Split(" "));
            int throwsToGetOut = int.Parse(Console.ReadLine());
            int numberOfThrows = 0;
            while (circle.Count > 1)
            {
                numberOfThrows++;
                if (numberOfThrows == throwsToGetOut)
                {
                    Console.WriteLine($"Removed {circle.Dequeue()}");
                    numberOfThrows = 0;


                }
                else
                {
                    string person = circle.Dequeue();
                    circle.Enqueue(person);

                }


            }
            Console.WriteLine($"Last is {circle.Dequeue()}");
        }
    }
}
