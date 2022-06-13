using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public List<Ski> Ski { get { return data; } set { data = value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get; private set; }
        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Ski = new List<Ski>();
        }
        public void Add(Ski ski)
        {
            if (Ski.Count < Capacity)
            {
                Ski.Add(ski);
                Count++;

            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski ski = Ski.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (ski == null)
                return false;
            Ski.Remove(ski);
            Count--;
            return true;

        }
        public Ski GetNewestSki()
        {
            if (Ski.Count == 0)
                return null;
            int newestYear = Ski.Max(x => x.Year);
            Ski ski = Ski.First(x => x.Year == newestYear);
            return ski;


        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = Ski.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return ski;


        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (Ski ski in Ski)
            {
                sb.AppendLine(ski.ToString());


            }
            return sb.ToString().TrimEnd();


        }
    }
}
