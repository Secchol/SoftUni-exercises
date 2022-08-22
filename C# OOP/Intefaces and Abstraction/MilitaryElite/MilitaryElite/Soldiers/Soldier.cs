using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Soldiers
{
    public abstract class Soldier : ISoldier
    {
        public Soldier(string Id, string firstName, string lastName)
        {
            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = lastName;


        }
        public string Id { get; }

        public string FirstName { get; }

        public string LastName { get; }
        public abstract override string ToString();
    }
}
