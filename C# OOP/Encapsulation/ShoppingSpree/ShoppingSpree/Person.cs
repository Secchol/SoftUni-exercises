using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            products = new List<Product>();


        }
        private string name;
        private double money;
        private List<Product> products;

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
        public double Money
        {
            get
            {
                return money;

            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                else
                    money = value;
            }


        }
        public IReadOnlyCollection<Product> Products => this.products;
        public void BuyProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Money -= product.Cost;
                this.products.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");

            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");

            }


        }
    }
}
