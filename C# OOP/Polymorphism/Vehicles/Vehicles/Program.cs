using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = commandArray[0];
                string vehicle = commandArray[1];
                double fuelQuantity = double.Parse(commandArray[2]);
                if (action == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        car.Drive(fuelQuantity);


                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Drive(fuelQuantity);


                    }
                    else if (vehicle == "Bus")
                    {
                        double oldConsumption = bus.FuelConsumption;
                        bus.FuelConsumption += 1.4;
                        bus.Drive(fuelQuantity);
                        bus.FuelConsumption = oldConsumption;


                    }


                }
                else if (action == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(fuelQuantity);


                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(fuelQuantity);


                    }
                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(fuelQuantity);


                    }


                }
                else if (action == "DriveEmpty")
                {
                    bus.Drive(fuelQuantity);

                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
