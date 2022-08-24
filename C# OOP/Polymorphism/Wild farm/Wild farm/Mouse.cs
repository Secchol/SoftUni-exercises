using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }
        public override string ToString(string type)
        {
            return $"{type} [{this.Name}, {this.Weight}, {this.LivingRegion}, {FoodEaten}]";


        }
        public override void IncreaseWeight(int quantity)
        {
            Weight += 0.10*quantity;
        }
        public override bool EatFood(string foodType, int quantity)
        {
            if (foodType != "Vegetable" && foodType != "Fruit")
            {
                return false;

            }
            FoodEaten += quantity;
            return true;
        }

    }
}
