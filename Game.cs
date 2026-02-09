using Olio_ohjelmointi_projekti.Shop;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Olio_ohjelmointi_projekti
{
    class Game
    {
        private Player _player;
        private Store _store;
        private bool _isRunning = true;

        public void Start()
        {
            Console.Write("What will be your hero's name?: ");
            string name = Console.ReadLine();
            _player = new Player(name);
            _store = new Store();

            Console.WriteLine($"Welcome, {_player.Name}!");

            while (_isRunning)
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
                    _store.Open(_player);
                    break;
                case "3":
                    _player.Inventory.ShowItems();
                    break;
                case "4":
                    Console.WriteLine("Thank you for playing!");
                    _isRunning = false;
                    break;
                default:
                    Console.WriteLine("Select from the above.");
                    break;
            }
        }
    }
}
