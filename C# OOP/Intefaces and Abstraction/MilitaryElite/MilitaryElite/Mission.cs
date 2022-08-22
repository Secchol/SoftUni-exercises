using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            if (state == "inProgress")
            {
                this.State = MissionState.inProgress;

            }
            else if (state == "Finished")
            {
                this.State = MissionState.Finished;

            }

        }
        public string CodeName { get; }
        public MissionState State { get; set; }

        public void CompleteMission()
        {
            this.State = MissionState.Finished;


        }
        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {this.State.ToString()}";
        }
    }
}
