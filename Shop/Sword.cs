using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti.Shop
{
    public class Sword : Item
    {
        public int Damage { get; set; }

        public Sword(string name, int damage) : base (name, 100)
        {
             
        }
    }
}
