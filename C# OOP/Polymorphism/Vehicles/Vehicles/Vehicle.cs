using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double FuelQuantity, double FuelConsumption,double tankCapacity)
        {
            this.FuelQuantity = FuelQuantity;
            this.FuelConsumption = FuelConsumption;
            TankCapacity = tankCapacity;


        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public abstract void Drive(double distance);
        public abstract void Refuel(double quantity);
    }
}
