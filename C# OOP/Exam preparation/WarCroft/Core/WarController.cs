using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characterParty;
        private List<Item> items;
        public WarController()
        {
            characterParty = new List<Character>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            Character character;
            if (characterType == "Priest")
            {
                character = new Priest(name);

            }
            else if (characterType == "Warrior")
            {
                character = new Warrior(name);

            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidCharacterType, characterType));

            }
            characterParty.Add(character);
            return String.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemType = args[0];
            Item item;
            if (itemType == "FirePotion")
            {
                item = new FirePotion();

            }
            else if (itemType == "HealthPotion")
            {
                item = new HealthPotion();

            }
            else
            {
                throw new ArgumentException($"Invalid item \"{ itemType }\"!");

            }
            items.Add(item);
            return String.Format(SuccessMessages.AddItemToPool, itemType);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if (characterParty.FirstOrDefault(x => x.Name == characterName) == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));


            }
            if (items.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemPoolEmpty));

            }
            characterParty.FirstOrDefault(x => x.Name == characterName).Bag.AddItem(items.Last());
            string lastItem = items.Last().GetType().Name;
            items.RemoveAt(items.Count - 1);
            return String.Format(SuccessMessages.PickUpItem, characterName, lastItem);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            if (characterParty.FirstOrDefault(x => x.Name == characterName) == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));


            }
            characterParty.FirstOrDefault(x => x.Name == characterName).UseItem(characterParty.FirstOrDefault(x => x.Name == characterName).Bag.GetItem(itemName));
            return String.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var character in characterParty.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive" : "Dead")}");

            }
            return sb.ToString();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            if (characterParty.FirstOrDefault(x => x.Name == attackerName) == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));

            }
            else if (characterParty.FirstOrDefault(x => x.Name == receiverName) == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiverName));


            }

            StringBuilder sb = new StringBuilder();
            Warrior warrior = characterParty.FirstOrDefault(x => x.Name == attackerName) as Warrior;
            Character receiver = characterParty.FirstOrDefault(x => x.Name == receiverName);
            warrior.Attack(receiver);
            sb.Append($"{attackerName} attacks {receiverName} for {warrior.AbilityPoints} hit points! ");
            sb.Append($"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and ");
            sb.AppendLine($"{receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");

            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            if (characterParty.FirstOrDefault(x => x.Name == healerName) == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healerName));

            }
            else if (characterParty.FirstOrDefault(x => x.Name == healingReceiverName) == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));


            }
            else if (!characterParty.FirstOrDefault(x => x.Name == healerName).IsAlive)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));

            }
            Priest healer = characterParty.FirstOrDefault(x => x.Name == healerName) as Priest;
            Character receiver = characterParty.FirstOrDefault(x => x.Name == healingReceiverName);
            StringBuilder sb = new StringBuilder();
            healer.Heal(receiver);
            sb.Append($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has ");
            sb.AppendLine($"{receiver.Health} health now!");
            return sb.ToString().TrimEnd();
        }
    }
}

