using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;

            }
            

        }
        public override void Drive(double distance)
        {
            if (this.FuelQuantity >= distance * this.FuelConsumption)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= distance * this.FuelConsumption;


            }
            else
            {
                Console.WriteLine("Bus needs refueling");

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
