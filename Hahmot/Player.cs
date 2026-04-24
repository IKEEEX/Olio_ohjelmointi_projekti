using Olio_ohjelmointi_projekti.Kauppa;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Olio_ohjelmointi_projekti.Hahmot
{
    // Pelin sankarin luokka. Träckkää leveliä, XP:tä, rahaa ja inventoryä.
    public class Player : Character
    {
        public int Level { get; set; }
        public int Experience { get; set; }
        public int ExperienceToNextLevel { get; set; }
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
        // Etsii ensimmäisen health potionin invistä
        public bool UseFirstPotion()
        {
            Item potion = Inventory.items.FirstOrDefault(i => i is Potion && i.Name == "Health potion");

            if (potion == null)
            {
                Console.WriteLine("No health potion in inventory!");
                return false;
            }

            if (potion is Kauppa.IUsable usable)
            {
                usable.Use(this);
                Inventory.RemoveItem(potion);
                return true;
            }

            return false;
        }

        // Näyttää invin ja antaa pelaajalle mahdollisuuden käyttää tai ottaa itemin käyttöön.
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

                if (item is Kauppa.IUsable usable)
                {
                    usable.Use(this);
                }
                else if (item is Kauppa.IEquippable equippable)
                {
                    equippable.Equip(this);
                }
            }
        }

        public override int Attack()
        {
            int damage = base.Attack(); // perityn Character luokan "satunnainen" laskenta Attack:lle

            if (random.NextDouble() < 0.10) // 10% tsäänssi tupla damageen
            {
                Console.WriteLine("Critical hit!");
                damage *= 2;
            }
            return damage;
        }
    }
}