using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();
            string command = Console.ReadLine();
            bool party = false;
            while (command != "END")
            {
                if (command == "PARTY")
                {
                    party = true;
                    command = Console.ReadLine();
                    continue;
                }

                if (party)
                {
                    if (VIP.Contains(command))
                        VIP.Remove(command);
                    else
                        regular.Remove(command);


                }
                else
                {
                    if (char.IsDigit(command[0]))
                        VIP.Add(command);
                    else
                        regular.Add(command);


                }

                command = Console.ReadLine();




            }
            Console.WriteLine(VIP.Count + regular.Count);
            foreach (string richPerson in VIP)
                Console.WriteLine(richPerson);
            foreach (string poorPerson in regular)
                Console.WriteLine(poorPerson);
        }
    }
}
