using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
                string[] allPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                
                foreach (var item in allPeople)
                {
                    string[] personInfo = item.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Person person = new Person(personInfo[0], double.Parse(personInfo[1]));
                    people.Add(person);

                }
                string[] allProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                
                foreach (var item in allProducts)
                {
                    string[] currentProduct = item.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Product product = new Product(currentProduct[0], double.Parse(currentProduct[1]));
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }


            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string person = commandArray[0];
                string product = commandArray[1];
                Person currentPerson = people.First(x => x.Name == person);
                Product currentProduct = products.First(x => x.Name == product);
                currentPerson.BuyProduct(currentProduct);

                command = Console.ReadLine();
            }

            foreach (Person person in people)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    List<string> productNames = new List<string>();
                    foreach (Product product in person.Products)
                    {
                        productNames.Add(product.Name);

                    }
                    Console.WriteLine($"{person.Name} - {string.Join(", ", productNames)}");
                }



            }
        }
    }
}
