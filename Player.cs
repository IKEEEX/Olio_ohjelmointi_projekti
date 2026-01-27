using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti
{
    public class Player : Character
    {
        public int Level { get; set; }
        public int Coins { get; set; }
        public Player(string name) : base(name, 100, 15)
        {
            Level = 1;
            Coins = 0;
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
    }
}
