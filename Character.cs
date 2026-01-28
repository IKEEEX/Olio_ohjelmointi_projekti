using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olio_ohjelmointi_projekti
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public Character(string name, int maxHealth, int attackPower)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            AttackPower = attackPower;
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }
        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}