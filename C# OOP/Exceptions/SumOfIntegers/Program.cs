﻿using System;

namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int sum = 0;
            foreach (string item in input)
            {
                try
                {
                    int currentElement = int.Parse(item);
                    sum += currentElement;
                }
                catch (FormatException)
                {

                    Console.WriteLine($"The element '{item}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{item}' is out of range!");


                }
                finally
                {
                    Console.WriteLine($"Element '{item}' processed - current sum: {sum}");


                }


            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
