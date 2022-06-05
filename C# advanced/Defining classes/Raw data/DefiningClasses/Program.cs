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
            List<Car> cars = new List<Car>();
            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                int engineSpeed = int.Parse(info[1]);
                int enginePower = int.Parse(info[2]);
                Engine engine = new Engine();
                engine.Speed = engineSpeed;
                engine.Power = enginePower;
                int cargoWeight = int.Parse(info[3]);
                string cargoType = info[4];
                Cargo cargo = new Cargo();
                cargo.Weight = cargoWeight;
                cargo.Type = cargoType;
                Tire[] tires = new Tire[4];
                int index = 0;
                for (int j = 5; j < info.Length; j += 2)
                {
                    double pressure = double.Parse(info[j]);
                    int age = int.Parse(info[j + 1]);

                    Tire tire = new Tire();
                    tire.Age = age;
                    tire.Pressure = pressure;
                    tires[index++] = tire;


                }
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string carCargoType = Console.ReadLine();
            List<Car> validCars = new List<Car>();
            if (carCargoType == "fragile")
            {
                cars = cars.Where(x => x.Cargo.Type == "fragile").ToList();

                foreach (Car car in cars)
                {
                    bool hasBrokenTire = false;
                    foreach (Tire tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            hasBrokenTire = true;
                            break;


                        }


                    }
                    if (hasBrokenTire)
                    {
                        validCars.Add(car);

                    }


                }


            }
            else
            {
                validCars = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250).ToList();


            }
            foreach (Car validCar in validCars)
            {
                Console.WriteLine(validCar.Model);


            }

        }
    }
}
