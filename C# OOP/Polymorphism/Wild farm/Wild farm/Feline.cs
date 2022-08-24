using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }

        public override void ProduceSound()
        {

        }
        public override string ToString(string type)
        {

            return $"{type} [{this.Name}, {Breed}, {this.Weight}, {this.LivingRegion}, {FoodEaten}]";

        }
        public override bool EatFood(string foodType, int quantity)
        {
            if (foodType != "Meat" && foodType != "Vegetable")
            {
                return false;

            }
            FoodEaten += quantity;
            return true;
        }
    }
}
