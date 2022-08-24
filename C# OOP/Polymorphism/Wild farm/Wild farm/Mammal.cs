using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight,string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

        public override bool EatFood(string foodType, int quantity)
        {
            return true;
        }

        public override void IncreaseWeight(int quantity)
        {
            
        }

        public override void ProduceSound()
        {
            
        }

        public override string ToString(string animalType)
        {
            return null;
        }
    }
}
