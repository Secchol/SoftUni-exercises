using HashTable;
using System;
using System.Net.Http.Headers;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable<int, string>();
            table.Add(10, "root");
        }
    }
}
