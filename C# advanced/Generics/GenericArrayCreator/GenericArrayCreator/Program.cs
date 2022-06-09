using System;


namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(10,"123");
            Console.WriteLine(string.Join(" ",strings));
        }
    }
}
