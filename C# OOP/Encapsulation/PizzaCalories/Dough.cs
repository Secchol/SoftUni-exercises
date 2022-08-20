using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;


        }
        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            { "white",1.5},
            { "wholegrain",1.0},
            { "crispy",0.9},
            { "chewy",1.1},
            { "homemade",1.0},


        };
        private string flourType;
        private string bakingTechnique;
        private int weight;
        public int Weight
        {
            get
            {

                return weight;

            }
             set
            {

                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                else
                    weight = value;

            }

        }
        public string FlourType
        {
            get
            {

                return this.flourType;

            }
            set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");

                }
                else
                {
                    flourType = value;

                }


            }




        }
        public string BakingTechnique
        {
            get
            {

                return this.bakingTechnique;

            }
             set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");

                }
                else
                {
                    bakingTechnique = value;

                }


            }

        }

        public double Calories =>
            2 * Weight * modifiers[FlourType.ToLower()] * modifiers[BakingTechnique.ToLower()];

    }
}
