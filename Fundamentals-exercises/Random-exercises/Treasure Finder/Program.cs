using System;
using System.Linq;
using System.Text;

namespace Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            string text = Console.ReadLine();
            while (text != "find")
            {
                int key = 0;
                StringBuilder workedText = new StringBuilder();
                for (int i = 0; i < text.Length; i++, key++)
                {
                    workedText.Append((char)(text[i] - keys[key]));
                    if (key == keys.Length - 1)
                    {
                        key = -1;
                    }
                }
                string reworkedText = workedText.ToString();
                string treasureType = reworkedText.Substring(reworkedText.IndexOf('&') + 1, reworkedText.LastIndexOf('&') - reworkedText.IndexOf('&') - 1);
                string coordinates = reworkedText.Substring(reworkedText.IndexOf('<') + 1, reworkedText.IndexOf('>') - reworkedText.IndexOf('<') - 1);
                Console.WriteLine($"Found {treasureType} at {coordinates}");


                text = Console.ReadLine();
            }
        }
    }
}
