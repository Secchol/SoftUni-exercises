using System;

namespace Fibonacii
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int[] fibonacii = new int[numbersCount];
            fibonacii[0] = 0;
            fibonacii[1] = 1;
            int firstNumberIndex = 0;
            int secondNumberIndex = 1;  
            for (int i = 2; i < numbersCount; i++)
            {
                fibonacii[i] = fibonacii[firstNumberIndex]+fibonacii[secondNumberIndex];
                firstNumberIndex++;
                secondNumberIndex++;
            }
            Console.WriteLine(String.Join(" ",fibonacii));

        }
    }
}
