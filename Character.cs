using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olio_ohjelmointi_projekti
{
    public abstract class Character
    {
        protected static Random random = new Random();

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

        public virtual int Attack()
        {
            return random.Next(AttackPower - 3, AttackPower + 4);
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