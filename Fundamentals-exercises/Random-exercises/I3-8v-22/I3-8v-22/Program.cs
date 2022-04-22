using System;

namespace I3_8v_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задача И3-34. /КУБОВЕ НА ЦИФРИТЕ/ Да се състави програма за намиране на всички естествени числа, равни на сумата от кубовете на цифрите си.
            // Изготвил Сечкин Чолак от 8в клас
            Console.WriteLine("This program finds all the natural numbers that are equal to the sum of all its cubed digits.");
            

            for (int i = 1; i <= 407; i++)
            {
                int number = i;
                int sum = 0;
                while (number != 0)
                {
                    int digit = number % 10;
                    sum += digit * digit * digit;
                    number /= 10;

                }
                if (sum == i)
                {
                    Console.WriteLine(i);


                }

            }
            Console.WriteLine("An Armstrong number of three digits is an integer such that the sum of the cubes of its digits is equal to the");
            Console.WriteLine("number itself. There are just five numbers which are the sums of the cubes of their digits.");



        }
    }
}
