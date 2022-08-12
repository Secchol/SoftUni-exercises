using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private ICollection<Item> items;
        public Bag(int capacity)
        {
            this.Capacity = capacity;

            items = new List<Item>();

        }
        public int Capacity { get; set; } = 100;

        public int Load => Items.Select(x => x.Weight).Sum();

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>)items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);

            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);


            }
            if (!Items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ItemNotFoundInBag, name));

            }
            Item item = Items.FirstOrDefault(x => x.GetType().Name == name);
            items.Remove(item);
            return item;
        }
    }
}
