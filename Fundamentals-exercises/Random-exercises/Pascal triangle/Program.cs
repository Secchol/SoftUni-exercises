using System;

namespace Pascal_triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[] array = { 1 };

            for (int i = 1; i <= rows; i++)
            {
                Console.WriteLine(String.Join(" ", array));
                int[] arrayToModify = new int[i + 1];
                arrayToModify[0] = 1;
                arrayToModify[arrayToModify.Length - 1] = 1;
                int j = 0;
                int position = 1;
                while (j < array.Length - 1)
                {
                    arrayToModify[position] = array[j] + array[j + 1];
                    position++;
                    j++;

                }
                array = arrayToModify;
            }
        }
    }
}
