using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];
                string sound = string.Empty;
                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;


                }

                if (input == "Cat")
                {
                    Cat cat = new Cat(name, age, gender);
                    sound = cat.ProduceSound();

                }
                else if (input == "Dog")
                {
                    Dog dog = new Dog(name, age, gender);
                    sound = dog.ProduceSound();
                }
                else if (input == "Frog")
                {
                    Frog frog = new Frog(name, age, gender);
                    sound = frog.ProduceSound();
                }
                Console.WriteLine(input);
                Console.WriteLine($"{name} {age} {gender}");
                Console.WriteLine(sound);
                input = Console.ReadLine();




            }
        }
    }
}
