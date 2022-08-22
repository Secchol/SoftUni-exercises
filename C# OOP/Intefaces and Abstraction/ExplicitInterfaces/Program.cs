using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            string command = Console.ReadLine();
            
            while (command != "End")
            {
                string[] citizenInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);
                Citizen citizen = new Citizen(name, age, country);
                citizens.Add(citizen);
                command = Console.ReadLine();

            }
            foreach (Citizen citizen in citizens)
            {
                PrintPersonName(citizen);
                PrintResidentName(citizen);


            }
        }
        public static void PrintPersonName(IPerson person)
        {
            Console.WriteLine(person.GetName());
        }
        public static void PrintResidentName(IResident resident)
        {
            Console.WriteLine(resident.GetName());
        }
    }
}
