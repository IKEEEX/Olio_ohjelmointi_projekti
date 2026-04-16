using System;
using System.Collections.Generic;
using System.Text;
using Olio_ohjelmointi_projekti.Hahmot;

namespace Olio_ohjelmointi_projekti.Kauppa
{
    public class Potion : Item, IUsable
    {
        public int HealAmount { get; set; }

        public Potion(string name) : base(name, 20)
        {
            HealAmount = 20;
        }

        public void Use(Player player)
        {
            player.Health += HealAmount;
            if (player.Health > player.MaxHealth) player.Health = player.MaxHealth;
            Console.WriteLine($"{player.Name} used {Name} (+{HealAmount} HP).");
        }
    }
}
