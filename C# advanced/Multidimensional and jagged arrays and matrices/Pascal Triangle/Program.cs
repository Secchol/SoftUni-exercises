using System;
using System.Linq;

namespace Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[count][];
            jaggedArray[0] = new long[] { 1 };

            for (int row = 1; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new long[row + 1];
                jaggedArray[row][0] = 1;
                jaggedArray[row][jaggedArray[row].Length - 1] = 1;
                for (int element = 1; element < jaggedArray[row].Length - 1; element++)
                {
                    jaggedArray[row][element] = jaggedArray[row - 1][element - 1] + jaggedArray[row - 1][element];
                }
            }


            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[row]));
            }
        }
    }
}
