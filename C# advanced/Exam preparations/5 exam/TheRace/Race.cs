using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public List<Racer> Data { get { return data; } set { data = value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get; private set; }
        public Race(string name, int capacity)
        {
            this.Name = name;
            Capacity = capacity;
            Data = new List<Racer>();


        }
        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
                Count++;
            }
            



        }
        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(x => x.Name == name);
            if (racer == null)
                return false;
            data.Remove(racer);
            Count--;
            return true;

        }

        public Racer GetOldestRacer()
        {
            int maxAge = data.Max(x => x.Age);
            return data.First(x => x.Age == maxAge);



        }
        public Racer GetRacer(string name)
        {
            return data.First(x => x.Name == name);



        }
        public Racer GetFastestRacer()
        {
            int maxSpeed = data.Max(x => x.Car.Speed);
            return data.First(x => x.Car.Speed == maxSpeed);


        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (Racer racer in Data)
            {
                sb.AppendLine(racer.ToString());


            }
            return sb.ToString().TrimEnd();


        }
    }
}
