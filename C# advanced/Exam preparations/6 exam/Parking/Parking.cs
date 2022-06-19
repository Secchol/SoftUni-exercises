using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public List<Car> Data { get { return data; } set { data = value; } }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get; private set; }
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            Data = new List<Car>();

        }
        public void Add(Car car)
        {
            if (Data.Count < Capacity)
            {
                Data.Add(car);
                Count++;
            }

        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (car == null)
                return false;
            Count--;
            Data.Remove(car);
            return true;

        }
        public Car GetLatestCar()
        {
            if (Data.Count == 0)
                return null;
            int maxYear = Data.Max(x => x.Year);
            return Data.First(x => x.Year == maxYear);


        }
        public Car GetCar(string manufacturer, string model)
        {
            Car car = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (car == null)
                return null;
            return car;


        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (Car car in Data)
            {
                sb.AppendLine(car.ToString());

            }
            return sb.ToString().TrimEnd();


        }
    }
}
