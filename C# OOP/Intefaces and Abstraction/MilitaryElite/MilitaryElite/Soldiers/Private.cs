using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Soldiers
{
    public class Private : Soldier, IPrivate
    {
        public Private(decimal salary, string id, string firstName, string lastName) : base(id, firstName, lastName)
        {
            Salary = salary;

        }

        public decimal Salary { get; }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:F2}";
        }


    }
}
