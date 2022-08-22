using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Soldiers
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(decimal salary, string id, string firstName, string lastName, List<Private> privates) : base(salary, id, firstName, lastName)
        {
            this.privates = privates;
        }

        public List<Private> privates { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var item in privates)
            {
                sb.AppendLine("   " + item.ToString());

            }
            return sb.ToString();
        }
    }
}
