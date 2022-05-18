using System;
using System.Collections.Generic;

namespace Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightTime = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int totalCarsPassed = 0;
            Queue<Queue<char>> cars = new Queue<Queue<char>>();
            bool newCarPassing = true;
            string currentCar = string.Empty;
            string command = Console.ReadLine();
            //car passes in time and another car starts and gets through
            //car passes in time and another car starts and crashes
            //car is exactly on the green light seconds

            while (command != "END")
            {
                if (command == "green")
                {
                    if (cars.Count == 0)
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                        currentCar = string.Join("", cars.Peek());
                        for (int i = 1; i <= greenLightTime; i++)
                        {
                            if (cars.Peek().Count > 0)
                            {
                                if (i == greenLightTime && cars.Peek().Count == 1)
                                {
                                    newCarPassing = false;
                                    cars.Dequeue();
                                    totalCarsPassed++;
                                    break;


                                }
                                else
                                {
                                    cars.Peek().Dequeue();

                                }



                            }
                            else
                            {
                                cars.Dequeue();
                                totalCarsPassed++;
                                if (cars.Count > 0)
                                {
                                    newCarPassing = true;
                                    currentCar = string.Join("", cars.Peek());
                                    cars.Peek().Dequeue();


                                }
                                else
                                {
                                    newCarPassing = false;
                                    break;

                                }

                            }
                        }
                        if (newCarPassing)
                        {
                            for (int i = 0; i < freeWindow; i++)
                            {
                                if (cars.Peek().Count > 0)
                                {
                                    cars.Peek().Dequeue();


                                }
                            }
                            if (cars.Peek().Count > 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {cars.Peek().Dequeue()}.");
                                Environment.Exit(0);

                            }
                            else
                            {
                                cars.Dequeue();
                                totalCarsPassed++;
                                newCarPassing = false;

                            }


                        }


                    }
                    else
                    {
                        cars.Enqueue(new Queue<char>(command.ToCharArray()));


                    }


                    command = Console.ReadLine();
                }
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }
        }
    }
