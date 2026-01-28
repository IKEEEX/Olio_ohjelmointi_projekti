using Olio_ohjelmointi_projekti.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} added to inventory.");
        }
        public void ShowItems()
        {
            if ( items.Count == 0 )
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("Inventory:");
            for ( int i = 0; i < items.Count; i++ )
            {
                Console.WriteLine($"{i + 1}. {items[i].Name}");
            }
        }
        public Item GetItem(int index)
        {
            if (index < 0 || index >= items.Count)
                return null;

            Item item = items[index];
            items.RemoveAt(index);
            return item;
        }
    }
}
