using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person("sdfsdfsdf", 85);

            bool isValidEntity = Validator.isValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
