using System;
using System.Collections.Generic;
using System.Linq;
namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get; private set; }
        public Net(string material, int capacity)
        {
            this.Material = material;
            Capacity = capacity;
            Count = 0;
            Fish = new List<Fish>();


        }
        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Weight <= 0 || fish.Length <= 0)
            {
                return "Invalid fish.";


            }

            if (this.Count == this.Capacity)
                return "Fishing net is full.";
            Fish.Add(fish);
            Count++;
            return $"Successfully added {fish.FishType} to the fishing net.";


        }
        public bool ReleaseFish(double weight)
        {
            Fish fish = Fish.FirstOrDefault(x => x.Weight == weight);
            if (fish == null)
                return false;

            Fish.Remove(fish);
            Count--;
            return true;


        }
        public Fish GetFish(string fishType)
        {
            return Fish.First(x => x.FishType == fishType);


        }
        public Fish GetBiggestFish()
        {
            double maxLength = double.MinValue;
            Fish longestFish = null;
            foreach (var fish in Fish)
            {
                if (fish.Length > maxLength)
                {
                    maxLength = fish.Length;
                    longestFish = fish;

                }


            }
            return longestFish;


        }
        public string Report()
        {

            return $"Into the {this.Material}:{string.Join(Environment.NewLine, Fish.OrderByDescending(x => x.Length))}";

        }
    }


}
