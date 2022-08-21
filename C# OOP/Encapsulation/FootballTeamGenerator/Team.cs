using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();

        }
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
        private IReadOnlyCollection<Player> Players
        {
            get { return players.AsReadOnly(); }


        }
        public int Rating => players.Any() ? (int)Math.Round((double)players.Sum(x => x.Stats.Overall) / players.Count()) : 0;

        public void AddPlayer(Player player)
        {
            players.Add(player);

        }
        public void RemovePlayer(Player player)
        {
            players.Remove(player);


        }
    }
}
