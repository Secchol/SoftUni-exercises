using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        //        •	double CoffeeMilliliters = 50
        //•	decimal CoffeePrice = 3.50
        //•	Caffeine – double
        public const double CoffeeMilliliters = 50;
        public const decimal CoffeePrice = 3.50m;
        public double Caffeine { get; set; }

        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMilliliters)
        {
            Caffeine = caffeine;
            


        }
    }
}
