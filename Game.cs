using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti
{
    class Game
    {
        private Player player;
        private bool isRunning = true;

        public void Start()
        {
            Console.Write("What will be your hero's name?: ");
            string name = Console.ReadLine();
            player = new Player(name);

            Console.WriteLine($"Welcome, {player.Name}!");

            while (isRunning)
            {
                ShowMainMenu();
            }
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("\n=== THE CAMPFIRE ===");
            Console.WriteLine("1 = Search for a battle");
            Console.WriteLine("2 = Travel to the shop");
            Console.WriteLine("3 = Show inventory");
            Console.WriteLine("4 = Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //StartBattle();
                    break;
                case "2":
                    //OpenShop();
                    break;
                case "3":
                    player.Inventory.ShowItems();
                    break;
                case "4":
                    isRunning = false;
                    Console.WriteLine("Thank you for playing!");
                    break;
                default:
                    Console.WriteLine("Select from the above.");
                    break;
            }
        }
    }
}
