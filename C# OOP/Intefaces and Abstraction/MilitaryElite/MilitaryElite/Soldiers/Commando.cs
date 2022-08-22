using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Soldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(decimal salary, string id, string firstName, string lastName, string corps, List<Mission> missions) : base(salary, id, firstName, lastName, corps)
        {
            this.Missions = missions;
        }

        public List<Mission> Missions { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine("   " + mission.ToString());

            }
            return sb.ToString().TrimEnd();
        }
    }
}
