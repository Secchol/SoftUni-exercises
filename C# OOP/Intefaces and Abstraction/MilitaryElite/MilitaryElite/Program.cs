using MilitaryElite.Interfaces;
using MilitaryElite.Soldiers;
using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<ISoldier> soldiers = new List<ISoldier>();
            var privates = new Dictionary<string, Private>();

            while (command != "End")
            {
                try
                {

                    string[] commandInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string soldierType = commandInfo[0];
                    string Id = commandInfo[1];
                    string firstName = commandInfo[2];
                    string lastName = commandInfo[3];
                    Soldier soldier;
                    if (soldierType == "Private")
                    {
                        soldier = new Private(decimal.Parse(commandInfo[4]), Id, firstName, lastName);
                        privates.Add(Id, soldier as Private);


                    }
                    else if (soldierType == "LieutenantGeneral")
                    {
                        List<Private> privatesPeople = new List<Private>();
                        for (int i = 5; i < commandInfo.Length; i++)
                        {
                            privatesPeople.Add(privates[commandInfo[i]]);
                        }
                        soldier = new LieutenantGeneral(decimal.Parse(commandInfo[4]), Id, firstName, lastName, privatesPeople);

                    }
                    else if (soldierType == "Engineer")
                    {
                        if (commandInfo[5] != "Airforces" && commandInfo[5] != "Marines")
                        {
                            throw new Exception();
                            command = Console.ReadLine();
                            continue;

                        }
                        List<Repair> repairs = new List<Repair>();
                        for (int i = 6; i < commandInfo.Length; i += 2)
                        {
                            string repairPart = commandInfo[i];
                            int repairHours = int.Parse(commandInfo[i + 1]);
                            Repair repair = new Repair(repairPart, repairHours);
                            repairs.Add(repair);

                        }
                        soldier = new Engineer(decimal.Parse(commandInfo[4]), Id, firstName, lastName, commandInfo[5], repairs);



                    }
                    else if (soldierType == "Commando")
                    {
                        if (commandInfo[5] != "Airforces" && commandInfo[5] != "Marines")
                        {
                            throw new Exception();
                            command = Console.ReadLine();
                            continue;

                        }
                        List<Mission> missions = new List<Mission>();
                        for (int i = 6; i < commandInfo.Length; i += 2)
                        {
                            string missionName = commandInfo[i];
                            string missionState = commandInfo[i + 1];
                            if (missionState != "inProgress" && missionState != "Finished")
                                continue;
                            Mission mission = new Mission(missionName, missionState);
                            missions.Add(mission);
                        }
                        soldier = new Commando(decimal.Parse(commandInfo[4]), Id, firstName, lastName, commandInfo[5], missions);
                    }
                    else if (soldierType == "Spy")
                    {
                        soldier = new Spy(Id, firstName, lastName, int.Parse(commandInfo[4]));

                    }
                    else
                    {
                        soldier = new Private(decimal.Parse(commandInfo[4]), Id, firstName, lastName);

                    }
                    soldiers.Add(soldier);

                    command = Console.ReadLine();
                }
                catch (Exception )
                {


                }
            }
            foreach (Soldier soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());

            }


        }
    }
}
