using System;
using System.Collections.Generic;
using System.Linq;

namespace Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsToPassCount = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string command = Console.ReadLine();
            int carsPassed = 0;
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < carsToPassCount; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            carsPassed++;

                        }
                        else
                        {
                            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
                            return;

                        }
                    }
                    
                }
                else
                {
                    cars.Enqueue(command);

                }
                command = Console.ReadLine();

            }
            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
