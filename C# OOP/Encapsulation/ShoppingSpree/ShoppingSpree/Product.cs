using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;

        }
        private string name;
        private double cost;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                else
                    name = value;

            }

        }
        public double Cost
        {
            get
            {
                return cost;

            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                else
                    cost = value;


            }


        }

    }
}
