using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_by_age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();
            for (int i = 0; i < count; i++)
            {
                string[] token = Console.ReadLine().Split(", ");
                people.Add(token[0], int.Parse(token[1]));
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<KeyValuePair<string, int>, bool> formatting = Formatting(condition, age);
            people = people.Where(formatting).ToDictionary(x => x.Key, x => x.Value);
            Action<KeyValuePair<string, int>> action = PrintingFormat(format);
            foreach (var person in people)
            {
                action(person);

            }
        }
        static Func<KeyValuePair<string, int>, bool> Formatting(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x.Value < age;
                case "older":
                    return x => x.Value >= age;
                default:
                    return null;


            }
        }
        static Action<KeyValuePair<string, int>> PrintingFormat(string format)
        {
            switch (format)
            {
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                case "name":
                    return x => Console.WriteLine($"{x.Key}");
                case "age":
                    return x => Console.WriteLine($"{x.Value}");
                default:
                    return null;
                    


            }
            



        }
    }
}
