using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationeryPhone = new StationaryPhone();
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();
            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.ToCharArray().Any(x => !char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid number!");

                }
                else if (phoneNumber.Length == 7)
                {
                    stationeryPhone.Call(phoneNumber);

                }
                else
                {
                    smartphone.Call(phoneNumber);

                }



            }

            foreach (string website in websites)
            {
                if (website.ToCharArray().Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");

                }
                
                else
                {
                    smartphone.Browse(website);

                }



            }
        }
    }
}
