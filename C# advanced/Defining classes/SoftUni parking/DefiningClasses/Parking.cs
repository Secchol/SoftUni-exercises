using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private HashSet<Car> cars;
        private static int capacity;
        public HashSet<Car> Cars { get { return this.cars; } set { cars = value; } }
        public static int Capactiy { get { return Parking.capacity; } private set {; } }
        public int Count { get { return this.cars.Count; } private set {; } }
        public Parking(int capacity)
        {
            this.Cars = new HashSet<Car>();
            Parking.capacity = capacity;


        }
        public string AddCar(Car car)
        {
            foreach (Car item in cars)
            {
                if (item.RegistrationNumber == car.RegistrationNumber)
                {

                    return "Car with that registration number, already exists!";


                }


            }
            if (cars.Count + 1 > Parking.Capactiy)
            {

                return "Parking is full!";


            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }
        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";


            }
            cars.Remove(car);
            return $"Successfully removed {registrationNumber}";



        }
        public Car GetCar(string registrationNumber)
        {
            return cars.First(x => x.RegistrationNumber == registrationNumber);



        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                RemoveCar(registrationNumber);


            }



        }
        
        
    }
}
