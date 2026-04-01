using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti.Shop
{
    public class Sword : Item, IEquippable
    {
        public int Damage { get; set; }

        public Sword(string name, int damage) : base (name, 100)
        {
             Damage = damage;
        }

        public void Equip(Player player)
        {
            player.AttackPower = Damage;
            Console.WriteLine($"{player.Name} equipped {Name}).");
        }
    }
}
