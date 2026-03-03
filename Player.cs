using Olio_ohjelmointi_projekti.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti
{
    public class Player : Character
    {
        public int Level { get; set; }
        public int Experience { get; private set; }
        public int ExperienceToNextLevel { get; private set; }
        public int Coins { get; set; }
        public Inventory Inventory { get; private set; }


        public Player(string name) : base(name, 100, 15)
        {
            Level = 1;
            Coins = 50;
            Experience = 0;
            ExperienceToNextLevel = 50;

            Inventory = new Inventory();
            Inventory.AddItem(new Potion("Health potion"));
        }

        public void GainExperience(int amount)
        {
            Experience += amount;
            Console.WriteLine($"{Name} gained {amount} XP!");

            while (Experience >= ExperienceToNextLevel)
            {
                Experience -= ExperienceToNextLevel;
                ExperienceToNextLevel = (int)(ExperienceToNextLevel * 1.5);
                LevelUp();
            }
        }
        public void LevelUp()
        {
            Level++;
            MaxHealth += 20;
            AttackPower += 5;
            Coins += 50;
            Health = MaxHealth;
            Console.WriteLine($"{Name} reached a new level: {Level}!");
        }
        public void UseHealthPotion()
        {
            Item potion = Inventory.items.FirstOrDefault(i => i is Potion && i.Name == "Health potion");

            if (potion == null)
            {
                Console.WriteLine("No health potion in inventory!");
                return;
            }

            Health += 30;
            if (Health > MaxHealth) Health = MaxHealth;
            Console.WriteLine($"{Name} used a health potion (+30 HP).");

            Inventory.RemoveItem(potion);
        }
        public void UseItem()
        {
            Inventory.ShowItems();
            Console.Write("Pick the item number: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Item item = Inventory.GetItem(choice - 1);

                if (item == null)
                {
                    Console.WriteLine("Incorrect choice.");
                    return;
                }

                else if (item is Potion)
                {
                    Health += 30;
                    if (Health > MaxHealth) Health = MaxHealth;
                    Console.WriteLine($"{Name} used a health potion (+30 HP).");
                }
                else if (item is Sword sword)
                {
                    AttackPower = sword.Damage;
                    Console.WriteLine($"You equipped {sword.Name}.");
                }
            }
        }
    }
}