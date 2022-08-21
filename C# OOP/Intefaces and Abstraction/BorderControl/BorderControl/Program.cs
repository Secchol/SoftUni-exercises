using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            HashSet<string> citizens = new HashSet<string>();
            HashSet<string> rebels = new HashSet<string>();
            for (int i = 0; i < peopleCount; i++)
            {
                string[] infoArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (infoArray.Length == 4)
                {
                    citizens.Add(infoArray[0]);

                }
                else if (infoArray.Length == 3)
                {
                    rebels.Add(infoArray[0]);

                }
            }
            string command = Console.ReadLine();
            int totalFood = 0;
            while (command != "End")
            {
                if (citizens.Contains(command))
                {
                    totalFood += 10;

                }
                else if (rebels.Contains(command))
                {
                    totalFood += 5;

                }


                command = Console.ReadLine();
            }
            Console.WriteLine(totalFood);
        }
    }
}
