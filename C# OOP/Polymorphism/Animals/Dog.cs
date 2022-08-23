using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog: Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {


        }
        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"I am {base.Name} and my fovourite food is {base.FavouriteFood}");
            sb.AppendLine("DJAAF");
            return sb.ToString();
        }
    }
}
