using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight,double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;   
        }

        public double WingSize { get; set; }

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
        public override  string ToString(string type)
        {
            return $"{type} [{this.Name}, {WingSize}, {this.Weight}, {this.FoodEaten}]";
        }

        
    }
}
