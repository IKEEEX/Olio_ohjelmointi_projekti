using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti.Shop
{
    public class Potion : Item
    {
        public int HealAmount { get; set; }
        public Potion(string name) : base(name, 20)
        {
            HealAmount = 20;
        }
    }
}
