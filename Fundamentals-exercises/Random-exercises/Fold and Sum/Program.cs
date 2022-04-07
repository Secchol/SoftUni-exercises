using System;
using System.Linq;

namespace Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int[] middleNumbers = new int[array.Length / 2];
            int position = 0;
            for (int i = array.Length / 4; i < array.Length - array.Length / 4; i++, position++)
            {
                middleNumbers[position] = array[i];


            }
            int[] firstPart = new int[array.Length / 4];

            for (int i = 0; i < array.Length / 4; i++)
            {
                firstPart[i] = array[i];


            }
            int[] secondPart = new int[array.Length / 4];
            position = 0;
            for (int i = array.Length - array.Length / 4; i < array.Length; i++, position++)
            {
                secondPart[position] = array[i];
            }
            Array.Reverse(firstPart);
            Array.Reverse(secondPart);
            int[] mixedFirstAndSecondPart = new int[array.Length / 2];
            firstPart.CopyTo(mixedFirstAndSecondPart, 0);
            secondPart.CopyTo(mixedFirstAndSecondPart, firstPart.Length);
            int[] sum = new int[array.Length / 2];
            for (int i = 0; i < array.Length / 2; i++)
            {
                sum[i] = mixedFirstAndSecondPart[i] + middleNumbers[i];
            }
            Console.WriteLine(String.Join(" ", sum));
        }
    }
}
