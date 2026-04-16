using Olio_ohjelmointi_projekti.Hahmot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti.Kauppa
{
    public class Store
    {
        public void Open(Player player)
        {
            bool inShop = true;

            while (inShop)
            {

                Potion potion = new Potion("Health potion");
                Sword sword = new Sword("Goblin slayer", 18);

                // Simpppeli UI kauppaan.
                Console.WriteLine("\n=== SHOP ===");
                Console.WriteLine($"You have {player.Coins} coins");
                Console.WriteLine($"1 = Health potion ({potion.Price})");
                Console.WriteLine($"2 = Goblin slayer ({sword.Price})");
                Console.WriteLine("3 = Exit");

                string choice = Console.ReadLine();

                if (choice == "1" && player.Coins >= potion.Price)
                {
                    player.Inventory.AddItem(potion);
                    Console.WriteLine("Thank you for your purchase");
                    player.Coins -= potion.Price;
                }
                else if (choice == "2" && player.Coins >= sword.Price)
                {
                    player.Inventory.AddItem(sword);
                    Console.WriteLine("Thank you for your purchase");
                    player.Coins -= sword.Price;
                }
                else if (choice == "3")
                {
                    inShop = false;
                }
                else
                {
                    Console.WriteLine("Insufficient coins");
                }
            }
        }
    }
}
