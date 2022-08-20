using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private List<Topping> toppings;
        private string name;
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            toppings = new List<Topping>();
            Dough = dough;


        }
        public string Name
        {
            get
            {
                return name;

            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                else
                    name = value;


            }

        }
        public List<Topping> Toppings { get { return toppings; } private set { toppings = value; } }
        public Dough Dough { get; private set; }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            else
                toppings.Add(topping);


        }
        public double Calories => this.Dough.Calories + toppings.Sum(x => x.Calories);
    }
}
