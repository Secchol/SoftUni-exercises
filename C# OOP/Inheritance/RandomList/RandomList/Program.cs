using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList myList = new RandomList();
            myList.Add("123fdfd");
            myList.Add("123fdfd");
            myList.Add("123dfd");
            myList.Add("123sdf");
            myList.Add("123fdfd");
            Console.WriteLine(myList.RandomString());

        }
    }
}
