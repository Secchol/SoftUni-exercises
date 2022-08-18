using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.Add("10");
            randomList.Add("11");
            randomList.RandomString();
            Console.WriteLine(String.Join(" ", randomList));

        }
    }
}
