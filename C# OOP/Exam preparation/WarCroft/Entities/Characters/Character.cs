using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;
        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            Name = name;
            BaseHealth = health;
            BaseArmor = armor;
            Health = health;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);


                }
                name = value;

            }

        }
        public double BaseHealth { get; private set; }
        public double Health
        {
            get => health;
            set
            {
                if (value < 0 || value > BaseHealth)
                {
                    throw new ArgumentException();

                }
                health = value;
            }

        }
        public double BaseArmor { get; private set; }
        public double Armor
        {
            get => armor;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();

                }
                armor = value;
            }


        }
        public double AbilityPoints { get; }
        public IBag Bag { get; }


        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                if (Armor - hitPoints < 0)
                {
                    hitPoints -= Armor;
                    Armor = 0;
                    if (this.Health - hitPoints < 0)
                    {
                        this.Health = 0;
                        IsAlive = false;

                    }
                    else
                    {
                        this.Health -= hitPoints;

                    }




                }
                else
                {
                    Armor -= hitPoints;

                }

            }


        }
        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);


            }


        }
    }
}