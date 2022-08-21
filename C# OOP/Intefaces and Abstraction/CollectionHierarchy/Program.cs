using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] collection = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int removeCount = int.Parse(Console.ReadLine());
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();
            PrintAdded(collection, addCollection);
            PrintAdded(collection, addRemoveCollection);
            PrintAdded(collection, myList);
            PrintRemoved(collection, addRemoveCollection, removeCount);
            PrintRemoved(collection, myList, removeCount);

        }
        public static void PrintAdded(string[] itemsToAdd, ICollection collection)
        {
            foreach (string item in itemsToAdd)
            {
                Console.Write(collection.Add(item) + " ");
            }
            Console.WriteLine();


        }
        public static void PrintRemoved(string[] itemsToRemove, IRemovable collection, int removeCount)
        {
            for (int i = 0; i < removeCount; i++)
            {
                Console.Write(collection.Remove() + " ");
            }


            Console.WriteLine();


        }
    }
}
