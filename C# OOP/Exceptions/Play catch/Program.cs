using System;
using System.Collections.Generic;
using System.Linq;

namespace Play_catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int exceptionsCount = 0;
            while (exceptionsCount != 3)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    string action = command[0];
                    int firstIndex = int.Parse(command[1]);
                    if (firstIndex < 0 || firstIndex >= numbers.Count)
                    {
                        throw new ArgumentException("The index does not exist!");


                    }
                    if (action == "Replace")
                    {
                        int element = int.Parse(command[2]);
                        numbers.RemoveAt(firstIndex);
                        numbers.Insert(firstIndex, element);


                    }
                    else if (action == "Print")
                    {
                        int endIndex = int.Parse(command[2]);
                        if (endIndex < 0 || endIndex >= numbers.Count)
                        {
                            throw new ArgumentException("The index does not exist!");


                        }
                        List<int> numbersToPrint = new List<int>();
                        for (int i = firstIndex; i <= endIndex; i++)
                        {
                            numbersToPrint.Add(numbers[i]);
                        }
                        Console.WriteLine(String.Join(", ", numbersToPrint));


                    }
                    else if (action == "Show")
                    {
                        Console.WriteLine(numbers[firstIndex]);


                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount++;


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    exceptionsCount++;
                }
                

            }
            Console.WriteLine(String.Join(", ",numbers));
        }
    }
}
