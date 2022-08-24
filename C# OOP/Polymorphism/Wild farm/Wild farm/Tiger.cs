using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
        public override void IncreaseWeight(int quantity)
        {
            Weight += 1.00* quantity;
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
