using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string info = Console.ReadLine();
            var users = new Dictionary<string, Dictionary<string, int>>();
            var submissions = new Dictionary<string, int>();
            while (info != "exam finished")
            {
                string[] infoArray = info.Split("-", StringSplitOptions.RemoveEmptyEntries);
                if (infoArray[1] == "banned")
                {
                    users.Remove(infoArray[0]);
                    info = Console.ReadLine();
                    continue;

                }
                string user = infoArray[0];
                string language = infoArray[1];
                int points = int.Parse(infoArray[2]);
                if (!submissions.ContainsKey(language))
                    submissions.Add(language, 0);
                submissions[language]++;
                if (!users.ContainsKey(user))
                    users.Add(user, new Dictionary<string, int>());
                if (users[user].ContainsKey(language))
                {
                    if (points > users[user][language])
                    {
                        users[user][language] = points;


                    }

                }
                else
                {
                    users[user].Add(language, points);

                }


                info = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var user in users.OrderByDescending(x => x.Value.Values.Max()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value.Values.Max()}");


            }
            Console.WriteLine("Submissions:");
            foreach (var submission in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");


            }

        }
    }
}
