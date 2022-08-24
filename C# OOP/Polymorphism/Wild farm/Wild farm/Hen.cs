using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
        public override void IncreaseWeight(int quantity)
        {
            Weight += 0.35 * quantity;
        }
        public override bool EatFood(string foodType, int quantity)
        {
            FoodEaten += quantity;
            return true;
        }
    }
}
