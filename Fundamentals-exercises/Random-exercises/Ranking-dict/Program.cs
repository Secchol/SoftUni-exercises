using System;
using System.Linq;
using System.Numerics;

using System.Collections.Generic;

namespace Ranking_dict
{
    class Contest
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public Contest(string name, int points)
        {
            this.Name = name;
            this.Points = points;



        }



    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string command = Console.ReadLine();
            while (command != "end of contests")
            {
                string[] commandsArray = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
                contests.Add(commandsArray[0], commandsArray[1]);
                command = Console.ReadLine();
            }
            string commands = Console.ReadLine();
            Dictionary<string, List<Contest>> contestsForUser = new Dictionary<string, List<Contest>>();
            while (commands != "end of submissions")
            {
                string[] array = commands.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = array[0];
                string password = array[1];
                string username = array[2];
                int points = int.Parse(array[3]);
                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == password)
                    {
                        Contest competition = new Contest(contest, points);
                        if (!contestsForUser.ContainsKey(username))
                        {
                            contestsForUser.Add(username, new List<Contest>());
                            contestsForUser[username].Add(competition);


                        }
                        else if (contestsForUser[username].Any(x => x.Name == competition.Name))
                        {
                            ReplaceOldPointsWithCurrent(contestsForUser, username, competition);
                        }
                        else
                        {
                            contestsForUser[username].Add(competition);


                        }



                    }



                }
                commands = Console.ReadLine();
            }
            contestsForUser = contestsForUser.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            StudentWithMostPoints(contestsForUser);
            Console.WriteLine("Ranking:");
            foreach (var user in contestsForUser)
            {
                Console.WriteLine($"{user.Key}");
                List<Contest> orderedContests = new List<Contest>();
                orderedContests = user.Value.OrderByDescending(x => x.Points).ToList();
                foreach (Contest contest in orderedContests)
                {
                    Console.WriteLine($"#  {contest.Name} -> {contest.Points}");



                }
            }








        }
        static void StudentWithMostPoints(Dictionary<string, List<Contest>> contestsForUser)
        {
            int maxPoints = 0;
            string name = string.Empty;
            foreach (var student in contestsForUser)
            {
                if (student.Value.Sum(x => x.Points) > maxPoints)
                {
                    maxPoints = student.Value.Sum(x => x.Points);
                    name = student.Key;



                }



            }
            Console.WriteLine($"Best candidate is {name} with total {maxPoints} points.");

        }
        static void ReplaceOldPointsWithCurrent(Dictionary<string, List<Contest>> contestsForUser, string username, Contest competition)
        {
            foreach (var race in contestsForUser[username])
            {
                if (race.Name == competition.Name)
                {
                    if (competition.Points > race.Points)
                    {
                        race.Points = competition.Points;



                    }

                }
            }



        }



    }
}
