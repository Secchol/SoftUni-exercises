using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;
        public List<Person> People { get { return people; } set { this.people = value; } }
        public void AddMember(Person member)
        {
            people.Add(member);


        }

        public string GetOldestMember()
        {
            Person oldestPerson = new Person();
            int maxAge = int.MinValue;
            foreach (Person person in people)
            {
                if (person.Age > maxAge)
                {
                    maxAge = person.Age;
                    oldestPerson = person;


                }


            }
            string[] personInfo = new string[] { oldestPerson.Name, oldestPerson.Age.ToString() };
            return string.Join(" ", personInfo);



        }
    }
}
