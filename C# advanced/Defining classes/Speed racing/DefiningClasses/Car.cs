using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;
        public string Model { get { return model; } set { model = value; } }
        public double FuelAmount { get { return fuelAmount; } set { fuelAmount = value; } }
        public double FuelConsumptionPerKilometer { get { return fuelConsumptionPerKilometer; } set { this.fuelConsumptionPerKilometer = value; } }
        public double TravelledDistance { get { return travelledDistance; } set { this.travelledDistance = value; } }
        public Car(string model, double fuelAmount, double fuelNeededFor1Km)
        {
            this.travelledDistance = 0;
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelNeededFor1Km;


        }
        public void DriveCar(Car car, double distanceTravelled)
        {


            if (car.FuelAmount - distanceTravelled * car.FuelConsumptionPerKilometer >= 0)
            {
                car.FuelAmount -= distanceTravelled * car.FuelConsumptionPerKilometer;
                car.TravelledDistance += distanceTravelled;


            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");


            }
        }
    }
}
