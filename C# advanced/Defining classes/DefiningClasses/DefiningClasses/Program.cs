using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Family family = new Family();
            family.People = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                string[] token = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(token[0], int.Parse(token[1]));
                family.AddMember(person);

            }
            family.People = family.People.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            foreach (Person member in family.People)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");



            }
        }
    }
}
