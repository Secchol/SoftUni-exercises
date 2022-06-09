using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog1 = new Dog("John", 20);
            Dog dog2 = new Dog("JOHN", 90);

            EqualityScale<Dog> scale = new EqualityScale<Dog>(dog1, dog2);
            Console.WriteLine(scale.AreEqual());

        }
    }
}
