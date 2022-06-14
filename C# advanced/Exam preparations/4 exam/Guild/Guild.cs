using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public List<Player> Roster { get { return roster; } set { roster = value; } }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get; private set; }
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Roster = new List<Player>();


        }
        public void AddPlayer(Player player)
        {
            if (Roster.Count < Capacity)
            {
                Roster.Add(player);
                Count++;
            }

        }
        public bool RemovePlayer(string name)
        {
            Player player = Roster.FirstOrDefault(x => x.Name == name);
            if (player == null)
                return false;
            Roster.Remove(player);
            Count--;
            return true;


        }
        public void PromotePlayer(string name)
        {
            Player player = Roster.First(x => x.Name == name);
            player.Rank = "Member";



        }
        public void DemotePlayer(string name)
        {
            Player player = Roster.First(x => x.Name == name);
            player.Rank = "Trial";



        }
        public Player[] KickPlayersByClass(string playerClass)
        {
            Player[] kickedPlayers = Roster.Where(x => x.Class == playerClass).ToArray();
            Roster.RemoveAll(x => x.Class == playerClass);
            Count -= kickedPlayers.Length;
            return kickedPlayers;



        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (Player player in Roster)
            {
                sb.Append(player.ToString());


            }
            return sb.ToString().TrimEnd();



        }
    }
}
