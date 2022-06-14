using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    //    •	Name: string
    //•	Class: string
    //•	Rank: string – "Trial" by default
    //•	Description: string – "n/a" by default

    public class Player
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }
        public Player(string name, string classVariable)
        {
            this.Name = name;
            this.Class = classVariable;
            this.Rank = "Trial";
            this.Description = "n/a";


        }
        public override string ToString()
        {
            return @$"Player {Name}: {Class}
Rank: {Rank}
Description: {Description}";

        }
    }
}
