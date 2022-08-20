using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {                 
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Dough dough = new Dough(doughInfo[1], doughInfo[2], int.Parse(doughInfo[3]));
                string command = Console.ReadLine();
                List<Topping> toppings = new List<Topping>();
                while (command != "END")
                {
                    string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Topping topping = new Topping(commandArray[1], int.Parse(commandArray[2]));
                    toppings.Add(topping);
                    command = Console.ReadLine();

                }
                Pizza pizza = new Pizza(pizzaInfo[1], dough);
                
                foreach (var topping in toppings)
                {
                    pizza.AddTopping(topping);

                }
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
