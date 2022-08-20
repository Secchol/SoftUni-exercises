using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private int weight;
        private Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            { "meat",1.2},
            { "veggies",0.8},
            { "cheese",1.1},
            { "sauce",0.9}

        };
        public string Type
        {
            get
            {

                return type;

            }
            set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");


                }
                else
                {
                    type = value;

                }


            }



        }
        public int Weight
        {
            get
            {

                return weight;

            }
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                else
                    weight = value;


            }


        }
        public Topping(string type, int weight)
        {
            Type = type;
            Weight = weight;


        }
        public double Calories => 2 * Weight * modifiers[Type.ToLower()];
    }
}
