using System;
using System.Collections.Generic;
using System.Linq;
namespace Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandsArray = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandsArray[0];
                string carNumber = commandsArray[1];
                if (action == "IN")
                    cars.Add(carNumber);
                else if (action == "OUT" && cars.Contains(carNumber))
                    cars.Remove(carNumber);

                command = Console.ReadLine();
            }
            if (cars.Count == 0)           
                Console.WriteLine("Parking Lot is Empty");          
            else
            {
                foreach (string car in cars)
                    Console.WriteLine(car);


            }
        }
    }
}
