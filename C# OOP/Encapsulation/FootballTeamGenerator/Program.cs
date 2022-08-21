using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            Dictionary<string, Player> players = new Dictionary<string, Player>();
            while (command != "END")
            {
                try
                {
                    string[] commandArray = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                    string action = commandArray[0];
                    if (action == "Team")
                    {
                        Team team = new Team(commandArray[1]);
                        teams.Add(team.Name, team);

                    }
                    else if (action == "Add")
                    {
                        string teamName = commandArray[1];
                        string playerName = commandArray[2];
                        int endurance = int.Parse(commandArray[3]);
                        int sprint = int.Parse(commandArray[4]);
                        int dribble = int.Parse(commandArray[5]);
                        int passing = int.Parse(commandArray[6]);
                        int shooting = int.Parse(commandArray[7]);
                        
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;

                        }
                        Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
                        Player player = new Player(playerName, stats);
                        teams[teamName].AddPlayer(player);
                        players.Add(playerName, player);



                    }
                    else if (action == "Remove")
                    {
                        string teamName = commandArray[1];
                        string playerName = commandArray[2];
                        if (!players.ContainsKey(playerName))
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                            command = Console.ReadLine();
                            continue;

                        }
                        teams[teamName].RemovePlayer(players[playerName]);

                    }
                    else if (action == "Rating")
                    {
                        string teamName = commandArray[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            command = Console.ReadLine();
                            continue;
                        }
                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");

                    }

                    command = Console.ReadLine();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    command = Console.ReadLine();
                }
                
            }
        }
    }
}
