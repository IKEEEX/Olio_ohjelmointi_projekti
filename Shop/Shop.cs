using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti.Shop
{
    public class Shop
    {
        public void Open(Player player)
        {
            bool inShop = true;

            while (inShop)
            {
                Console.WriteLine("\n=== SHOP ===");
                Console.WriteLine("1 = Health potion");
                Console.WriteLine("2 = Goblin slayer");
                Console.WriteLine("3 = Exit");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    player.Inventory.AddItem(new Potion("Parannusjuoma"));
                    Console.WriteLine("Thank you for your purchase");
                }
                if (choice == "2")
                {
                    player.Inventory.AddItem(new Sword("Goblin slayer", 18));
                    Console.WriteLine("Thank you for your purchase");
                }
                else if (choice == "3")
                {
                    inShop = false;
                }
            }
        }
    }
}
