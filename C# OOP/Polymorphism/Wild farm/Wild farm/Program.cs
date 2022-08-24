using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<Animal, string> animals = new Dictionary<Animal, string>();
            while (command != "End")
            {
                string[] animalInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string animalType = animalInfo[0];
                Animal animal;
                if (animalType == "Owl")
                {
                    animal = new Owl(animalInfo[1], double.Parse(animalInfo[2]), int.Parse(animalInfo[3]));

                }
                else if (animalType == "Hen")
                {
                    animal = new Hen(animalInfo[1], double.Parse(animalInfo[2]), int.Parse(animalInfo[3]));

                }
                else if (animalType == "Dog")
                {
                    animal = new Dog(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);

                }
                else if (animalType == "Mouse")
                {
                    animal = new Mouse(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);

                }
                else if (animalType == "Cat")
                {
                    animal = new Cat(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);

                }
                else if (animalType == "Tiger")
                {
                    animal = new Tiger(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);

                }
                else
                {
                    animal = new Hen(animalInfo[1], double.Parse(animalInfo[2]), int.Parse(animalInfo[3]));

                }
                animal.ProduceSound();
                command = Console.ReadLine();
                string[] foodInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);
                Food food;
                if (foodType == "Vegetable")
                {
                    food = new Vegetable(foodQuantity);

                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(foodQuantity);

                }
                else if (foodType == "Meat")
                {
                    food = new Meat(foodQuantity);

                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(foodQuantity);

                }
                else
                {
                    food = new Meat(foodQuantity);

                }

                if (!animal.EatFood(foodType, foodQuantity))
                {
                    Console.WriteLine($"{animalType} does not eat {foodType}!");


                }
                else
                {
                    animal.IncreaseWeight(foodQuantity);


                }
                animals.Add(animal, animalType);


                command = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Key.ToString(animal.Value));


            }


        }
    }
}
