using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
        public override void IncreaseWeight(int quantity)
        {
            Weight += 0.25*quantity;
        }
        public override bool EatFood(string foodType, int quantity)
        {
            if (foodType != "Meat")
            {
                return false;

            }
            FoodEaten += quantity;
            return true;
        }
    }
}
