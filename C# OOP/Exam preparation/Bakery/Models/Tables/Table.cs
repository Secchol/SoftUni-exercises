using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            FoodOrders = new List<BakedFood>();
            DrinkOrders = new List<Drink>();
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);

                }
                capacity = value;
            }

        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);

                }
                numberOfPeople = value;

            }

        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => FoodOrders.Select(x => x.Price).Sum() + DrinkOrders.Select(x => x.Price).Sum() + PricePerPerson * NumberOfPeople;
        private ICollection<BakedFood> FoodOrders { get; set; }
        private ICollection<Drink> DrinkOrders { get; set; }

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            this.NumberOfPeople = 0;
            IsReserved = false;
        }

        public decimal GetBill()
        {
            return this.Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");
            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink as Drink);
        }

        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food as BakedFood);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
