using System;

namespace MyTuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string names = $"{personInfo[0]} {personInfo[1]}";
            string street = personInfo[2];
            string city = personInfo.Length > 4 ? $"{personInfo[3]} {personInfo[4]}" : $"{personInfo[3]}";
            string[] alcoholicInfo = Console.ReadLine().Split();
            string name = alcoholicInfo[0];
            int age = int.Parse(alcoholicInfo[1]);
            string state = alcoholicInfo[2];
            if (state == "drunk")
            {
                state = "True";

            }
            else
            {
                state = "False";

            }
            string[] bankInfo = Console.ReadLine().Split();
            string personName = bankInfo[0];
            double balance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];
            MyTuple<string, string, string> firstTuple = new MyTuple<string, string, string>(names, street, city);
            MyTuple<string, int, string> secondTuple = new MyTuple<string, int, string>(name, age, state);
            MyTuple<string, double, string> thirdTuple = new MyTuple<string, double, string>(personName, balance, bankName);
            Console.WriteLine(firstTuple.ToString());
            Console.WriteLine(secondTuple.ToString());
            Console.WriteLine(thirdTuple.ToString());
        }
    }
}
