


using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = int.Parse(Console.ReadLine());
            int i1 = int.Parse(Console.ReadLine());
            int i2 = int.Parse(Console.ReadLine());
            int i3 = int.Parse(Console.ReadLine());
            int i4 = int.Parse(Console.ReadLine());
            int i5 = int.Parse(Console.ReadLine());
            int vs = i1 + i2 + i3 + i4 + i5;
            double dena;
            double cena;
            if (vs >= 50)
            {
                cena = 0.75 * (i1 * 2.60 + i2 * 3 + i3 * 4.10 + i4 * 8.20 + i5 * 2);
                dena = cena * 0.9;
            }
            else
            {
                cena = i1 * 2.60 + i2 * 3 + i3 * 4.10 + i4 * 8.20 + i5 * 2;
                dena = cena * 0.9;
            }
            if (dena >= i)
            {
                Console.WriteLine("Yes! " + Math.Round((dena - i), 2) + " lv left.");
            }
            else
            {
                Console.WriteLine("Not enough money! " + Math.Round((i - dena), 2) + " lv needed.");
            }
        }
    }
}
