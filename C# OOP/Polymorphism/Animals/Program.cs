using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("kotka","kuche");
            Dog dog = new Dog("dog","hrana");
            Console.WriteLine(dog.ExplainSelf());
            Console.WriteLine(cat.ExplainSelf());
        }
    }
}
