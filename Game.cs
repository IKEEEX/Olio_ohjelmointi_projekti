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
        private int _enemyLevel = 1;
        private Random random = new Random();

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
        private Enemy GenerateEnemy()
        {
            int variation = random.Next(-1, 2);
            int level = Math.Max(1, _player.Level + variation);

            return new Enemy("Goblin", level);
        }

        private void StartBattle()
        {
            Enemy enemy = GenerateEnemy();

            Console.WriteLine($"\nA wild {enemy.Name} (Level {enemy.Level}) appears!");

            while (enemy.IsAlive() && _player.IsAlive())
            {
                Console.WriteLine("\n1 = Attack");
                Console.WriteLine("2 = Use Potion");
                Console.WriteLine("3 = Run");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    int playerDamage = _player.Attack();
                    enemy.TakeDamage(playerDamage);
                    Console.WriteLine($"You deal {playerDamage} damage!");

                    if (!enemy.IsAlive())
                        break;

                    int enemyDamage = enemy.Attack();
                    _player.TakeDamage(enemyDamage);
                    Console.WriteLine($"{enemy.Name} hits you for {enemyDamage} damage!");
                }
                else if (choice == "2")
                {
                    _player.UseHealthPotion();
                    Console.WriteLine("You used a health potion");
                }
                else if (choice == "3")
                {
                    Console.WriteLine("You escaped!");
                    return;
                }

                Console.WriteLine($"Your HP: {_player.Health}/{_player.MaxHealth}");
                Console.WriteLine($"{enemy.Name} HP: {enemy.Health}/{enemy.MaxHealth}");
            }

            if (_player.IsAlive())
            {
                Console.WriteLine($"\nYou defeated {enemy.Name}!");
                _player.GainExperience(enemy.ExperienceReward);
                _enemyLevel++;
            }
            else
            {
                Console.WriteLine("\nYou died in battle...");
                _isRunning = false;
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
                    StartBattle();
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
