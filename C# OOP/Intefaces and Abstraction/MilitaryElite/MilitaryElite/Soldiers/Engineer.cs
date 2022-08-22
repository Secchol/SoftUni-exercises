using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Soldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(decimal salary, string id, string firstName, string lastName, string corps, List<Repair> repairs) : base(salary, id, firstName, lastName, corps)
        {
            this.Repairs = repairs;
        }

        public List<Repair> Repairs { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var repair in Repairs)
            {
                sb.AppendLine("   " + repair.ToString());

            }
            return sb.ToString().TrimEnd();
        }
    }
}
