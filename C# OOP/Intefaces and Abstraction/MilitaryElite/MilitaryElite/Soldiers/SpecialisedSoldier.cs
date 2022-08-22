using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Soldiers
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(decimal salary, string id, string firstName, string lastName, string corps) : base(salary, id, firstName, lastName)
        {
            if (corps == "Airforces")
            {
                Corps = Corps.Airforces;

            }
            else if (corps == "Marines")
            {
                Corps = Corps.Marines;

            }
        }

        public Corps Corps { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps.ToString()}");
            return sb.ToString();

        }
    }
}
