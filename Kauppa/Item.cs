using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti.Kauppa
{
    public class Item
    {
        public string Name { get; }
        public int Price { get; }


        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
