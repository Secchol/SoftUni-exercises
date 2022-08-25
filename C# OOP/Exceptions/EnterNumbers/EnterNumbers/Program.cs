using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> validNumbers = new List<int>();
            int start = 1;
            int end = 100;
            while (validNumbers.Count < 10)
            {
                try
                {
                    int currentNum = ReadNumber(start, end);
                    validNumbers.Add(currentNum);
                    start = validNumbers[validNumbers.Count - 1];
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                }




            }
            Console.WriteLine(String.Join(", ", validNumbers));
        }

        public static int ReadNumber(int start, int end)
        {

            int number = int.Parse(Console.ReadLine());
            if (number <= start || number >= end)
                throw new ArgumentException($"Your number is not in range {start} - {end}!");
            return number;





        }
    }
}
