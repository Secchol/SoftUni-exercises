using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBA_game_simulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();
            string commands = Console.ReadLine();
            while (commands != "Season end")
            {
                string[] commandsArray = commands.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                if (commandsArray.Length == 0)
                {
                    commandsArray = commands.Split(" vs ", StringSplitOptions.RemoveEmptyEntries);
                    string firstPlayer = commandsArray[0];
                    string secondPlayer = commandsArray[1];
                    if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPlayer))
                    {
                        foreach (var position in players[firstPlayer])
                        {
                            if (players[secondPlayer].ContainsKey(position.Key))
                            {
                                int firstPlayerPoints = players[firstPlayer].Values.ToList().Sum();
                                int secondPlayerPoints = players[secondPlayer].Values.ToList().Sum();
                                if (firstPlayerPoints > secondPlayerPoints)
                                {
                                    players.Remove(secondPlayer);



                                }
                                else if (firstPlayerPoints < secondPlayerPoints)
                                {
                                    players.Remove(firstPlayer);



                                }




                            }



                        }



                    }


                }
                else
                {
                    string player = commandsArray[0];
                    string position = commandsArray[1];
                    int skill = int.Parse(commandsArray[2]);
                    if (!players.ContainsKey(player))
                    {
                        players[player] = new Dictionary<string, int>();
                        players[player].Add(position, skill);


                    }
                    else
                    {
                        if (players[player].ContainsKey(position))
                        {
                            if (players[player][position] < skill)
                            {
                                players[player][position] = skill;


                            }


                        }
                        else
                        {
                            players[player].Add(position, skill);



                        }


                    }


                }


                commands = Console.ReadLine();


            }
        }
    }
}

