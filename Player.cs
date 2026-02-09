using Olio_ohjelmointi_projekti.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti
{
    public class Player : Character
    {
        public int Level { get; set; }
        public int Coins { get; set; }
        public Inventory Inventory { get; private set; }
        public Player(string name) : base(name, 100, 15)
        {
            Level = 1;
            Coins = 50;
            Inventory = new Inventory();
            Inventory.AddItem(new Potion("Health potion"));
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

                else if (item.Name == "Health potion")
                {
                    Health += 30;
                    if (Health > MaxHealth) Health = MaxHealth;
                    Console.WriteLine($"{Name} used a health potion (+30 HP).");
                }
                else if (item.Name == "Goblin slayer")
                {
                    Sword sword = new Sword("Goblin slayer", 18);
                    int DamagePlus = sword.Damage - AttackPower;
                    AttackPower += DamagePlus;
                    Console.WriteLine($"You equipped the Goblin slayer.");
                }
            }
        }
    }
}
