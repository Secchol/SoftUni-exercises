﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            

        }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public abstract void ProduceSound();
        public abstract void IncreaseWeight(int quantity);
        public abstract bool EatFood(string foodType,int quantity);
        public abstract string ToString(string animalType);
    }
}
