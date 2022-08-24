using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += 0.9;
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;

            }
            


        }

        public override void Drive(double distance)
        {
            if (this.FuelQuantity >= distance * this.FuelConsumption)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= distance * this.FuelConsumption;


            }
            else
            {
                Console.WriteLine("Car needs refueling");

            }
        }

        public override void Refuel(double quantity)
        {
            if (this.FuelQuantity + quantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {quantity} fuel in the tank");

            }
            else if (quantity <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");

            }
            else
            {
                this.FuelQuantity += quantity;
            }
        }
    }
}
