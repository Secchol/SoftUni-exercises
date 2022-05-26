using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            string contest = Console.ReadLine();
            while (contest != "end of contests")
            {
                string[] contestInfo = contest.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contestName = contestInfo[0];
                string contestPassword = contestInfo[1];
                contests.Add(contestName, contestPassword);


                contest = Console.ReadLine();
            }
            contest = Console.ReadLine();
            var users = new Dictionary<string, Dictionary<string, int>>();
            string smartestUser = string.Empty;
            int maxPoints = 0;
            while (contest != "end of submissions")
            {
                string[] token = contest.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contestName = token[0];
                string contestPassword = token[1];
                string user = token[2];
                int userPoints = int.Parse(token[3]);
                if (contests.ContainsKey(contestName) && contests[contestName] == contestPassword)
                {
                    if (users.ContainsKey(user) && users[user].ContainsKey(contestName))
                    {
                        if (userPoints > users[user][contestName])
                        {
                            users[user][contestName] = userPoints;



                        }


                    }
                    else
                    {
                        if (!users.ContainsKey(user))
                            users.Add(user, new Dictionary<string, int>());
                        users[user].Add(contestName, userPoints);
                    }

                    if (userPoints > maxPoints)
                    {
                        maxPoints = userPoints;
                        smartestUser = user;
                    }

                    
                }
                contest = Console.ReadLine();


            }

            Console.WriteLine($"Best candidate is {smartestUser} with total {users[smartestUser].Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var item in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");


                }



            }
        }
    }
}
