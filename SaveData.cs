using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Olio_ohjelmointi_projekti
{
    public class SaveData
    {
        public PlayerData Player { get; set; }
        public int EnemyLevel { get; set; }
    }

    public class PlayerData
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int ExperienceToNextLevel { get; set; }
        public int Coins { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AttackPower { get; set; }
        public List<ItemData> Inventory { get; set; } = new List<ItemData>();
    }

    public class ItemData
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int HealAmount { get; set; }
        public int Damage { get; set; }
    }

    public static class SaveLoad
    {
        private const string DefaultSaveFile = "savegame.json";

        public static void Save(Player player, int enemyLevel, string path = DefaultSaveFile)
        {
            var data = new SaveData
            {
                EnemyLevel = enemyLevel,
                Player = new PlayerData
                {
                    Name = player.Name,
                    Level = player.Level,
                    Experience = player.Experience,
                    ExperienceToNextLevel = player.ExperienceToNextLevel,
                    Coins = player.Coins,
                    Health = player.Health,
                    MaxHealth = player.MaxHealth,
                    AttackPower = player.AttackPower
                }
            };

            foreach (var item in player.Inventory.items)
            {
                var id = new ItemData
                {
                    Name = item.Name,
                    Price = item.Price
                };

                if (item is Shop.Potion potion)
                {
                    id.Type = "Potion";
                    id.HealAmount = potion.HealAmount;
                }
                else if (item is Shop.Sword sword)
                {
                    id.Type = "Sword";
                    id.Damage = sword.Damage;
                }
                else
                {
                    id.Type = "Item";
                }

                data.Player.Inventory.Add(id);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(path, json);
        }

        public static bool Load(out Player player, out int enemyLevel, string path = DefaultSaveFile)
        {
            player = null;
            enemyLevel = 1;

            if (!File.Exists(path))
                return false;

            try
            {
                var json = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<SaveData>(json);
                if (data == null || data.Player == null) return false;

                var pd = data.Player;
                player = new Player(pd.Name);

                player.Level = pd.Level;
                player.Experience = pd.Experience;
                player.ExperienceToNextLevel = pd.ExperienceToNextLevel;

                player.Coins = pd.Coins;
                player.Health = pd.Health;
                player.MaxHealth = pd.MaxHealth;
                player.AttackPower = pd.AttackPower;

                player.Inventory.items.Clear();
                foreach (var id in pd.Inventory)
                {
                    if (id.Type == "Potion")
                    {
                        var p = new Shop.Potion(id.Name) { HealAmount = id.HealAmount };
                        player.Inventory.AddItem(p);
                    }
                    else if (id.Type == "Sword")
                    {
                        var s = new Shop.Sword(id.Name, id.Damage);
                        player.Inventory.AddItem(s);
                    }
                    else
                    {
                        var it = new Shop.Item(id.Name, id.Price);
                        player.Inventory.AddItem(it);
                    }
                }

                enemyLevel = data.EnemyLevel;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
