using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Valid_emails
{

    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(?<=\s)([a-z]+|\d+)(\d+|\w+|\.+|-+)([a-z]+|\d+)\@[a-z]+\-?[a-z]+\.[a-z]+(\.[a-z]+)?";
            List<string> validEmails = Regex.Matches(text, pattern).Select(x => x.Value).Select(x => x.Trim()
            ).ToList();
            Console.WriteLine(String.Join(Environment.NewLine, validEmails));


        }
    }
}

