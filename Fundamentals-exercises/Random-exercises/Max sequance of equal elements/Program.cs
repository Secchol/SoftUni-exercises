using System;
using System.Linq;

namespace Max_sequance_of_equal_elements
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int maxLength = int.MinValue;
            int maxNum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int length = 0;
                int currNum = 0;
                for (int j = i; j < array.Length - 1; j++)
                {
                    if (array[j] == array[j + 1])
                    {
                        length++;
                        currNum = array[j];
                    }
                    else
                    {
                        break;

                    }
                }
                if (length > maxLength)
                {
                    maxLength = length;
                    maxNum = currNum;
                }
            }
            for (int i = 0; i <= maxLength; i++)
            {
                Console.Write($"{maxNum} ");
            }





        }
    }
}


