using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int engineCount = int.Parse(Console.ReadLine());
            List<Engine> engineList = new List<Engine>();
            for (int i = 0; i < engineCount; i++)
            {
                string[] token = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = token[0];
                int power = int.Parse(token[1]);
                string displacement = string.Empty;
                string efficiency = string.Empty;
                if (2 < token.Length)
                    if (char.IsDigit(token[2][0]))
                    {
                        displacement = token[2];
                    }
                    else
                    {
                        efficiency = token[2];
                        displacement = "n/a";
                    }
                else
                    displacement = "n/a";


                if (3 < token.Length && efficiency == String.Empty)
                    efficiency = token[3];
                else if (efficiency == String.Empty)
                    efficiency = "n/a";
                Engine engine = new Engine(model, power, displacement, efficiency);
                engineList.Add(engine);


            }
            int carCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < carCount; i++)
            {
                string[] token = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = token[0];
                string engineModel = token[1];
                string weight = string.Empty;
                string color = string.Empty;
                if (2 < token.Length)
                    if (char.IsDigit(token[2][0]))
                    {
                        weight = token[2];
                    }
                    else
                    {
                        color = token[2];
                        weight = "n/a";
                    }

                else
                    weight = "n/a";


                if (3 < token.Length && color == String.Empty)
                    color = token[3];
                else if (color == String.Empty)
                    color = "n/a";
                Engine carEngine = engineList.First(x => x.Model == engineModel);
                Car car = new Car(model, carEngine, weight, color);
                cars.Add(car);

            }
            foreach (Car car in cars)
            {
                Console.WriteLine($@"{car.Model}:
  {car.Engine.Model}:
    Power: { car.Engine.Power}
    Displacement: { car.Engine.Displacement}
    Efficiency: { car.Engine.Efficiency}
  Weight: { car.Weight}
  Color: { car.Color}");


            }
        }
    }
}
