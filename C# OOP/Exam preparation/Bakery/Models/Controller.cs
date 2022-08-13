using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models
{
    public class Controller : IController
    {
        private ICollection<BakedFood> bakedFoods;
        private ICollection<Drink> drinks;
        private ICollection<Table> tables;
        private decimal totalIncome;
        public Controller()
        {
            this.bakedFoods = new List<BakedFood>();
            this.drinks = new List<Drink>();
            this.tables = new List<Table>();


        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink drink;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);

            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);

            }
            else
            {
                return null;

            }
            drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            BakedFood food;
            if (type == "Bread")
            {
                food = new Bread(name, price);
                bakedFoods.Add(food);
                return $"Added {name} ({type}) to the menu";
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
                bakedFoods.Add(food);
                return $"Added {name} ({type}) to the menu";
            }

            return null;

        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);


            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);

            }
            else
            {
                return null;

            }
            tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in tables.Where(x => !x.IsReserved))
            {
                sb.AppendLine(table.GetFreeTableInfo());


            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            Table table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {table.GetBill()}");
            totalIncome+=table.GetBill();
            table.Clear();
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (tables.FirstOrDefault(x => x.TableNumber == tableNumber) == null)
            {
                return $"Could not find table {tableNumber}";


            }
            else if (drinks.FirstOrDefault(x => x.Name == drinkName) == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";


            }
            tables.FirstOrDefault(x => x.TableNumber == tableNumber).OrderDrink(drinks.FirstOrDefault(x => x.Name == drinkName));
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (tables.FirstOrDefault(x => x.TableNumber == tableNumber) == null)
            {
                return $"Could not find table {tableNumber}";


            }
            else if (bakedFoods.FirstOrDefault(x => x.Name == foodName) == null)
            {
                return $"No {foodName} in the menu";


            }
            tables.FirstOrDefault(x => x.TableNumber == tableNumber).OrderFood(bakedFoods.FirstOrDefault(x => x.Name == foodName));
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {

            foreach (var table in tables)
            {
                if (!table.IsReserved && table.Capacity >= numberOfPeople)
                {

                    table.Reserve(numberOfPeople);
                    return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";


                }

            }

            return $"No available table for {numberOfPeople} people";



        }
    }
}
