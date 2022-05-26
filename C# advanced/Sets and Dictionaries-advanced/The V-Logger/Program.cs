using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Following
    {
        public int PeopleFollowed { get; set; }
        public HashSet<string> Followers { get; set; }
        public Following(int peopleFollowed, HashSet<string> followers)
        {
            this.PeopleFollowed = peopleFollowed;
            this.Followers = followers;



        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Following>();
            string command = Console.ReadLine();
            while (command != "Statistics")
            {
                string[] token = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string vlogger = token[0];
                string action = token[1];
                if (action == "followed")
                {
                    string followedPerson = token[2];
                    if (vlogger != followedPerson && vloggers.ContainsKey(followedPerson) && vloggers.ContainsKey(vlogger) && !vloggers[followedPerson].Followers.Contains(vlogger))
                    {
                        vloggers[followedPerson].Followers.Add(vlogger);
                        vloggers[vlogger].PeopleFollowed++;


                    }


                }
                else if (action == "joined")
                {
                    if (!vloggers.ContainsKey(vlogger))
                        vloggers[vlogger] = new Following(0, new HashSet<string>());



                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            string bestVlogger = string.Empty;
            int maxFollowers = 0;
            int maxFollowed = 0;
            foreach (var vlogger in vloggers)
            {
                if (vlogger.Value.Followers.Count > maxFollowers)
                {
                    bestVlogger = vlogger.Key;
                    maxFollowers = vlogger.Value.Followers.Count;
                    maxFollowed = vlogger.Value.PeopleFollowed;


                }
                else if (vlogger.Value.Followers.Count == maxFollowers && vlogger.Value.PeopleFollowed < maxFollowed
                    )
                {
                    bestVlogger = vlogger.Key;
                    maxFollowers = vlogger.Value.Followers.Count;
                    maxFollowed = vlogger.Value.PeopleFollowed;



                }


            }
            vloggers[bestVlogger].Followers = vloggers[bestVlogger].Followers.OrderBy(x => x).ToHashSet();
            Console.WriteLine($"1. {bestVlogger} : {vloggers[bestVlogger].Followers.Count} followers, {vloggers[bestVlogger].PeopleFollowed} following");
            foreach (string followedPerson in vloggers[bestVlogger].Followers)
            {
                Console.WriteLine($"*  { followedPerson}");


            }
            vloggers.Remove(bestVlogger);
            int vloggersCount = 2;
            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.PeopleFollowed))
            {
                Console.WriteLine($"{vloggersCount}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.PeopleFollowed} following");
                vloggersCount++;



            }
        }
    }
}
