using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
        public override string ToString(string type)
        {
            return $"{type} [{this.Name}, {this.Weight}, {this.LivingRegion}, {FoodEaten}]";


        }
        public override void IncreaseWeight(int quantity)
        {
            Weight += 0.40*quantity;
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
