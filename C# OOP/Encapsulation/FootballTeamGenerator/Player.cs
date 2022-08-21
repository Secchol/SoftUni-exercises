using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;

        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("A name should not be empty.");
                else
                    name = value;

            }

        }
        public Stats Stats { get; set; }
    }
}
