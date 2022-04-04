using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Exercise_two
{
    class Program
    {

        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\S+)>(?<numbers>\d{3})\|(?<lowercaseLetters>[a-z]{3})\|(?<uppercaseLetters>[A-Z]{3})\|(?<randomSymbols>[^<>]{3})<\1");
            int inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                string text = Console.ReadLine();
                if (regex.IsMatch(text))
                {
                    StringBuilder encryptedPassword = new StringBuilder();
                    Match match = regex.Match(text);
                    string numbers = match.Groups["numbers"].Value;
                    string lowercaseLetters = match.Groups["lowercaseLetters"].Value;
                    string uppercaseLetters = match.Groups["uppercaseLetters"].Value;
                    string randomSymbols = match.Groups["randomSymbols"].Value;
                    encryptedPassword = encryptedPassword.Append(numbers).Append(lowercaseLetters).Append(uppercaseLetters).Append(randomSymbols);
                    Console.WriteLine($"Password: {encryptedPassword}");
                }
                else
                {
                    Console.WriteLine("Try another password!");


                }



            }



        }
    }
}

