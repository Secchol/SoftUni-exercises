using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] accountsInput = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, double> accounts = new Dictionary<int, double>();
            foreach (string account in accountsInput)
            {
                string[] accountInfo = account.Split("-", StringSplitOptions.RemoveEmptyEntries);
                int accountNumber = int.Parse(accountInfo[0]);
                double accountBalance = double.Parse(accountInfo[1]);
                accounts.Add(accountNumber, accountBalance);


            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    string[] commandsArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string action = commandsArray[0];
                    int accountNumber = int.Parse(commandsArray[1]);
                    double sum = double.Parse(commandsArray[2]);

                    if (action == "Deposit")
                    {
                        AccountChecker(accountNumber, accounts);
                        accounts[accountNumber] += sum;
                        Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:F2}");
                    }
                    else if (action == "Withdraw")
                    {
                        AccountChecker(accountNumber, accounts);
                        BalanceChecker(sum, accountNumber, accounts);
                        accounts[accountNumber] -= sum;
                        Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:F2}");


                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");

                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally
                {

                    Console.WriteLine("Enter another command");

                }

                command = Console.ReadLine();
            }
        }
        public static bool AccountChecker(int account, Dictionary<int, double> accounts)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account!");

            }
            return true;


        }
        public static bool BalanceChecker(double sum, int account, Dictionary<int, double> accounts)
        {
            if (accounts[account] < sum)
            {
                throw new ArgumentException("Insufficient balance!");

            }
            return true;


        }
    }
}
