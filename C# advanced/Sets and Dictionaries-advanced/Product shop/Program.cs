using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string token = Console.ReadLine();
            var list = new Dictionary<string, Dictionary<string, double>>();
            while (token != "Revision")
            {
                string[] infoArr = token.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = infoArr[0];
                string product = infoArr[1];
                double price = double.Parse(infoArr[2]);
                if (!list.ContainsKey(shop))
                    list[shop] = new Dictionary<string, double>();
                list[shop][product] = price;

                token = Console.ReadLine();
            }
            foreach (var (shop, products) in list.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop}->");
                foreach (var product in products)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");


                }


            }
        }
    }
}
