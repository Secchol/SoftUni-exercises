using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < count; i++)
            {
                string[] token = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = token[0];
                double fuelAmount = double.Parse(token[1]);
                double fuelConsumptionFor1km = double.Parse(token[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] token = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = token[1];
                double distanceTravelled = int.Parse(token[2]);
                foreach (Car car in cars)
                {
                    if (car.Model == model)
                    {
                        car.DriveCar(car, distanceTravelled);
                        
                        break;

                    }


                }


                command = Console.ReadLine();
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");


            }

        }
    }
}
