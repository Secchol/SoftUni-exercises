using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int g = 1990;// начабна година
            double a = 20;// начална реколта
            double sum = 20;// обща реколта
            int c = 0;// годината когато реклотата пада под 5 тона
            bool foundYear = false;//гледа дали вече не е намерена годината когато общата реколта става за първи път над 90 тона
            while (a > 5)
            {
                g++;
                if (g % 2 == 0)
                {
                    a = 0.8 * a;


                }
                sum = sum + a;
                if (sum > 90 && foundYear == false)
                {
                    c = g;
                    foundYear = true;

                }
                


            }
            Console.WriteLine(c.To);//изписва годината когато общата реколта става над 90 тона
            Console.WriteLine(g);//изписва годината когато добивната реколта става под 5 тона



        }
    }
}
