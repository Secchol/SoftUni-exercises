using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG");

            var car2 = new Car("Audi", "A3", 110, "EB8787MN");
            Console.WriteLine(car.ToString());

            // Make: Skoda

            // Model: Fabia

            // HorsePower: 65

            // RegistrationNumber: CC1856BG

            var parking = new Parking(5);

            Console.WriteLine(parking.AddCar(car));

            // Successfully added new car Skoda CC1856BG

            Console.WriteLine(parking.AddCar(car));

            // Car with that registration number, already exists!

            Console.WriteLine(parking.AddCar(car2));

            // Successfully added new car Audi EB8787MN

            Console.WriteLine(parking.GetCar("EB8787MN").ToString());

            // Make: Audi

            // Model: A3

            // HorsePower: 110

            // RegistrationNumber: EB8787MN

            Console.WriteLine(parking.RemoveCar("EB8787MN"));

            // Successfullyremoved EB8787MN

            Console.WriteLine(parking.Count);
            List<String> toRemove = new List<String>();
            var car4 = new Car("Skodaddddd", "Fabia", 65, "CC1856BGTTT");
            var car5 = new Car("SkodaFfFFFFFF", "Fabia", 65, "CC1856BG555");
            toRemove.Add(car4.RegistrationNumber);
            toRemove.Add(car5.RegistrationNumber);
            parking.Cars.Add(car4);
            parking.Cars.Add(car5);
            parking.RemoveSetOfRegistrationNumber(toRemove);


        }
    }
}
