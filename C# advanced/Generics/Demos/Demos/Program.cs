using System;
using System.Collections.Generic;
using System.Linq;

namespace Demos
{
    public class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = int.Parse(Console.ReadLine());
            List<double> elements = new List<double>();
            for (int i = 0; i < elementsCount; i++)
            {
                double element = double.Parse(Console.ReadLine());
                elements.Add(element);
            }
            double itemToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(CompareElements(elements, itemToCompare));

        }
        static void SwapElements<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;



        }
        static int CompareElements<T>(List<T> elements, double itemToCompare)
        {
            int largerElements = 0;
            foreach (T element in elements)
            {
                double number = double.Parse(element.ToString());
                if (number > itemToCompare)
                {
                    largerElements++;

                }


            }
            return largerElements;


        }

    }
}
