using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        

        public const double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
            FuelConsumption = DefaultFuelConsumption;
        }
        public virtual void Drive(double kilometers)
        {
            if (Fuel - (kilometers * FuelConsumption) >= 0)
                Fuel -= kilometers * FuelConsumption;

        }
    }
}
