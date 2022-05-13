using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numbersText = Console.ReadLine().Trim();
            string[] numbers = numbersText.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            Stack<string> stack = new Stack<string>(numbers);
            int sum = 0;

            while (stack.Count > 1)
            {

                int number = int.Parse(stack.Pop());
                string sign = stack.Pop();
                if (sign == "+")
                {
                    number = Math.Abs(number);


                }
                else if (sign == "-")
                {
                    number = -number;


                }
                sum += number;



            }
            int firstNum = int.Parse(stack.Pop());
            Console.WriteLine(sum+firstNum);
        }

    }
}
