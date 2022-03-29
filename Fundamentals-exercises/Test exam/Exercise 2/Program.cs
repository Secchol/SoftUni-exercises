using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Exercise_2
{


    class Program
    {

        static void Main(string[] args)
        {
            int barcodesCount = int.Parse(Console.ReadLine());
            List<string> productGroups = new List<string>();
            Regex regex = new Regex(@"^@#+(?<product>[A-Z][A-Za-z\d]{4,}[A-Z])@#+$");
            for (int i = 0; i < barcodesCount; i++)
            {
                string barcode = Console.ReadLine();
                Match match = regex.Match(barcode);
                if (match.Success)
                {
                    string product = match.Groups["product"].Value;
                    string productGroup = string.Join("", product.Where(x => char.IsDigit(x)));
                    if (productGroup.Length == 0)
                    {
                        productGroup = "00";


                    }
                    Console.WriteLine($"Product group: {productGroup}");

                }
                else
                {
                    Console.WriteLine("Invalid barcode");


                }

            }




        }




    }
}
